﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReceiveConfirmation.aspx.cs" Inherits="Request_ReceiveConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />

    <table style="width:100%;">
        <tr>
            <td>
                <asp:GridView ID="GridViewDept" runat="server" AutoGenerateColumns="False" Width="98%" CssClass="table table-hover table-striped">
                    <RowStyle CssClass="cursor-pointer" />
                    <Columns>
                        <asp:TemplateField HeaderText="DepartmentID" Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("DepartmentID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="DepartmentName" SortExpression="Department" Visible="false">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("DepartmentName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ItemID" SortExpression="Item">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("ItemID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("ItemDesp") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Requested" Visible="true">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("NeededNumber") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Received">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("GivenNumber") %>'></asp:Label>
                                <%--<asp:TextBox ID="received" runat="server" min="0" TextMode="Number" Text='<%#Eval("GivenNumber") %>'></asp:TextBox>--%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                <asp:DetailsView ID="DetailsView" runat="server" Height="50px" Width="125px">
                </asp:DetailsView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ButtonDept0" runat="server" Text="Submit" OnClick="Button0_Click" CssClass="button" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

</asp:Content>

