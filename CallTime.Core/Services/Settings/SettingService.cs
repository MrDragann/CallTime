﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CallTime.Core.Enums;
using CallTime.Core.Interfaces;
using CallTime.Core.Models.Content;
using CallTime.Core.Models.Responses;
using CallTime.Core.Models.Setting;
using CallTime.Data;

namespace CallTime.Core.Services.Settings
{
    public class SettingService : ISettingService
    {
        /// <summary>
        /// Получить модель настройки
        /// </summary>
        /// <returns></returns>
        public SettingModel GetSettingModel()
        {
            return CurrentSettings.Data;
        }

        /// <summary>
        /// Получить контент
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public List<ContentModel> GetContent(EnumLanguage lang)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var contentList = new List<ContentModel>();
                    foreach (EnumContentKey key in Enum.GetValues(typeof(EnumContentKey)))
                    {
                        var model = new ContentModel();
                        model.Key = key;
                        model.Content = db.PageContentLangs.AsNoTracking()
                            .FirstOrDefault(x => x.PageContentId == (int) key && x.Lang == (int)lang)?.Content;
                        contentList.Add(model);
                    }
                    return contentList;
                }
            }
            catch (Exception ex)
            {
                return new List<ContentModel>();
            }
        }

        /// <summary>
        /// Обновление настроек
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
     //   public BaseResponse UpdateSettings(SettingModel model)
     //   {
     //       using (var db = new DataContext())
     //       {
     //           var ruTitle = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.RuTitle);
     //           var enTitle = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.EnTitle);
     //           var ruDescription = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.RuDescription);
     //           var enDescription = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.EnDescription);
     //           var ruKeywords = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.RuKeywords);
     //           var enKeywords = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.EnKeywords);
     //           var ruAddress = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.RuAddress);
     //           var enAddress = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.EnAddress);
     //           var phone = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.Phone);
     //           var email = db.Settings.FirstOrDefault(x => x.Key == (int)EnumSettingKey.Email);
     //           if (ruTitle == null || enTitle == null || ruDescription == null || enDescription == null ||
     //           ruKeywords == null || enKeywords == null || ruAddress == null || enAddress == null ||
     //                   phone == null || email == null)
					//return new BaseResponse(EnumResponseStatus.Error);

     //           ruTitle.Value = model.RuTitle;
     //           enTitle.Value = model.EnTitle;
     //           ruDescription.Value = model.RuDescription;
     //           enDescription.Value = model.EnDescription;
     //           ruKeywords.Value = model.RuKeywords;
     //           enKeywords.Value = model.EnKeywords;
     //           ruAddress.Value = model.RuAddress;
     //           enAddress.Value = model.EnAddress;
     //           phone.Value = model.Phone;
     //           email.Value = model.Email;

     //           db.SaveChanges();
     //           CurrentSettings.Init();
     //           return new BaseResponse(0, "Настройки успешно изменены");
     //       }
     //   }

    }
}
