using System.Collections.Generic;
using project.Entities;

public interface IOrderProduct
{

    int Add(OrderProduct prod);
    void Update(OrderProduct prod);
    void Delete(int id);
    OrderProduct GetById(int id);
    IEnumerable<OrderProduct> GetAll();
}