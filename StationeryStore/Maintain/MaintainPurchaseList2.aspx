<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MaintainPurchaseList2.aspx.cs" Inherits="MaintainPurchaseList2" EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="Item List" Font-Bold="True" Font-Size="Larger"></asp:Label>
           <br />
           <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>
           <asp:Button ID="SearchBtn" runat="server" Text="Search" OnClick="SearchBtn_Click" CssClass="buttonsmall" />
           &nbsp; 
           <asp:Button ID="ShowAllBtn" runat="server" Text="Show All" OnClick="ShowAllBtn_Click" CssClass="buttonsmall" />
    </div>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="ItemID" 
            onselectedindexchanged="GridView1_SelectedIndexChanged"
              OnRowDataBound="GridView1_RowDataBound"  AllowPaging="True" 
            OnPageIndexChanging="GridView1_PageIndexChanging" ViewStateMode="Enabled" PageSize="30">
       

        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="button" />
</asp:Content>
