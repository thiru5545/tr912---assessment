//Ottplatform.cs
//using ConsoleApp1;
using System;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Text.RegularExpressions;

    class Ott : Adminfunctions //multilevel inheritance
    {
        static void Main()
        {

            Ott ott = new Ott();
            video ott1=new video();
            ott.adduser(1, "thiru", "12345678@", "t@t", "PB",Role.Admin);
            ott.adduser(2, "safeek", "12345678@", "s@s", "B",Role.User);
            while (true)// while loop --> infinite loop
            {
                Console.WriteLine("1.NEW USER \n2.LOGIN NOW \n3.EXIT");

                int choice = int.Parse(Console.ReadLine()); // type casting we can use convert.ToInt32()
                switch (choice) //switch case which is a type of conditional statement
                {
                    case 1:
                        Console.WriteLine("you choosed to add new user");
                        Console.WriteLine("ENTER THE ID");
                        int id=Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ENTER THE USER NAME");
                        string name=Console.ReadLine();
                        bool passcheck = true;
                        string password;
                        do {
                            Console.WriteLine("ENTER THE PASSWORD");
                            password = Console.ReadLine();
                            //if (Regex.IsMatch(password,@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,}$"))
                            if(password.Length>=8 && password.Any(char.IsLower) && password.Any(char.IsUpper) && !password.All(char.IsLetterOrDigit) && password.Any(char.IsDigit))
                            {
                                passcheck = false;
                            }
                            else
                            {
                                Console.WriteLine("RE-ENTER THE PASSWORD");
                            }
                        } while (passcheck);
                        Console.WriteLine("ENTER THE EMAIL");
                        string email=Console.ReadLine();
                        Console.WriteLine("ENTER THE SUBSCRIPTION STATUS");
                        string sub = Console.ReadLine();
                        ott.adduser(id, name, password, email,sub,Role.User);//method call with parameter 
                        Console.WriteLine("---USER ADDED---");
                        break;
                    case 2:
                        Console.WriteLine("you choosed to login");
                    bool log;
                    int id2;
                    string password2;
                    do {
                        Console.WriteLine("ENTER THE ID");
                        id2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ENTER THE PASSWORD");
                        password2 = Console.ReadLine();
                        log = ott.login(id2, password2);
                    }while (!log);
                        Console.WriteLine("---User logedin---");
                        Console.WriteLine(ott.getuserbyid(id2).ToString());
                        Userinfo user = ott.getuserbyid(id2);
                    while (log)
                    {
                        if (user.rolee == Role.Admin)
                            {
                                //admin call
                                ott.adminfunctions(id2,ott,ott1);
                                
                            }
                            else
                            {
                                //user call
                                ott.userfunctions(id2,ott,ott1);
                            }
                        log = false;
                    }
                    break;
                    
                    case 3:
                        Console.WriteLine("THANKS FOR USING OUR OTT PLATFORM !!!");
                        return;
                        
                }
            }
        }
    }
