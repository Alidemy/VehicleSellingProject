using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace VehicleSellingProject.WebApplication.Models.Config
{
    public class BodyTypeConfig : IEntityTypeConfiguration<BodyType>
    {
        public void Configure(EntityTypeBuilder<BodyType> builder)
        {
            builder.ToTable("BodyType");

            builder.Property(e => e.Id).HasColumnName("Code");
            builder.Property(e => e.TypeName).HasColumnName("TypeName")
                   .IsRequired(true)
                   .IsUnicode(true)
                   .HasMaxLength(15);
            
        }
    }
}
