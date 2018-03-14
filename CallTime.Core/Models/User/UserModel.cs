using System.Collections.Generic;

namespace CallTime.Core.Models.User
{
    public class UserModel
    {
        /// <summary>
        /// Ид пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Список имен ролей пользователя
        /// </summary>
        public List<string> Roles { get; set; }
    }
}
