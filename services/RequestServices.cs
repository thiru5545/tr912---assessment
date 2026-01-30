//Requestoperation.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

internal class RequestServices :AdminServices , IRequestServices
{
    Dictionary<int, Request> requests = new Dictionary<int, Request>();
    int requestid = 0;

    //public Requestoperation()
    //{
    //    raiseRequest(1, 1, "thiru");
    //}
    public void raiseRequest(int userid, int requestId, string message)
    {
        requests.Add(requestId, new Request(userid, requestId, message, RequestType.Pending));
    }

    public void viewrequest()
    {
        if (requests.Count == 0) { Console.WriteLine("---NO REQUEST FOUND---"); }
        else
        {
            foreach (int vidid in requests.Keys)
            {
                Console.WriteLine(requests[vidid].ToString());
            }
        }
    }
    public void addrequest(int userid)
    {
        int a = 0;
        foreach (Request i in requests.Values)
        {
            if (i.Userid == userid && i.requestType == RequestType.Pending)
            {
                a = 1;
                Console.WriteLine("---YOUR REQUEST IS PENDING---"); return;
            }
            else if (i.Userid == userid && i.requestType == RequestType.Approved)
            {
                a = 2;
                Console.WriteLine("---YOUR REQUEST IS APPROVED---"); return;
            }
            else
            {
                a = 3;
                Console.WriteLine("---YOUR REQUEST GOT REJECTED---");
                Console.WriteLine("DID YOU WANT TO RAISE NEW REQUEST \n 1.YES \n 2.NO");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    Console.WriteLine("Enter the message:");
                    string message1 = Console.ReadLine();
                    raiseRequest(userid, ++requestid, message1);
                }
                return;
            }
        }

        Console.WriteLine("Enter the message:");
        string message = Console.ReadLine();
        raiseRequest(userid, ++requestid, message);
    }

    public void updatestatus(int requestID, RequestType req)
    {
        if (requests.ContainsKey(requestID))
        {
            requests[requestID].requestType = req;
        }
        else
        {
            Console.WriteLine("---REQUEST ID NOT FOUND---");
        }
    }

    public Request GetRequest(int requestID)
    {
        if (requests.ContainsKey(requestID))
        {
            return requests[requestID];
        }
        return null;
    }

    public void viewrequest(int uid)
    {
        foreach (Request i in requests.Values)
        {
            if (i.Userid == uid)
            {
                Console.WriteLine($"---YOUR REQUEST IS {i.requestType}---");
                return;
            }
        }
        Console.WriteLine("--- YOU DIDNT MADE ANY REQUEST---");
    }
}

