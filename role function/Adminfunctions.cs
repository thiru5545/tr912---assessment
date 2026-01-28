//Adminfunctions.cs
//using ConsoleApp11;
//using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Text;
using Consolevideo;
using consoleuser;
using ConsoleApp1.role_function;
//using ConsoleApp1.data;

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
                    Console.WriteLine("choose the video by number");

                    Console.WriteLine("ENTER THE VIDEO ID (only numbers)");
                    int vidid = Convert.ToInt32(Console.ReadLine());
                    videoinfos videoi = ott1.getvideobyid(vidid);
                    if (videoi == null) { Console.WriteLine("---NO VIDEO FOUND---"); break; }
                    Userinfo useri = ott.getuserbyid(id2);
                    if ((useri.sub==Subscription.Basic && videoi.sub ==Subscription.Basic) || useri.sub==Subscription.Premium)
                    {
                        Console.WriteLine(videoi.ToString());
                        Console.WriteLine("1.COMMENT ON THE VIDEO \n2.SHOW ALL THE COMMENTS\n3.NO NEED TO COMMENT");
                        int coment = Convert.ToInt32(Console.ReadLine());
                        if (coment == 1)
                        {
                            Console.WriteLine("Enter the coment:");
                            string comment = Console.ReadLine();
                            videoi.addcomments(id2, comment);
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
                    if (ott.getuserbyid(id2).rolee == Role.Admin)
                    {
                        //Console.WriteLine("ENTER THE VIDEO ID:");
                        //int videoid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ENTER THE VIDEO NAME:");
                        string videotitle = Console.ReadLine();
                        Console.WriteLine("ENTER THE VIDEO URL:");
                        string videourl = Console.ReadLine();
                        Console.WriteLine("ENTER THE VIDEO SUBSCRIPTION:");
                        string videosubscription = Console.ReadLine();
                        Subscription sub1=Subscription.Basic;
                        if (videosubscription.ToLower().Equals("pb"))
                        {
                            sub1 = Subscription.Premium;
                        }
                        ott1.addvideo(videoid++, videotitle, videourl, sub1);
                    }
                    else
                    {
                        Console.WriteLine("---YOU HAVE ENTERED THE WROND ONE---");
                    }
                    break;
                case 6:
                    if (ott.getuserbyid(id2).rolee == Role.Admin)
                    {
                        int videoid1 = Convert.ToInt32(Console.ReadLine());
                        ott1.removevideo(videoid);
                    }
                    else
                    {
                        Console.WriteLine("---YOU HAVE ENTERED THE WRONG ONE---");
                    }
                    break;
                case 7:
                    Console.WriteLine("Enter the video id:");
                    int vid = Convert.ToInt32(Console.ReadLine());
                    ott1.deletecomment(vid);
                    break;
                default:
                    Console.WriteLine("---LOGING OUT---");
                    //return false;
                    loop = false;
                    break;
                    //return true;
            }
        }

    }
}

