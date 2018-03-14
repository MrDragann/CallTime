using System.Collections.Generic;

namespace CallTime.Data.Models
{
    /// <summary>
    /// Класс модели настроек
    /// </summary>
    public class PageContent
    {
        #region [ Свойства ]

        /// <summary>
        /// Ид страницы
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string PageName { get; set; }

        #endregion

        #region [ Связанные объекты ]

        public List<PageContentLang> PageContentLangs { get; set; }

        #endregion
    }
}
