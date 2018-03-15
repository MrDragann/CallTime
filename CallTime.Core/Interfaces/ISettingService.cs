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

        ///// <summary>
        ///// Получить модель настройки
        ///// </summary>
        ///// <returns></returns>
        //SettingModel GetSettingModel();

        ///// <summary>
        ///// Обновление настроек
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //BaseResponse UpdateSettings(SettingModel model);

    }
}
