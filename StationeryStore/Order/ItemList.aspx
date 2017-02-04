<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ItemList.aspx.cs" Inherits="Order_ItemList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
     <div>
     <center>  <h3><b>Item List</b></h3>
     <div class="input-group" id="searchbar" style="margin-left: 20px; margin-right: 20px; margin-top: 20px; margin-bottom: 20px;">
        <asp:TextBox ID="SearchTextBox" runat="server" MaxLength="70" ToolTip="Search by Item Description" cssClass="form-control" placeholder="Search for..."></asp:TextBox>
      <span class="input-group-btn">
          <asp:Button ID="SearchBtn" style="color:#D9853B" runat="server" OnClick="SearchBtn_Click" Text="Search" CssClass="btn btn-default" />
      </span></center>
    </div>
           
           &nbsp;&nbsp;
           
           <asp:Button ID="ShowAllBtn" runat="server" Text="Show All" OnClick="ShowAllBtn_Click" CssClass="buttonm"/>
        <br />
        <br />
&nbsp;&nbsp;
       </div>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label>
        <br />
           <center>     <asp:GridView ID="GridView1" CssClass="table table-hover table-striped" runat="server" OnRowCreated="GridView1_RowCreated" DataKeyNames="ItemID" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" Width="98%">
                                 <RowStyle CssClass="cursor-pointer" />
                    <PagerStyle CssClass="pagination-ys" />
                     <Columns>
             <asp:TemplateField HeaderText="ItemID">
                <ItemTemplate>
                    <asp:Label ID="itemid" runat="server" Text='<%#Eval("ItemID") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:Label ID="category" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="description" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

                  <asp:TemplateField HeaderText="Reorder Level">
                <ItemTemplate>
                    <asp:Label ID="reorderLevel" runat="server" Text='<%#Eval("ReorderLevel") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Reorder Quantity">
                <ItemTemplate>
                    <asp:Label ID="reorderQty" runat="server" Text='<%#Eval("ReorderQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Unit of Measure">
                <ItemTemplate>
                    <asp:Label ID="uom" runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
           </Columns>
        </asp:GridView></center>
        <br />
</asp:Content>

