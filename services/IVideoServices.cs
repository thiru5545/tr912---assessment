using System;

internal interface IVideoServices
{
    // Video management (admin)
    void addvideo(int id, string name, string url, Subscription sub);
    //void removevideo(int id);
    //void Addvideo(out int tid, int id);

    // Video listing & access
    void videolist();
    videoinfos getvideobyid(int id);

    // Video interaction
    void selectvideo(int id2, UserServices ott);

    // Comments
    bool showcomments(int id);
    //void deletecomment(int id);
}
