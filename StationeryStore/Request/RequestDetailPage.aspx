﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RequestDetailPage.aspx.cs" Inherits="RequestDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="98%" CssClass="table table-hover table-striped">
        <RowStyle CssClass="cursor-pointer" />
        <Columns>

                <asp:TemplateField HeaderText="Request Date">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("RequestDate") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UOM">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Request Qty">
                    <ItemTemplate>
                        <asp:Label runat="server"  Text='<%#Eval("RequestQty") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comment">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Comment") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
           

            </Columns>
    </asp:GridView>

    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowCommand" Width="98%" CssClass="table table-hover table-striped">
            <RowStyle CssClass="cursor-pointer" />
            <Columns>
                <asp:TemplateField HeaderText="Request Date">
                    <ItemTemplate>                        
                        <asp:Label runat="server" Text='<%#Eval("RequestDate") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="UOM">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Request Qty">
                    <ItemTemplate>
                        <asp:TextBox ID="quantity" runat="server" Required="true" TextMode="Number" min="1" Text='<%#Eval("RequestQty") %>'></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comment">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("Comment") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkdelete" runat="server" CommandName="Delete" >Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel Request" OnClick="ButtonCancel_Click" CssClass="button" />
        &nbsp;<asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" CssClass="button" />
        <br />
        <br />
    </asp:Panel>

</asp:Content>

