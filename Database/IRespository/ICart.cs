using System.Collections.Generic;

interface ICart {
    int Add(Cart cart);
    void Delete(int id);
    void Update(Cart cart);
    IEnumerable<Cart> getAll();
    Cart GetByID(int id);
}