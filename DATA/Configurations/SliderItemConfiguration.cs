using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DATA.Configurations
{
    public class SliderItemConfiguration:IEntityTypeConfiguration<SliderItem>
    {
        public void Configure(EntityTypeBuilder<SliderItem> builder)
        {

            builder.ToTable("SliderItems");

            builder.HasKey(c => c.Id);

            builder.Property(s => s.ImgPath)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(s => s.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(s => s.Description)
                .HasMaxLength(1000)
                .IsRequired();
        }      
    }
}
