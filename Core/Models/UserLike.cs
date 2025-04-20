using CORE.Models.Base;

namespace CORE.Models
{
    public  class UserLike:BaseEntity
    {
        public string UserId { get; set; } 
        public int JobId { get; set; } 
        public Job Job { get; set; } 
        public AppUser User { get; set; }
    }
}
