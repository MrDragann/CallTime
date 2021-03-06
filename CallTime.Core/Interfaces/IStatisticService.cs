﻿using CallTime.Core.Enums;
using CallTime.Core.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallTime.Core.Models.Statistic;

namespace CallTime.Core.Interfaces
{
    public interface IStatisticService
    {
        /// <summary>
        /// Добавить посещение сайту
        /// </summary>
        /// <param name="ip">Ип пользователя</param>
        /// <param name="page">Страница</param>
        /// <returns></returns>
        BaseResponse SetVisit(string ip, EnumSitePage page);

        /// <summary>
        /// Получить статистику по посещениям
        /// </summary>
        /// <returns></returns>
        VisitModel GetVisitStatistic();
    }
}
