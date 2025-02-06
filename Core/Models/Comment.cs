using CORE.Models.Base;

namespace CORE.Models
{
    public  class Comment:BaseEntity
    {
        public  string? Message { get; set; }
        public string? ImgPath { get; set; }
        public  string? Name { get; set; }
        public  string? Profession { get; set; }
    }
}
