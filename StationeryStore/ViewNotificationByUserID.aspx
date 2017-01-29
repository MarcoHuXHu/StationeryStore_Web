﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="ViewNotificationByUserID.aspx.cs" Inherits="Notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" DataKeyNames="NotificationID" Height="48px" Width="310px" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" style="margin-top: 0px">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                
                 <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="Button1" CommandArgument='<%#Eval("NotificationID") %>' runat="server" Text="Details" />
                            </ItemTemplate>
                        </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" style="z-index: 1; left: 573px; top: 18px; position: absolute; width: 390px; height: 108px" TextMode="MultiLine"></asp:TextBox>
</asp:Content>
