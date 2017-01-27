<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewDiscrepancy.aspx.cs" Inherits="ViewDiscrepancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="New Discrepancy" OnClick="Button1_Click" CssClass="buttonm" />
&nbsp;<asp:Label ID="Label1" runat="server" Text="View By:"></asp:Label>
&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" style="height: 29px">
            <asp:ListItem Value="ShowAll">ShowAll</asp:ListItem>
            <asp:ListItem>Approved</asp:ListItem>
            <asp:ListItem>Rejected</asp:ListItem>
            <asp:ListItem Value="Pending Approval">PendingApproval</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" >
        </asp:GridView>
    
    </div>
</asp:Content>
