<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="chargebackreport2.aspx.cs" Inherits="Reports_chargenbackreport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Select
        Start Date:
        <asp:TextBox ID="txtstartdate" runat="server" Height="21px"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="txtstartdate_CalendarExtender" runat="server" TargetControlID="txtstartdate" Format="dd/MM/yyyy" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select End Date:&nbsp;&nbsp;
        <asp:TextBox ID="txtenddate" runat="server" Height="21px"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="txtenddate_CalendarExtender" runat="server" TargetControlID="txtenddate" Format="dd/MM/yyyy" />
        
       
    </p>
    <p>
        Select 1 or more departments:
        <asp:ListBox ID="LBdept" runat="server" DataSourceID="SqlDataSource1" DataTextField="DepartmentID" DataValueField="DepartmentID" Height="114px" Width="148px" SelectionMode="Multiple"></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Team5ADProjectConnectionString %>" SelectCommand="SELECT DISTINCT [DepartmentID] FROM [Department]"></asp:SqlDataSource>
               
    </p>
    <p>
        <asp:Button ID="btnGenrpt" runat="server" Text="Generate Report" OnClick="btnGenrpt_Click" />
       
      
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowValidationErrors="False" Visible="False" />
    
    <p>
    
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtstartdate" ErrorMessage="*Start Date must not be blank"
    ForeColor="Red"></asp:RequiredFieldValidator> </p>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtstartdate"
                  ForeColor="Red" SetFocusOnError="true" ControlToCompare="txtenddate"
                  ErrorMessage="*End Date must be greater than Start Date"
                  Operator="LessThan"
                  ValidationGroup="vg" Type="Date"                           
                  CultureInvariantValues="true"></asp:CompareValidator> &nbsp;&nbsp;<br/> 
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtenddate" ErrorMessage="*End Date must not be blank"
    ForeColor="Red"></asp:RequiredFieldValidator> <br /> 
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LBdept" ErrorMessage="*Select 1 or more departments"
    ForeColor="Red"></asp:RequiredFieldValidator> <br />
    
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
    <p>
        &nbsp;</p>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <p>
        &nbsp;</p>
</asp:Content>

