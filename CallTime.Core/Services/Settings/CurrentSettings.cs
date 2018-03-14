using System;
using System.Linq;
using CallTime.Core.Enums;
using CallTime.Core.Models.Setting;
using CallTime.Data;

namespace CallTime.Core.Services.Settings
{
    /// <summary>
    /// Настройки
    /// </summary>
    public static class CurrentSettings
    {
        /// <summary>
        /// Данные
        /// </summary>
        public static SettingModel Data { get; set; }

        /// <summary>
        /// Инициализация настроек
        /// </summary>
        //public static void Init()
        //{
        //    try
        //    {
        //        Data = new SettingModel();
        //        using (var db = new DataContext())
        //        {
        //            Data.RuTitle = GetSettingValue(EnumSettingKey.RuTitle, db);
        //            Data.EnTitle = GetSettingValue(EnumSettingKey.EnTitle, db);
        //            Data.RuDescription = GetSettingValue(EnumSettingKey.RuDescription, db);
        //            Data.EnDescription = GetSettingValue(EnumSettingKey.EnDescription, db);
        //            Data.RuKeywords = GetSettingValue(EnumSettingKey.RuKeywords, db);
        //            Data.EnKeywords = GetSettingValue(EnumSettingKey.EnKeywords, db);
        //            Data.RuAddress = GetSettingValue(EnumSettingKey.RuAddress, db);
        //            Data.EnAddress = GetSettingValue(EnumSettingKey.EnAddress, db);
        //            Data.Email = GetSettingValue(EnumSettingKey.Email, db);
        //            Data.Phone = GetSettingValue(EnumSettingKey.Phone, db);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("При инициализации настроек возникла ошибка", ex);
        //    }
        //}

        ///// <summary>
        ///// Получить настройку по ключу
        ///// </summary>
        ///// <param name="key">Ключ настройки</param>
        ///// <returns></returns>
        //private static string GetSettingValue(EnumSettingKey key, DataContext db)
        //{
        //    var setting = db.Settings.FirstOrDefault(x => x.Key == (int)key)?.Value;
        //    return setting;
        //}
    }
}
