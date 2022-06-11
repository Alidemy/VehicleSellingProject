using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSellingProject.WebApplication.Models.Config
{
    public class SellingInfoConfig : IEntityTypeConfiguration<SellingInfo>
    {
        public void Configure(EntityTypeBuilder<SellingInfo> builder)
        {
            builder.ToTable("SellingInfo");

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.BuyerName).HasColumnName("BuyerName").HasMaxLength(20).IsRequired(true).IsUnicode(true);
            builder.Property(e => e.BuyerTel).HasColumnName("BuyerTel").HasMaxLength(11).IsRequired(true);

            builder.Property(e => e.VehicleId).HasColumnName("VehicleId").IsRequired(true);
            builder.Property(e => e.BranchId).HasColumnName("BranchID").IsRequired(true);

            builder.HasOne(d => d.Vehicle)
                   .WithMany(p => p.SellingInfo)
                   .HasForeignKey(d => d.VehicleId)
                   .HasConstraintName("FK_SellingInfo_Vehicle");

            builder.HasOne(d => d.SellingBranch)
                   .WithMany(p => p.SellingInfo)
                   .HasForeignKey(d => d.BranchId)
                   .HasConstraintName("FK_SellingInfo_SellingBranch");
        }
    }
}
