using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Order_MakeNewOrder : System.Web.UI.Page
{
    Work Work = new Work();
    string userId;
    protected void Page_Load(object sender, EventArgs e)
    {
        userId = (string)Session["user"];
        if (userId == null)
        {
            Response.Redirect("~/login.aspx");
        }
        if (!IsPostBack)
        {
            ItemIDLbl.Text = Request.QueryString["ItemID"];
            DescriptionLbl.Text = Request.QueryString["Description"];
        }
    }

    string orderID;
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {

        orderID = Work.InsertNewOrder(ItemIDLbl.Text, QuantityTextBox.Text, JustificationTextBox.Text, userId);

        //Multi Thread
        //ThreadStart childref = new ThreadStart(sendemail);
        //Thread childThread = new Thread(childref);
        //childThread.Start();

        AsyncEmail ae = sendemail;
        ae.BeginInvoke(null, null);


        string message = "Your order id is " + orderID + ".";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + message + "');window.location='OrderList.aspx'", true);
    }
    private delegate void AsyncEmail();
    private void sendemail()
    {
        string headID = Work.getDeptHeadId(Work.getUser(userId).DepartmentID);
        string subject = "Order " + orderID + " for approval";
        string body = "Dear Sir/ Madam,<br />" + "<br />Order " + orderID + " is pending your approval. Please click <a href = 'http://localhost/StationeryStore/Order/ApproveOrder.aspx'>here</a> to see more details.<br />" + "<br />Thanks & regards.";
        SendEmail sm = new SendEmail(headID, subject, body);
        sm.initEmail();
        sm.sendEmail();
    }
}