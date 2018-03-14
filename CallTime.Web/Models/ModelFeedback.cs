using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallTime.Web.Models
{
    public class ModelFeedback
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Компания пользователя
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Телефон пользователя
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string Subject { get; set; }
    }
}