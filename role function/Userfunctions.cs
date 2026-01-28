//UserFunctions.cs
using System;
using System.Collections.Generic;
using System.Text;
using consoleuser;
using Consolevideo;
internal class Userfunctions
{
    public void userfunctions(int id2, Users ott, video ott1)
    {
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("1.SHOW ALL VIDEO AS LIST \n2.SELECT THE VIDEO BY VIDEO ID \n3.LOGOUT");
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
                    int vidid = Convert.ToInt32(Console.ReadLine());
                    videoinfos videoi = ott1.getvideobyid(vidid);
                    if (videoi == null) {Console.WriteLine("---NO VIDEO FOUND---"); break; } // this line will check for the video id if null breaks and loop continue
                    Userinfo useri = ott.getuserbyid(id2);
                    if ((useri.subscription.ToLower()).Contains(videoi.subscription.ToLower()))
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
                default:
                    Console.WriteLine("---LOGOUT---");
                    loop = false;
                    break;
            }
        }
    }
}

