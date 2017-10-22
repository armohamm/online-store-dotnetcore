using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using project.Entities;

public class ProducerRespository : IProducer
{
    private string connectionString;
    public ProducerRespository()
    {
        connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
    }

    public IDbConnection Connection
    {
        get
        {
            return new SqlConnection(connectionString);
        }
    }

    public int Add(Producer prod)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "INSERT INTO Providers(name, address, rating, note) values(@name, @address, @rating, @note); " +
                            "SELECT CAST(SCOPE_IDENTITY() AS INT) ";
            dbConnection.Open();
            return dbConnection.Query<int>(sQuery, prod).Single();
        }
    }

   public void Delete(int Id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "DELETE from Providers where id= @id";
            dbConnection.Open();
            dbConnection.Execute(sQuery, new { id = Id });
        }
    }

    public IEnumerable<Producer> GetAll()
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "SELECT * from Providers";
            dbConnection.Open();
            return dbConnection.Query<Producer>(sQuery);
        }

    }

   public Producer GetById(int Id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "SELET * from Providers where id=@id";
            dbConnection.Open();
            return dbConnection.Query<Producer>(sQuery, new { id = Id }).FirstOrDefault();
        }
    }

  public  void Update(Producer prod)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "UPDATE Providers set name=@name, address=@address, rating =@rating, note=@note " +
                            "where id=@id";
            dbConnection.Open();
            dbConnection.Execute(sQuery, prod);
        }
    }
}