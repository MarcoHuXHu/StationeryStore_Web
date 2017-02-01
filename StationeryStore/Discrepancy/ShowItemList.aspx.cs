using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowItemList : System.Web.UI.Page
{
    Work work;
    List<ItemModel> ilist;
    protected void Page_Load(object sender, EventArgs e)
    {
        string userId = (string)Session["user"];
        if (userId == null)
        {
            Response.Redirect("~/login.aspx");
        }
        work = new Work();
        if (ViewState["category"] == null)
        {
            Label4.Visible = false;
            ilist = work.showAllItems();
            GridView1.DataSource = ilist;
            GridView1.DataBind();
        }
        Page.ClientScript.GetPostBackEventReference(GridView1, "");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label4.Visible = false;
        ViewState["category"] = TextBox1.Text;
        if (TextBox1.Text.Trim() == String.Empty)
        {
            Label4.Visible = false;
            ilist = work.showAllItems();
        }
        else
        {
            ilist = work.searchItems((string)ViewState["category"]);
            if(ilist.Count==0)
            {
                Label4.Visible = true;
                Label4.Text = "No item found!";
            }
        }
        GridView1.DataSource = ilist;
        GridView1.DataBind();
    }

    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes.Add("onmouseover", "if(this!=prevselitem){this.style.backgroundColor='#Efefef'}");
    //        e.Row.Attributes.Add("onmouseout", "if(this!=prevselitem){this.style.backgroundColor='#ffffff'}");
    //        e.Row.Attributes.Add("onclick", e.Row.ClientID.ToString() + ".checked=true;selectx(this)");
    //    }
    //}

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("/NewDiscrepancy.aspx?id=1&description=2");
    }

    protected void display()
    {
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = work.showAllItems();
        GridView1.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Label4.Visible = false;
        TextBox1.Text = "";
        ilist = work.showAllItems();
        GridView1.DataSource = ilist;
        GridView1.DataBind();
    }
}