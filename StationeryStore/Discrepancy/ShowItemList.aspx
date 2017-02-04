<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ShowItemList.aspx.cs" Inherits="ShowItemList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
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
           <h3><b>Item List</b></h3>

        </div>
        <asp:Label ID="Label3" runat="server" Text="Category:"></asp:Label>

    <div class="input-group" id="searchbar" style="margin-left: 20px; margin-right: 20px; margin-top: 20px; margin-bottom: 20px;">
        <asp:TextBox ID="TextBox1" runat="server" cssClass="form-control" placeholder="Search for..."></asp:TextBox>
      <span class="input-group-btn">
          <asp:Button ID="Button1" style="color:#D9853B" runat="server" OnClick="Button1_Click" Text="Search" CssClass="btn btn-default" />
      </span>
    </div>

       <%-- <asp:TextBox ID="TextBox1" runat="server" cssClass="form-control" placeholder="Search for..."></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" CssClass="buttonm" />--%>
       
     &nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Show All" CssClass="buttonm" />
        <br />
        <div>
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Visible="False"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="ItemID,Description" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="true" CssClass="table table-hover table-striped" OnPageIndexChanging="GridView1_PageIndexChanging">
                <RowStyle CssClass="cursor-pointer" />
                    <PagerStyle CssClass="pagination-ys" />
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