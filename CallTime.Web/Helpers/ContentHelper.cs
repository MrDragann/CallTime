using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CallTime.Core.Enums;
using System.Web.Mvc;
using System.Web.Routing;
using CallTime.Core.Models.Content;
using CallTime.Web.Infrastructure;

namespace CallTime.Web.Helpers
{
    public static class ContentHelper
    {
        public static MvcHtmlString GetContent(List<ContentModel> list, EnumContentKey key)
        {
            var content = list.Key(key);
            var routeData = HttpContext.Current.Request.RequestContext.RouteData;
            var routeValueDictionary = new RouteValueDictionary(routeData.Values);

            var div = new TagBuilder("div");
            div.Attributes.Add("id", $"text-{(int)key}");
            var user = new WebUser();
            if (routeValueDictionary.ContainsKey("edit"))
            {
                if (routeData.Values["edit"] as string == "edit" && user.IsAdmin)
                {
                    div.AddCssClass("ckeditor");
                    div.Attributes.Add("contenteditable", "true");
                }
            }
            div.InnerHtml = content;
            return new MvcHtmlString(div.ToString());
        }

        public static string Key(this List<ContentModel> list, EnumContentKey key)
        {
            return list.FirstOrDefault(x => x.Key == key)?.Content;
        }
    }
}