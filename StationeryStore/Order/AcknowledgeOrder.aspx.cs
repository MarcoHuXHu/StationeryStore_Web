using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order_AcknowledgeOrder : System.Web.UI.Page
{
    Work Work = new Work();
    string userid;
    string orderID;
    string itemID;
    protected void Page_Load(object sender, EventArgs e)
    {
        userid = (string)Session["user"];
        orderID = Request.QueryString["OrderID"];
        if (!IsPostBack)
        {
            OrderIDLbl.Text = orderID;
            ItemIDLbl.Text = Request.QueryString["Item"];
            DescriptionLbl.Text = Request.QueryString["Description"];

            List<OrderDetail> list = Work.getOrderDetailsList(orderID);
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }

    protected void SubmitBtn_Click1(object sender, EventArgs e)
    {
        orderID = Request.QueryString["OrderID"];
        itemID = Request.QueryString["Item"];
        string stt = "Completed";
        Work.UpdateOrderStatus(orderID, stt);
        Work.UpdateItemStock(orderID, itemID);
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string poNumber = ((Label)GridView1.Rows[i].FindControl("poid")).Text;
            Work.UpdateOrderDetails(poNumber);
        }

        orderID = Request.QueryString["OrderID"];
        string message = "Acknowledgement for order " + orderID + " is successful.";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + message + "');window.location='OrderList.aspx'", true);
    }
}