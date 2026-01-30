//AdminServices.cs
//using consoleuser;
using System;
using System.Collections.Generic;
using System.Text;



    internal class AdminServices
    {
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
    }

