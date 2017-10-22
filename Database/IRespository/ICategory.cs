using System.Collections.Generic;
using project.Entities;

public interface ICategory{
    int Add(Category prod);
    void Update(Category prod);
    void Delete(int id);
    Category  GetById(int id);
    IEnumerable<Category> GetAll();

}