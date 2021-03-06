using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

public class Cart
{
    [Key]
    public int orderCode { get; set; }
    public string customerName { get; set; }
    public string customerPhone { get; set; }
    public string customerAddress { get; set; }
    public string customerEmail { get; set; }
    public string Note { get; set; }
    // 0 not payment , 1 is payment
    public int isPayment { get; set; }
    // 0 not confirm , 1 confirm 
    public int delivery { get; set; }
    [Required]
    public IEnumerable<productInOrder> products { get; set; }
    // format yyyy-mm-dd
    public string orderDate { get; set; }
    public IEnumerable<detailProductInOrder> listProducts {get;set;}
}

public class productInOrder{
    [Required]
    public int productId{set;get;}
    [Required]
    public int number{set;get;}
}

public class detailProductInOrder: project.Entities.OrderProduct
{
    public string Name{get;set;}
    public string  Quantity {get;set;}
}