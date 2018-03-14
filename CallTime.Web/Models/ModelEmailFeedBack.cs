using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallTime.Web.Models
{
    public static  class ModelEmailFeedBack
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
    }
}