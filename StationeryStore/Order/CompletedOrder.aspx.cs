using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order_CompletedOrder : System.Web.UI.Page
{

    string userid;
    string orderID;
    Work Work;
    protected void Page_Load(object sender, EventArgs e)
    {
        Work = new Work();
        userid = (string)Session["user"];
        if (!IsPostBack)
        {
            OrderIDLbl.Text = Request.QueryString["OrderID"];
            ItemIDLbl.Text = Request.QueryString["Item"];
            DescriptionLbl.Text = Request.QueryString["Description"];
            TotalQtyLbl.Text = Request.QueryString["Quantity"];
            OrderDateLbl.Text = Request.QueryString["OrderDate"];

            List<OrderDetail> odlist = Work.getCompletedOrderList(OrderIDLbl.Text);
            GridView2.DataSource = odlist;
            GridView2.DataBind();

            

        }
    }
}