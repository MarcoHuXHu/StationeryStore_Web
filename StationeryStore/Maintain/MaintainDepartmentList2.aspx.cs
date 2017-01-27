using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MaintainDepartmentList2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            string chosenCollectionPoint = DropDownList1.SelectedValue;
        }
        
    


}

    protected void Button1_Click(object sender, EventArgs e)
    {
        Team5ADProjectEntities model = new Team5ADProjectEntities();
        string DeptID = TextBox1.Text;
        string collectionpoint = DropDownList1.SelectedValue;
        string departmentname = TextBox3.Text;
        string contact = TextBox4.Text;
        string tel = TextBox5.Text;
        string headname = TextBox6.Text;
        string repName = TextBox7.Text;
        string contactID = TextBox8.Text;
        string headID = TextBox9.Text;
        string repID = TextBox10.Text;

        if (headID == repID)
        {
            throw new Exception("head cannot be same as rep");
        }

        //Work.CreateDepartment(DeptID, departmentname, contact,
        //tel, collectionpoint);
        Department toAddDepartment = new Department();


        toAddDepartment.DepartmentID = DeptID;
        toAddDepartment.DepartmentName = departmentname;
        toAddDepartment.ContactName = contact;
        toAddDepartment.Telephone = tel;

        toAddDepartment.Collection_Point = collectionpoint;


        model.Departments.Add(toAddDepartment);
        try
        {
            model.SaveChanges();
        }

        catch (DbEntityValidationException ex)
        {
            string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
            throw new DbEntityValidationException(errorMessages);
        }

        Staff contactPerson = model.Staffs.Where(p => p.UserID == contactID).First();
      
        Staff departmentHead = model.Staffs.Where(p => p.UserID == headID).First();
        Staff departmentRep = model.Staffs.Where(p => p.UserID == repID).First();

        if (contactPerson.Role=="DeptHead" || contactPerson.Role=="DeptRep" || departmentHead.Role=="DeptHead"
            || departmentHead.Role=="DeptRep"||departmentRep.Role=="DeptHead"||departmentRep.Role=="DeptRep")
        {
            throw new Exception("cannot select existing department head or department rep!");
        }

        else
        {
            contactPerson.DepartmentID = DeptID;
            departmentHead.Role = "DeptHead";
            departmentHead.DepartmentID = DeptID;

            departmentRep.Role = "DeptRep";
            departmentRep.DepartmentID = DeptID;
            model.SaveChanges();
            Response.Redirect("MaintainDepartmentList1.aspx");
        }
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintainDepartmentList1.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {

        Team5ADProjectEntities model = new Team5ADProjectEntities();
        string contactID = TextBox8.Text;

        Staff toSearch = model.Staffs.Where(p => p.UserID == contactID).First();

        string contactName = toSearch.Name;
        TextBox4.Text = contactName;

        string headID = TextBox9.Text;

        Staff toSearchHead = model.Staffs.Where(p => p.UserID == headID).First();

        string HeadName = toSearchHead.Name;
        TextBox6.Text = HeadName;

        string repID = TextBox10.Text;

        Staff toSearchRep = model.Staffs.Where(p => p.UserID == repID).First();

        string repName = toSearchRep.Name;
        TextBox7.Text = repName;
    }
}