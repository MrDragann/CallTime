using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallTime.Data.Models
{
    /// <summary>
    /// Класс модели настроек
    /// </summary>
    public class PageContent
    {
        #region [ Свойства ]

        /// <summary>
        /// Ид контента
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string ContentName { get; set; }

        #endregion

        #region [ Связанные объекты ]

        public List<PageContentLang> PageContentLangs { get; set; }

        #endregion
    }
}
