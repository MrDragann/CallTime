using CallTime.Core.Enums;
using CallTime.Core.Interfaces;
using CallTime.Core.Models.Responses;
using CallTime.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallTime.Core.Models.Statistic;

namespace CallTime.Core.Services.Statistic
{
    public class StatisticService : IStatisticService
    {
        #region [ Static ]

        private readonly List<string> localIps = new List<string>{ "::1", "127.0.0.1" };

        #endregion

        /// <summary>
        /// Добавить посещение сайту
        /// </summary>
        /// <param name="ip">Ип пользователя</param>
        /// <param name="page">Страница</param>
        /// <returns></returns>
        public BaseResponse SetVisit (string ip, EnumSitePage page)
        {
            try
            {
                using(var db = new DataContext())
                {
                    db.Visits.Add(new Data.Models.Visit()
                    {
                        Date = DateTime.Now,
                        Ip = ip,
                        Page = (int)page
                    });
                    db.SaveChanges();
                    return new BaseResponse()
                    {
                        Status = 0,
                        Message = "Success"
                    };
                }
            }
            catch(Exception e)
            {
                return new BaseResponse()
                {
                    Status = 2,
                    Message = e.Message
                };
            }
        }

        /// <summary>
        /// Получить статистику по посещениям
        /// </summary>
        /// <returns></returns>
        public VisitModel GetVisitStatistic()
        {
            try
            {
                var model = new VisitModel();
                using (var db = new DataContext())
                {
                    var allVisits = db.Visits.AsNoTracking().Where(x => !localIps.Contains(x.Ip)).ToList();
                    var homeVisits = allVisits.Where(x => x.Page == (int) EnumSitePage.Home).ToList();
                    model.HomeVisit = homeVisits.Count;
                    model.HomeVisitUnique = homeVisits.GroupBy(x=>x.Ip).ToList().Count;

                    var tokenVisits = allVisits.Where(x => x.Page == (int) EnumSitePage.Token).ToList();
                    model.TokenVisit = tokenVisits.Count;
                    model.TokenVisitUnique = tokenVisits.GroupBy(x => x.Ip).ToList().Count;
                }
                return model;
            }
            catch (Exception ex)
            {
                return new VisitModel();
            }
        }
    }
}
