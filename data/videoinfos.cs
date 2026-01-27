//videoinfos.cs

using System;
using System.Collections.Generic;
using System.Text;


internal class videoinfos       //video data object 
{
    private int Videoid;
    private string Videoname;
    private string Videourl;
    private string Subscription;
    public Dictionary<int, List<String>> Comments;

    public videoinfos(int Videoid,string Videoname,string Videourl,string Subscription){
        this.Videoid=Videoid;
        this.Videoname=Videoname;
        this.Videourl=Videourl;
        this.Subscription = Subscription;
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
    public string subscription
    {
        get{
        return Subscription;
        }
        set
        {
            Subscription = value;
        }    
    }
    //public Dictionary<int,string> comments
    //{
    //    get { return Comments};
    //}

    public void addcomments(int userid, string comment)
    {
        if (!Comments.ContainsKey(userid))
        {
            Comments.Add(userid, new List<string>());
        }
        Comments[userid].Add(comment);
    }


    //public Dictionary<int,String> comments
    //{
    //    get
    //    {
    //        return Comments;
    //    }
    //}


    public override string ToString()
    {
        return $"VIDEO ID : {videoid} \tVIDEO TITLE : {videoname} \tVIDEO URL : {videourl}";
    }
}

