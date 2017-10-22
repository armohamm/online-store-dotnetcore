namespace project.Entities
{
    public class OrderProduct
    {
        public int orderCode { set; get; }
        public int productId { set; get; }
        public string productCode { set; get; }
        public double netPrice { set; get; }
        public double price { set; get; }
        public int number { set; get; }
    }
}