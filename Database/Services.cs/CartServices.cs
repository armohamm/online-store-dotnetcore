namespace project.Services
{
    public class CartServices : ICartServices
    {
        private readonly CartRespository cartRespository;
        private readonly ProductRepository productRepository;
        private readonly OrderProductRespository orderProductRespository;
        public CartServices()
        {
            cartRespository = new CartRespository();
            productRepository = new ProductRepository();
            orderProductRespository = new OrderProductRespository();
        }
        public int addOrder(Cart order)
        {
            // insert order to database
            var orderCode = cartRespository.Add(order);
            // insert to OrderProduct
            // get list product by ids
           foreach(var product in order.products){
               // get product information 
               var p = productRepository.GetByID(product.productId);
               // insert order
               var newOrderProduct = new Entities.OrderProduct();
               newOrderProduct.netPrice = p.netPrice;
               newOrderProduct.price = p.Price;
               newOrderProduct.number = product.number;
               newOrderProduct.orderCode = orderCode;
               newOrderProduct.productId = p.ProductId;
               newOrderProduct.productCode = p.code;
               // insert mapping
               orderProductRespository.Add(newOrderProduct);
           }
            return orderCode;

        }

        public void deleteOrder(int orderId)
        {
            throw new System.NotImplementedException();
        }

        public void getAllOrder()
        {
            throw new System.NotImplementedException();
        }

        public void getOrder()
        {
            throw new System.NotImplementedException();
        }

        public void updateOrder()
        {
            throw new System.NotImplementedException();
        }
    }
}