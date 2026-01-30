//VideoServices.cs
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;
//using ConsoleApp1.services;

//using ConsoleApp1.data;


    internal class VideoServices : AdminServices , IVideoServices
    {
        public Dictionary<int, videoinfos> videoData = new Dictionary<int, videoinfos>();
        public VideoServices()  //Default constructor which will create a video database
        {
            videoData.Add(123, new videoinfos(123, "C# Language Fundamentals & OOPS Basics", "https://www.youtube.com/watch?v=gfkTfcpWqAY", Subscription.Basic));
            videoData.Add(124, new videoinfos(124, "Core C# Language Features & Collections & LINQ (Fundamentals)", "https://www.youtube.com/watch?v=hss23NMqW0k", Subscription.Basic));
            videoData.Add(125, new videoinfos(125, "C# Language Fundamentals & OOPS Basics", "https://www.youtube.com/watch?v=gfkTfcpWqAY", Subscription.Premium));
            videoData.Add(126, new videoinfos(126, "C# Language Fundamentals & OOPS Basics", "https://www.youtube.com/watch?v=gfkTfcpWqAY", Subscription.Premium));
            videoData.Add(127, new videoinfos(127, "C# Language Fundamentals & OOPS Basics", "https://www.youtube.com/watch?v=gfkTfcpWqAY", Subscription.Premium));
        }

        public void addvideo(int id, string name, string url, Subscription sub)   //admin should be able to add the video this method will handle it
        {
            videoData.Add(id, new videoinfos(id, name, url, sub));
        }
        public void removevideo(int id) { videoData.Remove(id); }   //admin should be able to remove the video

        public void videolist()             // list of videos 
        {
            if (videoData.Count == 0) { Console.WriteLine("---NO VIDEO FOUND---"); }
            else
            {
                foreach (int vidid in videoData.Keys)
                {
                    Console.WriteLine(videoData[vidid].ToString());
                }
            }
        }

        public videoinfos getvideobyid(int id) => (videoData.ContainsKey(id)) ? videoData[id] : null; //get video by video id if no video found returns null 


        public bool showcomments(int id)        //show all commets by video id
        {
            Console.WriteLine("---Comments for the video ID : " + id + "---");

            if (videoData[id].Comments.Count==0) 
        {
            Console.WriteLine("---NO COMMENTS FOUND---");
            return false;
        }
        //Console.WriteLine(videoData[id].Comments.Count);
            foreach (int idofcommets in videoData[id].Comments.Keys)
            {
                foreach (string comments_wid in videoData[id].Comments[idofcommets])
                    Console.WriteLine(idofcommets + " - " + comments_wid);
            }
            return true;
        }

        public void deletecomment(int id) {
        if (showcomments(id))
        {
            Console.WriteLine("Enter the user id:");
            int uid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(string.Join("\n", videoData[id].Comments[uid].Select((text, index) => $"{index + 1}.{text}")));
            Console.WriteLine("Enter the comment number to be delete:");
            int cnum = Convert.ToInt32(Console.ReadLine());
            videoData[id].Comments[uid].RemoveAt(cnum - 1);//remove by index
            Console.WriteLine("---COMMENT DELETED SUCCESSFULLY---");
            if (videoData[id].Comments[uid].Count == 0)
            {
                videoData[id].Comments.Remove(uid);
                Console.WriteLine("---COMMENT DELETED SUCCESSFULLY---");
            }
            //Console.WriteLine(string.Join("\n", videoData[id]));
        }
        }

        public void selectvideo(int id2,UserServices ott )
        {
            Console.WriteLine("choose the video by number");

            Console.WriteLine("ENTER THE VIDEO ID (only numbers)");
            int vidid;
            ott.typecheck(out vidid);
            videoinfos videoi = getvideobyid(vidid);
            if (videoi == null) { Console.WriteLine("---NO VIDEO FOUND---"); return; }
            Userinfo useri = ott.getuserbyid(id2);
            if ((useri.sub == Subscription.Basic && videoi.sub == Subscription.Basic) || useri.sub == Subscription.Premium)
            {
                Console.WriteLine(videoi.ToString());
                Console.WriteLine("1.COMMENT ON THE VIDEO \n2.SHOW ALL THE COMMENTS\n3.NO NEED TO COMMENT");
                int coment;
                ott.typecheck(out  coment);
                if (coment == 1)
                {
                    Console.WriteLine("Enter the coment:");
                    string comment = Console.ReadLine();
                    videoi.addcomments(id2, comment);
                }
                else if (coment == 2)
                {
                    showcomments(vidid);
                }

            }
            else
            {
                Console.WriteLine("---YOU CAN'T VIEW THIS VIDEO ,TO WATCH THIS VIDEO YOU HAVE TO SUBSCRIBE FOR PRIMEUM");
                Console.WriteLine("---TRY ANOTHER VIDEO---");
            }
        }
        public void Addvideo(out int tid,int id)
        {
            tid=id+1;
            Console.WriteLine("ENTER THE VIDEO NAME:");
            string videotitle = Console.ReadLine();
            Console.WriteLine("ENTER THE VIDEO URL:");
            string videourl = Console.ReadLine();
            Console.WriteLine("ENTER THE VIDEO SUBSCRIPTION:");
            string videosubscription = Console.ReadLine();
            Subscription sub1 = Subscription.Basic;
            if (videosubscription.ToLower().Equals("pb"))
            {
                sub1 = Subscription.Premium;
            }
            addvideo(tid, videotitle, videourl, sub1);
        }
        
    }
