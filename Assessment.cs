using ConsoleApp1;
using System;
namespace ConsoleApp11
{
    class Ott : Users
    {
        static void Main()
        {

            Ott ott = new Ott();
            while (true)
            {
                Console.WriteLine("1.NEW USER \n2.LOGIN NOW \n3.VIEW ALL \n4.EXIT");

                int choice = int.Parse(Console.ReadLine()); // type casting we can use convert.ToInt32()
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("you choosed to add new user");
                        Console.WriteLine("ENTER THE ID");
                        int id=Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ENTER THE USER NAME");
                        string name=Console.ReadLine();
                        Console.WriteLine("ENTER THE PASSWORD");
                        string password=Console.ReadLine();
                        Console.WriteLine("ENTER THE EMAIL");
                        string email=Console.ReadLine();
                        Console.WriteLine("ENTER THE SUBSCRIPTION STATUS");
                        string sub = Console.ReadLine();
                        ott.adduser(id, name, password, email,sub);
                        Console.WriteLine("---USER ADDED---");
                        break;
                    case 2:
                        Console.WriteLine("you choosed to login");
                        Console.WriteLine("ENTER THE ID");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ENTER THE PASSWORD");
                        string password2 = Console.ReadLine();
                        bool log=ott.login(id2, password2);
                        while (log)
                        {
                            ott.getuserbyid(id2);

                        }
                        break;
                    case 3:
                        Console.WriteLine("view users");
                        ott.viewall();
                        break;
                    case 4:
                        Console.WriteLine("remove user");
                        Console.WriteLine("ENTER THE ID");
                        int id4 = Convert.ToInt32(Console.ReadLine());
                        ott.removeuser(id4);
                        break;
                    case 5:
                        Console.WriteLine("THANKS FOR USING OUR OTT PLATFORM !!!");
                        return;
                        
                }
            }
        }
    }
}