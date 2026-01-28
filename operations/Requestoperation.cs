using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

    internal class Requestoperation
    {
        Dictionary<int,Request> requests=new Dictionary<int,Request>();
        int requestid = 0;

    //public Requestoperation()
    //{
    //    raiseRequest(1, 1, "thiru");
    //}
    public void raiseRequest(int userid, int requestId, string message) { 
        requests.Add(requestId,new Request(userid,requestId,message,RequestType.Pending));
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
        Console.WriteLine("Enter the message:");
        string message=Console.ReadLine();
        raiseRequest(userid, ++requestid, message);
    }

    public void updatestatus(int requestID,RequestType req)
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
    }

