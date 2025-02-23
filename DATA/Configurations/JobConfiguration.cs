using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DATA.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs");

            builder.HasKey(c => c.Id);

            builder.Property(j => j.CompanyIconPath)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(j => j.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(j => j.Location)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(j => j.JobNature)
                .IsRequired();

            builder.Property(j => j.MinSalary)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(j => j.MaxSalary)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(j => j.Description)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(j => j.Responsiblity)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(j => j.Qualification)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(j => j.DateLine)
                .IsRequired();

            builder.Property(j => j.CompanyDetail)
                .HasColumnType("text")
                .IsRequired();

            builder.Property(j => j.VacancyCount)
                .IsRequired();

            builder.Property(j => j.CategoryId)
                .IsRequired();

            builder.HasOne(j => j.Category)
                .WithMany()
                .HasForeignKey(j => j.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
