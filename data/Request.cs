using System;
using System.Collections.Generic;
using System.Text;


    internal class Request
    {
        public  int Userid;
        public int Requestid;
        public string Message;
    public RequestType requestType;
        public Request(int Userid,int Requestid,String Message,RequestType requestType)
        { 
            this.Requestid = Requestid;
            this.Userid = Userid;
            this.Message = Message;
        this.requestType=requestType;
        }
    public override string ToString()
    {
        return $"USERID : {Userid} \tREQUESTID : {Requestid} \tMESSAGE : {Message} \tREQUEST STATUS : {requestType}";
    }
}

