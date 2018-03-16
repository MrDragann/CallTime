using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CallTime.Core.Enums;
using CallTime.Core.Interfaces;
using CallTime.Core.Models.Content;
using CallTime.Core.Models.Responses;
using CallTime.Core.Models.Setting;
using CallTime.Data;
using CallTime.Data.Models;

namespace CallTime.Core.Services.Settings
{
    public class SettingService : ISettingService
    {
        /// <summary>
        /// Получить модель настройки
        /// </summary>
        /// <returns></returns>
        public SettingModel GetSettingModel(EnumSitePage page)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var model = new SettingModel();
                    model.SitePageId = (int)page;
                    var ruSetting = db.PageSettingLangs.AsNoTracking()
                        .FirstOrDefault(x => x.PageSettingId == (int) page && x.Lang==(int)EnumLanguage.Ru);
                    model.RuTitle = ruSetting?.Title;
                    model.RuKeywords = ruSetting?.Keywords;
                    model.RuDescription = ruSetting?.Description;
                    var enSetting = db.PageSettingLangs.AsNoTracking()
                        .FirstOrDefault(x => x.PageSettingId == (int)page && x.Lang == (int)EnumLanguage.En);
                    model.EnTitle = enSetting?.Title;
                    model.EnKeywords = enSetting?.Keywords;
                    model.EnDescription = enSetting?.Description;
                    return model;
                }
            }
            catch (Exception ex)
            {
                return new SettingModel();
            }
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
        /// Редактирование контента
        /// </summary>
        /// <param name="content"></param>
        /// <param name="id"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public BaseResponse EditContent(string content, string id, EnumLanguage lang)
        {
            try
            {
                var keyString = id.Split('-')[1];
                if (!string.IsNullOrEmpty(keyString))
                {
                    var key = int.Parse(keyString);
                    using (var db = new DataContext())
                    {
                        var setting = db.PageContentLangs.FirstOrDefault(x => x.PageContentId == key && x.Lang == (int) lang);
                        if (setting != null)
                        {
                            setting.Content = content;
                            //for (int i = 17; i < 300; i++)
                            //{
                            //    var pageContent = new PageContent {Id = i};
                            //    db.PageContents.Add(pageContent);
                            //    var contentRu = new PageContentLang{PageContentId = i,Lang = 1};
                            //    db.PageContentLangs.Add(contentRu);
                            //    var contentEn = new PageContentLang{PageContentId = i,Lang = 2};
                            //    db.PageContentLangs.Add(contentEn);
                            //}
                            db.SaveChanges();
                            return new BaseResponse(EnumResponseStatus.Success, "Контент успешно изменен");
                        }
                    }
                }
                return new BaseResponse(EnumResponseStatus.Error);
            }
            catch (Exception ex)
            {
                return new BaseResponse(EnumResponseStatus.Exception);
            }
        }

        /// <summary>
        /// Обновление настроек
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponse UpdateSettings(SettingModel model)
        {
            using (var db = new DataContext())
            {
                var ruSetting = db.PageSettingLangs.FirstOrDefault(x =>
                    x.PageSettingId == model.SitePageId && x.Lang == (int)EnumLanguage.Ru);
                var enSetting = db.PageSettingLangs.FirstOrDefault(x =>
                    x.PageSettingId == model.SitePageId && x.Lang == (int)EnumLanguage.En);
                if(ruSetting==null || enSetting==null)
                    return new BaseResponse(EnumResponseStatus.Error);

                ruSetting.Title = model.RuTitle;
                ruSetting.Keywords = model.RuKeywords;
                ruSetting.Description = model.RuDescription;
                enSetting.Title = model.EnTitle;
                enSetting.Keywords = model.EnKeywords;
                enSetting.Description = model.EnDescription;
                db.SaveChanges();
                return new BaseResponse(0, "Настройки успешно изменены");
            }
        }

    }
}
