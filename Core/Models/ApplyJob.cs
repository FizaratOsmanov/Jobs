using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.Models.Base;

namespace CORE.Models
{
    public class ApplyJob:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Portfolio { get; set; }
        public string CV { get; set; }
        public string CoverLetter { get; set; }
    }
}
