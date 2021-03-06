﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AllocateStationery.aspx.cs" Inherits="Request_AllocateStationery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
    <asp:Button ID="ButtonGenerate" runat="server" Text="Generate" OnClick="ButtonGenerate_Click"  CssClass="buttonm"/>
    <asp:GridView ID="GridView1" runat="server" Width="98%" CssClass="table table-hover table-striped"  AutoGenerateColumns="False" AllowSorting="True" OnSorting="GridView1_Sorting" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
        <RowStyle CssClass="cursor-pointer" />
        <PagerStyle CssClass="pagination-ys" />
         <Columns>
            <asp:TemplateField HeaderText="Item Description" SortExpression ="Item">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("description") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Requester" SortExpression ="Requester">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("userName") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Request Date">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("date") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Needed">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("neededQty")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="UOM">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("uom")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Allocated">
                <ItemTemplate>
                    <asp:TextBox width="100px" ID="allocated" runat="server" TextMode="Number" min="0" max ='<%#Eval("neededQty")%>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click1" CssClass="button"/>
    </asp:Content>

