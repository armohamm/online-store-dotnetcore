using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public double netPrice { get; set; }
    public string expiryDate { get; set; }
    public string code { get; set; }
    public int providerId { get; set; }
    public int categoryId {get;set;}
}