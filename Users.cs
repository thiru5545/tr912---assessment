using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Users
    {
        Dictionary<int,Userinfo> userinfos = new Dictionary<int,Userinfo>();

        public void adduser(int id, string name, string password, string email,string sub)
        {
            userinfos.Add(id,new Userinfo(id, name, password,email,sub));   
        }

        public void removeuser(int id)
        {
            userinfos.Remove(id);
            Console.WriteLine("ID REMOVED SUCCESSFULLY");
        }

        public void viewall()
        {
            Console.WriteLine(userinfos.Count);
            foreach (int user in userinfos.Keys)
            {
                Console.WriteLine(userinfos[user].ToString());
            }
        }

        public bool login(int id, string password)
        {
            bool t = userinfos.ContainsKey(id);
            if (t)
            {
                if (userinfos[id].password.Equals(password))
                {
                    Console.WriteLine("USER LOGINED");
                    return true;
                }
            }
            return false;
        }

        public void getuserbyid(int id)
        {
            //return userinfos[id];
            Console.WriteLine(userinfos[id].ToString());
        }


    }
}
