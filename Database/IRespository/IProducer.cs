using System.Collections.Generic;
using project.Entities;

public interface IProducer{
    int Add(Producer prod);
    void Update(Producer prod);
    void Delete(int id);
    Producer  GetById(int id);
    IEnumerable<Producer> GetAll();

}