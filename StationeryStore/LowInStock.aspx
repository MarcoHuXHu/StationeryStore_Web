<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LowInStock.aspx.cs" Inherits="LowInStock" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
     <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
       <br />
  <asp:Label ID="Label1" runat="server" Text="Reminder: Below items are in low stock. Please proceed to order." Font-Size="Medium" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <center><asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" Width="95%">
                            <RowStyle CssClass="cursor-pointer" />
        <Columns>
        <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:HyperLink Text="Order" runat="server" NavigateUrl='<%# "~/Order/MakeNewOrder.aspx?ItemID="+Eval("ItemID")+"&Description="+Eval("Description") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
    </asp:GridView></center>
</asp:Content>

