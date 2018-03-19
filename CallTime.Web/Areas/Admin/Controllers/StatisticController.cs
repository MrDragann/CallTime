using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CallTime.Core.Interfaces;
using CallTime.Core.Services.Statistic;
using CallTime.Web.Infrastructure;

namespace CallTime.Web.Areas.Admin.Controllers
{
    [Authorization(Roles = ConstRoles.Admin)]
    public class StatisticController : Controller
    {
        private IStatisticService _statisticService = new StatisticService();

        // GET: Admin/Statistic
        public ActionResult Visit()
        {
            var model = _statisticService.GetVisitStatistic();
            return View(model);
        }
    }
}