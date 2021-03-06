﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewSubmission.aspx.cs" Inherits="RequestHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
    <p>
        <center><h3><b>View Submission</b></h3>
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>All</asp:ListItem>
            <asp:ListItem>PendingApproval</asp:ListItem>
            <asp:ListItem>Approved</asp:ListItem>
            <asp:ListItem>Rejected</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="98%" CssClass="table table-hover table-striped">
            <RowStyle CssClass="cursor-pointer" />
            <Columns>

                <asp:TemplateField HeaderText="Request ID">
                    <ItemTemplate>
                        <asp:HyperLink ID="rqId" runat="server" NavigateUrl='<%#Eval("rqId", "ApproveRequest.aspx?id={0}") %>'><%#Eval("rqId") %></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Date Requested">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("date") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Requester">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("requester") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("status") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:TemplateField>


            </Columns>
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
        </asp:GridView></center>
    </p>
    <p>
        &nbsp;
    </p>
</asp:Content>

