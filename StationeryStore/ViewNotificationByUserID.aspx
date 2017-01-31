<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="ViewNotificationByUserID.aspx.cs" Inherits="Notification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" HtmlEncode="True"/>
                <asp:BoundField DataField="Message"  ItemStyle-Width="60%" HeaderText="Message" SortExpression="Message" HtmlEncode="False" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" HtmlEncode="False"/>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Team5ADProjectConnectionString %>" SelectCommand="SELECT [Subject], [Message], [Date] FROM [Notification] WHERE ([UserID] = @UserID) ORDER BY [Date] DESC">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="null" Name="UserID" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        </asp:Content>
