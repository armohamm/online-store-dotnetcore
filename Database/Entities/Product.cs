using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string Name { get; set; }
    [MaxLength(10)]
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double netPrice { get; set; }
    public string expiryDate { get; set; }
    public string code { get; set; }
    public string providerId { get; set; }
    public string categoryId {get;set;}
}