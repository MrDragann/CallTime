using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace CallTime.Web.Models
{
    public static class Emailer
    {
   
        /// <summary>
        /// Отправка сообщений через SMTP 
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        /// <param name="subject">Тема сообщения</param>
        public static void Send(string text, string subject,string email)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(email);
                msg.Subject = subject;
                msg.IsBodyHtml = true;
                msg.Body = text;
                SmtpClient smtp = new SmtpClient();
                smtp.Send(msg);
            }
            catch (Exception e)
            {

            }
        }

    }
}