using System.Collections.Generic;

namespace CallTime.Data.Models
{
    /// <summary>
    /// Класс модели ролей пользователя
    /// </summary>
    public class Role
    {
        #region [ Свойства ]

        /// <summary>
        /// Идентификатор роли
        /// </summary>
        /// <value>Идентификатор</value>
        public int Id { get; set; }
        /// <summary>
        /// Наименование роли
        /// </summary>
        /// <value>Наименование</value>
        public string Name { get; set; }

        #endregion

        #region [ Связанные объекты ]

        /// <summary>
        /// Ссылка на список пользователей
        /// </summary>
        /// <value>Список пользователей</value>
        public List<User> Users { get; set; }

        #endregion
    }
}
