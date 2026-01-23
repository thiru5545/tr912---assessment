using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;


internal class video
{
    Dictionary<int, videoinfos> videoData = new Dictionary<int, videoinfos>();
    public video()
    {
        videoData.Add(123, new videoinfos(123, "C# Language Fundamentals & OOPS Basics", "https://www.youtube.com/watch?v=gfkTfcpWqAY", "B"));
        videoData.Add(124, new videoinfos(124, "Core C# Language Features & Collections & LINQ (Fundamentals)", "https://www.youtube.com/watch?v=hss23NMqW0k", "B"));
        videoData.Add(125, new videoinfos(125, "C# Language Fundamentals & OOPS Basics", "https://www.youtube.com/watch?v=gfkTfcpWqAY", "B"));
        videoData.Add(126, new videoinfos(126, "C# Language Fundamentals & OOPS Basics", "https://www.youtube.com/watch?v=gfkTfcpWqAY", "P"));
        videoData.Add(127, new videoinfos(127, "C# Language Fundamentals & OOPS Basics", "https://www.youtube.com/watch?v=gfkTfcpWqAY", "P"));
    }

    public void addvideo(int id, string name, string url, string sub)
    {
        videoData.Add(id, new videoinfos(id, name, url, sub));
    }

    public void removevideo(int id)
    {
        videoData.Remove(id);
    }

    public void videolist()
    {
        foreach (int vidid in videoData.Keys)
        {
            Console.WriteLine(videoData[vidid].ToString());
        }
    }

    public videoinfos getvideobyid(int id)
    {
        return videoData[id];
    }


    public void showcomments(int id)
    {
        foreach (int com in videoData[id].Comments.Keys)
        {
            Console.WriteLine(com+" - "+videoData[id].Comments[com]);
        }
    }
}

