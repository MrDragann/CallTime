using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using CallTime.Core.Enums;
using CallTime.Core.Interfaces;
using CallTime.Core.Models.Responses;
using CallTime.Core.Models.User;
using CallTime.Data;
using CallTime.Data.Models;

namespace CallTime.Core.Services
{
    /// <summary>
    /// Сервис авторизации
    /// </summary>
    public class AuthCommonService : IAuthCommonService
    {
        #region Авторизация
        
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model">Модель пользователя</param>
        /// <returns></returns>
        public BaseResponse Register(UserModel model)
        {
            try
            {
                using (var db = new DataContext())
                {
                    if (string.IsNullOrEmpty(model.Email))
                        return new BaseResponse(EnumResponseStatus.ValidationError, "Email не может быть пустым");

                    if (db.Users.Any(x => x.Login == model.Login))
                        return new BaseResponse(EnumResponseStatus.ValidationError, "Пользователь с логином уже существует");

                    if (db.Users.Any(x => x.Email == model.Email))
                        return new BaseResponse(EnumResponseStatus.ValidationError, "Пользователь с таким адресом электронной почты уже существует");

                    if (string.IsNullOrEmpty(model.Password))
                        return new BaseResponse(EnumResponseStatus.ValidationError, "Пароль не может быть пустым");

                    var user = new User
                    {
                        Email = model.Email,
                        Login = model.Login,
                        PasswordHash = model.Password
                    };

                    db.Users.Add(user);
                    db.SaveChanges();

                    return new BaseResponse(EnumResponseStatus.Success, "Регистрация успешно выполнена");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(EnumResponseStatus.Exception);
            }
        }

        /// <summary>
        /// Метод выполняющий авторизацю пользователя
        /// </summary>
        /// <param name="email">Почта</param>
        /// <param name="passwordHash">Пароль пользователя</param>
        public BaseResponse<UserModel> Login(string email, string passwordHash)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.Include(x => x.Roles).FirstOrDefault(_ => _.Email == email && _.PasswordHash == passwordHash);
                if (user != null)
                {
                    var webUser = new UserModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Roles = user.Roles.Select(x => x.Name).ToList()
                    };

                    return new BaseResponse<UserModel>(webUser);
                }
                return new BaseResponse<UserModel>(EnumResponseStatus.ValidationError, "Введен неверный Email или пароль");
            }
        }

        /// <summary>
        /// Проверка на существование ролей у пользователя
        /// </summary>
        /// <param name="userId">Ид пользователя</param>
        /// <param name="roles">Роли</param>
        /// <returns></returns>
        public BaseResponse CheckUserRole(int userId, params string[] roles)
        {
            using (var db = new DataContext())
            {
                var userRoles = db.Users.Include(x => x.Roles).Where(x => x.Id == userId).SelectMany(_ => _.Roles.Select(m => m.Name)).ToList();
                if (userRoles.Any())
                {
                    var haveRole = userRoles.Intersect(roles.Where(x => !string.IsNullOrEmpty(x))).Any();
                    if (haveRole)
                        return new BaseResponse(EnumResponseStatus.Success, "Пользователь имеет указанную роль");
                }
                return new BaseResponse(EnumResponseStatus.ValidationError, "Пользователь не имеет указанную роль");
            }
        }

        /// <summary>
        /// Проверить токен пользователя 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public BaseResponse CheckUserToken(string email, Guid token)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(_ => _.Email == email && _.ConfirmationToken == token && _.TokenExpireDate > DateTime.UtcNow);
                if (user != null)
                {
                    return new BaseResponse(EnumResponseStatus.Success);
                }
                return new BaseResponse(EnumResponseStatus.ValidationError);
            }
        }

        /// <summary>
        /// Подтверждение аккаунта пользователя
        /// </summary>
        /// <param name="token">Токен</param>
        /// <param name="email">Почта</param>
        /// <returns></returns>
        public BaseResponse ConfrimUser(Guid token, string email)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(_ => _.Email == email && _.ConfirmationToken == token);
                if (user != null)
                {
                    user.ConfirmationToken = null;
                    user.TokenExpireDate = null;
                    db.SaveChanges();
                    return new BaseResponse(EnumResponseStatus.Success);
                }
                return new BaseResponse(EnumResponseStatus.Error);
            }
        }

        /// <summary>
        /// Сгенерировать токен пользователю
        /// </summary>
        /// <param name="email">Почта</param>
        /// <param name="userId">Ид пользователя</param>
        /// <param name="isExpireDate">Установить токену срок действия</param>
        /// <returns></returns>
        public BaseResponse<Guid?> GenerateToken(string email, int? userId = null, bool isExpireDate = true)
        {
            using (var db = new DataContext())
            {
                var user = userId.HasValue ? db.Users.FirstOrDefault(x => x.Id == userId) : db.Users.FirstOrDefault(x => x.Email == email);
                if (user != null)
                {
                    user.ConfirmationToken = Guid.NewGuid();

                    if (isExpireDate)
                        user.TokenExpireDate = DateTime.UtcNow.AddHours(1);
                    db.SaveChanges();
                    return new BaseResponse<Guid?>(user.ConfirmationToken);
                }
                return new BaseResponse<Guid?>(EnumResponseStatus.Error);
            }
        }

        /// <summary>
        /// Отправка письма на эл.адрес пользователя
        /// </summary>
        /// <param name="subject">Тема письма</param>
        /// <param name="email">Эл.адрес</param>
        /// <param name="body">Текст письма</param>
        public BaseResponse SendMail(string subject, string email, string body)
        {
            try
            {
                var msg = new MailMessage();
                msg.To.Add(email);
                msg.Subject = subject;
                msg.Body = body;
                msg.IsBodyHtml = true;
                var smtp = new SmtpClient();
                smtp.Send(msg);
                return new BaseResponse(EnumResponseStatus.Success, "Письмо успешно отправлено");
            }
            catch (Exception ex)
            {
                return new BaseResponse(EnumResponseStatus.Exception, ex.Message);
            }
        }
        #endregion

        #region Статичные методы

        /// <summary>
        /// Хеширование строки по стандарту SHA256
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetHashString(string s)
        {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(s), 0, Encoding.UTF8.GetByteCount(s));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        #endregion
    }
}
