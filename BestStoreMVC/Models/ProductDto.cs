using System.ComponentModel.DataAnnotations;

namespace BestStoreMVC.Models;

public class ProductDto
{
    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required, MaxLength(100)]
    public string? Brand { get; set; } = null!;

    [Required, MaxLength(100)]
    public string? Category { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string? Description { get; set; } = null!;

    public IFormFile? ImageFile { get; set; }
}