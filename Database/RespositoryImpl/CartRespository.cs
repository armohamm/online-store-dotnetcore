using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

public class CartRespository : ICart
{
    private string connectionString;

    public CartRespository()
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

    public int Add(Cart cart)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "INSERT INTO Cart (customerName, customerPhone, customerAddress, customerEmail, Note, isPayment,delivery, orderDate  )"
                            + " VALUES( @customerName, @customerPhone, @customerAddress, @customerEmail, @Note,@isPayment, @delivery, @orderDate);"
                            + " SELECT CAST(SCOPE_IDENTITY() AS INT) ";
            dbConnection.Open();
            return dbConnection.Query<int>(sQuery, cart).Single();
        }
    }

    public void Delete(int code)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "Delete from Cart where orderCode= @orderCode;";
            dbConnection.Open();
            dbConnection.Execute(sQuery, new { orderCode = code });
        }
    }

    public IEnumerable<Cart> getAll()
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "Select * from Cart";
            dbConnection.Open();
            return dbConnection.Query<Cart>(sQuery);
        }
    }

    public Cart GetByID(int code)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "Select * from Cart where orderCode= @orderCode";
            dbConnection.Open();
            return dbConnection.Query<Cart>(sQuery, new { orderCode = code }).FirstOrDefault();
        }
    }

    public void Update(Cart cart)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "UPDATE Cart SET customerName= @customerName, customerPhone= @customerPhone, " +
                            " customerAddress= @customerAddress, customerEmail= @customerEmail, orderDate= @orderDate " +
                            "Note=@Note, isPayment=@isPayment, delivery=@delivery " +
                            " where orderCode = @orderCode;";
            dbConnection.Open();
            dbConnection.Execute(sQuery, cart);
        }
    }
}