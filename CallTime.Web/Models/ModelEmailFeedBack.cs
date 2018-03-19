using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallTime.Web.Models
{
    public static class ModelEmailFeedBack
    {
        public static string GetHtmlText(ModelFeedback model)
        {
            return string.Format($"<p>Новый вопрос на сайте CallTime. Данные пользователя:" +
                $"<br>Имя:{model.Name}" +
                $"<br>Почта:{model.Email}" +
                $"<br>Телефон:{model.Phone}" +
                $"<br>Компания:{model.Company}" +
                $"</p><p> Вопрос:{model.Text} </p>");
        }
        public static string GetHtmlTextSubscribe(string email)
        {
            return string.Format($"<p>Новый подписка на сайте CallTime. Данные пользователя:" +
                $"<br>Почта:{email}");
        }
        public static string GetHtmlTextCareers(ModelCareers model)
        {
            return string.Format($"<p>Новая заявка на сайте CallTime. Данные пользователя:" +
                $"<br>Имя:{model.Name}" +
                $"<br>Почта:{model.Email}" +
                $"<br>Телефон:{model.Phone}" +
                $"<br>Дата рождения:{model.Date.ToLongDateString()}" +
                $"<br>Образование:{model.Education}" +
                $"<br>Дополнительные крусы, стажировки и тд:{model.Course}" +
                $"<br>Опыт работы в контакт - центре:{model.Experience}" +
                $"<br>Причина ухода с последнего места работы:{model.ReasonLeave}" +
                $"<br>Желаемый оклад:{model.Salary}" +
                $"<br>Уровень владение ПК:{model.SkillPc}" +
                $"<br>Откуда вы узнали о нас:{model.About}" +
                $"<br>3 положительных качества*:{model.Positive}" +
                $"<br>3 негативных факта:{model.Negative}" +
                $"<br>Допольнительная информация:{model.Additionally}" +
                $"</p>");
        }
    }
}