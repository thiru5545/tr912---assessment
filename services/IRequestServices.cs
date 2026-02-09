using System;

internal interface IRequestServices
{
    // Raise / add requests
    void raiseRequest(int userid, int requestId, string message);
    void addrequest(int userid);

    // View requests
    void viewrequest();
    void viewrequest(int uid);

    // Update / fetch request
    void updatestatus(int requestID, RequestType req);
    Request GetRequest(int requestID);
}
