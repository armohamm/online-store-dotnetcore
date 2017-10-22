using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using project.Entities;

public class CategoryRespository : ICategory
{
    private readonly string connectionString;

    public CategoryRespository()
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

    public int Add(Category category)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "INSERT into Category(name, categoryType) values (@name, @categoryType);"
                            + " SELECT CAST(SCOPE_IDENTITY() AS INT) ";
            dbConnection.Open();
            return dbConnection.Query<int>(sQuery, category).Single();
        }
    }

    public void Delete(int Id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "DELETE FROM Category where id = @id;";
            dbConnection.Open();
            dbConnection.Execute(sQuery, new { id = Id });
        }
    }

    public IEnumerable<Category> GetAll()
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "SELECT * FROM Category";
            dbConnection.Open();
            return dbConnection.Query<Category>(sQuery);
        }
    }

    public Category GetById(int Id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "SELECT * FROM Category where id =@id;";
            dbConnection.Open();
            return dbConnection.Query<Category>(sQuery, new { id = Id }).Single();
        }
    }

    public void Update(Category category)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "Update Category set name=@name, categoryType=@categoryType where id=@id;";
            dbConnection.Open();
            dbConnection.Query<Category>(sQuery, category);
        }
    }
}