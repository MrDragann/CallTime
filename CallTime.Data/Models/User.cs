using System;
using System.Collections.Generic;

namespace CallTime.Data.Models
{
    /// <summary>
    /// Класс модели пользователя
    /// </summary>
    public class User
    {
        #region [ Свойства ]

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string PasswordHash { get; set; }
        /// <summary>
        /// Токен для восстановления пароля или активации пользователя
        /// </summary>
        public Guid? ConfirmationToken { get; set; }
        /// <summary>
        /// Время истечения срока действия токена
        /// </summary>
        public DateTime? TokenExpireDate { get; set; }

        #endregion

        #region [ Связанные объекты ]

        /// <summary>
        /// Ссылка на список ролей
        /// </summary>
        public List<Role> Roles { get; set; }

        #endregion
    }
}
