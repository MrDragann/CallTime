using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallTime.Web.Models
{
    public class ModelCareers
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Образование
        /// </summary>
        public string Education { get; set; }
        /// <summary>
        /// Дополнительные крусы, стажировки и тд
        /// </summary>
        public string Course { get; set; }
        /// <summary>
        /// опыт работы в контакт  - центре
        /// </summary>
        public string Experience { get; set; }
        /// <summary>
        /// Причина ухода из работы
        /// </summary>
        public string ReasonLeave { get; set; }
        /// <summary>
        /// Желаемый оклад
        /// </summary>
        public string Salary { get; set; }
        /// <summary>
        /// Уровень владение ПК
        /// </summary>
        public string SkillPc { get; set; }
        /// <summary>
        /// Откуда вы узнали о нас
        /// </summary>
        public string About { get; set; }
        /// <summary>
        /// 3 положительных факта
        /// </summary>
        public string Positive { get; set; }
        /// <summary>
        /// 3 негативных факта
        /// </summary>
        public string Negative { get; set; }
        /// <summary>
        /// Допольнительная информация
        /// </summary>
        public string Additionally { get; set; }    
    }
}