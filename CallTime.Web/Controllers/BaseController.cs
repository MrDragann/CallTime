using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;
using CallTime.Core.Enums;
using CallTime.Core.Interfaces;
using CallTime.Core.Models.Setting;
using CallTime.Core.Services.Settings;

namespace CallTime.Web.Controllers
{
    public class BaseController : Controller
    {
        private ISettingService _settingService = new SettingService();

        public static string HostName = string.Empty;

        private string CurrentLangCode { get; set; }

        public static EnumLanguage Lang { get; set; }

        public void SetSitePageSettings(EnumLanguage lang, EnumSitePage page)
        {
            var model = _settingService.GetSettingModel(page);
            if (lang == EnumLanguage.Ru)
            {
                ViewBag.Title = model.RuTitle;
                ViewBag.Keywords = model.RuKeywords;
                ViewBag.Description = model.RuDescription;
            }
            else if (lang == EnumLanguage.En)
            {
                ViewBag.Title = model.EnTitle;
                ViewBag.Keywords = model.EnKeywords;
                ViewBag.Description = model.EnDescription;
            }
        }
        
        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Url != null)
            {
                HostName = requestContext.HttpContext.Request.Url.Authority;
            }

            if (requestContext.RouteData.Values["lang"] != null && requestContext.RouteData.Values["lang"] as string != "null")
            {
                CurrentLangCode = requestContext.RouteData.Values["lang"] as string;

                if (CurrentLangCode != null)
                {
                    Lang = (EnumLanguage)Enum.Parse(typeof(EnumLanguage), CurrentLangCode, true);
                    var ci = new CultureInfo(CurrentLangCode);
                    Thread.CurrentThread.CurrentUICulture = ci;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
                }
            }
            base.Initialize(requestContext);
        }
    }
}