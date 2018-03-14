using System;
using CallTime.Core.Models.Responses;
using CallTime.Core.Models.User;

namespace CallTime.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса авторизации
    /// </summary>
    public interface IAuthCommonService
    {
        #region Авторизация

        /// <summary>
        /// Проверка на существование ролей у пользователя
        /// </summary>
        /// <param name="userId">Ид пользователя</param>
        /// <param name="roles">Роли</param>
        /// <returns></returns>
        BaseResponse CheckUserRole(int userId, params string[] roles);

        /// <summary>
        /// Проверить токен пользователя 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        BaseResponse CheckUserToken(string email, Guid token);

        /// <summary>
        /// Метод выполняющий авторизацю пользователя
        /// </summary>
        /// <param name="email">Почта</param>
        /// <param name="passwordHash">Пароль пользователя</param>
        BaseResponse<UserModel> Login(string email, string passwordHash);

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model">Модель пользователя</param>
        /// <returns></returns>
        BaseResponse Register(UserModel model);

        /// <summary>
        /// Подтверждение аккаунта пользователя
        /// </summary>
        /// <param name="token">Токен</param>
        /// <param name="email">Почта</param>
        /// <returns></returns>
        BaseResponse ConfrimUser(Guid token, string email);

        /// <summary>
        /// Сгенерировать токен пользователю
        /// </summary>
        /// <param name="email">Почта</param>
        /// <param name="userId">Ид пользователя</param>
        /// <param name="isExpireDate">Установить токену срок действия</param>
        /// <returns></returns>
        BaseResponse<Guid?> GenerateToken(string email, int? userId = null, bool isExpireDate = true);
        
        /// <summary>
        /// Отправка письма на эл.адрес пользователя
        /// </summary>
        /// <param name="subject">Тема письма</param>
        /// <param name="email">Эл.адрес</param>
        /// <param name="body">Текст письма</param>
        BaseResponse SendMail(string subject, string email, string body);

        #endregion
    }
}
