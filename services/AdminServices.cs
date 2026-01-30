//AdminServices.cs
//using consoleuser;
using System;
using System.Collections.Generic;
using System.Text;



    internal class AdminServices : IAdminServices
    {
    int id = 2;
        public void ActionOnRequest(UserServices ott,RequestServices req)
        {
            Console.WriteLine("ENTER THE REQUEST ID:");
            int reqid;
            ott.typecheck(out reqid);
            Console.WriteLine("1.APPROVE \n2.REJECT");
            int option;
            ott.typecheck(out option);
            if (option == 1)
            {
                req.updatestatus(reqid, RequestType.Approved);
                Request re = req.GetRequest(reqid);
                if (re == null) { Console.WriteLine("---REQUEST NOT FOUND---"); }
                else
                {
                    ott.updateuserstatus(re.Userid);
                }
            }
            else
            {
                req.updatestatus(reqid, RequestType.Rejected);
            }
        }
    public void DeleteComments(int id, VideoServices ott1)
    {
        if (ott1.showcomments(id))
        {
            Console.WriteLine("Enter the user id:");
            int uid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(string.Join("\n", ott1.videoData[id].Comments[uid].Select((text, index) => $"{index + 1}.{text}")));
            Console.WriteLine("Enter the comment number to be delete:");
            int cnum = Convert.ToInt32(Console.ReadLine());
            ott1.videoData[id].Comments[uid].RemoveAt(cnum - 1);//remove by index
            Console.WriteLine("---COMMENT DELETED SUCCESSFULLY---");
            if (ott1.videoData[id].Comments[uid].Count == 0)
            {
                ott1.videoData[id].Comments.Remove(uid);
                Console.WriteLine("---COMMENT DELETED SUCCESSFULLY---");
            }
            //Console.WriteLine(string.Join("\n", videoData[id]));
        }
    }

    public void Addvideo(out int tid, int id,VideoServices ott1)
    {
        tid = id + 1;
        Console.WriteLine("ENTER THE VIDEO NAME:");
        string videotitle = Console.ReadLine();
        Console.WriteLine("ENTER THE VIDEO URL:");
        string videourl = Console.ReadLine();
        Console.WriteLine("ENTER THE VIDEO SUBSCRIPTION: pb - premium");
        string videosubscription = Console.ReadLine();
        Subscription sub1 = Subscription.Basic;
        if (videosubscription.ToLower().Equals("pb"))
        {
            sub1 = Subscription.Premium;
        }
        ott1.addvideo(tid, videotitle, videourl, sub1);
    }
    public void CreateUser(UserServices ott)
    {
        Console.WriteLine("you choosed to add new user");

        Console.WriteLine("ENTER THE USER NAME");
        string name = Console.ReadLine();
        bool passcheck = true;
        string password;
        do
        {
            Console.WriteLine("ENTER THE PASSWORD");
            Console.WriteLine("THE PASSWORD SHOULD BE OF ATLEAST 8 CHARACTER OF COMBINATION UPPERCASE,LOWERCASE,DIGITS,SPECIALCHARACTER");
            password = Console.ReadLine();
            //if (Regex.IsMatch(password,@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,}$"))
            if (password.Length >= 8 && password.Any(char.IsLower) && password.Any(char.IsUpper) && !password.All(char.IsLetterOrDigit) && password.Any(char.IsDigit))
            {
                passcheck = false;
            }
            else
            {
                Console.WriteLine("RE-ENTER THE PASSWORD");
            }
        } while (passcheck);
        Console.WriteLine("ENTER THE EMAIL");
        string email = Console.ReadLine();
        ott.adduser(++id, name, password, email, Subscription.Basic, Role.User);//method call with parameter 
        Console.WriteLine($"---USER ID : {id}---");
        Console.WriteLine("---USER ADDED---");
    }


    public void removevideo(int id,VideoServices ott1) { ott1.videoData.Remove(id); }



    public void viewrequest(RequestServices req)
    {
        if (req.requests.Count == 0) { Console.WriteLine("---NO REQUEST FOUND---"); }
        else
        {
            foreach (int vidid in req.requests.Keys)
            {
                Console.WriteLine(req.requests[vidid].ToString());
            }
        }
    }
}
    

