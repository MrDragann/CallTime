using System.Collections.Generic;
using CallTime.Core.Enums;
using CallTime.Core.Models.Content;
using CallTime.Core.Models.Responses;
using CallTime.Core.Models.Setting;

namespace CallTime.Core.Interfaces
{
    public interface ISettingService
    {
        /// <summary>
        /// Получить контент
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        List<ContentModel> GetContent(EnumLanguage lang);

        /// <summary>
        /// Редактирование контента
        /// </summary>
        /// <param name="content"></param>
        /// <param name="id"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        BaseResponse EditContent(string content, string id, EnumLanguage lang);

        /// <summary>
        /// Получить модель настройки
        /// </summary>
        /// <returns></returns>
        SettingModel GetSettingModel(EnumSitePage page);

        /// <summary>
        /// Обновление настроек
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        BaseResponse UpdateSettings(SettingModel model);

    }
}
