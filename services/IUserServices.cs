using System;

internal interface IUserServices
{
    // User management
    void adduser(int id, string name, string password, string email, Subscription sub, Role role);
    void removeuser(int id);
    void viewall();

    // Authentication
    bool login(int id, string password);
    Userinfo getuserbyid(int id);

    // Subscription
    void updateuserstatus(int userid);

    // User creation & login flow
    //void CreateUser();
    void UserLogin(UserServices ott, VideoServices ott1, RequestServices req);
}
