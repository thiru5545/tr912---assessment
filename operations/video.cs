//video.cs
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace Consolevideo
{
    internal class video
    {
        Dictionary<int, videoinfos> videoData = new Dictionary<int, videoinfos>();
        public video()  //Default constructor which will create a video database
        {
            videoData.Add(123, new videoinfos(123, "C# Language Fundamentals & OOPS Basics", "https://www.youtube.com/watch?v=gfkTfcpWqAY", "B"));
            videoData.Add(124, new videoinfos(124, "Core C# Language Features & Collections & LINQ (Fundamentals)", "https://www.youtube.com/watch?v=hss23NMqW0k", "B"));
            videoData.Add(125, new videoinfos(125, "C# Language Fundamentals & OOPS Basics", "https://www.youtube.com/watch?v=gfkTfcpWqAY", "B"));
            videoData.Add(126, new videoinfos(126, "C# Language Fundamentals & OOPS Basics", "https://www.youtube.com/watch?v=gfkTfcpWqAY", "P"));
            videoData.Add(127, new videoinfos(127, "C# Language Fundamentals & OOPS Basics", "https://www.youtube.com/watch?v=gfkTfcpWqAY", "P"));
        }

        public void addvideo(int id, string name, string url, string sub)   //admin should be able to add the video this method will handle it
        {
            videoData.Add(id, new videoinfos(id, name, url, sub));
        }

        //public void removevideo(int id)     //admin should be able to remove the video
        //{
        //    videoData.Remove(id);
        //}
        public void removevideo(int id) { videoData.Remove(id); }

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
                                                                                                      //{
                                                                                                      //    return videoData[id];
                                                                                                      //}


        public void showcomments(int id)        //show all commets by video id
        {
            Console.WriteLine("---Comments for the video ID : " + id + "---");
            if (videoData[id].Comments != null) { Console.WriteLine("---NO COMMENTS FOUND---"); }
            foreach (int idofcommets in videoData[id].Comments.Keys)
            {
                foreach (string comments_wid in videoData[id].Comments[idofcommets])
                    Console.WriteLine(idofcommets + " - " + comments_wid);
            }
        }

        public void deletecomment(int id) { 
            showcomments(id);
            Console.WriteLine("Enter the user id:");
            int uid=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(string.Join("\n",videoData[id].Comments[uid].Select((text,index)=>$"{index+1}.{text}")));
            Console.WriteLine("Enter the comment number to be delete:");
            int cnum=Convert.ToInt32(Console.ReadLine());
            videoData[id].Comments[uid].RemoveAt(cnum-1);
            Console.WriteLine(string.Join("\n", videoData[id].Comments[uid]));

        }
    }
}