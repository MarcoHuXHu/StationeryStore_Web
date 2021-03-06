﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MaintainPurchaseList1.aspx.cs" Inherits="MaintainPurchaseList1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
    

      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  Select Supplier<asp:DropDownList ID="DropDownList1" runat="server" onselectedindexchanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" ViewStateMode="Enabled"></asp:DropDownList>
    <center>
         <asp:GridView ID="GridView1"  runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" Height="242px"  onrowcancelingedit="GridView1_RowCancelingEdit" 
   onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" onrowdeleting="GridView1_OnRowDeleting" Width="98%">
            <RowStyle CssClass="cursor-pointer" />
            <Columns>
                
<asp:BoundField DataField="ItemID" HeaderText="ItemID" ReadOnly="true" />
                <asp:BoundField DataField="Description" HeaderText="ItemDescription" ReadOnly="true" />
            
                 <asp:TemplateField HeaderText="Price">
          <ItemTemplate>
              <%# Eval("Price")%> 
          </ItemTemplate>
          <EditItemTemplate>
              <asp:TextBox runat="server" ID="txtPrice" Text='<%# Eval("Price")%>' />
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
ErrorMessage="RegularExpressionValidator" ControlToValidate="txtPrice"
ValidationExpression="[0-9]{1,2}.[0-9]{2}"
ForeColor="Red">Invalid price. please input with 2 decimal places. max price set to $99.99</asp:RegularExpressionValidator>
             
          </EditItemTemplate>
      </asp:TemplateField>
                <asp:BoundField DataField="UOM" HeaderText="Unit of Measure" ReadOnly="true" />
                
                <asp:TemplateField HeaderText="Priority">
          <ItemTemplate>
              <%# Eval("Priority")%>
          </ItemTemplate>
          <EditItemTemplate>
                 
              <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                  <asp:ListItem>1</asp:ListItem>
                  <asp:ListItem>2</asp:ListItem>
                  <asp:ListItem>3</asp:ListItem>
                 
              </asp:DropDownList>
              
          </EditItemTemplate>
      </asp:TemplateField>
         
                
                <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true"  ControlStyle-CssClass="buttonm" />
                
                <asp:CommandField ShowDeleteButton="true" ButtonType="Button"  ControlStyle-CssClass="buttonm" />
                    
            </Columns>
        </asp:GridView></center>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Item" CssClass="button" />

</asp:Content>
