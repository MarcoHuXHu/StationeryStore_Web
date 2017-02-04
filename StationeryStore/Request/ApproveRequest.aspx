<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApproveRequest.aspx.cs" Inherits="RequestDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
        <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
    <br />
    <center> <asp:GridView ID="GridView2" runat="server" Width="98%" AutoGenerateColumns="False" CssClass="table table-hover table-striped">
                            <RowStyle CssClass="cursor-pointer" />
        <Columns>

                <asp:TemplateField HeaderText="RequestDate">
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
                <asp:TemplateField HeaderText="RequestQty">
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
    <asp:GridView ID="GridView1" Width="98%" CssClass="table table-hover table-striped" runat="server" AutoGenerateColumns="False">
       <RowStyle CssClass="cursor-pointer" />
         <Columns>

                <asp:TemplateField HeaderText="RequestDate">
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
                <asp:TemplateField HeaderText="RequestQty">
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

           

            </Columns>
    </asp:GridView>

    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:Label runat="server" Text="Comment:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="ButtonApprove" runat="server" Text="Approve" OnClick="ButtonApprove_Click" CssClass="button" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonReject" runat="server" Text="Reject" OnClick="ButtonReject_Click" CssClass="button" />
    </asp:Panel></center>

</asp:Content>

