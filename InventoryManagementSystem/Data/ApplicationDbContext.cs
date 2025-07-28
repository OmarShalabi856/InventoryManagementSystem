using Microsoft.EntityFrameworkCore;
using System;

namespace InventoryManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>().HasData(
               new Item { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Laptop", Description = "15-inch laptop", Quantity = 10, Price = 1200.00m, Category = "Electronics", Status = InventoryStatus.InStock },
            new Item { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Mouse", Description = "Wireless mouse", Quantity = 25, Price = 25.99m, Category = "Electronics", Status = InventoryStatus.InStock },
            new Item { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Keyboard", Description = "Mechanical keyboard", Quantity = 15, Price = 75.50m, Category = "Electronics", Status = InventoryStatus.InStock },
            new Item { Id = Guid.Parse("44444444-4444-4444-4444-444444444444"), Name = "Monitor", Description = "24-inch monitor", Quantity = 8, Price = 150.00m, Category = "Electronics", Status = InventoryStatus.LowStock },
            new Item { Id = Guid.Parse("55555555-5555-5555-5555-555555555555"), Name = "Desk Chair", Description = "Ergonomic chair", Quantity = 5, Price = 200.00m, Category = "Furniture", Status = InventoryStatus.LowStock },
            new Item { Id = Guid.Parse("66666666-6666-6666-6666-666666666666"), Name = "USB Cable", Description = "Type-C USB cable", Quantity = 50, Price = 9.99m, Category = "Accessories", Status = InventoryStatus.InStock },
            new Item { Id = Guid.Parse("77777777-7777-7777-7777-777777777777"), Name = "Notebook", Description = "A5 ruled notebook", Quantity = 100, Price = 3.50m, Category = "Stationery", Status = InventoryStatus.InStock },
            new Item { Id = Guid.Parse("88888888-8888-8888-8888-888888888888"), Name = "Pen", Description = "Blue ink pen", Quantity = 200, Price = 1.00m, Category = "Stationery", Status = InventoryStatus.InStock },
            new Item { Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), Name = "Desk Lamp", Description = "LED desk lamp", Quantity = 7, Price = 45.00m, Category = "Furniture", Status = InventoryStatus.InStock },
            new Item { Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), Name = "External HDD", Description = "1TB external hard drive", Quantity = 12, Price = 80.00m, Category = "Electronics", Status = InventoryStatus.InStock }
        );
        }
    }
}
