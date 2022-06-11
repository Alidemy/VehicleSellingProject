using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VehicleSellingProject.WebApplication.Models.Config
{
    public class CylinderConfig : IEntityTypeConfiguration<Cylinder>
    {
        public void Configure(EntityTypeBuilder<Cylinder> builder)
        {
            builder.ToTable("Cylinder");

            builder.Property(e => e.Id).HasColumnName("Code");
            builder.Property(e => e.Qty).HasColumnName("Qty").IsRequired(true);
            builder.Property(e => e.BodyTypeId).HasColumnName("BodyTypeCode").IsRequired(true);

            builder.HasOne(d => d.BodyType)
                   .WithMany(p => p.Cylinders)
                   .HasForeignKey(d => d.BodyTypeId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Cylinder_BodyType");
        }
    }
}
