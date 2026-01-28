//Users.cs
using System;
using System.Collections.Generic;
using System.Text;
//using ConsoleApp1.data;
//this class is used to create a user database and do operation with the datas
namespace consoleuser
{
    internal class Users : Adminfunctions // video class is inherited to the User class basically it is a single inheritance 
    {
        Dictionary<int, Userinfo> userinfos = new Dictionary<int, Userinfo>(); //this is the data base here dictionary is used so that data can be accessed easylly 
                                                                               //dictionary with user id and userinfo data object
        
        public void adduser(int id, string name, string password, string email, Subscription sub, Role role) // this method is used to add user to the database
        {
            userinfos.Add(id, new Userinfo(id, name, password, email, sub, role));  //here creating and initialize(useing parameterized constructor) the userinfo dataobject and adding to the database
        }

        public void removeuser(int id) //method to remove user by id (method with parameter)
        {
            userinfos.Remove(id); //removed from the dictonary using remove buildin function
            Console.WriteLine("ID REMOVED SUCCESSFULLY");
        }

        public void viewall()//to view all the users (simpple method)
        {
            Console.WriteLine(userinfos.Count); // counts the number of users
            foreach (int user in userinfos.Keys)// foreach loop to iterate one by one over the keys of the database that is user id
            {
                Console.WriteLine(userinfos[user].ToString()); // using the key we got the data object and here we used the ToString() override method to print hte datas
            }
        }

        public bool login(int id, string password)  // user can login method
        {
            bool t = userinfos.ContainsKey(id);     // first checks the id is present in the database or not
            if (t)
            {
                if (userinfos[id].password.Equals(password)) // check the password entered and the password in the database is same
                {
                    Console.WriteLine("USER LOGINED");
                    return true;
                }
                else
                {
                    Console.WriteLine("---ENTERED THE WRONG PASSWORD---");
                }
            }
            else
            {
                Console.WriteLine("---ENTER THE CORRECT ID---");
            }
            return false;
        }

        public Userinfo getuserbyid(int id) // method to find the data object by and id and return them
        {
            return userinfos[id];
            //Console.WriteLine(userinfos[id].ToString());
        }


    }

}