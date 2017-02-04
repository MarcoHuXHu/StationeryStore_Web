<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MakeRequest.aspx.cs" Inherits="MakeRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />

    <style type="text/css">
        .auto-style9 {
            width: 430px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />

    <script src="../Stylesheet/js/jquery.js"></script>
    <script src="../Stylesheet/js/bootstrap.js"></script>

    <script src="../Stylesheet/toastr.min.js"></script>
    <link href="../Stylesheet/toastr.min.css" rel="stylesheet" />
    <script>
        function showToaster() {
            //alert("Your cart is currently empty.");
            var cartCount = '<%= (Session["cart"] as Dictionary<string, int>).Count %>';
            if (cartCount <= 0) {
                toastr.options.closeButton = true;
                toastr.error('', 'Your cart is currently empty.', { timeOut: 3000, positionClass: "toast-bottom-right" });
            }
            return cartCount>0;

        }
    </script>
    <style type="text/css">
        #searchbar {
            width: 400px;
        }
        .auto-style8{
            border-spacing: 2px;
            border-collapse: separate;
        }
        .input-group{
            border-spacing:0px;
        }
    </style>
    <div class="input-group" id="searchbar" style="margin-left: 20px; margin-right: 20px; margin-top: 20px; margin-bottom: 20px;">
        <asp:TextBox ID="TextBox1" runat="server" cssClass="form-control" placeholder="Search for..."></asp:TextBox>
      <span class="input-group-btn">
          <asp:Button ID="Button1" style="color:#D9853B" runat="server" OnClick="Button1_Click" Text="Search" CssClass="btn btn-default" />
      </span>
    </div>
<%--    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" CssClass="button" />--%>

    <asp:Label ID="Label4" runat="server"></asp:Label>

    <table style="width: 80%;">
        <tr>
            <td class="auto-style9" style="width: 60%;">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="50px" ImageAlign="right" ImageUrl="~/Image/Shopping Cart Filled-100.png" OnClick="ImageButton1_Click" OnClientClick="return showToaster()" Width="50px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:GridView ID="itemGridView" runat="server"  style="margin-left: 20px; " CssClass="table table-hover table-striped" AutoGenerateColumns="False" OnPageIndexChanging="itemGridView_PageIndexChanging" AllowPaging="True">
                    <RowStyle CssClass="cursor-pointer" />
                    <PagerStyle CssClass="pagination-ys" />
                    <Columns>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UOM">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:TextBox ID="quantity" runat="server" TextMode="Number" min="0"></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" Text="Add to Cart" OnClick="Button2_Click" CssClass="button" />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
</asp:Content>
