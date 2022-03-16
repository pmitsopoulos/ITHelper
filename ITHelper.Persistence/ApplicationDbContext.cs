using ITHelper.Domain.AssetInventoryEntities;
using ITHelper.Domain.IssueTrackerEntities;
using ITHelper.Domain.NetworkPortInfoEntities;
using ITHelper.Persistence.Configurations.AssetInventoryConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder  modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new HardwareTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new VendorConfiguration());
        }

        //Asset Inventory DbSets
        public DbSet<Hardware> Hardware { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HardwareType> HardwareTypes { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        //Issue Tracker DbSets
        public DbSet<ApplicationSystem> ApplicationSystems { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<SystemContact> SystemContacts { get; set; }

        //Network Port Information DbSets
        public DbSet<NetworkPortInformation> NetworkPortInformation { get; set; }
    }
}
