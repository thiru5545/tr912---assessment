using System;
using System.Collections.Generic;
//this class is declared for data object it will not include any operations
class Userinfo
{
    private int Id;                     //encapsulation binding both the data and the method but avoiding the direct access of the data by declareing it as private
    private string Username;            //made all the data as private access control
    private string Password;
    private string Email;
    private string Subscription;

    public Userinfo(int Id,string Username,string Password,string Email,string Subscription) //used parameterized constructor to initialize the object
    {
        this.Id = Id;
        this.Username = Username;
        this.Password = Password;
        this.Email = Email;
        this.Subscription = Subscription;
    }
    public int id               //public variable to access the private variable 
    {
        get {  return Id; }
        set { Id = value; }
    }
    public string name          //same as all private variable declaration
    {
        get { return Username; }
        set { Username = value; }
    }
    public string password
    {
        get { return Password; }
        set { Password = value; }
    }
    public string email
    {
        get { return Email; }
        set { Email = value; }
    }
    public string subscription {
        get { return Subscription; }
        set { Subscription = value; }
    }
    public override string ToString()   //override method to make priting process easyer
    {
        return $"USER ID : {Id} \tUSERNAME : {name} \tEMAIL : {email} \t SUBSCRIPTION : {subscription}";
    }
}