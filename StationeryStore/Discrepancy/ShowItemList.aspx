<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ShowItemList.aspx.cs" Inherits="ShowItemList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <%--    <script type="text/javascript">
        var prevselitem = null;
        function selectx(row) {
            if (prevselitem != null) {
                prevselitem.style.backgroundColor = '#ffffff';
            }
            row.style.backgroundColor = 'PeachPuff';
            prevselitem = row;
        }
    </script>--%>

        <div>
            <asp:Label ID="Label2" runat="server" Text="Item List" Font-Bold="True" Font-Italic="True" Font-Underline="True"></asp:Label>

        </div>
        <asp:Label ID="Label3" runat="server" Text="Category:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" CssClass="buttonm" />
        &nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Show All" CssClass="buttonm" />
        <br />
        <div>
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Visible="False"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="ItemID,Description" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>

                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# string.Format("NewDiscrepancy.aspx?id={0}&description={1}", Eval("ItemID"),Eval("Description"))%>'>New Discrepancy</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#FFCC00" />
            </asp:GridView>
        </div>
</asp:Content>