using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using project.Entities;

public class OrderProductRespository : IOrderProduct
{
    private readonly string connectionString;

    public OrderProductRespository()
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

    public void Add(OrderProduct OrderProduct)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "INSERT into OrderProduct(orderCode,productId, productCode, netPrice, price, number) " +
                            "values (@orderCode,@productId, @productCode, @netPrice, @price, @number);";            dbConnection.Open();
             dbConnection.Query<int>(sQuery, OrderProduct);
        }
    }

     public void Delete(int Id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "DELETE FROM OrderProduct where orderCode = @id;";
            dbConnection.Open();
            dbConnection.Execute(sQuery, new { id = Id });
        }
    }

    public IEnumerable<OrderProduct> GetAll()
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "SELECT * FROM OrderProduct";
            dbConnection.Open();
            return dbConnection.Query<OrderProduct>(sQuery);
        }
    }

    public IEnumerable<detailProductInOrder> GetById(int Id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "select o.*, p.Name, p.Quantity from OrderProduct as o inner join Products as p on o.productId = p.ProductID where o.orderCode = @id";
            dbConnection.Open();
            return dbConnection.Query<detailProductInOrder>(sQuery, new { id = Id });
        }
    }

    public void Update(OrderProduct OrderProduct)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "Update OrderProduct set productId=@productId, productCode=@productCode, netPrice=@netPrice, price=@price, number=@number where orderCode=@orderCode;";
            dbConnection.Open();
            dbConnection.Query<OrderProduct>(sQuery, OrderProduct);
        }
    }
}