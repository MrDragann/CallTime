using CallTime.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using CallTime.Core.Enums;
using CallTime.Core.Interfaces;
using CallTime.Core.Services.Settings;
using CallTime.Core.Services.Statistic;

namespace CallTime.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IStatisticService _statisticService = new StatisticService();
        private ISettingService _settingService = new SettingService();
        private string GetIpAddress()
        {
            string stringIpAddress;
            stringIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (stringIpAddress == null)
            {
                stringIpAddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            return stringIpAddress;
        }
        public ActionResult Index()
        {
            SetSitePageSettings(Lang,EnumSitePage.Home);
            var model = new ViewModel {PageContents = _settingService.GetContent(Lang)};
            if (HttpContext.Request.Cookies["Visit"] == null)
            {
                var address = GetIpAddress();
                var resp = _statisticService.SetVisit(address,Core.Enums.EnumSitePage.Home);
                if (resp.IsSuccess)
                {
                    System.Web.HttpContext context = System.Web.HttpContext.Current;
                    HttpCookie myCookie = new HttpCookie("Visit");
                    myCookie["Date"] = DateTime.Now.ToLongDateString();
                    myCookie.Expires = DateTime.Now.AddHours(1d);
                    Response.Cookies.Add(myCookie);
                }
            }
            return View(model);
        }
        public ActionResult Token()
        {
            SetSitePageSettings(Lang,EnumSitePage.Token);
            var model = new ViewModel { PageContents = _settingService.GetContent(Lang)};

            if (HttpContext.Request.Cookies["VisitToken"] == null)
            {
                var address = GetIpAddress();
                var resp = _statisticService.SetVisit(address, Core.Enums.EnumSitePage.Token);
                if (resp.IsSuccess)
                {
                    System.Web.HttpContext context = System.Web.HttpContext.Current;
                    HttpCookie myCookie = new HttpCookie("VisitToken");
                    myCookie["Date"] = DateTime.Now.ToLongDateString();
                    myCookie.Expires = DateTime.Now.AddHours(1d);
                    Response.Cookies.Add(myCookie);
                }
            }
            return View(model);
        }
        public ActionResult PersonalCabinet()
        {
            return View();
        }
        public ActionResult Subscribe(string email)
        {
            var message = ModelEmailFeedBack.GetHtmlTextSubscribe(email);
            Emailer.Send(message, "Подписка", "token@call-time.ru");
            return RedirectToAction("Token");
        }

        public ActionResult Feedback(ModelFeedback model)
        {
            model.Subject = "Обратная связь";
            model.Text = ModelEmailFeedBack.GetHtmlText(model);
            Emailer.Send(model.Text, model.Subject, "sss8474@gmail.com");
            return RedirectToAction("Index");
        }
        public ActionResult Careers(ModelCareers model)
        {            
            Emailer.Send(ModelEmailFeedBack.GetHtmlTextCareers(model), "Новая заявка на сайте CallTime", "kadri.calltime@gmail.com");
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditContent(string editabledata, string editorID)
        {
            var respone = _settingService.EditContent(editabledata, editorID, Lang);
            return Json(respone);
        }
    }
}