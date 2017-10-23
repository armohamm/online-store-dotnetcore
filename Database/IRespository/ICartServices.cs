using System.Collections.Generic;

public interface ICartServices{
    int addOrder(Cart order);
    void updateOrder();
    void deleteOrder(int orderId);
    Cart getOrder(int orderId);
    IEnumerable<Cart> getAllOrder();
}