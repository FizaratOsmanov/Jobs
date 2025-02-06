using CORE.Models.Base;

namespace CORE.Models
{
    public  class Category:BaseEntity
    {
        public string? Title { get; set; }
        public int? VacancyCount { get; set; }
    }
}
