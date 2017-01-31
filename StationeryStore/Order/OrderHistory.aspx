<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderHistory.aspx.cs" Inherits="Order_OrderHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
     <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Label ID="Label2" runat="server" Text="Order History" Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Choose Status:"></asp:Label>
                <asp:DropDownList ID="SearchDDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SearchDDL_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="Label"></asp:Label>
        <br />
        <asp:GridView ID="HistoryGV" runat="server" Width="248px"></asp:GridView>
    </div>
</asp:Content>

