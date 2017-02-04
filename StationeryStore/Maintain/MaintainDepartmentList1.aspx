<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MaintainDepartmentList1.aspx.cs" Inherits="MaintainDepartmentList1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Stylesheet/css/bootstrap.css" rel="stylesheet" />
    <link href="../Stylesheet/css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../Stylesheet/pagingCss.css" rel="stylesheet" />

    <h3 style="margin-left: 20px; "><B>Department List</B></h3>
        <div style="overflow-x:scroll;width:90%;margin-left: 20px; ">
        <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" Height="242px"  onrowcancelingedit="GridView1_RowCancelingEdit" 
   onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" CssClass="table table-hover table-striped" 
            onrowdeleting="GridView1_OnRowDeleting" Width="98%">
             <RowStyle CssClass="cursor-pointer" />

            
            <AlternatingRowStyle HorizontalAlign="Left" />
            
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="DepartmentID" ReadOnly="true"/>
                
                <asp:TemplateField HeaderText="Department">
          <ItemTemplate>
            <%# Eval("DepartmentName")%>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:TextBox runat="server" ID="txtDepartmentName" Text='<%# Eval("DepartmentName")%>'/>
          </EditItemTemplate>
      </asp:TemplateField>

                 <asp:TemplateField HeaderText="Contact">
          <ItemTemplate>
              <%# Eval("ContactName")%> 
          </ItemTemplate>
          <EditItemTemplate>
            <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="Name" DataValueField="UserID" 
Height="21px" Width="100px">
</asp:DropDownList>

               
         
          </EditItemTemplate>
      </asp:TemplateField>
                <asp:TemplateField HeaderText="Tel">
          <ItemTemplate>
              <%# Eval("Telephone")%>
          </ItemTemplate>
          <EditItemTemplate>
              <asp:TextBox runat="server" ID="txtTelephone" Text='<%# Eval("Telephone")%>' />
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                   ErrorMessage="RegularExpressionValidator" ControlToValidate="txtTelephone"
ValidationExpression="[8,9][0-9]{6}">tel should have exactly 7 digits, start with either
                  8 or 9
              </asp:RegularExpressionValidator>
          </EditItemTemplate>
      </asp:TemplateField>
                <asp:TemplateField HeaderText="Head">
          <ItemTemplate>
              <%# Eval("DeptHead")%>
          </ItemTemplate>
          <EditItemTemplate>
             <asp:DropDownList ID="DropDownList4" runat="server" DataTextField="Name" DataValueField="UserID" 
Height="21px" Width="100px"></asp:DropDownList>
          </EditItemTemplate>
      </asp:TemplateField>
                <asp:TemplateField HeaderText="Collection Point">
          <ItemTemplate>
              <%# Eval("CollectionPoint")%>
          </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                            <asp:ListItem>Stationery Store</asp:ListItem>
        <asp:ListItem>Science School</asp:ListItem>
        <asp:ListItem>Management School</asp:ListItem>
        <asp:ListItem>Medical School</asp:ListItem>
        <asp:ListItem>Engineering School</asp:ListItem>
                        </asp:DropDownList>

                    </EditItemTemplate>
      </asp:TemplateField>
                <asp:TemplateField HeaderText="Rep Name">
          <ItemTemplate>
              <%# Eval("DeptRep")%>
          </ItemTemplate>
          <EditItemTemplate>
                 <asp:DropDownList ID="DropDownList3" runat="server" DataTextField="Name" DataValueField="UserID" 
Height="21px" Width="100px"></asp:DropDownList>
          </EditItemTemplate>
      </asp:TemplateField>
                
                
                <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" ControlStyle-CssClass="buttonm" />
                
                <asp:CommandField ShowDeleteButton="true" ButtonType="Button"  ControlStyle-CssClass="buttonm" />
                    
            </Columns>
        </asp:GridView>
        </div>
        </>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Department" CssClass="button" />



</asp:Content>
