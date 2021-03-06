﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MaintainCatalogueList1 : System.Web.UI.Page
{
    Work Work = new Work();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = Work.GetItems();

            GridView1.DataBind();
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        GridView1.DataSource = Work.GetItems();

        GridView1.DataBind();
        GridViewRow row = GridView1.Rows[e.NewEditIndex];
        DropDownList dropdownlist1 = (DropDownList)row.FindControl("DropDownList1");
        dropdownlist1.DataSource = Work.GetCategory();
        dropdownlist1.DataTextField = "Category";
        dropdownlist1.DataValueField = "Category";
        dropdownlist1.DataBind();

        DropDownList dropdownlist2 = (DropDownList)row.FindControl("DropDownList2");
        dropdownlist2.DataSource = Work.GetUOM();
        dropdownlist2.DataTextField = "UOM";
        dropdownlist2.DataValueField = "UOM";
        dropdownlist2.DataBind();

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        e.Cancel = true;
        GridView1.EditIndex = -1;
        GridView1.DataSource = Work.GetItems();

        GridView1.DataBind();


    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];


        TextBox txtDescription = (TextBox)row.FindControl("txtDescription");
        DropDownList dropdownlist1 = (DropDownList)row.FindControl("DropDownList1");
        TextBox txtReorderLevel = (TextBox)row.FindControl("txtReorderLevel");
        TextBox txtReorderQty = (TextBox)row.FindControl("txtReorderQty");
        TextBox txtUOM = (TextBox)row.FindControl("txtUOM");
        DropDownList dropdownlist2 = (DropDownList)row.FindControl("DropDownList2");
        string Description = txtDescription.Text;
        string Category = dropdownlist1.SelectedValue;
        string ReorderLevel = txtReorderLevel.Text;
        string ReorderQty = txtReorderQty.Text;
        string UOM = dropdownlist2.SelectedValue;

        //string SupplierCode = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string itemCode = row.Cells[0].Text;




        Work.UpdateItem(itemCode, Description, Category, ReorderLevel, ReorderQty, UOM);
        GridView1.EditIndex = -1;
        GridView1.DataSource = Work.GetItems();

        GridView1.DataBind();

        //UpdateSupplier(SupplierCode,SupplierName,GSTRegistrationNo,ContactName,Phone,Fax,Address);
        //method name: UpdateSupplier
        //input arguments: SupplierCode,SupplierName,GSTRegistrationNo,ContactName,Phone,Fax,Address
        //return type: void
    }

    protected void GridView1_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);

        //GridView1.DeleteRow(index);
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string ItemCode = row.Cells[0].Text;
        Work.DeleteItem(ItemCode);

        GridView1.DataSource = Work.GetItems();

        GridView1.DataBind();



        //GridView1.DataSource = GetSuppliers();
        //no input argument
        //return type is list of suppliers (select * from suppliers)


    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        GridView1.DataSource = Work.GetItems();

        GridView1.DataBind();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintainCatalogueList2.aspx");
    }
}