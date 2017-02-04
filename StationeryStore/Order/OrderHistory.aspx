<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderHistory.aspx.cs" Inherits="Order_OrderHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
    <div>
       <center> <h3><b>Order History</b></h3>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Choose Status:"></asp:Label>
&nbsp;<asp:DropDownList ID="SearchDDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SearchDDL_SelectedIndexChanged">
        </asp:DropDownList></center>
        <br />
        &nbsp;
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black" Text="Label"></asp:Label>
        <br />
        <center>
        <asp:GridView ID="HistoryGV" runat="server" Width="98%" CssClass="table table-hover table-striped" AllowPaging="True" OnPageIndexChanging="HistoryGV_PageIndexChanging">
                                <RowStyle CssClass="cursor-pointer" />
                    <PagerStyle CssClass="pagination-ys" />
        </asp:GridView></center>
    </div>
</asp:Content>

