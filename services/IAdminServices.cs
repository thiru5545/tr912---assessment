using System;

internal interface IAdminServices
{
    // Request actions
    void ActionOnRequest(UserServices ott, RequestServices req);

    // Comment management
    void DeleteComments(int id, VideoServices ott1);

    // Video management
    void Addvideo(out int tid, int id, VideoServices ott1);
    void removevideo(int id, VideoServices ott1);

    // User management
    //void CreateUser(UserServices ott);

    // Request viewing
    void viewrequest(RequestServices req);
}
