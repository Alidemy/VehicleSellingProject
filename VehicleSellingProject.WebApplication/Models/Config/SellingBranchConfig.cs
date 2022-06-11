using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSellingProject.WebApplication.Models.Config
{
    public class SellingBranchConfig : IEntityTypeConfiguration<SellingBranch>
    {
        public void Configure(EntityTypeBuilder<SellingBranch> builder)
        {
            builder.ToTable("SellingBranch");

            builder.Property(e => e.Id).HasColumnName("Code");
            builder.Property(e => e.BNumber).HasColumnName("BranchNumber").IsRequired(true);
            builder.Property(e => e.BName).HasColumnName("BranchName").HasMaxLength(15).IsRequired(true).IsUnicode(true);
            builder.Property(e=> e.BAddress).HasColumnName("BranchAddress").HasMaxLength(100).IsRequired(true).IsUnicode(true);
            builder.Property(e => e.BTel).HasColumnName("BranchTelephone").HasMaxLength(11).IsRequired(true);
        }
    }
}
