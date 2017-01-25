using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Web.UI;
using System.Web.Script.Services;

[ServiceContract]
public interface IService
{
    [OperationContract]
    [WebInvoke(UriTemplate = "/Authenticate", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
    bool Authenticate(WCFUser user);

    [OperationContract]
    [WebGet(UriTemplate = "/DiscrepancyList/{selected}", ResponseFormat = WebMessageFormat.Json)]
    List<ItemDiscrepancyModel> GetDiscrepancyList(string selected);

    [OperationContract]
    [WebGet(UriTemplate = "/ItemList", ResponseFormat = WebMessageFormat.Json)]
    List<ItemModel> GetItemList();

    [OperationContract]
    [WebGet(UriTemplate = "/SearchItemList/{search}", ResponseFormat = WebMessageFormat.Json)]
    List<ItemModel> SearchItemList(string search);

    [OperationContract]
    [WebGet(UriTemplate = "/GetMaxPrice/{id}", ResponseFormat = WebMessageFormat.Json)]
    decimal GetMaxPrice(string id);

    [OperationContract]
    [WebGet(UriTemplate = "/GetMaxDiscrepancyId", ResponseFormat = WebMessageFormat.Json)]
    string GetMaxDiscrepancyId();

    //[OperationContract]
    //[WebInvoke(UriTemplate = "/SaveDiscrepancy", Method = "POST",
    //RequestFormat = WebMessageFormat.Json,
    //ResponseFormat = WebMessageFormat.Json)]
    //void saveDiscrepancy(Discrepancy dis);

    [OperationContract]
    [WebGet(UriTemplate = "/GetDiscrepancy/{id}", ResponseFormat = WebMessageFormat.Json)]
    ItemDiscrepancyModel GetDiscrepancy(string id);

    [OperationContract]
    [WebGet(UriTemplate = "/ UpdateDiscrepancy /{id}/{status}", ResponseFormat = WebMessageFormat.Json)]
    void UpdateDiscrepancy(string id,string status);

    [OperationContract]
    [WebGet(UriTemplate = "/ViewSubmission/{userId}", ResponseFormat = WebMessageFormat.Json)]
    List<RqHistory> ViewSubmission(string userId);

    [OperationContract]
    [WebGet(UriTemplate = "/ViewSubmission/{userId}/{status}", ResponseFormat = WebMessageFormat.Json)]
    List<RqHistory> SearchSubmission(string userId,string status);

    [OperationContract]
    [WebGet(UriTemplate = "/RequestDetail?id={id}", ResponseFormat = WebMessageFormat.Json)]
    List<RqDetail> ViewRequestDetail(string id);

    [OperationContract]
    [WebGet(UriTemplate = "/ApproveRequest?id={id}&comment={comment}&status={status}", ResponseFormat = WebMessageFormat.Json)]
    void ApproveRequest(string id,string comment,string status);

    [OperationContract]
    [WebGet(UriTemplate = "/ViewNotificationByUserID?id={id}", ResponseFormat =WebMessageFormat.Json)]
    List <WCFNotification> ViewNotificationByUserID(string id);

    [OperationContract]
    [WebGet(UriTemplate = "/OrderList", ResponseFormat = WebMessageFormat.Json)]
    List<OrderModel> GetOrderList();


    [OperationContract]
    [WebGet(UriTemplate = "/PendingOrderList", ResponseFormat = WebMessageFormat.Json)]
    List<OrderModel> getPendingOrder();

    [OperationContract]
    [WebGet(UriTemplate = "/UpdateOrderStatus/{id}/{status}", ResponseFormat = WebMessageFormat.Json)]
    void UpdateOrderStatus(string id, string status);

    [OperationContract]
    [WebGet(UriTemplate = "/GetCollectionPoint/{userId}", ResponseFormat = WebMessageFormat.Json)]
    string getCollectionPoint(string userId);

    [OperationContract]
    [WebGet(UriTemplate = "/UpdateCollectionPoint/{userId}/{point}", ResponseFormat = WebMessageFormat.Json)]
    void UpdateCollectionPoint(string userId, string point);

    [OperationContract]
    [WebGet(UriTemplate = "/GetDeptRep/{userId}", ResponseFormat = WebMessageFormat.Json)]
    string GetDeptRep(string userId);

    [OperationContract]
    [WebGet(UriTemplate = "/GetDeptStaff/{userId}", ResponseFormat = WebMessageFormat.Json)]
    List<string> GetDeptStaff(string userId);

    [OperationContract]
    [WebGet(UriTemplate = "/UpdateDeptRep/{userId}/{newRepName}", ResponseFormat = WebMessageFormat.Json)]
    void UpdateDeptRep(string userId,string newRepName);

}


[DataContract]
public class WCFUser
{
    string username;
    string password;


    public WCFUser (string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    [DataMember]
    public string Username
    {
        get { return username; }
        set { username = value; }
    }

    [DataMember]
    public string Password
    {
        get { return password; }
        set { password = value; }
    }



}

