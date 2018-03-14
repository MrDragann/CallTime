using System.Web.Mvc;
using CallTime.Core.Interfaces;
using CallTime.Core.Models.Requests;
using CallTime.Core.Models.User;
using CallTime.Core.Services;
using CallTime.Core.Services.Static;
using CallTime.Web.Infrastructure;

namespace CallTime.Web.Areas.Admin.Controllers
{
    [Authorization(Roles = ConstRoles.Admin)]
    public class HomeController : Controller
    {
        private IAuthCommonService _authCommonService = new AuthCommonService();
        private IModuleService _moduleService = new ModuleService();

        #region [ Авторизация ]

        [AllowAnonymous]
        public ActionResult Index()
        {
            //var reg = _authCommonService.Register(new UserModel
            //{
            //    Email = "vs-admin",
            //    Login = "vs-admin",
            //    Password = "3yZdomzEEn7B"
            //});
            var user = new WebUser();
            if (user.IsAdmin)
                return RedirectToAction("Index", "Settings");

            return View(new UserLoginModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(UserLoginModel model)
        {
            var passwordHash = model.Password.GetHashString();
            var loginStatus = _authCommonService.Login(model.Email, passwordHash);
            if (loginStatus.IsSuccess)
            {
                var webUser = new WebUser
                {
                    UserId = loginStatus.Value.Id,
                    Email = loginStatus.Value.Email,
                    Roles = loginStatus.Value.Roles,
                    IsAuthorized = true
                };
                HttpContext.Session["UserSession"] = webUser;
                var returnUrl =
                    HttpContext.Request.UrlReferrer?.AbsoluteUri.Replace("/Admin/Home/Index?returnUrl=", "");
                return Redirect(returnUrl);
            }
            return View(new UserLoginModel());
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            HttpContext.Session.Remove("UserSession");
            return RedirectToAction("Index");
        }

        #endregion
    }
}