using System.ComponentModel.DataAnnotations;


public class Employee{
    [Key]
    public int id {get;set;}
    public string username {get;set;}
    public string password {get;set;}
    public int role_id {get;set;}
    public int user_type{get;set;}
}