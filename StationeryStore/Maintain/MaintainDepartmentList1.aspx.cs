using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MaintainDepartmentList1 : System.Web.UI.Page
{
    Work Work = new Work();
    protected void Page_Load(object sender, EventArgs e)
    {
        Team5ADProjectEntities model = new Team5ADProjectEntities();
        if (!IsPostBack)
        {

            var query = from head in model.Staffs.Where(head => head.Role == "DeptHead")
                        join rep in model.Staffs.Where(rep => rep.Role == "DeptRep")
                        on head.DepartmentID equals rep.DepartmentID
                        join
                        department in model.Departments
                        on head.DepartmentID equals department.DepartmentID
                        select new
                        {
                            ID = department.DepartmentID,
                            DepartmentName = department.DepartmentName,
                            ContactName = department.ContactName,
                            Telephone = department.Telephone,
                            DeptHead = head.Name,
                            CollectionPoint = department.Collection_Point,
                            DeptRep = rep.Name,

                        };


            GridView1.DataSource = query.ToList();
            GridView1.DataBind();
            

        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        Team5ADProjectEntities model = new Team5ADProjectEntities();
        GridView1.EditIndex = e.NewEditIndex;
        GridViewRow row = GridView1.Rows[e.NewEditIndex];

       

        var query = from head in model.Staffs.Where(head => head.Role == "DeptHead")
                    join rep in model.Staffs.Where(rep => rep.Role == "DeptRep")
                    on head.DepartmentID equals rep.DepartmentID
                    join
                    department in model.Departments
                    on head.DepartmentID equals department.DepartmentID
                    select new
                    {
                        ID = department.DepartmentID,
                        DepartmentName = department.DepartmentName,
                        ContactName = department.ContactName,
                        Telephone = department.Telephone,
                        DeptHead = head.Name,
                        CollectionPoint = department.Collection_Point,
                        DeptRep = rep.Name,

                    };


        GridView1.DataSource = query.ToList();

        GridView1.DataBind();
        string deptID = row.Cells[0].Text;
        DropDownList DropDownList2 = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList2");
        DropDownList2.DataSource = GetStaff(deptID);
        
        DropDownList2.DataTextField = "Name";
        DropDownList2.DataValueField = "UserID";
        DropDownList2.DataBind();
        Department affectedDepartment = new Department();
        affectedDepartment = model.Departments.Where(department => department.DepartmentID == deptID).First();
        Staff contactPerson = new Staff();
        contactPerson = model.Staffs.Where(s=>s.Name==affectedDepartment.ContactName).First();
        DropDownList2.SelectedValue = contactPerson.UserID;
        DropDownList DropDownList3 = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList3");
        DropDownList3.DataSource = GetStaff(deptID);

        DropDownList3.DataTextField = "Name";
        DropDownList3.DataValueField = "UserId";
        DropDownList3.DataBind();
        Staff existingDeptRep = new Staff();
        existingDeptRep = model.Staffs.Where(staff => staff.Role == "DeptRep" &&
        staff.DepartmentID == deptID).First();
        DropDownList3.SelectedValue = existingDeptRep.UserID;
        DropDownList DropDownList4 = (DropDownList)GridView1.Rows[e.NewEditIndex].FindControl("DropDownList4");
        DropDownList4.DataSource = GetStaff(deptID);

        DropDownList4.DataTextField = "Name";
        DropDownList4.DataValueField = "UserId";
        DropDownList4.DataBind();


        Staff existingDeptHead = new Staff();
        //List<Staff> stafflistofdeptHead = new List<Staff>();
        existingDeptHead = model.Staffs.Where(staff => staff.Role == "DeptHead" &&
        staff.DepartmentID == deptID).First();
        DropDownList4.SelectedValue = existingDeptHead.UserID;
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        e.Cancel = true;
        GridView1.EditIndex = -1;

        Team5ADProjectEntities model = new Team5ADProjectEntities();
        var query = from head in model.Staffs.Where(head => head.Role == "DeptHead")
                    join rep in model.Staffs.Where(rep => rep.Role == "DeptRep")
                    on head.DepartmentID equals rep.DepartmentID
                    join
                    department in model.Departments
                    on head.DepartmentID equals department.DepartmentID
                    select new
                    {
                        ID = department.DepartmentID,
                        DepartmentName = department.DepartmentName,
                        ContactName = department.ContactName,
                        Telephone = department.Telephone,
                        DeptHead = head.Name,
                        CollectionPoint = department.Collection_Point,
                        DeptRep = rep.Name,

                    };


        GridView1.DataSource = query.ToList();

        GridView1.DataBind();



    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];

		string departmentCode = row.Cells[0].Text;
        TextBox txtDepartmentName = (TextBox)row.FindControl("txtDepartmentName");
 
 
        TextBox txtTelephone = (TextBox)row.FindControl("txtTelephone");
        
        DropDownList dropdownlist1 = (DropDownList)row.FindControl("DropDownList1");
        DropDownList dropdownlist2 = (DropDownList)row.FindControl("DropDownList2");
        DropDownList dropdownlist3 = (DropDownList)row.FindControl("DropDownList3");
        DropDownList dropdownlist4 = (DropDownList)row.FindControl("DropDownList4");

       

        string DepartmentName = txtDepartmentName.Text;
        //string ContactName = dropdownlist2.SelectedValue;
        string Telephone = txtTelephone.Text;
        string HeadID = dropdownlist4.SelectedValue;
        string Collection_Point = dropdownlist1.SelectedValue; 
        string RepresentativeID = dropdownlist3.SelectedValue;
        string contactPersonID = dropdownlist2.SelectedValue;
        //string SupplierCode = GridView1.DataKeys[e.RowIndex].Value.ToString();
		        
        //System.Diagnostics.Debug.WriteLine(RepresentativeID);
        //System.Diagnostics.Debug.WriteLine(contactPersonID);
        //System.Diagnostics.Debug.WriteLine("SomeText");
        //System.Diagnostics.Debug.WriteLine("SomeText");
        //string departmentCode = row.Cells[0].Text;

        Team5ADProjectEntities model = new Team5ADProjectEntities();
        //List<Department> departmentlist = new List<Department>();
        Department affectedDepartment = new Department();
        affectedDepartment = model.Departments.Where(department => department.DepartmentID == departmentCode).First();

        affectedDepartment.DepartmentName = DepartmentName;
        //affectedDepartment.ContactName = ContactName;
        affectedDepartment.Telephone = Telephone;
		Staff contactPerson = new Staff();
        contactPerson=model.Staffs.Where(staff => staff.UserID == contactPersonID).First();
        affectedDepartment.ContactName = contactPerson.Name;

        affectedDepartment.Collection_Point = Collection_Point;

        Staff existingDeptHead = new Staff();
        //List<Staff> stafflistofdeptHead = new List<Staff>();
        existingDeptHead = model.Staffs.Where(staff => staff.Role == "DeptHead" &&
        staff.DepartmentID == departmentCode).First();
        //foreach (Staff c in stafflistofdeptHead)
        //{
        existingDeptHead.Role = "Employee";
            //stafflistofdeptHead.Remove(c);

        //}
                Staff existingDeptRep = new Staff();
        existingDeptRep = model.Staffs.Where(staff => staff.Role == "DeptRep" &&
        staff.DepartmentID == departmentCode).First();
        existingDeptRep.Role = "Employee";

        if (dropdownlist4.SelectedValue==dropdownlist3.SelectedValue)
        {
            throw new Exception("head cannot be same as rep");
        }
        if (dropdownlist2.SelectedValue==dropdownlist4.SelectedValue)
        {
            
            contactPerson.Role = "DeptHead";
            Staff toAddtoListofRep = new Staff();
            toAddtoListofRep = model.Staffs.Where(staff => staff.UserID == RepresentativeID).First();
            toAddtoListofRep.Role = "DeptRep";
        }
		//Staff toAddtoList = new Staff();
        //toAddtoList = model.Staffs.Where(staff => staff.UserID==HeadID).First();
		else if (dropdownlist2.SelectedValue==dropdownlist3.SelectedValue)
        {
            contactPerson.Role = "DeptRep";
            Staff toAddtoList = new Staff();
            toAddtoList = model.Staffs.Where(staff => staff.UserID == HeadID).First();

            toAddtoList.Role = "DeptHead";
        }
        
        else
        {
            Staff toAddtoList = new Staff();
            toAddtoList = model.Staffs.Where(staff => staff.UserID == HeadID).First();

            toAddtoList.Role = "DeptHead";
            Staff toAddtoListofRep = new Staff();
            toAddtoListofRep = model.Staffs.Where(staff => staff.UserID == RepresentativeID).First();
            toAddtoListofRep.Role = "DeptRep";
        }
        //toAddtoList.Role = "DeptHead";
        //stafflistofdeptHead.Add(toAddtoList);

        //Staff existingDeptRep = new Staff();
        //List<Staff> stafflistofdeptRep = new List<Staff>();
        //existingDeptRep = model.Staffs.Where(staff => staff.Role == "DeptRep" &&
        //staff.DepartmentID == departmentCode).First();
        //foreach (Staff c in stafflistofdeptRep)
        //{
        //existingDeptRep.Role = "Employee";
            //stafflistofdeptRep.Remove(c);

        //}
        //Staff toAddtoListofRep = new Staff();
        //toAddtoListofRep = model.Staffs.Where(staff => staff.UserID == RepresentativeID).First();
        //toAddtoListofRep.Role = "DeptRep";
        //stafflistofdeptHead.Add(toAddtoList);
        model.SaveChanges();

        //Work.UpdateDepartment(departmentCode, DepartmentName, ContactName, Telephone, HeadName, Collection_Point, RepresentativeName);


        var query = from head in model.Staffs.Where(head => head.Role == "DeptHead")
                    join rep in model.Staffs.Where(rep => rep.Role == "DeptRep")
                    on head.DepartmentID equals rep.DepartmentID
                    join
                    department in model.Departments
                    on head.DepartmentID equals department.DepartmentID
                    select new
                    {
                        ID = department.DepartmentID,
                        DepartmentName = department.DepartmentName,
                        ContactName = department.ContactName,
                        Telephone = department.Telephone,
                        DeptHead = head.Name,
                        CollectionPoint = department.Collection_Point,
                        DeptRep = rep.Name,

                    };

        GridView1.EditIndex = -1;
        GridView1.DataSource = query.ToList();
        GridView1.DataBind();


       
       


        //UpdateSupplier(SupplierCode,SupplierName,GSTRegistrationNo,ContactName,Phone,Fax,Address);
        //method name: UpdateSupplier
        //input arguments: SupplierCode,SupplierName,GSTRegistrationNo,ContactName,Phone,Fax,Address
        //return type: void
    }

    protected void GridView1_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        Team5ADProjectEntities model = new Team5ADProjectEntities();
        //GridView1.DeleteRow(index);
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string departmentcode = row.Cells[0].Text;

        Work.DeleteDepartment(departmentcode);
        var query = from head in model.Staffs.Where(head => head.Role == "DeptHead")
                    join rep in model.Staffs.Where(rep => rep.Role == "DeptRep")
                    on head.DepartmentID equals rep.DepartmentID
                    join
                    department in model.Departments
                    on head.DepartmentID equals department.DepartmentID
                    select new
                    {
                        ID = department.DepartmentID,
                        DepartmentName = department.DepartmentName,
                        ContactName = department.ContactName,
                        Telephone = department.Telephone,
                        DeptHead = head.Name,
                        CollectionPoint = department.Collection_Point,
                        DeptRep = rep.Name,

                    };
        GridView1.DataSource = query.ToList();
        GridView1.DataBind();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("MaintainDepartmentList2.aspx");
    }

    public static List<Staff> GetStaff(string deptID)
    {
        Team5ADProjectEntities model1 = new Team5ADProjectEntities();
        return model1.Staffs.Where(x=>x.DepartmentID==deptID).ToList<Staff>();
    }



}