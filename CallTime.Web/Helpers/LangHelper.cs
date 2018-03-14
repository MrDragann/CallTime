using CallTime.Core.Enums;
using System.Web.Mvc;
using System.Web.Routing;

namespace CallTime.Web.Helpers
{
    public static class LangHelper
    {
        /// <summary>
        /// Смена языка на странице
        /// </summary>
        /// <param name="url"></param>
        /// <param name="routeData"></param>
        /// <param name="lang">На какой язык сменить</param>
        /// <param name="changeKeyUrl">KeyUrl языка</param>
        /// <returns></returns>
        public static MvcHtmlString LangSwitcher(this UrlHelper url, RouteData routeData, string lang)
        {
            var enDiv = new TagBuilder("div");
            var enA = new TagBuilder("a");
            var rusDiv = new TagBuilder("div");
            var rusA = new TagBuilder("a");
            var routeValueDictionary = new RouteValueDictionary(routeData.Values);
            if (routeValueDictionary.ContainsKey("lang"))
            {
                if (routeData.Values["lang"] as string != lang)
                {
                    routeValueDictionary["lang"] = lang;
                }
            }
            if (lang == EnumLanguage.En.ToString().ToLower())
            {
                enA.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
                rusA.AddCssClass("active");
            }
            else
            {
                rusA.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
                enA.AddCssClass("active");
            }
            enA.SetInnerText("ENG");
            rusA.SetInnerText("РУС");
            enDiv.AddCssClass("lang-switch flex-item");
            enDiv.InnerHtml = enA.ToString();
            rusDiv.AddCssClass("lang-switch flex-item");
            rusDiv.InnerHtml = rusA.ToString();
            return new MvcHtmlString($"{rusDiv}{enDiv}");
        }
    }
}