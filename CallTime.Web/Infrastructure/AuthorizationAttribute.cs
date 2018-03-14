using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallTime.Web.Infrastructure
{
    /// <summary>
    /// Аттрибут авторизации
    /// </summary>
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        private WebUser user => new WebUser();

        /// <summary>
        /// Допустимые роли
        /// </summary>
        private List<string> _allowedRoles;
        /// <summary>
        /// Роли пользователя
        /// </summary>
        private List<string> _userRoles;

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!user.IsAuthorized)
                return false;

            _userRoles = user.Roles;

            if (!_userRoles.Any())
                return false;

            _allowedRoles = Roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            ////если пользователь админ
            //if (_allowedRoles.Contains(ConstRoles.Admin) && user.IsAdmin)
            //    return true;

            //проверка пользователя на существование роли
            if (!_userRoles.Intersect(_allowedRoles.Where(x => !string.IsNullOrEmpty(x))).Any())
                return false;

            return true;
        }

        /// <summary>
        /// Редирект в случае если пользователю отказано в доступе
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var returnUrl = filterContext.HttpContext.Request.Url;
            filterContext.Result = string.IsNullOrWhiteSpace(returnUrl?.PathAndQuery) ? new RedirectResult("/Admin/", false)
                : new RedirectResult($"/Admin/Home/Index?returnUrl={returnUrl.PathAndQuery}", false);
        }

    }
}