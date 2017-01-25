﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaintainPurchaseList3.aspx.cs" Inherits="MaintainPurchaseList3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
            Item Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"/>
       
        <br />
        Item Description:&nbsp; <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true"/>
        
        <br />
        Tender Price:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="RequiredFieldValidator">please enter tender price</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
ErrorMessage="RegularExpressionValidator" ControlToValidate="TextBox3"
ValidationExpression="[0-9]{1,2}.[0-9]{2}"
ForeColor="Red">
            Invalid price. please input with 2 decimal places. max price set to $99.99</asp:RegularExpressionValidator>
        <br />
        Unit of Measure:&nbsp;&nbsp; <asp:TextBox ID="TextBox4" runat="server" ReadOnly="true"/>
        
        <br />
        Priority:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
        </asp:DropDownList>
    
        <p>
    
        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Cancel" CausesValidation="false" OnClick="Button2_Click" />
        </p>
    </form>
</body>
</html>
