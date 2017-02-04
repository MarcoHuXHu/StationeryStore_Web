<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MaintainSupplierList1.aspx.cs" Inherits="MaintainSupplierList1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />
    <div style="overflow-x:scroll;width:90%;margin-left: 20px; ">
    
        <h3><B> Supplier List</B></h3>
        <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" Height="242px"  onrowcancelingedit="GridView1_RowCancelingEdit" 
   onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
            onrowdeleting="GridView1_OnRowDeleting" CellPadding="0" Width="98%" 
            OnPageIndexChanging="GridView1_PageIndexChanging"  AllowPaging="True" PageSize="30"
            CssClass="table table-hover table-striped" overflow-x="scroll">
            <RowStyle CssClass="cursor-pointer" />
                    <PagerStyle CssClass="pagination-ys" />
            <RowStyle HorizontalAlign="Left"></RowStyle>
            <Columns>
                
                 <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" ReadOnly="true" />
                
                <asp:TemplateField HeaderText="Supplier Name">
          <ItemTemplate>
            <%# Eval("SupplierName")%>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:TextBox runat="server" ID="txtSupplierName" Text='<%# Eval("SupplierName")%>' />
          </EditItemTemplate>
      <ControlStyle BorderWidth="0px" Width="300px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="GST Registration No.">
          <ItemTemplate>
              <%# Eval("GSTRegistrationNo")%> 
          </ItemTemplate>
          <EditItemTemplate>
              <asp:TextBox runat="server" ID="txtGSTRegistrationNo" Text='<%# Eval("GSTRegistrationNo")%>' />
				<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                  ErrorMessage="RegularExpressionValidator" ControlToValidate="txtGSTRegistrationNo"
				  ValidationExpression="[M][R][-][0-9]{7}[-][0-9]">gst registration number should be in MR-XXXXXXX-X format!
              </asp:RegularExpressionValidator>
          </EditItemTemplate>
      </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact Name">
          <ItemTemplate>
              <%# Eval("ContactName")%>
          </ItemTemplate>
          <EditItemTemplate>
              <asp:TextBox runat="server" ID="txtContactName" Text='<%# Eval("ContactName")%>' />
          </EditItemTemplate>
      </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone">
          <ItemTemplate>
              <%# Eval("Phone")%>
          </ItemTemplate>
          <EditItemTemplate>
              <asp:TextBox runat="server" ID="txtPhone" Text='<%# Eval("Phone")%>' />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                   ErrorMessage="RegularExpressionValidator" ControlToValidate="txtPhone"
ValidationExpression="[0-9]{9}">tel should have exactly 9 digits
              </asp:RegularExpressionValidator>
            
          </EditItemTemplate>
      </asp:TemplateField>
                <asp:TemplateField HeaderText="Fax">
          <ItemTemplate>
              <%# Eval("FaxNo")%>
          </ItemTemplate>
          <EditItemTemplate>
              <asp:TextBox runat="server" ID="txtFax" Text='<%# Eval("FaxNo")%>' />
				<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                  ErrorMessage="RegularExpressionValidator" ControlToValidate="txtFax"
				  ValidationExpression="[0-9]{7}">fax should have exactly 7 digits
              </asp:RegularExpressionValidator>
          </EditItemTemplate>
      </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
          <ItemTemplate>
              <%# Eval("Address")%>
          </ItemTemplate>
          <EditItemTemplate>
              <asp:TextBox runat="server" ID="txtAddress" Text='<%# Eval("Address")%>' />
          </EditItemTemplate>
                        
      </asp:TemplateField>

                
                <asp:CommandField ButtonType="Button" ShowEditButton="True" ShowCancelButton="true" ControlStyle-CssClass="buttonm" />
                
                <asp:CommandField ShowDeleteButton="True" ButtonType="Button"  ControlStyle-CssClass="buttonm" />
                    
            </Columns>
            
        </asp:GridView>
  
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Supplier" CssClass="button" />
    </div>
</asp:Content>
