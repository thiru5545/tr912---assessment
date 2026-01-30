//AdminMenu.cs
//using ConsoleApp1.role_function;
//using consoleuser;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class AdminMenu : UserMenu,IAdminMenu //Admin can perform the user functions too so the userfuncton is inherited to admin function  
{
    //Ott ott =new Ott();
    //video ott1 = new video();
    public void adminmenu(int id2,UserServices ott,VideoServices ott1,RequestServices req)
    {
        bool loop = true;
        int videoid=128;        // this is used as a auto increament for video id
        while (loop) {
            Console.WriteLine("1.SHOW ALL VIDEO AS LIST \n2.SELECT THE VIDEO BY VIDEO ID \n3.VIEW ALL USERS \n4.REMOVE USER \n5.ADD VIDEO \n6.REMOVE VIDEO BY ID \n7.DELETE COMMENT \n8.VIEW REQUEST \n9.ACTION ON REQUEST BY ID \n10.LOGOUT");
            int options;
            typecheck(out  options);

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
                    int id4;
                    typecheck(out id4);
                    ott.removeuser(id4);
                    break;
                case 5:
                    ott1.Addvideo(out videoid, videoid,ott1);
                    break;
                case 6:
                    int videoid1;
                    typecheck(out videoid1);
                    ott1.removevideo(videoid,ott1);
                    break;
                case 7:
                    Console.WriteLine("Enter the video id:");
                    int vid;
                    typecheck(out vid);
                    ott1.DeleteComments(vid,ott1);
                    break;
                case 8:
                    Console.WriteLine("show all request as list");
                    req.viewrequest(req);
                    break;
                case 9:req.ActionOnRequest(ott,req);break;
                default:
                    Console.WriteLine("---LOGING OUT---");
                    loop = false;
                    break;
            }
        }

    }
    
}

