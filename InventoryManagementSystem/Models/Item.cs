using System;
using System.ComponentModel.DataAnnotations;

public enum InventoryStatus
{
    InStock,
    Ordered,
    Discontinued,
    LowStock
}

public class Item
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string Description { get; set; } = null!;

    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [MaxLength(50)]
    public string Category { get; set; } = null!;

    [Required]
    public InventoryStatus Status { get; set; }
}
