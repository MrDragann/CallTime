using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallTime.Data.Models
{
    /// <summary>
    /// Класс модели настроек
    /// </summary>
    public class PageContentLang
    {
        #region [ Свойства ]

        [Key, ForeignKey("PageContent"), Column(Order = 1)]
        public int PageContentId { get; set; }

        [Key, Column(Order = 2)]
        public int Lang { get; set; }

        public string Content { get; set; }

        #endregion

        #region [ Связанные объекты ]

        public PageContent PageContent { get; set; }

        #endregion
    }
}
