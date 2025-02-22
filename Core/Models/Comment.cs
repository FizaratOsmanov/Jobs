using CORE.Models.Base;

namespace CORE.Models
{
    public  class Comment:BaseEntity
    {
        public  string? Message { get; set; }
        public string? PhotoPath { get; set; }
        public  string? FirstName { get; set; }
        public  string? Profession { get; set; }
        public Guid? AppUserId {  get; set; }
        public AppUser AppUser { get; set; }
    }
}
