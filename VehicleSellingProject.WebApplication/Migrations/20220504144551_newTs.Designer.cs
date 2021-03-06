// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleSellingProject.WebApplication.Models;

namespace VehicleSellingProject.WebApplication.Migrations
{
    [DbContext(typeof(VehicleContext))]
    [Migration("20220504144551_newTs")]
    partial class newTs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.BodyType", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnName("Code");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("TypeName");

                    b.HasKey("Id");

                    b.ToTable("BodyType");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.Door", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnName("Code");

                    b.Property<byte>("BodyTypeId")
                        .HasColumnType("tinyint")
                        .HasColumnName("BodyTypeCode");

                    b.Property<byte>("Qty")
                        .HasColumnType("tinyint")
                        .HasColumnName("Qty");

                    b.HasKey("Id");

                    b.HasIndex("BodyTypeId");

                    b.ToTable("Door");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.EngineDetails", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnName("Code");

                    b.Property<byte>("Cylinders")
                        .HasColumnType("tinyint")
                        .HasColumnName("Cylinders");

                    b.Property<int>("EngineSize")
                        .HasColumnType("int")
                        .HasColumnName("EngineSize");

                    b.HasKey("Id");

                    b.ToTable("EngineDetails");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.EngineSize", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnName("Code");

                    b.Property<byte>("BodyTypeId")
                        .HasColumnType("tinyint")
                        .HasColumnName("BodyTypeCode");

                    b.Property<int>("Size")
                        .HasColumnType("int")
                        .HasColumnName("Size");

                    b.HasKey("Id");

                    b.HasIndex("BodyTypeId");

                    b.ToTable("EngineSize");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.SedanVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("EngineDetailsId")
                        .HasColumnType("tinyint")
                        .HasColumnName("EngineDetailsCode");

                    b.Property<int>("Model")
                        .HasColumnType("int")
                        .HasColumnName("Model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("EngineDetailsId");

                    b.ToTable("Sedan");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("BodyTypeId")
                        .HasColumnType("tinyint")
                        .HasColumnName("BodyTypeCode");

                    b.Property<byte>("DoorId")
                        .HasColumnType("tinyint")
                        .HasColumnName("DoorCode");

                    b.Property<byte>("EngineSizeId")
                        .HasColumnType("tinyint")
                        .HasColumnName("EngineSizeCode");

                    b.Property<DateTime>("Model")
                        .HasColumnType("datetime2")
                        .HasColumnName("Model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("BodyTypeId");

                    b.HasIndex("DoorId");

                    b.HasIndex("EngineSizeId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.Door", b =>
                {
                    b.HasOne("VehicleSellingProject.WebApplication.Models.BodyType", "BodyType")
                        .WithMany("Doors")
                        .HasForeignKey("BodyTypeId")
                        .HasConstraintName("FK_Door_BodyType")
                        .IsRequired();

                    b.Navigation("BodyType");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.EngineSize", b =>
                {
                    b.HasOne("VehicleSellingProject.WebApplication.Models.BodyType", "BodyType")
                        .WithMany("EngineSizes")
                        .HasForeignKey("BodyTypeId")
                        .HasConstraintName("FK_EngineSize_BodyType")
                        .IsRequired();

                    b.Navigation("BodyType");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.SedanVehicle", b =>
                {
                    b.HasOne("VehicleSellingProject.WebApplication.Models.EngineDetails", "EngineDetails")
                        .WithMany("SedanVehicles")
                        .HasForeignKey("EngineDetailsId")
                        .HasConstraintName("FK_Sedan_EngineDetails")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EngineDetails");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.Vehicle", b =>
                {
                    b.HasOne("VehicleSellingProject.WebApplication.Models.BodyType", "BodyType")
                        .WithMany("Vehicles")
                        .HasForeignKey("BodyTypeId")
                        .HasConstraintName("FK_Vehicle_BodyType")
                        .IsRequired();

                    b.HasOne("VehicleSellingProject.WebApplication.Models.Door", "Door")
                        .WithMany("Vehicles")
                        .HasForeignKey("DoorId")
                        .HasConstraintName("FK_Vehicle_Door")
                        .IsRequired();

                    b.HasOne("VehicleSellingProject.WebApplication.Models.EngineSize", "EngineSize")
                        .WithMany("Vehicles")
                        .HasForeignKey("EngineSizeId")
                        .HasConstraintName("FK_Vehicle_EngineSize")
                        .IsRequired();

                    b.Navigation("BodyType");

                    b.Navigation("Door");

                    b.Navigation("EngineSize");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.BodyType", b =>
                {
                    b.Navigation("Doors");

                    b.Navigation("EngineSizes");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.Door", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.EngineDetails", b =>
                {
                    b.Navigation("SedanVehicles");
                });

            modelBuilder.Entity("VehicleSellingProject.WebApplication.Models.EngineSize", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
