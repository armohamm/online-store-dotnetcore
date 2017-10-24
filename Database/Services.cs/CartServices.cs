
using System.Collections.Generic;

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
            foreach (var product in order.products)
            {
                // get product information 
                var p = productRepository.GetByID(product.productId);
                // insert order
                var newOrderProduct = new Entities.OrderProduct();
                newOrderProduct.netPrice = p.netPrice * product.number;
                newOrderProduct.price = p.Price * product.number;
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
            // delete from Cart table
            cartRespository.Delete(orderId);
            // delete from mapping table
            orderProductRespository.Delete(orderId);
        }

        public IEnumerable<Cart> getAllOrder()
        {
            return cartRespository.getAll();
        }

        public Cart getOrder(int orderId)
        {
            // get order 
            var order = cartRespository.GetByID(orderId);
            order.listProducts = orderProductRespository.GetById(orderId);
            return order;
        }

        public void updateOrder(Cart order)
        {
            // update Cart information
            cartRespository.Update(order);
            // delete mapping record
            orderProductRespository.Delete(order.orderCode);
            // Reinsert mapping
            foreach (var product in order.products)
            {
                // get product information 
                var p = productRepository.GetByID(product.productId);
                // insert order
                var newOrderProduct = new Entities.OrderProduct();
                newOrderProduct.netPrice = p.netPrice * product.number;
                newOrderProduct.price = p.Price * product.number;
                newOrderProduct.number = product.number;
                newOrderProduct.orderCode = order.orderCode;
                newOrderProduct.productId = p.ProductId;
                newOrderProduct.productCode = p.code;
                // insert mapping
                orderProductRespository.Add(newOrderProduct);
            }

        }
    }
}