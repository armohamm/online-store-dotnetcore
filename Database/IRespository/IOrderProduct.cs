using System.Collections.Generic;
using project.Entities;

public interface IOrderProduct
{

    void Add(OrderProduct prod);
    void Update(OrderProduct prod);
    void Delete(int id);
    IEnumerable<detailProductInOrder> GetById(int id);
    IEnumerable<OrderProduct> GetAll();
}