using ConsoleApp1;
using System;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Text.RegularExpressions;
namespace ConsoleApp11
{
    class Ott : Users
    {
        static void Main()
        {

            Ott ott = new Ott();
            video ott1=new video();
            ott.adduser(1, "thiru", "12345678@", "t@t", "PB");
            ott.adduser(2, "safeek", "12345678@", "s@s", "B");
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
                        ott.adduser(id, name, password, email,sub);//method call with parameter 
                        Console.WriteLine("---USER ADDED---");
                        break;
                    case 2:
                        Console.WriteLine("you choosed to login");
                        Console.WriteLine("ENTER THE ID");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ENTER THE PASSWORD");
                        string password2 = Console.ReadLine();
                        bool log=ott.login(id2, password2);
                        Console.WriteLine("---User logedin---");
                        ott.getuserbyid(id2).ToString();
                        while (log)
                        {
                            if (id2 == 1)
                            {
                                Console.WriteLine("1.SHOW ALL VIDEO AS LIST \n2.SELECT THE VIDEO BY VIDEO ID \n3.VIEW ALL USERS \n4.REMOVE USER \n5.ADD VIDEO \n6.REMOVE VIDEO BY ID \n7.LOGOUT");
                            }
                            else
                            {
                                Console.WriteLine("1.SHOW ALL VIDEO AS LIST \n2.SELECT THE VIDEO BY VIDEO ID\n10.LOGOUT");
                            }
                            int options = Convert.ToInt32(Console.ReadLine());
                            switch (options)
                            {
                                case 1:
                                    Console.WriteLine("show all video as list");
                                    ott1.videolist();
                                    break;
                                case 2:
                                    Console.WriteLine("choose the video by number");
                                    Console.WriteLine("ENTER THE VIDEO ID");
                                    int vidid=Convert.ToInt32(Console.ReadLine());
                                    videoinfos videoi=ott1.getvideobyid(vidid);
                                    Userinfo useri = ott.getuserbyid(id2);
                                    if ((useri.subscription.ToLower()).Contains(videoi.subscription.ToLower()))
                                    {
                                        Console.WriteLine(videoi.ToString());
                                        Console.WriteLine("1.COMMENT ON THE VIDEO \n2.SHOW ALL THE COMMENTS\n3.NO NEED TO COMMENT");
                                        int coment = Convert.ToInt32(Console.ReadLine());
                                        if (coment == 1)
                                        {
                                            Console.WriteLine("Enter the coment:");
                                            string comment=Console.ReadLine();
                                            videoi.addcomments(id2,comment);
                                        }
                                        else if (coment == 2)
                                        {
                                            ott1.showcomments(vidid);
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("---YOU CAN'T VIEW THIS VIDEO ,TO WATCH THIS VIDEO YOU HAVE TO SUBSCRIBE FOR PRIMEUM");
                                        Console.WriteLine("---TRY ANOTHER VIDEO---");
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
                                    if (id2 == 1)
                                    {
                                        Console.WriteLine("ENTER THE VIDEO ID:");
                                        int videoid = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("ENTER THE VIDEO NAME:");
                                        string videotitle = Console.ReadLine();
                                        Console.WriteLine("ENTER THE VIDEO URL:");
                                        string videourl = Console.ReadLine();
                                        Console.WriteLine("ENTER THE VIDEO SUBSCRIPTION:");
                                        string videosubscription = Console.ReadLine();
                                        ott1.addvideo(videoid, videotitle, videourl, videosubscription);
                                    }
                                    else
                                    {
                                        Console.WriteLine("---YOU HAVE ENTERED THE WROND ONE---");
                                    }
                                    break;
                                case 6:
                                    if (id2 == 1)
                                    {
                                        int videoid = Convert.ToInt32(Console.ReadLine());
                                        ott1.removevideo(videoid);
                                    }
                                    else
                                    {
                                        Console.WriteLine("---YOU HAVE ENTERED THE WRONG ONE---");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("---LOGING OUT---");
                                    log = false;
                                    break;
                            }
                        }
                        break;
                    
                    case 3:
                        Console.WriteLine("THANKS FOR USING OUR OTT PLATFORM !!!");
                        return;
                        
                }
            }
        }
    }
}