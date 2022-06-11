using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace VehicleSellingProject.WebApplication.Models.Config
{
    public class EngineSizeConfig : IEntityTypeConfiguration<EngineSize>
    {
        public void Configure(EntityTypeBuilder<EngineSize> builder)
        {
            builder.ToTable("EngineSize");

            builder.Property(e => e.Id).HasColumnName("Code");
            builder.Property(e => e.Size).HasColumnName("Size").IsRequired(true);
            builder.Property(e => e.BodyTypeId).HasColumnName("BodyTypeCode").IsRequired(true);

            builder.HasOne(d => d.BodyType)
                   .WithMany(p => p.EngineSizes)
                   .HasForeignKey(d => d.BodyTypeId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_EngineSize_BodyType");
        }
    }
}
