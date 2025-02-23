using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DATA.Configurations
{
    public class ApplyJobConfiguration : IEntityTypeConfiguration<ApplyJob>
    {
        public void Configure(EntityTypeBuilder<ApplyJob> builder)
        {
            builder.ToTable("ApplyJobs");

            builder.HasKey(a => a.Id); 

            builder.Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Portfolio)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(a => a.CV)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(a => a.CoverLetter)
                .HasColumnType("text")
                .IsRequired();

            builder.HasOne(a => a.Job)
                   .WithMany(j => j.ApplyJobs)
                   .HasForeignKey(a => a.JobId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
