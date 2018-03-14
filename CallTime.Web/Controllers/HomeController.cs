using CallTime.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallTime.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Token()
        {
            return View();
        }

        public ActionResult Subscribe(string email)
        {
            var message = ModelEmailFeedBack.GetHtmlTextSubscribe(email);
            Emailer.Send(message, "Подписка");
            return RedirectToAction("Token");
        }

        public ActionResult Feedback(ModelFeedback model)
        {
            model.Subject = "Обратная связь";
            model.Text = ModelEmailFeedBack.GetHtmlText(model);
            Emailer.Send(model.Text, model.Subject);
            return RedirectToAction("Index");
        }
    }
}