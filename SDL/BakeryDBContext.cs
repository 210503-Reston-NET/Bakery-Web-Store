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

            modelBuilder.Entity<Bread>().HasData(
                new Bread { BreadId = 1, Breadtype = "Baguette", Price = 4.00 },
                new Bread { BreadId = 2, Breadtype = "Brioche", Price = 3.79 },
                new Bread { BreadId = 3, Breadtype = "Bagel", Price = 2.00 },
                new Bread { BreadId = 4, Breadtype = "Sourdough", Price = 3.60 },
                new Bread { BreadId = 5, Breadtype = "Rye", Price = 3.00 },
                new Bread { BreadId = 6, Breadtype = "Pita", Price = 2.50 },
                new Bread { BreadId = 7, Breadtype = "Multigrain", Price = 2.50 },
                new Bread { BreadId = 8, Breadtype = "Focaccia", Price = 3.12 },
                new Bread { BreadId = 9, Breadtype = "White", Price = 2.50 },
                new Bread { BreadId = 10, Breadtype = "Wheat", Price = 2.50 },
                new Bread { BreadId = 11, Breadtype = "English Muffin", Price = 1.5 },
                new Bread { BreadId = 12, Breadtype = "Matzo", Price = 2.00 },
                new Bread { BreadId = 13, Breadtype = "Tortilla", Price = 2.50 },
                new Bread { BreadId = 14, Breadtype = "Banana", Price = 4.50 },
                new Bread { BreadId = 15, Breadtype = "BreadStick", Price = .75 },
                new Bread { BreadId = 16, Breadtype = "Corn Bread", Price = 2.00 },
                new Bread { BreadId = 17, Breadtype = "Pumpernickel", Price = 3.50 });

            modelBuilder.Entity<Bakery>().HasData(
                new Bakery { BakeryId = 1, BakeryName = "Ben's Bakery,", City = "Pasadena", State = "CA" },
                new Bakery { BakeryId = 2, BakeryName = "Suzies", City = "Pheonix", State = "AZ" },
                new Bakery { BakeryId = 3, BakeryName = "SD Breads & More", City = "El Paso", State = "TX" },
                new Bakery { BakeryId = 4, BakeryName = "Pita Palace", City = "Chicago", State = "IL" },
                new Bakery { BakeryId = 5, BakeryName = "Wheat Workers", City = "Seattle", State = "WA" },
                new Bakery { BakeryId = 6, BakeryName = "Bread Store", City = "Portland", State = "OR" },
                new Bakery { BakeryId = 7, BakeryName = "Chomps", City = "New York", State = "NY" },
                new Bakery { BakeryId = 8, BakeryName = "Matzo & More", City = "Boston", State = "MA" },
                new Bakery { BakeryId = 9, BakeryName = "Desert Farms", City = "Columbia", State = "SC" }
            );
            modelBuilder.Entity<BakeryInventory>().HasData(
                new BakeryInventory {Id = 1,StoreId = 1,ProductId = 1, Stock = 3},
                new BakeryInventory {Id = 2,StoreId = 1, ProductId = 2, Stock = 1 },
                new BakeryInventory {Id = 3,StoreId = 1, ProductId = 3, Stock = 2 },
                new BakeryInventory {Id = 4,StoreId = 1, ProductId = 4, Stock = 4 },
                new BakeryInventory {Id = 5,StoreId = 1, ProductId = 5, Stock = 5 },
                new BakeryInventory {Id = 6,StoreId = 1, ProductId = 6, Stock = 1 },
                new BakeryInventory {Id = 7,StoreId = 1, ProductId = 7, Stock = 1 },
                new BakeryInventory {Id = 8,StoreId = 1, ProductId = 8, Stock = 6 },
                new BakeryInventory {Id = 9,StoreId = 1, ProductId = 9, Stock = 4 },
                new BakeryInventory {Id = 10,StoreId = 1, ProductId = 10, Stock = 8 },
                new BakeryInventory {Id = 11,StoreId = 1, ProductId = 15, Stock = 2 }
                );

        }
    }
}