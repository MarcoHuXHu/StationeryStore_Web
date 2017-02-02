﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ItemList.aspx.cs" Inherits="Order_ItemList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
           <asp:Label ID="Label1" runat="server" Text="Item List" Font-Bold="True" Font-Size="Larger"></asp:Label>
           <br />
           <asp:TextBox ID="SearchTextBox" runat="server" ToolTip="Search by Item Description" MaxLength="70"></asp:TextBox>
           <asp:Button ID="SearchBtn" runat="server" Text="Search" OnClick="SearchBtn_Click" />
           
           <asp:Button ID="ShowAllBtn" runat="server" Text="Show All" OnClick="ShowAllBtn_Click" />
       </div>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label>
        <br />
                <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated" DataKeyNames="ItemID" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
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
        </asp:GridView>
        <br />
</asp:Content>

