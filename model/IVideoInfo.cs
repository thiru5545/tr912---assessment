using System.Collections.Generic;

internal interface IVideoInfo
{
    int videoid { get; set; }
    string videoname { get; set; }
    string videourl { get; set; }
    Subscription sub { get; set; }

    //Dictionary<int, List<string>> Comments { get; }

    void addcomments(int userid, string comment);
}
