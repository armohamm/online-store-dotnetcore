using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using project.Entities;

public class ReportRespository : IReport
{
    private string connectionString;
    public ReportRespository()
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
    public IEnumerable<Report> GetReport(string startDate, string endDate)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "select b.Name as productName, a.* from Products as b inner join " +
                            " (select OrderProduct.productId," +
                            " sum(OrderProduct.netPrice) as totalNetPrice, " +
                            " SUM(OrderProduct.price) as totalPrice, SUM(OrderProduct.number) as totalItem from dbo.Cart " +
                            " inner join OrderProduct on Cart.orderCode = OrderProduct.orderCode" +
                            " where orderDate  between '"+startDate+"' and '"+endDate+"' group by OrderProduct.productId) as a on a.productId = b.ProductID;";
            dbConnection.Open();
            return dbConnection.Query<Report>(sQuery, new { start = startDate, end = endDate });
        }
    }
}