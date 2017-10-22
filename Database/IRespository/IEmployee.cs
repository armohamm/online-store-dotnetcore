using System.Collections.Generic;

interface IEmployee {
    int Add(Employee cart);
    void Delete(int id);
    void Update(Employee cart);
    IEnumerable<Employee> getAll();
    Employee GetByID(int id);
    Employee GetByUserName(string username);
    
}