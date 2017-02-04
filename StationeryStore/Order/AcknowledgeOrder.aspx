<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AcknowledgeOrder.aspx.cs" Inherits="Order_AcknowledgeOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type = "text/javascript" >
        function preventBack(){window.history.forward();}
        setTimeout("preventBack()", 0);
        window.onunload=function(){null};
    </script> 

    <asp:Label ID="Label4" runat="server" Text="Order ID:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="OrderIDLbl" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Item ID:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="ItemIDLbl" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Description:"></asp:Label>
&nbsp;<asp:Label ID="DescriptionLbl" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
              <Columns>
             <asp:TemplateField HeaderText="PurchaseOrderID">
                <ItemTemplate>
                    <asp:Label ID="poid" runat="server" Text='<%#Eval("PurchaseOrderID") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="SupplierID">
                <ItemTemplate>
                    <asp:Label ID="supplierid" runat="server" Text='<%#Eval("SupplierID") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Ordered Quantity">
                <ItemTemplate>
                    <asp:Label ID="ordered" runat="server" Text='<%#Eval("OrderQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
                
                  <asp:templatefield  HeaderText="Acknowledge">
                     <itemtemplate>
                            <asp:checkbox ID="cbSelect" runat="server" OnCheckedChanged="SelectCheckBox_OnCheckedChanged" AutoPostBack="True"></asp:checkbox>
                    </itemtemplate>
                </asp:templatefield>

           </Columns>
        </asp:GridView>
        <br />
    
        
    <asp:Button ID="SubmitBtn" runat="server" Text="Acknowledge" CssClass="button" OnClick="SubmitBtn_Click" />
    <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Red" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Completed Purchase Order" Font-Bold="True"></asp:Label>
     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
              <Columns>
             <asp:TemplateField HeaderText="PurchaseOrderID">
                <ItemTemplate>
                    <asp:Label ID="poid" runat="server" Text='<%#Eval("PurchaseOrderID") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="SupplierID">
                <ItemTemplate>
                    <asp:Label ID="supplierid" runat="server" Text='<%#Eval("SupplierID") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Ordered Quantity">
                <ItemTemplate>
                    <asp:Label ID="ordered" runat="server" Text='<%#Eval("OrderQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
           </Columns>
        </asp:GridView>
    <br />
</asp:Content>



