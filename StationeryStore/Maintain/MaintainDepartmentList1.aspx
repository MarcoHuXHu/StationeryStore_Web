<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaintainDepartmentList1.aspx.cs" Inherits="MaintainDepartmentList1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    Department List
        
        <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" Height="242px"  onrowcancelingedit="GridView1_RowCancelingEdit" 
   onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
            onrowdeleting="GridView1_OnRowDeleting" Width="1115px">
            
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="DepartmentID" ReadOnly="true"/>
                
                <asp:TemplateField HeaderText="Department">
          <ItemTemplate>
            <%# Eval("DepartmentName")%>
          </ItemTemplate>
          <EditItemTemplate>
            <asp:TextBox runat="server" ID="txtDepartmentName" Text='<%# Eval("DepartmentName")%>' />
          </EditItemTemplate>
      </asp:TemplateField>

                 <asp:TemplateField HeaderText="Contact">
          <ItemTemplate>
              <%# Eval("ContactName")%> 
          </ItemTemplate>
          <EditItemTemplate>
            <asp:DropDownList ID="DropDownList2" runat="server" DataTextField="Name" DataValueField="UserID" 
Height="21px" Width="263px">
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
Height="21px" Width="263px"></asp:DropDownList>
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
Height="21px" Width="263px"></asp:DropDownList>
          </EditItemTemplate>
      </asp:TemplateField>
                
                
                <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowCancelButton="true" />
                
                <asp:CommandField ShowDeleteButton="true" ButtonType="Button"  />
                    
            </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Department" />
        
  
        
    </form>
</body>
</html>
