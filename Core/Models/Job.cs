﻿using CORE.Enums;
using CORE.Models.Base;
namespace CORE.Models
{
    public  class Job:BaseEntity
    {
        public string CompanyIconPath { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public JobNature JobNature { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public string Description { get; set; }
        public string Responsiblity { get; set; }
        public string Qualification { get; set; }
        public DateTime DateLine { get; set; }
        public string CompanyDetail { get; set; }
        public int  VacancyCount { get; set; }              
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<ApplyJob> ApplyJobs { get; set; }
    }
}
