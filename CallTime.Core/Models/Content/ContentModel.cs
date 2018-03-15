using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallTime.Core.Enums;

namespace CallTime.Core.Models.Content
{
    public class ContentModel
    {
        public EnumContentKey Key { get; set; }

        public string Content { get; set; }
    }
}
