using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace VehicleSellingProject.WebApplication.Models.Config
{
    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.Brand)
                   .HasColumnName("Brand")
                   .HasMaxLength(20)
                   .IsUnicode(true)
                   .IsRequired(true);
            builder.Property(e => e.Name)
                   .HasColumnName("Name")
                   .HasMaxLength(20)
                   .IsUnicode(true)
                   .IsRequired(true);
            builder.Property(e => e.Model)
                   .HasColumnName("Model")
                   .IsRequired(true);
            builder.Property(e => e.CostPrice)
                   .HasColumnName("CostPrice")
                   .IsRequired(true);
            builder.Property(e => e.SellPrice)
                   .HasColumnName("SellPrice")
                   .IsRequired(true);

            builder.Property(e => e.EngineSizeId).HasColumnName("EngineSizeCode").IsRequired(true);
            builder.Property(e => e.BodyTypeId).HasColumnName("BodyTypeCode").IsRequired(true);
            builder.Property(e => e.DoorId).HasColumnName("DoorCode").IsRequired(true);


            builder.HasOne(d => d.BodyType)
                   .WithMany(p => p.Vehicles)
                   .HasForeignKey(d => d.BodyTypeId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Vehicle_BodyType");

            builder.HasOne(d => d.EngineSize)
                   .WithMany(p => p.Vehicles)
                   .HasForeignKey(d => d.EngineSizeId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Vehicle_EngineSize");

            builder.HasOne(d => d.Door)
                   .WithMany(p => p.Vehicles)
                   .HasForeignKey(d => d.DoorId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Vehicle_Door");
        }
    }
}
