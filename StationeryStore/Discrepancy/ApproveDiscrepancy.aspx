<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApproveDiscrepancy.aspx.cs" Inherits="ApproveDiscrepancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
        
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Italic="True" Font-Underline="True" Text="Discrepancies"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" DataKeyNames="DiscrepancyID" CssClass="table table-hover table-striped">
                <RowStyle CssClass="cursor-pointer" />
                <Columns>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btn11" CssClass=" buttonsmall" CommandName="Approved" CommandArgument='<%#Eval("DiscrepancyID") %>' runat="server" Text="Approve" />
                            <asp:Button ID="btn12" CssClass=" buttonsmall" CommandName="Rejected" CommandArgument='<%#Eval("DiscrepancyID") %>' runat="server" Text="Reject" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#558C89" Visible="False"></asp:Label>

            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Italic="True" Font-Underline="True" Text="Discrepancy History"></asp:Label>
            <br />
            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" CssClass="table table-hover table-striped" AutoGenerateColumns="False" DataKeyNames="DiscrepancyID" DataSourceID="SqlDataSource1">
                       <RowStyle CssClass="cursor-pointer" />
                    <PagerStyle CssClass="pagination-ys" />
                <Columns>
                    <asp:BoundField DataField="DiscrepancyID" HeaderText="DiscrepancyID" ReadOnly="True" SortExpression="DiscrepancyID" />
                    <asp:BoundField DataField="Name" HeaderText="Requester" SortExpression="Name" />
                    <asp:BoundField DataField="ItemID" HeaderText="ItemID" SortExpression="ItemID" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Team5ADProjectConnectionString %>" SelectCommand="SELECT d.DiscrepancyID, s.Name, d.ItemID, d.Quantity, d.Reason, d.Status FROM Discrepancy AS d INNER JOIN Staff AS s ON d.UserID = s.UserID WHERE (d.Status = 'Approved') OR (d.Status = 'Rejected')"></asp:SqlDataSource>
            <br />

  </asp:Content>