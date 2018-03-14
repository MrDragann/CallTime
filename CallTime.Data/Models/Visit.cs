using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTime.Data.Models
{
   public class Visit
    {
        /// <summary>
        /// Ид
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Енум страницы
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Дата посещения
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Ип адресс пользователя
        /// </summary>
        public string Ip { get; set; }
    }
}
