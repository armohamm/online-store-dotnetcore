using System.ComponentModel.DataAnnotations;


public class Cart
{
    [Key]
    public int orderCode { get; set; }
    public int productId { get; set; }
    public string productCode { get; set; }
    public double price { get; set; }
    public double netPrice { get; set; }
    public string orderDate { get; set; }
}