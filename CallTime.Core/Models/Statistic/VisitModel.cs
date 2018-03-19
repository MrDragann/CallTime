using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTime.Core.Models.Statistic
{
    public class VisitModel
    {
        public int HomeVisit { get; set; }

        public int HomeVisitUnique { get; set; }

        public int TokenVisit { get; set; }

        public int TokenVisitUnique { get; set; }
    }
}
