//USerMenu.cs
//using ConsoleApp1.data;
//using consoleuser;
using System;
using System.Collections.Generic;
using System.Text;
internal class UserMenu
{
    public void usermenu(int id2, UserServices ott, VideoServices ott1, RequestServices req)
    {
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("1.SHOW ALL VIDEO AS LIST \n2.SELECT THE VIDEO BY VIDEO ID \n3.RAISE REQUEST FOR SUBSCRIPTION \n4.VIEW REQUEST STATUS \n5.LOGOUT");
            int options;
            typecheck(out options);
            switch (options)
            {
                case 1:
                    Console.WriteLine("show all video as list");
                    ott1.videolist();
                    break;
                case 2:
                    ott1.selectvideo(id2, ott);
                    break;
                case 3:
                    //Console.WriteLine("PENDING");
                    req.addrequest(id2);
                    break;
                case 4:
                    //view request status
                    req.viewrequest(id2);
                    break;
                default:
                    Console.WriteLine("---LOGOUT---");
                    loop = false;
                    break;
            }
        }
    }
    public void typecheck(out int type)
    {
        //int id;
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out type))
            {
                Console.WriteLine("--- ENTER THE CORRECT VALUE (STRICTLY ONLY INTEGER) ---");
                continue;
            }
            break;
        }
    }
}

