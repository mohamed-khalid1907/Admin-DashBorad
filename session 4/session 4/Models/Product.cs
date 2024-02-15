using session_4.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    public bool EnableSize { get; set; }

    [Required]
    public int CompId { get; set; }

    [ForeignKey("CompId")] // Corrected ForeignKey attribute
    public Company company { get; set; }
}