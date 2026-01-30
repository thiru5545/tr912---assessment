//UserServices.cs
using System;
using System.Collections.Generic;
using System.Text;
//using ConsoleApp1.data;
//this class is used to create a user database and do operation with the datas

    internal class UserServices : AdminMenu,IUserServices// video class is inherited to the User class basically it is a single inheritance 
    {
        Dictionary<int, Userinfo> userinfos = new Dictionary<int, Userinfo>(); //this is the data base here dictionary is used so that data can be accessed easylly 
        int id = 2;                                                                     //dictionary with user id and userinfo data object

        public void adduser(int id, string name, string password, string email, Subscription sub, Role role) // this method is used to add user to the database
        {
            userinfos.Add(id, new Userinfo(id, name, password, email, sub, role));  //here creating and initialize(useing parameterized constructor) the userinfo dataobject and adding to the database
        }

        public void removeuser(int id) //method to remove user by id (method with parameter)
        {
            userinfos.Remove(id); //removed from the dictonary using remove buildin function
            Console.WriteLine("ID REMOVED SUCCESSFULLY");
        }

        public void viewall()
        {
            foreach (var item in userinfos.Values)
            {
                Console.WriteLine(item.ToString());
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

        public void updateuserstatus(int userid)
        {
            userinfos[userid].sub = Subscription.Premium;
        }

        public Userinfo getuserbyid(int id) // method to find the data object by and id and return them
        {
            return userinfos[id];
        }

        //public void CreateUser()
        //{
        //    Console.WriteLine("you choosed to add new user");

        //    Console.WriteLine("ENTER THE USER NAME");
        //    string name = Console.ReadLine();
        //    bool passcheck = true;
        //    string password;
        //    do
        //    {
        //        Console.WriteLine("ENTER THE PASSWORD");
        //        Console.WriteLine("THE PASSWORD SHOULD BE OF ATLEAST 8 CHARACTER OF COMBINATION UPPERCASE,LOWERCASE,DIGITS,SPECIALCHARACTER");
        //        password = Console.ReadLine();
        //        //if (Regex.IsMatch(password,@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,}$"))
        //        if (password.Length >= 8 && password.Any(char.IsLower) && password.Any(char.IsUpper) && !password.All(char.IsLetterOrDigit) && password.Any(char.IsDigit))
        //        {
        //            passcheck = false;
        //        }
        //        else
        //        {
        //            Console.WriteLine("RE-ENTER THE PASSWORD");
        //        }
        //    } while (passcheck);
        //    Console.WriteLine("ENTER THE EMAIL");
        //    string email = Console.ReadLine();
        //    adduser(++id, name, password, email, Subscription.Basic, Role.User);//method call with parameter 
        //    Console.WriteLine($"---USER ID : {id}---");
        //    Console.WriteLine("---USER ADDED---");
        //}


        public void UserLogin(UserServices ott, VideoServices ott1,RequestServices req)
        {
            Console.WriteLine("you choosed to login");
            bool log = false;
            int id2;
            string password2;
            do
            {
                Console.WriteLine("ENTER THE ID");
                if (!int.TryParse(Console.ReadLine(), out id2))
                {
                    Console.WriteLine("--- ENTER THE CORRECT VALUE (STRICTLY ONLY INTEGER) ---");
                    continue;
                }
                Console.WriteLine("ENTER THE PASSWORD");
                password2 = Console.ReadLine();
                log = login(id2, password2);
            } while (!log);

            Console.WriteLine("---User logedin---");
            Console.WriteLine(getuserbyid(id2).ToString());
            Userinfo user = getuserbyid(id2);
            while (log)
            {
                if (user.rolee == Role.Admin)
                {
                    //admin call
                    adminmenu(id2, ott, ott1,req);

                }
                else
                {
                    //user call
                    usermenu(id2, ott, ott1,req);
                }
                log = false;
            }
        }


    }
