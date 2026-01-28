//UserFunctions.cs
//using ConsoleApp1.data;
using consoleuser;
using Consolevideo;
using System;
using System.Collections.Generic;
using System.Text;
internal class Userfunctions : Requestoperation
{
    public void userfunctions(int id2, Users ott, video ott1)
    {
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("1.SHOW ALL VIDEO AS LIST \n2.SELECT THE VIDEO BY VIDEO ID \n3.RAISE REQUEST FOR SUBSCRIPTION \n4.LOGOUT");
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
                    //Console.WriteLine("PENDING");
                    ott.addrequest(id2);
                    break;
                default:
                    Console.WriteLine("---LOGOUT---");
                    loop = false;
                    break;
            }
        }
    }
}

