using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallTime.Web.Models
{
    public class GoogleModel
    {
        public bool success { get; set; }
        public DateTime challenge_ts { get; set; }
        public string hostname { get; set; }
        
    }
}