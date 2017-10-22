public interface ICartServices{
    int addOrder(Cart order);
    void updateOrder();
    void deleteOrder(int orderId);
    void getOrder();
    void getAllOrder();
}