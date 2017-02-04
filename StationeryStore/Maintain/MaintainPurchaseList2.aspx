<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MaintainPurchaseList2.aspx.cs" Inherits="MaintainPurchaseList2" EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />

    <center><h3><B>Item List</B></h3>

          <div class="input-group" id="searchbar" style="margin-left: 20px; margin-right: 20px; margin-top: 20px; margin-bottom: 20px;">
              <asp:TextBox ID="SearchTextBox" runat="server" cssClass="form-control" placeholder="Search for..."></asp:TextBox>
      <span class="input-group-btn">
          <asp:Button ID="SearchBtn" style="color:#D9853B" runat="server" OnClick="SearchBtn_Click" Text="Search" CssClass="btn btn-default" />
      </span>
    </div>
 
       </center>
           &nbsp;&nbsp;
           <asp:Button ID="ShowAllBtn" runat="server" Text="Show All" OnClick="ShowAllBtn_Click" CssClass="buttonsmall" />

       <center><asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="ItemID" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" Width="98%"
              OnRowDataBound="GridView1_RowDataBound"  AllowPaging="True" CssClass="table table-hover table-striped"
            OnPageIndexChanging="GridView1_PageIndexChanging" ViewStateMode="Enabled" PageSize="30">
                    <RowStyle CssClass="cursor-pointer" />
                    <PagerStyle CssClass="pagination-ys" />
       

        </asp:GridView></center> 
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="button" />
</asp:Content>
