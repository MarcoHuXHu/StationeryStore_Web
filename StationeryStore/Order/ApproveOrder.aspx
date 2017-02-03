﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApproveOrder.aspx.cs" Inherits="Order_ApproveOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
        <asp:Label ID="Label1" runat="server" Text="Pending Approval" Font-Bold="True"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Order/OrderHistory.aspx">Order History</asp:HyperLink>
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black" Text="Label"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated" OnRowCommand="GridView1_RowCommand" Width="472px">
            <Columns>

                <asp:ButtonField ButtonType="Button" CommandName="Approve" Text="Approve" ControlStyle-CssClass="buttonsmall" />
                <asp:ButtonField ButtonType="Button" CommandName="Reject" Text="Reject" ControlStyle-CssClass="buttonsmall" />
            </Columns>
        </asp:GridView>  
        <asp:Label ID="ConfirmLbl" runat="server" Font-Bold="True" ForeColor="Black" Text="Label"></asp:Label>
        <asp:Button ID="YesBtn" runat="server" OnClick="YesBtn_Click" Text="Yes" CssClass="buttonm" />
        &nbsp;<asp:Button ID="NoBtn" runat="server" OnClick="NoBtn_Click" Text="No" CssClass="buttonm" />
        <br />
        <asp:Label ID="ReasonLbl" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label>
        <br />
        <asp:TextBox ID="ReasonTextBox" runat="server" Height="71px" TextMode="MultiLine" MaxLength="150"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" CssClass="button" />
        <br />
        <br />
    </div>
</asp:Content>

