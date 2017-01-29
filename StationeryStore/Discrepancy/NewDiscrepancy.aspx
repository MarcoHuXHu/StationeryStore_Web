<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="NewDiscrepancy.aspx.cs" Inherits="NewDiscrepancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Item Code:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Description:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Value($):"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true"></asp:TextBox>
            per item<br />
            <br />
            <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="*Negative(-): decrease stock number. Positive: increase stock number."></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Quantity:"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            &nbsp;
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Reason:"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" CssClass="button" />
        </div>

</asp:Content>
