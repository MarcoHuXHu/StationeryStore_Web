<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="depttrendreport.aspx.cs" Inherits="Reports_depttrendreport" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style10 {
            margin-left: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <p> <asp:Label ID="Label1" runat="server" Text="Department Trend Report" Font-Bold="True" Font-Size="X-Large" Height="45px"></asp:Label> </p>
    <p>
        Select 1 or more reporting period(months) :
        <asp:ListBox ID="LBmth" runat="server" DataSourceID="SqlDataSource2" DataTextField="YYYY/MM" DataValueField="YYYY/MM" Height="105px" SelectionMode="Multiple" Width="131px"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Team5ADProjectConnectionString %>" SelectCommand="SELECT DISTINCT FORMAT(RequestDate, 'yyyy/MM') AS [YYYY/MM] FROM Request AS r ORDER BY [YYYY/MM] DESC"></asp:SqlDataSource>
    </p>
    <p>
        Select 1 or more departments:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="LBdepts" runat="server" CssClass="auto-style10" DataSourceID="SqlDataSource1" DataTextField="DepartmentID" DataValueField="DepartmentID" Height="102px" SelectionMode="Multiple" Width="136px"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Team5ADProjectConnectionString %>" SelectCommand="SELECT DISTINCT [DepartmentID] FROM [Department]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:Button ID="btn_rpt" runat="server" OnClick="Button1_Click" Text="Generate Report" CssClass="button" /> <br />

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LBmth" ErrorMessage="*Select 1 or more months"
    ForeColor="Red"></asp:RequiredFieldValidator> <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LBdepts" ErrorMessage="*Select 1 or more departments"
    ForeColor="Red"></asp:RequiredFieldValidator> <br />

    </p>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    <p>
        &nbsp;</p>
</asp:Content>

