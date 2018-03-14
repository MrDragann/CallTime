using System.Collections.Generic;
using System.Web;

namespace CallTime.Web.Infrastructure
{
    /// <summary>
    /// Класс веб-пользователя
    /// </summary>
    public class WebUser
    {
        public WebUser()
        {
            var value = HttpContext.Current.Session["UserSession"] as WebUser;
            if (value == null)
            {
                IsAuthorized = false;
                return;
            }
            Update(value);
        }

        /// <summary>
        /// Ид пользователя
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Роли пользователя
        /// </summary>
        public List<string> Roles { get; set; }
        /// <summary>
        /// Авторизован пользователь или нет
        /// </summary>
        public bool IsAuthorized { get; set; }
        /// <summary>
        /// Имеет ли пользователь доступ к админке
        /// </summary>
        public bool IsAdmin => Roles?.Contains(ConstRoles.Admin) ?? false;
        /// <summary>
        /// Обновить информацию о пользователе
        /// </summary>
        private void Update(WebUser user)
        {
            IsAuthorized = user.IsAuthorized;
            Roles = user.Roles;
            UserId = user.UserId;
            Email = user.Email;
        }
    }
}