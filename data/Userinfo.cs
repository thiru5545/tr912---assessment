//Userinfo.cs
//using ConsoleApp1.data;
using System;
using System.Collections.Generic;
//this class is declared for data object it will not include any operations
//using ConsoleApp1.data;

class Userinfo
{
    private int Id;                     //encapsulation binding both the data and the method but avoiding the direct access of the data by declareing it as private
    private string Username;            //made all the data as private access control
    private string Password;
    private string Email;
    private Subscription Sub;
    private Role role;
    public Userinfo(int Id,string Username,string Password,string Email,Subscription Sub,Role role) //used parameterized constructor to initialize the object
    {
        this.Id = Id;
        this.Username = Username;
        this.Password = Password;
        this.Email = Email;
        this.Sub = Sub;
        this.role=role;
    }
    public int id { get { return Id; } }               //public variable to access the private variable 
    public string name { get { return Username; } }          //same as all private variable declaration
    public string password { get { return Password; } }
    public string email { get { return Email; } }
    public Subscription sub { get { return Sub; } }
    public Role rolee { get { return role; }}
    public override string ToString()   //override method to make priting process easyer
    {
        return $"USER ID : {Id} \tUSERNAME : {name} \tEMAIL : {email} \t SUBSCRIPTION : {sub} \t ROLE : {rolee}";
    }
}