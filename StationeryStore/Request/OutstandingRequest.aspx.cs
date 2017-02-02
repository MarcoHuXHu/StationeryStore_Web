using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Request_OutstandingRequest : System.Web.UI.Page
{
    Work Work = new Work();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PanelSummary.Visible = true;
            PanelDept.Visible = false;

            List<DisbursementModel> bySummary = Work.viewRequestSummary();
            List<DisbursementModel> byDepartment = Work.viewRequestByDept();
            int res = Work.GetRetrieveLog(bySummary, byDepartment);
            if (res == 0)
            {
                // Auto-Allocate
                AutoAllocate automator = new AutoAllocate();
                Dictionary<string, int> res1 = automator.AllocateAllItem();
                Dictionary<string, Dictionary<string, int>> res2 = automator.AllocateAllDepartment(res1);
                bySummary = Work.viewRequestSummary();
                byDepartment = Work.viewRequestByDept();
                foreach (DisbursementModel model in bySummary)
                    model.RetrivedNumber = res1[model.ItemID];
                foreach (DisbursementModel model in byDepartment)
                    model.RetrivedNumber = res2[model.DepartmentID][model.ItemID];
            }
            this.ViewState["listBySummary"] = bySummary;
            this.ViewState["listByDept"] = byDepartment;

            GridViewSummary.DataSource = bySummary;
            GridViewSummary.DataBind();
        }

    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(RadioButtonList1.SelectedValue == "ViewSummary")
        {
            PanelSummary.Visible = true;
            PanelDept.Visible = false;
            List<DisbursementModel> list = (List<DisbursementModel>) ViewState["listBySummary"];
            GridViewSummary.DataSource = list;
            GridViewSummary.DataBind();
            
        }
    

        else if (RadioButtonList1.SelectedValue == "ViewByDepartment")
        {
            PanelSummary.Visible = false;
            PanelDept.Visible = true;
            List<DisbursementModel> list = (List<DisbursementModel>) ViewState["listByDept"];
            GridViewDept.DataSource = list;
            GridViewDept.DataBind();
            
        }
    }



    protected void GridViewDept_Sorting(object sender, GridViewSortEventArgs e)
    {
        List<DisbursementModel> list = (List <DisbursementModel>)this.ViewState["listByDept"];

        if (this.ViewState["ItemSort"] == null)
        {
            this.ViewState["ItemSort"] = SortDirection.Ascending;
        }
        if (this.ViewState["DepartmentSort"] == null)
        {
            this.ViewState["DepartmentSort"] = SortDirection.Ascending;
        }

        switch (e.SortExpression)
        {
            case "Department":
                if ((SortDirection)this.ViewState["DepartmentSort"] == SortDirection.Ascending)
                {
                    list = list.OrderBy(x => x.DepartmentName).ToList();
                    GridViewDept.DataSource = list;
                    GridViewDept.DataBind();
                    this.ViewState["listByDept"] = list;
                    this.ViewState["DepartmentSort"] = SortDirection.Descending;
                }
                else
                {
                    list = list.OrderByDescending(x => x.DepartmentName).ToList();
                    GridViewDept.DataSource = list;
                    GridViewDept.DataBind();
                    this.ViewState["listByDept"] = list;
                    this.ViewState["DepartmentSort"] = SortDirection.Ascending;
                }
                break;
            case "Item":

                if ((SortDirection)this.ViewState["ItemSort"] == SortDirection.Ascending)
                {
                    list = list.OrderBy(x => x.ItemID).ToList();
                    GridViewDept.DataSource = list;
                    GridViewDept.DataBind();
                    this.ViewState["listByDept"] = list;
                    this.ViewState["ItemSort"] = SortDirection.Descending;

                }
                else
                {
                    list = list.OrderByDescending(x => x.ItemID).ToList();
                    GridViewDept.DataSource = list;
                    GridViewDept.DataBind();
                    this.ViewState["listByDept"] = list;
                    this.ViewState["ItemSort"] = SortDirection.Ascending;
                }
                break;
        }
    }

    protected void GridViewDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        string deptId = GridViewDept.SelectedRow.Cells[0].Text;
        string itemId = GridViewDept.SelectedRow.Cells[2].Text;


        //DetailsView.DataSource = 
        //DetailsView.DataBind();
    }

    // submit in "By Summary" page
    protected void ButtonSummary_Click(object sender, EventArgs e)
    {
        List<DisbursementModel> oldlistBySummary = (List<DisbursementModel>)ViewState["listBySummary"];
        List<DisbursementModel> oldlistByDepartment = (List<DisbursementModel>)ViewState["listByDept"];
        // Copy from ViewState as backup so input on screen would not change list in ViewState
        List<DisbursementModel> listBySummary = new List<DisbursementModel>();
        foreach (DisbursementModel dm in oldlistBySummary)
            listBySummary.Add(new DisbursementModel(dm.ItemID, dm.ItemDesp, dm.NeededNumber, dm.InStock, dm.binNum, dm.RetrivedNumber));

        List<DisbursementModel> listByDepartment = new List<DisbursementModel>();
        foreach (DisbursementModel dm in oldlistByDepartment)
            listByDepartment.Add(new DisbursementModel(dm.DepartmentID, dm.DepartmentName, dm.ItemID, dm.ItemDesp, dm.NeededNumber, dm.InStock, dm.RetrivedNumber));

        // Update RetrievedNum by Find Control
        for (int i=0; i<listBySummary.Count(); i++)
        {
            TextBox retrieveText = GridViewSummary.Rows[i].FindControl("retrieved") as TextBox;
            if (retrieveText != null)
            {
                int retrieveQty = 0;
                if (retrieveText.Text != null)
                {
                    bool isInt = int.TryParse(retrieveText.Text, out retrieveQty);
                }
                listBySummary[i].RetrivedNumber = retrieveQty;
            }
        }
        // Call Service for Validation, Auto-Allocate and Update DisbursementLogs
        int res = Work.SubmitSummary(listBySummary, listByDepartment);
        if (res == 0)
        {
            // Successfully passed Validation and Changed Database, Update data in ViewState
            ViewState["listBySummary"] = listBySummary;
            ViewState["listByDept"] = listByDepartment;
            string errorItem = "Update successfully!\\nAuto allocation is done based on the priority and retrieved number given. Please select ViewByDepartment to see more details.";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + errorItem + "')</script>");
        }
        else if (res == -1001)
        {
            // Failed in Validation (Over Needed)
            // Find the wrong retrieve number and send Message
            string errorItem = "";
            foreach (DisbursementModel dm in listBySummary)
                if (dm.RetrivedNumber > dm.NeededNumber)
                    errorItem += dm.ItemDesp + "\\n";
            if (errorItem.Length > 0)
            {
                errorItem = "These Items put more retrieved quantity than Needed: \\n" + errorItem;
                //System.Windows.Forms.MessageBox.Show(errorItem);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + errorItem + "')</script>");
            }
        }
        else if (res == -1002)
        {
            // Failed in Validation (Over InStock)
            // Find the wrong retrieve number and send Message
            string errorItem = "";
            foreach (DisbursementModel dm in listBySummary)
                if (dm.RetrivedNumber > dm.InStock)
                    errorItem += dm.ItemDesp + "\\n";
            if (errorItem.Length > 0)
            {
                errorItem = "These Items put more retrieved quantity than InStock: \\n" + errorItem;
                //System.Windows.Forms.MessageBox.Show(errorItem);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + errorItem + "')</script>");
            }
        }

    }

    // submit in "By Department" page
    protected void ButtonDept0_Click(object sender, EventArgs e)
    {
        List<DisbursementModel> oldlistBySummary = (List<DisbursementModel>)ViewState["listBySummary"];
        List<DisbursementModel> oldlistByDepartment = (List<DisbursementModel>)ViewState["listByDept"];
        // Copy from ViewState as backup so input on screen would not change list in ViewState
        List<DisbursementModel> listBySummary = new List<DisbursementModel>();
        foreach (DisbursementModel dm in oldlistBySummary)
            listBySummary.Add(new DisbursementModel(dm.ItemID, dm.ItemDesp, dm.NeededNumber, dm.InStock, dm.binNum, dm.RetrivedNumber));

        List<DisbursementModel> listByDepartment = new List<DisbursementModel>();
        foreach (DisbursementModel dm in oldlistByDepartment)
            listByDepartment.Add(new DisbursementModel(dm.DepartmentID, dm.DepartmentName, dm.ItemID, dm.ItemDesp, dm.NeededNumber, dm.InStock, dm.RetrivedNumber));

        // Update RetrievedNum by Find Control
        for (int i = 0; i < listByDepartment.Count(); i++)
        {
            TextBox retrieveText = GridViewDept.Rows[i].FindControl("retrieved") as TextBox;
            if (retrieveText != null)
            {
                int retrieveQty = 0;
                if (retrieveText.Text != null)
                {
                    bool isInt = int.TryParse(retrieveText.Text, out retrieveQty);
                }
                listByDepartment[i].RetrivedNumber = retrieveQty;
            }
        }

        // Call Service for Validation and Update DisbursementLogs
        int res = Work.SubmitByDepartment(listBySummary, listByDepartment);
        if (res >= 0)
        {
            // Successfully passed Validation and Changed Database, Update data in ViewState
            if (res >0)
            {
                // Discrepency in BySummary and ByDepartment, Send Message
                //System.Windows.Forms.MessageBox.Show("There are discrepency in Retrieved between By Summary and By Department.\\nWe fixed it by changing the Retrieved By Summary");
                string errorItem = "Update successfully!\\nThere are discrepency in Retrieved between By Summary and By Department.\\nWe fixed it by changing the Retrieved By Summary";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + errorItem + "')</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Update successfully!')</script>");
            }
            ViewState["listBySummary"] = listBySummary;
            ViewState["listByDept"] = listByDepartment;
        }
        else if (res == -1001)
        {
            // Failed in Validation (Over Needed)
            // Find the wrong retrieve number and send Message
            string errorItem = "";
            foreach (DisbursementModel dm in listBySummary)
                if (dm.RetrivedNumber > dm.NeededNumber)
                    errorItem += dm.ItemDesp + "\\n";
            if (errorItem.Length > 0)
            {
                errorItem = "These Items put more retrieved quantity than Needed: \\n" + errorItem;
                //System.Windows.Forms.MessageBox.Show(errorItem);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + errorItem + "')</script>");
            }
        }
        else if (res == -1002)
        {
            // Failed in Validation (Over InStock)
            // Find the wrong retrieve number and send Message
            string errorItem = "";
            foreach (DisbursementModel dm in listBySummary)
                if (dm.RetrivedNumber > dm.InStock)
                    errorItem += dm.ItemDesp + "\\n";
            if (errorItem.Length > 0)
            {
                errorItem = "These Items put more retrieved quantity than InStock: \\n" + errorItem;
                //System.Windows.Forms.MessageBox.Show(errorItem);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + errorItem + "')</script>");
            }
        }

    }

}