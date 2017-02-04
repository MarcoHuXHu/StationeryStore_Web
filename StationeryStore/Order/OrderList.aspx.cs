using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order_OrderList : System.Web.UI.Page
{
    string userId;
    static string all = "Show All";
    Work Work = new Work();
    protected void Page_Load(object sender, EventArgs e)
    {
        userId = (string)Session["user"];
        if (userId == null)
        {
            Response.Redirect("~/login.aspx");
        }

        if (!IsPostBack)
        {
            var list = Work.getOrderStatus();
            list.Insert(0, all);
            SearchDDL.DataSource = list;
            SearchDDL.DataBind();

            List<OrderModel> oList = Work.getOrderList();
            Session["orderList"] = oList;
            display();
        }
        Label1.Text = "";
    }

    protected void display()
    {
        List<OrderModel> oList = (List<OrderModel>)Session["orderList"];
        OrderListGV.DataSource = oList;
        OrderListGV.DataBind();
        if (oList.Count == 0)
        {
            Label2.ForeColor = System.Drawing.Color.Red;
            Label2.Text = "No order!";
        }
        else if (oList.Count > 1)
        {
            Label2.ForeColor = System.Drawing.Color.Black;
            Label2.Text = "There are a total of " + oList.Count + " orders.";
        }
        else
        {
            Label2.ForeColor = System.Drawing.Color.Black;
            Label2.Text = "There is only " + oList.Count + " order.";
        }

    }



    protected void OrderBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ItemList.aspx");
    }

    protected void SearchDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["status"] = SearchDDL.SelectedValue;
        List<OrderModel> list = Work.getOrderList((string)ViewState["status"]);
        Session["orderList"] = list;
        display();
    }


    protected void OrderListGV_SelectedIndexChanged(object sender, EventArgs e)
    {
        StringBuilder x;

        GridViewRow row = OrderListGV.SelectedRow;
        string stt = ((Label)row.FindControl("stt")).Text;
        string orderID = ((Label)row.FindControl("orderid")).Text;
        string itemID = ((Label)row.FindControl("itemid")).Text;
        string description = ((Label)row.FindControl("desc")).Text;
        string quantity = ((Label)row.FindControl("qty")).Text;
        string justification = ((Label)row.FindControl("justification")).Text;
        string orderdate = ((Label)row.FindControl("orderdate")).Text;

        if (stt == "Cancelled") 
        {
            Label1.Text = "The order <b>" + orderID + "</b> is <b>" + stt.ToLower() + "</b>. No more further process.";
        }
        else if (stt == "Rejected")
        {
            x = new StringBuilder();
            x.Append("The order <b>" + orderID + "</b> is <b>" + stt.ToLower() + "</b>.");

            string cmt = Work.ShowComment(orderID);
            if ((cmt != null) && (cmt != ""))
            {
                x.Append(" The reason is " + cmt + ".");
            }
            Label1.Text = x.ToString();
        } else if (stt == "Completed")
        {
            Response.Redirect("CompletedOrder.aspx?OrderID=" + orderID + "&Item=" + itemID + "&Description=" + description + "&Quantity=" + quantity + "&OrderDate=" + orderdate);
        }
            else if (stt == "Approved")
        {
            Response.Redirect("ProceedApprovedOrder.aspx?Order=" + orderID + "&Item=" + itemID + "&Description=" + description + "&Quantity=" + quantity);
        }
        else if (stt == "Ordered")
        {
            Response.Redirect("AcknowledgeOrder.aspx?OrderID=" + orderID + "&Item=" + itemID + "&Description=" + description);
        }
        else if (stt == "PendingApproval")
        {
            Response.Redirect(String.Format("EditOrder.aspx?Order={0}&Item={1}&Description={2}&Quantity={3}&Justification={4}", orderID, itemID, Server.UrlEncode(description), quantity, justification.Replace("\n", " ")));
            //  Response.Redirect("EditOrder.aspx?Order=" + orderID + "&Item=" + itemID + "&Description=" + description + "&Quantity=" + quantity + "&Justification=" + justification.Replace("\n", " "));
        }

    }

    protected void OrderListGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        OrderListGV.PageIndex = e.NewPageIndex;
        display();
    }
}