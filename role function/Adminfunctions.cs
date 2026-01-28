//Adminfunctions.cs
using System;
using System.Collections.Generic;
using System.Text;
using Consolevideo;
using consoleuser;
using ConsoleApp1.role_function;


internal class Adminfunctions : Userfunctions,IAdminfunctions //Admin can perform the user functions too so the userfuncton is inherited to admin function  
{
    //Ott ott =new Ott();
    //video ott1 = new video();
    public void adminfunctions(int id2,Users ott,video ott1)
    {
        bool loop = true;
        int videoid=128;        // this is used as a auto increament for video id
        while (loop) {
            Console.WriteLine("1.SHOW ALL VIDEO AS LIST \n2.SELECT THE VIDEO BY VIDEO ID \n3.VIEW ALL USERS \n4.REMOVE USER \n5.ADD VIDEO \n6.REMOVE VIDEO BY ID \n7.DELETE COMMENT \n8.LOGOUT");
            int options = Convert.ToInt32(Console.ReadLine());
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
                    //if (ott.getuserbyid(id2).rolee == Role.Admin)
                        ott1.Addvideo(out videoid, videoid);
                    break;
                case 6:
                    //if (ott.getuserbyid(id2).rolee == Role.Admin)
                        int videoid1 = Convert.ToInt32(Console.ReadLine());
                        ott1.removevideo(videoid);
                    break;
                case 7:
                    Console.WriteLine("Enter the video id:");
                    int vid = Convert.ToInt32(Console.ReadLine());
                    ott1.deletecomment(vid);
                    break;
                default:
                    Console.WriteLine("---LOGING OUT---");
                    loop = false;
                    break;
            }
        }

    }
}

