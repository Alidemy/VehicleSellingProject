using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSellingProject.WebApplication.Models.Config;

namespace VehicleSellingProject.WebApplication.Models
{
    public class VehicleContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<EngineSize> EngineSizes { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<Cylinder> Cylinders  { get; set; }
        public DbSet<SellingBranch> SellingBranches { get; set; }
        public DbSet<SellingInfo> SellingInfos { get; set; }

        public VehicleContext(DbContextOptions<VehicleContext> options ) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleConfig());
            modelBuilder.ApplyConfiguration(new EngineSizeConfig());
            modelBuilder.ApplyConfiguration(new BodyTypeConfig());
            modelBuilder.ApplyConfiguration(new DoorConfig());
            modelBuilder.ApplyConfiguration(new CylinderConfig());
            modelBuilder.ApplyConfiguration(new SellingBranchConfig());
            modelBuilder.ApplyConfiguration(new SellingInfoConfig());
        }
    }
}
