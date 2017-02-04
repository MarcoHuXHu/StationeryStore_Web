using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order_AcknowledgeOrder : System.Web.UI.Page
{
    string userid;
    string orderID;

    List<OrderDetail> completedList;
    List<OrderDetail> list1;
    Work Work;

    protected void Page_Load(object sender, EventArgs e)
    {
        Work = new Work();
        userid = (string)Session["user"];
        orderID = Request.QueryString["OrderID"];
        if (!IsPostBack)
        {
            OrderIDLbl.Text = orderID;
            ItemIDLbl.Text = Request.QueryString["Item"];
            DescriptionLbl.Text = Request.QueryString["Description"];

            List<OrderDetail> odlist = Work.getInCompleteOrderList(orderID);
            GridView1.DataSource = odlist;
            GridView1.DataBind();
            Label5.Visible = false;
            Label6.Text = "";

            completedList = Work.getCompletedOrderList(orderID);
            GridView2.DataSource = completedList;
            GridView2.DataBind();

            if (GridView2.Rows.Count == 0)
            {
                GridView2.Visible = false;
            }
            else
            {
                GridView2.Visible = true;
                Label5.Visible = true;
            }
        }

    }

    protected void SelectCheckBox_OnCheckedChanged(object sender, EventArgs e)
    {
        string poId;
        //  List<string> ls = new List<string>();
        List<string> poList = new List<string>();
        int count = 0;

        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[3].FindControl("cbSelect") as CheckBox);
                if (chkRow.Checked)
                {
                    poId = ((Label)row.FindControl("poid")).Text; ;
                    poList.Add(poId);
                    count++;
                }
            }
        }
        Session["poList"] = poList;
        ViewState["count"] = count;

    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {
        Label6.Text = "";
        string[] arr;
        List<string> lst = new List<string>();
        lst = (List<string>)Session["poList"];
        int countChecked = Convert.ToInt32(ViewState["count"]);

       // if (Session["poList"] == null)
       if (countChecked == 0)
        {
            Label6.Text = "Please select Purchase Order which has been done!";
        }
        else
        {
            arr = lst.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                updatePO(arr[i], OrderIDLbl.Text);
            }
        }

        list1 = Work.getInCompleteOrderList(orderID);
        GridView1.DataSource = list1;
        GridView1.DataBind();


        GridView2.Visible = true;
        completedList = Work.getCompletedOrderList(orderID);
        GridView2.DataSource = completedList;
        GridView2.DataBind();
        if (GridView2.Rows.Count != 0)
        {
            Label5.Visible = true;
        }

        if (GridView1.Rows.Count == 0)
        {
            GridView1.Visible = false;
            Work.UpdateOrderStatus(orderID, "Completed");
            string message = "Acknowledgement for order " + orderID + " is successful.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('" + message + "');window.location='OrderList.aspx'", true);
        }
    }

    protected void updatePO(string po, string orderID)
    {
        Work.UpdateOrderDetails(po, orderID);
        Work.UpdateItemStock(ItemIDLbl.Text, po, orderID);
    }
}