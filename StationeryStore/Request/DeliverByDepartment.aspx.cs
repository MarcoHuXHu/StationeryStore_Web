using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Request_DeliverByDepartment : System.Web.UI.Page
{
    Work Work = new Work();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // dicByDept to store all Log and Map to DepartmentID
            Dictionary<string, List<DisbursementModel>> dicByDept = new Dictionary<string, List<DisbursementModel>>();
			// deptList for DropdownList
            List<DisbursementModel> deptList = new List<DisbursementModel>();
            // Get Data
            List<DisbursementModel> listByDepartment = Work.viewRequestByDept();
            Work.GetRetrieveLog(new List<DisbursementModel>(), listByDepartment);
            foreach (DisbursementModel dm in listByDepartment)
            {
                if (!dicByDept.ContainsKey(dm.DepartmentID))
                {
                    DisbursementModel dept = new DisbursementModel();
                    dept.DepartmentID = dm.DepartmentID;
                    dept.DepartmentName = dm.DepartmentName;
                    deptList.Add(dept);
                    dicByDept.Add(dm.DepartmentID, new List<DisbursementModel>());
                }
                dicByDept[dm.DepartmentID].Add(dm);
            }
            // Initiate the DropdownBox
            DropDownList1.DataSource = deptList;
            DropDownList1.DataTextField = "DepartmentName";
            DropDownList1.DataValueField = "DepartmentID";
            DropDownList1.DataBind();
            // Bind dicByDept to Session
            ViewState["dicByDept"] = dicByDept;
            // Initiate the GridView
            string selectedDept = DropDownList1.SelectedValue;
            GridViewDept.DataSource = dicByDept[selectedDept];
            GridViewDept.DataBind();
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Dictionary<string, List<DisbursementModel>> dicByDept = (Dictionary<string, List<DisbursementModel>>)ViewState["dicByDept"];
        string selectedDept = DropDownList1.SelectedValue;
        GridViewDept.DataSource = dicByDept[selectedDept];
        GridViewDept.DataBind();
    }

    protected void Button0_Click(object sender, EventArgs e)
    {
        Transaction clerk = new Transaction();
        Dictionary<string, List<DisbursementModel>> dicByDept = (Dictionary<string, List<DisbursementModel>>)ViewState["dicByDept"];
        string selectedDept = DropDownList1.SelectedValue;
        List<DisbursementModel> list = new List<DisbursementModel>();

        // Backup the list
        foreach (DisbursementModel dm in dicByDept[selectedDept])
            list.Add(new DisbursementModel(dm.DepartmentID, dm.DepartmentName, dm.ItemID, dm.ItemDesp, dm.NeededNumber, dm.InStock, dm.RetrivedNumber));

        // Read data from input
        for (int i = 0; i < list.Count(); i++)
        {
            TextBox giveText = GridViewDept.Rows[i].FindControl("Given") as TextBox;
            if (giveText != null)
            {
                int giveQty = 0;
                if (giveText.Text != null)
                {
                    bool isInt = int.TryParse(giveText.Text, out giveQty);
                }
                list[i].GivenNumber = giveQty;
                // move to Work
            }
        }
        int res = Work.SubmitDeliver(list);
        if (res == 0)
        {
            // Update ViewState
            dicByDept[selectedDept] = list;
            ViewState["dicByDept"] = dicByDept;
        }
        else if (res == -1001)
        {
            // Failed in Validation (Over Needed)
            // Find the wrong retrieve number and send Message
            string errorItem = "";
            foreach (DisbursementModel dm in list)
                if (dm.GivenNumber > dm.NeededNumber)
                    errorItem += dm.ItemDesp + "\r\n";
            if (errorItem.Length > 0)
            {
                errorItem = "These Items put more given quantity than Needed: \r\n" + errorItem;
                //System.Windows.Forms.MessageBox.Show(errorItem);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + errorItem + "')</script>");
            }
        }
        else if (res == -1002)
        {
            // Failed in Validation (Over InStock)
            // Find the wrong retrieve number and send Message
            string errorItem = "";
            foreach (DisbursementModel dm in list)
                if (dm.GivenNumber > dm.InStock)
                    errorItem += dm.ItemDesp + "\r\n";
            if (errorItem.Length > 0)
            {
                errorItem = "These Items put more given quantity than InStock: \r\n" + errorItem;
                //System.Windows.Forms.MessageBox.Show(errorItem);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + errorItem + "')</script>");
            }
        }
        else if (res == -1003)
        {
            // Failed in Validation (Over InStock)
            // Find the wrong retrieve number and send Message
            string errorItem = "";
            foreach (DisbursementModel dm in list)
                if (dm.GivenNumber > dm.RetrivedNumber)
                    errorItem += dm.ItemDesp + "\r\n";
            if (errorItem.Length > 0)
            {
                errorItem = "These Items put more given quantity than retrieved: \r\n" + errorItem;
                //System.Windows.Forms.MessageBox.Show(errorItem);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + errorItem + "')</script>");
            }
        }
    }
}