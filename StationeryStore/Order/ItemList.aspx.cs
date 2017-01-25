using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Order_ItemList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = "";
        if (!IsPostBack)
        {
            ShowAllBtn.Enabled = false;
            List<Item> iList = Work.getAllItems();
            GridView1.DataSource = iList;
            GridView1.DataBind();
            if (!iList.Any())
            {
                Label2.Text = "No item found!";
            }
            Session["all"] = iList;
        }

    }

    protected void SearchBtn_Click(object sender, EventArgs e)
    {
        ShowAllBtn.Enabled = true;
        if (!(string.IsNullOrEmpty(SearchTextBox.Text)))
        {
            List<Item> list = Work.getFoundItems(SearchTextBox.Text);
            if (!list.Any())
            {
                Label2.Text = "No item found!";
            }
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }

    protected void ShowAllBtn_Click(object sender, EventArgs e)
    {
        ShowAllBtn.Enabled = false;
        SearchTextBox.Text = String.Empty;
        GridView1.DataSource = Session["all"];
        GridView1.DataBind();
        if (GridView1.Rows.Count == 0)
        {
            Label2.Text = "No item found!";
        }
    }


    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.textDecoration='underline';this.style.backgroundColor ='#CCCCCC'");
            e.Row.Attributes.Add("onmouseout", "this.style.textDecoration='none',this.style.backgroundColor=''");
            e.Row.ToolTip = "Click on item to order!";
            e.Row.Attributes.Add("style", "cursor:pointer;");
            e.Row.Attributes["onClick"] = string.Format("window.location = 'MakeNewOrder.aspx?ItemID={0}&Description={1}';", DataBinder.Eval(e.Row.DataItem, "ItemID"), DataBinder.Eval(e.Row.DataItem, "Description"));

        }
    }
}