<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisbursementHistory.aspx.cs" Inherits="Request_DisbursementHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:DropDownList ID="DropDownYear" runat="server" OnSelectedIndexChanged="DropDownYear_SelectedIndexChanged" AutoPostBack="true" Font-Names="Arial">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownMonth" runat="server" OnSelectedIndexChanged="DropDownMonth_SelectedIndexChanged" AutoPostBack="true" Font-Names="Arial">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownWeek" runat="server" OnSelectedIndexChanged="DropDownWeek_SelectedIndexChanged" AutoPostBack="true" Font-Names="Arial">
    </asp:DropDownList>


    <br />
    <br />
    <br />
    
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Selected="True">View Summary</asp:ListItem>
        <asp:ListItem>View By Department</asp:ListItem>
    </asp:RadioButtonList>

    <asp:Panel ID="PanelSummary" runat="server">

        <asp:GridView ID="GridViewSummary" runat="server" AutoGenerateColumns="False">
            <Columns>
            <asp:TemplateField HeaderText="ItemID">
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
            
            <asp:TemplateField HeaderText="InStock">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("InStock") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BinNumber">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("BinNum") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Needed">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("NeededNumber") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Retrieved">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("RetrivedNumber") %>'></asp:Label>
                    
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ActualGiven" Visible="true">
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%#Eval("GivenNumber") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </asp:Panel>
    <asp:Panel ID="PanelDept" runat="server">
        
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:GridView ID="GridViewDept" runat="server"
                         AllowSorting="True" AutoGenerateColumns="False" OnSorting="GridViewDept_Sorting" OnSelectedIndexChanged="GridViewDept_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="DepartmentID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("DepartmentID") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DepartmentName" SortExpression="Department">
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
                            <asp:TemplateField HeaderText="Needed">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("NeededNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Retrieved">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("RetrivedNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ActualGiven" Visible="true">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("GivenNumber") %>'></asp:Label>
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
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>


</asp:Content>

