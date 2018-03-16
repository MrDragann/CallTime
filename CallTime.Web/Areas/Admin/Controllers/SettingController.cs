using System.Web.Mvc;
using CallTime.Core.Enums;
using CallTime.Core.Interfaces;
using CallTime.Core.Models.Setting;
using CallTime.Core.Services.Settings;
using CallTime.Web.Controllers;
using CallTime.Web.Infrastructure;

namespace CallTime.Web.Areas.Admin.Controllers
{
    [Authorization(Roles = ConstRoles.Admin)]
    public class SettingController : Controller
    {
        private ISettingService _settingService = new SettingService();

        // GET: Admin/Dashboard
        public ActionResult Index(EnumSitePage page)
        {
            var model = _settingService.GetSettingModel(page);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateSettings(SettingModel model)
        {
            var response = _settingService.UpdateSettings(model);
            return RedirectToAction("Index",new{page=model.SitePageId});
        }
    }
}