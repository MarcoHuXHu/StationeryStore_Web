﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MaintainCatalogueList1.aspx.cs" Inherits="MaintainCatalogueList1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet"/>
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet"/>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
    <center><h3><B>Catalogue List</B></h3> 
        
        <asp:GridView Width="95%" ID="GridView1"  runat="server" AutoGenerateColumns="False" Height="242px"  onrowcancelingedit="GridView1_RowCancelingEdit" 
   onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" onrowdeleting="GridView1_OnRowDeleting"
            AllowPaging="True" 
            CssClass="table table-hover table-striped"
            OnPageIndexChanging="GridView1_PageIndexChanging"  PageSize="30">
             <RowStyle CssClass="cursor-pointer" />
                    <PagerStyle CssClass="pagination-ys" />
            
            <Columns>
                <asp:BoundField DataField="ItemID" HeaderText="ItemID" ReadOnly="true" />
                
                <asp:TemplateField HeaderText="Description">
          <ItemTemplate>
            <%# Eval("Description")%>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:TextBox runat="server" ID="txtDescription" Text='<%# Eval("Description")%>' />
          </EditItemTemplate>
      </asp:TemplateField>
                 <asp:TemplateField HeaderText="Category">
          <ItemTemplate>
              <%# Eval("Category")%> 
          </ItemTemplate>
          <EditItemTemplate>
               <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"></asp:DropDownList>
          </EditItemTemplate>
      </asp:TemplateField>
                <asp:TemplateField HeaderText="Reorder Level">
          <ItemTemplate>
              <%# Eval("ReorderLevel")%>
          </ItemTemplate>
          <EditItemTemplate>
              <asp:TextBox runat="server" ID="txtReorderLevel" Text='<%# Eval("ReorderLevel")%>' />
               <asp:RangeValidator ID="RangeValidator1" runat="server"
ErrorMessage="RangeValidator" ControlToValidate="txtReorderLevel"
ForeColor="Red" Type="Integer"
MaximumValue="999" MinimumValue="1">please input positive integer!</asp:RangeValidator>
          </EditItemTemplate>
      </asp:TemplateField>
                <asp:TemplateField HeaderText="Reorder Qty">
          <ItemTemplate>
              <%# Eval("ReorderQty")%>
          </ItemTemplate>
          <EditItemTemplate>
              <asp:TextBox runat="server" ID="txtReorderQty" Text='<%# Eval("ReorderQty")%>' />
              <asp:RangeValidator ID="RangeValidator2" runat="server"
ErrorMessage="RangeValidator" ControlToValidate="txtReorderQty"
ForeColor="Red" Type="Integer"
MaximumValue="999" MinimumValue="1">please input positive integer!</asp:RangeValidator>
          </EditItemTemplate>
      </asp:TemplateField>
                <asp:TemplateField HeaderText="Unit of Measure">
          <ItemTemplate>
              <%# Eval("UOM")%>
          </ItemTemplate>
          <EditItemTemplate>
             
              <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                  <asp:ListItem>Box</asp:ListItem>
                  <asp:ListItem>Dozen</asp:ListItem>
                  <asp:ListItem>Each</asp:ListItem>
                  <asp:ListItem>Packet</asp:ListItem>
                  <asp:ListItem>Set</asp:ListItem>
              </asp:DropDownList>
          </EditItemTemplate>
      </asp:TemplateField>
                
                
                <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" ControlStyle-CssClass="buttonm" />
                
                <asp:CommandField ShowDeleteButton="true" ButtonType="Button"  ControlStyle-CssClass="buttonm" />
                    
            </Columns>
        </asp:GridView> </center> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Item" CssClass="button" />

</asp:Content>
