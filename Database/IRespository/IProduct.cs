using System.Threading.Tasks;

public interface IProduct
{
    void Add(Product prod);
    void Delete(int id);
    Task<System.Collections.Generic.IEnumerable<Product>> GetAll();
    void Update(int id);
    Product GetByID(int id);
    
}