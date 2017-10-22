using project.Entities;

public interface IEmployeeServices{
    string createToken(Employee obj);
    bool comparePassword(string password, string hash);
    Token parseToken(string token);
    string hashPassword(string password);
    string login(Login login);
    Employee getUserInfoByToken(string token);
    void changePassword(NewPassword pass);
}