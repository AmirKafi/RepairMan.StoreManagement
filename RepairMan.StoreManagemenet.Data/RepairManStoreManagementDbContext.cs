using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Domain.Parts;
using RepairMan.StoreManagement.Domain.Phones;

namespace RepairMan.StoreManagement.Data
{
    public class RepairManStoreManagementDbContext : DbContext
    {

        protected RepairManStoreManagementDbContext()
        {

        }

        public RepairManStoreManagementDbContext(DbContextOptions<RepairManStoreManagementDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RepairManStoreManagement_DB;Persist Security Info=True;MultipleActiveResultSets=true;User ID=RepairMan;Password=ASD110asd;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        public DbSet<Part> Parts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
