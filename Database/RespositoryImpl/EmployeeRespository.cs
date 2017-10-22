using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
class EmployeeResposity : IEmployee
{
    private string connectionString;
    public EmployeeResposity()
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

    public int Add(Employee employee)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "INSERT into Employee(username, password, role_id, user_type)" +
                            " values(@username, @password, @role_id, @user_type);" +
                            " SELECT CAST(SCOPE_IDENTITY() AS INT) ";
            dbConnection.Open();
            return dbConnection.Query<int>(sQuery, employee).Single();
        }
    }

    public void Delete(int Id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "DELETE from Employee where id=@id";
            dbConnection.Open();
            dbConnection.Execute(sQuery, new { id = @Id });

        }
    }

    public IEnumerable<Employee> getAll()
    {
        using (IDbConnection dbConnection = Connection)
        {
            dbConnection.Open();
            return dbConnection.Query<Employee>("select * from Employee");
        }
    }

    public Employee GetByID(int id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string sQuery = "select * from Employee where id=@Id";
            dbConnection.Open();
            return dbConnection.Query<Employee>(sQuery, new { Id = id }).FirstOrDefault();
        }
    }

    public Employee GetByUserName(string userName)
    {
       using(IDbConnection dbConnection = Connection){
           string sQuery = "select * from Employee where username=@username";
           dbConnection.Open();
           return dbConnection.Query<Employee>(sQuery, new {username=userName}).FirstOrDefault();
       }
    }

    public void Update(Employee employee)
    {
       using(IDbConnection dbConnection = Connection){
           string sQuery = "UPDATE Employee set username= @username ," +
           "password=@password, role_id= @role_id, user_type= @user_type"+
           " where id=@id";
           dbConnection.Open();
           dbConnection.Execute(sQuery, employee);
       }
    }
}