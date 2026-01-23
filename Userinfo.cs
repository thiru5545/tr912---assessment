using System;
using System.Collections.Generic;
class Userinfo
{
    private int Id;
    private string Username;
    private string Password;
    private string Email;
    private string Subscription;

    public Userinfo(int Id,string Username,string Password,string Email,string Subscription)
    {
        this.Id = Id;
        this.Username = Username;
        this.Password = Password;
        this.Email = Email;
        this.Subscription = Subscription;
    }
    public int id
    {
        get {  return Id; }
        set { Id = value; }
    }
    public string name
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
    public override string ToString()
    {
        return $"USER ID : {Id} \tUSERNAME : {name} \tEMAIL : {email} \t SUBSCRIPTION : {subscription}";
    }
}