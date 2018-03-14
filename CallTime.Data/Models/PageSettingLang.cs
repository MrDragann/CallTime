using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CallTime.Data.Models
{
    /// <summary>
    /// Класс модели настроек
    /// </summary>
    public class PageSettingLang
    {
        #region [ Свойства ]

        [Key, ForeignKey("PageSetting"), Column(Order = 1)]
        public int PageSettingId { get; set; }

        [Key, Column(Order = 2)]
        public int Lang { get; set; }

        public string Title { get; set; }

        public string Keywords { get; set; }

        public string Description { get; set; }

        #endregion

        #region [ Связанные объекты ]

        public PageSetting PageSetting { get; set; }

        #endregion
    }
}
