using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace VehicleSellingProject.WebApplication.Models.Config
{
    public class DoorConfig : IEntityTypeConfiguration<Door>
    {
        public void Configure(EntityTypeBuilder<Door> builder)
        {
            builder.ToTable("Door");

            builder.Property(e => e.Id).HasColumnName("Code");
            builder.Property(e => e.Qty).HasColumnName("Qty").IsRequired(true);
            builder.Property(e => e.BodyTypeId).HasColumnName("BodyTypeCode").IsRequired(true);

            builder.HasOne(d => d.BodyType)
                   .WithMany(p => p.Doors)
                   .HasForeignKey(d => d.BodyTypeId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Door_BodyType");
        }
    }
}
