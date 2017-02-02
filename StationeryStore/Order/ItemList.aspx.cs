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
            Session["itemList"] = iList;
            // GridView1.DataSource = iList;
            //GridView1.DataBind();
            display();
            // if (!iList.Any())
            // {
            //     Label2.Text = "No item found!";
            // }

        }

    }

    protected void display()
    {
        List<Item> iList = (List<Item>)Session["itemList"];
        GridView1.DataSource = iList;
        GridView1.DataBind();
        if (iList.Count == 0)
        {
            Label2.ForeColor = System.Drawing.Color.Red;
            Label2.Text = "No item found!";

        }
        else if (iList.Count > 1)
        {
            Label2.ForeColor = System.Drawing.Color.Black;
            Label2.Text = "There are a total of " + iList.Count + " items.";
        }
        else
        {
            Label2.ForeColor = System.Drawing.Color.Black;
            Label2.Text = "There is only " + iList.Count + " item.";
        }

    }

    protected void SearchBtn_Click(object sender, EventArgs e)
    {
        ShowAllBtn.Enabled = true;
        if (!(string.IsNullOrEmpty(SearchTextBox.Text)))
        {
            List<Item> list = Work.getFoundItems(SearchTextBox.Text);
            Session["itemList"] = list;
            /* if (!list.Any())
             {
                 Label2.Text = "No item found!";
             }
             GridView1.DataSource = list;
             GridView1.DataBind();*/
            display();
        }
    }

    protected void ShowAllBtn_Click(object sender, EventArgs e)
    {
        ShowAllBtn.Enabled = false;
        SearchTextBox.Text = String.Empty;
        List<Item> iList = Work.getAllItems();
        Session["itemList"] = iList;
        /*GridView1.DataSource = Session["itemList"];
        GridView1.DataBind();
        if (GridView1.Rows.Count == 0)
        {
            Label2.Text = "No item found!";
        }*/
        display();
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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        display();
    }
}