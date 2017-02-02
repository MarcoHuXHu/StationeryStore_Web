using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class myYear
{
    Work Work = new Work();
    public int value { get; set; }
    public string text { get; set; }
    public myYear() { }
    public myYear(int year)
    {
        value = year;
        text = "Year: " + year.ToString();
    }
}

public class myMonth
{
    public int value { get; set; }
    public string text { get; set; }
    public myMonth() { }
    public myMonth(int month)
    {
        value = month;
        text = "Month: " + (new DateTime(1, month, 1)).ToString("MMMM");
    }
}

public class myWeek
{
    public DateTime value { get; set; }
    public int numOfWeek { get; set; }
    public string text { get; set; }
    public myWeek() { }
    public myWeek(DateTime time, int no)
    {
        value = time;
        numOfWeek = no;
        DateTime next = time.AddDays(6);
        text = "Week " + no + "(" + time.ToString("dd MMMM") + " to " + next.ToString("dd MMMM") + ")";
    }
}

public partial class Request_DisbursementHistory : System.Web.UI.Page
{
    int startYear = 2010;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PanelSummary.Visible = true;
            PanelDept.Visible = false;
            // Add data to DropDownYear
            addYear();
            // Add data to DropDownMonth
            addMonth();
            // Add data to DropDownWeek
            addWeek();
            // Got selected startDate and EndDate, show the History
            getData();
        }
    }

    // Select Year changed, change Month and Week
    protected void DropDownYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Add data to DropDownMonth
        addMonth();
        // Add data to DropDownWeek
        addWeek();
        // Got selected startDate and EndDate, show the History
        getData();
    }

    protected void DropDownMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Add data to DropDownWeek
        addWeek();
        // Got selected startDate and EndDate, show the History
        getData();
    }

    protected void DropDownWeek_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Got selected startDate and EndDate, show the History
        getData();
    }

    private void addYear()
    {
        DateTime now = DateTime.Now;
        while (now.DayOfWeek != DayOfWeek.Monday)
            now = now.AddDays(-1);
        now = now.AddDays(-7);
        int year = now.Year;
        List<myYear> yearlist = new List<myYear>();
        while (year >= startYear)
        {
            yearlist.Add(new myYear(year));
            year--;
        }
        DropDownYear.DataSource = yearlist;
        DropDownYear.DataValueField = "value";
        DropDownYear.DataTextField = "text";
        DropDownYear.DataBind();

    }
    private void addMonth()
    {
        DateTime now = DateTime.Now;
        while (now.DayOfWeek != DayOfWeek.Monday)
            now = now.AddDays(-1);
        now = now.AddDays(-7);
        int endMonth = 12;
        List<myMonth> monthlist = new List<myMonth>();
        if (DropDownYear.SelectedValue == now.Year.ToString())
            endMonth = now.Month;
        for (int i = 1; i <= endMonth; i++)
            monthlist.Add(new myMonth(i));
        DropDownMonth.DataSource = monthlist;
        DropDownMonth.DataValueField = "value";
        DropDownMonth.DataTextField = "text";
        DropDownMonth.DataBind();
    }

    private void addWeek()
    {
        List<myWeek> weeks = new List<myWeek>();
        int year = int.Parse(DropDownYear.SelectedValue);
        int month = int.Parse(DropDownMonth.SelectedValue);
        DateTime time = new DateTime(year, month, 1);
        DateTime end = time.AddMonths(1);
        //bool samemonth = false;
        DateTime now = DateTime.Now;
        while (now.DayOfWeek != DayOfWeek.Monday)
            now = now.AddDays(-1);
        now = now.AddDays(-7);
        if ((year == now.Year) && (month == now.Month))
        {
            end = new DateTime(now.Year, now.Month, now.Day);
            //samemonth = true;
        }
        while (time < end)
        {
            if (time.DayOfWeek == DayOfWeek.Monday) break;
            time = time.AddDays(1);
        }
        int i = 1;
        while (time <= end)
        {
            //if ((samemonth) && (time.AddDays(7) > end)) break;
            //if (time.AddDays(7) > now) break;
            weeks.Add(new myWeek(time, i));
            time = time.AddDays(7);
            i++;
        }
        DropDownWeek.DataSource = weeks;
        DropDownWeek.DataValueField = "value";
        DropDownWeek.DataTextField = "text";
        DropDownWeek.DataBind();
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "ViewSummary")
        {
            PanelSummary.Visible = true;
            PanelDept.Visible = false;
            //List<DisbursementLog> list = (List<DisbursementLog>)ViewState["listBySummary"];
            //GridViewSummary.DataSource = list;
            //GridViewSummary.DataBind();

        }


        else if (RadioButtonList1.SelectedValue == "ViewByDepartment")
        {
            PanelSummary.Visible = false;
            PanelDept.Visible = true;
            //List<DisbursementLog> list = (List<DisbursementLog>)ViewState["listByDept"];
            //GridViewDept.DataSource = list;
            //GridViewDept.DataBind();

        }
    }


    protected void GridViewDept_Sorting(object sender, GridViewSortEventArgs e)
    {
        List<DisbursementModel> list = (List<DisbursementModel>)this.ViewState["listByDept"];

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


    private void getData()
    {
        List<DisbursementModel> showlistBySummary = new List<DisbursementModel>();
        List<DisbursementModel> showlistByDepartment = new List<DisbursementModel>();

        HistoryDisbursement clerk = new HistoryDisbursement();
        DateTime time = DateTime.Parse(DropDownWeek.SelectedValue);
        //DateTime start = new DateTime(time.Year, time.Month, time.Day, 23, 59, 59);
        DateTime start = time.AddDays(1);
        DateTime end = time.AddDays(8);
        clerk.GetHistory(start, end);

        //List<DisbursementLog> listBySummary = new List<DisbursementLog>();
        foreach (DisbursementLog log in clerk.SummaryByItem.Values)
        {
            //listBySummary.Add(log);
            DisbursementModel dm = new DisbursementModel(log.ItemID, log.Item.Description, (int)log.NeededNumber, log.Item.InStock, log.Item.BinNumber, (int)log.RetrivedNumber);
            dm.GivenNumber = (int)log.GivenNumber;
            showlistBySummary.Add(dm);

        }

        //List<DisbursementLog> listByDepartment = new List<DisbursementLog>();
        foreach (Dictionary<string, DisbursementLog> dic in clerk.SummaryByDepartment.Values)
        {
            foreach (DisbursementLog log in dic.Values)
            {
                DisbursementModel dm = new DisbursementModel(log.DepartmentID, log.Department.DepartmentName, log.ItemID, log.Item.Description, (int)log.NeededNumber, log.Item.InStock, (int)log.RetrivedNumber);
                dm.GivenNumber = (int)log.GivenNumber;
                showlistByDepartment.Add(dm);
            }
        }

        GridViewSummary.DataSource = showlistBySummary;
        GridViewSummary.DataBind();
        GridViewDept.DataSource = showlistByDepartment;
        GridViewDept.DataBind();

        ViewState["listBySummary"] = showlistBySummary;
        ViewState["listByDept"] = showlistByDepartment;

    }
}