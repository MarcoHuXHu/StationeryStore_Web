﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="Order_OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
<div>
         <center>  <h3><b>Order List</b></h3>
        &nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Choose Status: "></asp:Label>
        <asp:DropDownList ID="SearchDDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="SearchDDL_SelectedIndexChanged">
        </asp:DropDownList></center>
    </div>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="OrderBtn" runat="server" Text="New Order" OnClick="OrderBtn_Click" CssClass="buttonm" />
     <br />
&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Font-Size="Medium" ForeColor="Black" Text="Label" Font-Bold="True"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Red"></asp:Label>
        <br />
       <center> <asp:GridView ID="OrderListGV"  CssClass="table table-hover table-striped"  runat="server" OnSelectedIndexChanged="OrderListGV_SelectedIndexChanged" Width="98%" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="OrderListGV_PageIndexChanging">
                                       <RowStyle CssClass="cursor-pointer" />
                    <PagerStyle CssClass="pagination-ys" />
             <Columns>
             <asp:TemplateField HeaderText="OrderID">
                <ItemTemplate>
                    <asp:Label ID="orderid" runat="server" Text='<%#Eval("orderId") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ItemID">
                <ItemTemplate>
                    <asp:Label ID="itemid" runat="server" Text='<%#Eval("itemId") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

        <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="desc" runat="server" Text='<%#Eval("description") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="qty" runat="server" Text='<%#Eval("quantity") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Justification">
                <ItemTemplate>
                    <asp:Label ID="justification" runat="server" Text='<%#Eval("justification") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

                 <asp:TemplateField HeaderText="OrderDate">
                <ItemTemplate>
                    <asp:Label ID="orderdate" runat="server" Text='<%#Eval("orderdate") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="stt" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

    
                <asp:ButtonField CommandName="Select" Text="Proceed" />
            </Columns>
        </asp:GridView></center>
        </asp:Content>

