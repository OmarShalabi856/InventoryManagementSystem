namespace InventoryManagementSystem.DTOs
{
    using System.ComponentModel.DataAnnotations;

    namespace InventoryManagementSystem.DTOs
    {
        public class AskInventoryDto
        {
            [Required]
            public string Question { get; set; } = null!;
        }

        public class ItemDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = null!;
            public string? Description { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public string? Category { get; set; }
            public InventoryStatus Status { get; set; }

            public static ItemDto FromModel(Item item) => new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Quantity = item.Quantity,
                Price = item.Price,
                Category = item.Category,
                Status = item.Status
            };
        }

        public class CreateItemDto
        {
            [Required, StringLength(100)]
            public string Name { get; set; } = null!;

            [StringLength(500)]
            public string? Description { get; set; }

            [Range(0, int.MaxValue)]
            public int Quantity { get; set; }

            [Range(0, double.MaxValue)]
            public decimal Price { get; set; }

            [StringLength(50)]
            public string? Category { get; set; }

            [Required]
            public InventoryStatus Status { get; set; }

            public Item ToModel()
            {
                return new Item
                {
                    Id = Guid.NewGuid(),
                    Name = Name,
                    Description = Description ?? string.Empty,
                    Quantity = Quantity,
                    Price = Price,
                    Category = Category ?? string.Empty,
                    Status = Status
                };
            }
        }

        public class UpdateItemDto
        {
            [Required]
            public Guid Id { get; set; }

            [Required, StringLength(100)]
            public string Name { get; set; } = null!;

            [StringLength(500)]
            public string? Description { get; set; }

            [Range(0, int.MaxValue)]
            public int Quantity { get; set; }

            [Range(0, double.MaxValue)]
            public decimal Price { get; set; }

            [StringLength(50)]
            public string? Category { get; set; }

            [Required]
            public InventoryStatus Status { get; set; }

            public Item ToModel(Item existingItem)
            {
                existingItem.Name = Name;
                existingItem.Description = Description ?? string.Empty;
                existingItem.Quantity = Quantity;
                existingItem.Price = Price;
                existingItem.Category = Category ?? string.Empty;
                existingItem.Status = Status;
                return existingItem;
            }
        }

        public class UpdateStatusDto
        {
            [Required]
            public InventoryStatus Status { get; set; }
        }
    }

}
