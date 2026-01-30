//videoinfos.cs

//using ConsoleApp1.data;
using System;
using System.Collections.Generic;
using System.Text;


internal class videoinfos : IVideoInfo   //video data object 
{
    private int Videoid;
    private string Videoname;
    private string Videourl;
    private Subscription Sub;
    public Dictionary<int, List<String>> Comments;

    public videoinfos(int Videoid,string Videoname,string Videourl,Subscription Sub){
        this.Videoid=Videoid;
        this.Videoname=Videoname;
        this.Videourl=Videourl;
        this.Sub = Sub;
        this.Comments = new Dictionary<int, List<String>>();
        }
    public int videoid
    {
        get
        {
            return Videoid;
        }
        set
        {
            Videoid = value;
        }
    }
    public string videoname
    {
        get
        {
            return Videoname;
        }
        set
        {
            Videoname = value;
        }
    }
    public string videourl
    {
        get
        {
            return Videourl;
        }
        set
        {
            Videourl = value;
        }
    }
    public Subscription sub
    {
        get{
        return Sub;
        }
        set
        {
            Sub = value;
        }    
    }


    public void addcomments(int userid, string comment)
    {
        if (!Comments.ContainsKey(userid))
        {
            Comments.Add(userid, new List<string>());
        }
        Comments[userid].Add(comment);
    }

    public override string ToString()
    {
        return $"VIDEO ID : {videoid} \tVIDEO TITLE : {videoname} \tVIDEO URL : {videourl} \tSUBSCRIPTION : {sub}";
    }
}

