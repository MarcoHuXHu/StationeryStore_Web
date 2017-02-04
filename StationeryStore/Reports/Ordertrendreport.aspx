<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Ordertrendreport.aspx.cs" Inherits="Reports_Ordertrendreport" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2> Order Trend Report</h2>
     <p>
        Select 1 or more reporting period (month):&nbsp;&nbsp;<asp:ListBox ID="LBperiod" runat="server" DataSourceID="SqlDataSource4" DataTextField="YYYY/MM" DataValueField="YYYY/MM" Height="73px" SelectionMode="Multiple" Width="165px"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Team5ADProjectConnectionString %>" SelectCommand="SELECT DISTINCT FORMAT(OrderDate, 'yyyy/MM') AS [YYYY/MM] FROM [Order] AS o ORDER BY [YYYY/MM] DESC"></asp:SqlDataSource>

    </p>
    <p>
        Select 1 or more suppliers:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:ListBox ID="LBss" runat="server" DataSourceID="SqlDataSource1" DataTextField="SupplierName" DataValueField="SupplierName" SelectionMode="Multiple" Width="163px" Height="87px"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Team5ADProjectConnectionString %>" SelectCommand="SELECT DISTINCT [SupplierName] FROM [Supplier]"></asp:SqlDataSource>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server">
        </asp:EntityDataSource>

    </p>
    <p>
        Select 1 or more categories:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="LBcate" runat="server" DataSourceID="SqlDataSource2" DataTextField="Category" DataValueField="Category" SelectionMode="Multiple" Width="157px" Height="88px"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Team5ADProjectConnectionString %>" SelectCommand="SELECT DISTINCT [Category] FROM [Item]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Generate Report" CssClass="button" />
    </p>
    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LBperiod" ErrorMessage="*Select 1 or more reporting period"
    ForeColor="Red"></asp:RequiredFieldValidator> <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LBss" ErrorMessage="*Select 1 or more suppliers"
    ForeColor="Red"></asp:RequiredFieldValidator><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LBcate" ErrorMessage="*Select 1 or more categories"
    ForeColor="Red"></asp:RequiredFieldValidator>

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" overflow-x="scroll" />
    <p>
        &nbsp;</p>
</asp:Content>

