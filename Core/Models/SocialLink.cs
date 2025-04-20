using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.Models.Base;

namespace CORE.Models
{
    public class SocialLink:BaseEntity
    {
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string YouTube { get; set; }
        public string LinkedIn { get; set; }
    }
}
