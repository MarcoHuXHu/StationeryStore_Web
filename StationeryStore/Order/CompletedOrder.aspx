<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CompletedOrder.aspx.cs" Inherits="Order_CompletedOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />

    <h4><b>Order Details</b></h4>
    <table cellpadding="10">
          <tr>
        <td class="auto-style19">&nbsp;<asp:Label ID="Label1" runat="server" Text="OrderID "></asp:Label></td>
        <td class="auto-style20">&nbsp;&nbsp;&nbsp; :</td>
        <td  class="auto-style21">&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="OrderIDLbl" runat="server" Text="Label"></asp:Label></td>
        </tr>

           <tr>
        <td class="auto-style22">&nbsp;<asp:Label ID="Label2" runat="server" Text="Item ID "></asp:Label></td>
        <td class="auto-style23">&nbsp;&nbsp;&nbsp; :</td>
         <td  class="auto-style24">&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="ItemIDLbl" runat="server" Text="Label"></asp:Label></td>
        </tr>

          <tr>
        <td class="auto-style25">&nbsp;<asp:Label ID="Label3" runat="server" Text="Description "></asp:Label></td>
        <td class="auto-style26">&nbsp;&nbsp;&nbsp; :</td>
              <td  class="auto-style27">&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="DescriptionLbl" runat="server" Text="Label"></asp:Label></td>
        </tr>

          <tr>
        <td class="auto-style28">&nbsp;<asp:Label ID="Label4" runat="server" Text="Total Quantity "></asp:Label></td>
        <td class="auto-style29">&nbsp;&nbsp;&nbsp; :</td>
              <td  class="auto-style30">&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="TotalQtyLbl" runat="server" Text="Label"></asp:Label></td>
        </tr>  
        
        
           <tr>
        <td class="auto-style22">&nbsp;<asp:Label ID="Label6" runat="server" Text="Order Date "></asp:Label></td>
        <td class="auto-style23">&nbsp;&nbsp;&nbsp; :</td>
         <td  class="auto-style24">&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="OrderDateLbl" runat="server" Text="Label"></asp:Label></td>
        </tr>
          
</table>
<br />

    <asp:GridView ID="GridView2" Width="70%" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False">
         <RowStyle CssClass="cursor-pointer" />
              <Columns>
             <asp:TemplateField HeaderText="PurchaseOrderID">
                <ItemTemplate>
                    <asp:Label ID="poid" runat="server" Text='<%#Eval("PurchaseOrderID") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="SupplierID">
                <ItemTemplate>
                    <asp:Label ID="supplierid" runat="server" Text='<%#Eval("SupplierID") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Ordered Quantity">
                <ItemTemplate>
                    <asp:Label ID="ordered" runat="server" Text='<%#Eval("OrderQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
           </Columns>
        </asp:GridView>
</asp:Content>



