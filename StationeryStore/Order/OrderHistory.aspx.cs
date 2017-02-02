using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order_OrderHistory : System.Web.UI.Page
{
    string userId;
    static string all = "Show All";
    protected void Page_Load(object sender, EventArgs e)
    {
        userId = (string)Session["user"];
        if (userId == null)
        {
            Response.Redirect("~/login.aspx");
        }

        if (!IsPostBack)
        {
            var list = Work.getOrderHistoryStatus();
            list.Insert(0, all);
            SearchDDL.DataSource = list;
            SearchDDL.DataBind();

            List<OrderModel> oList = Work.getOrderHistory();
            Session["history"] = oList;
            display();
        }
    }

    protected void SearchDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["status"] = SearchDDL.SelectedValue;
        List<OrderModel> list = Work.getOrderHistory((string)ViewState["status"]);
        Session["history"] = list;
        display();
    }

    protected void display()
    {
        List<OrderModel> list = (List<OrderModel>)Session["history"];
        HistoryGV.DataSource = list;
        HistoryGV.DataBind();
        if (list.Count == 0)
        {
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "No order!";
        }
        else if (list.Count > 1)
        {
            Label1.ForeColor = System.Drawing.Color.Black;
            Label1.Text = "There are a total of " + list.Count + " orders.";
        }
        else
        {
            Label1.ForeColor = System.Drawing.Color.Black;
            Label1.Text = "There is only " + list.Count + " order.";
        }

    }

    protected void HistoryGV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        HistoryGV.PageIndex = e.NewPageIndex;
        display();
    }
}