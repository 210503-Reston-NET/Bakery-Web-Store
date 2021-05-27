using Microsoft.EntityFrameworkCore;
using SModel;
namespace SDL
{
    public class BakeryDBContext : DbContext
    {
        public BakeryDBContext(DbContextOptions options) : base(options)
        {

        }
        public BakeryDBContext()
        {

        }

        public virtual DbSet<Bakery> Bakeries { get; set; }
        public virtual DbSet<BakeryInventory> BakeryInventories { get; set; }
        public virtual DbSet<Bread> Breads { get; set; }
        public virtual DbSet<BreadBatch> BreadBatches { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .Property(customer => customer.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Orders>()
            .Property(orders => orders.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Bread>()
            .Property(bread => bread.BreadId)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Bakery>()
            .Property(bakery => bakery.BakeryId)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<BreadBatch>()
            .Property(batch => batch.BreadBatchId)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<BakeryInventory>()
            .Property(bakeryinv => bakeryinv.Id)
            .ValueGeneratedOnAdd();
            
        }
    }
}