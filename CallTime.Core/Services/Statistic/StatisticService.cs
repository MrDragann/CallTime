using CallTime.Core.Enums;
using CallTime.Core.Interfaces;
using CallTime.Core.Models.Responses;
using CallTime.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTime.Core.Services.Statistic
{
    public class StatisticService : IStatisticService
    {
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
    }
}
