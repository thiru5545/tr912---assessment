internal interface IUserInfo
{
    int id { get; }
    string name { get; }
    string password { get; }
    string email { get; }
    Subscription sub { get; set; }
    Role rolee { get; }
}
