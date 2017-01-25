using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Request_DeliverByDepartment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Get Data
            Dictionary<string, List<DisbursementModel>> dicByDept = new Dictionary<string, List<DisbursementModel>>();
            List<DisbursementModel> deptList = new List<DisbursementModel>();
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
        List<DisbursementModel> list = (List<DisbursementModel>)GridViewDept.DataSource;
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

            }
        }
    }
}