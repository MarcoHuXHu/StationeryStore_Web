<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MaintainSupplierList2.aspx.cs" Inherits="MaintainSupplierList2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Supplier Code:&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator">please enter supplier id</asp:RequiredFieldValidator>
        <br />
        Supplier Name:&nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="RequiredFieldValidator">please enter suppliername</asp:RequiredFieldValidator>
        <br />
        Contact Name:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="RequiredFieldValidator">please enter contactname</asp:RequiredFieldValidator>
        <br />
        Phone No.:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="RequiredFieldValidator">please enter phone</asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                   ErrorMessage="RegularExpressionValidator" ControlToValidate="TextBox4"
ValidationExpression="[0-9]{9}">tel should have exactly 9 digits
              </asp:RegularExpressionValidator>
        <br />
        Fax No.:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="RequiredFieldValidator">please enter fax</asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                   ErrorMessage="RegularExpressionValidator" ControlToValidate="TextBox5"
ValidationExpression="[0-9]{7}">fax should have exactly 7 digits
              </asp:RegularExpressionValidator>
        <br />
        Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" ErrorMessage="RequiredFieldValidator">please enter address</asp:RequiredFieldValidator>
        <br />
        GST No.:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>

        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                   ErrorMessage="RegularExpressionValidator" ControlToValidate="TextBox7"
ValidationExpression="[M][R][-][0-9]{7}[-][0-9]">gst registration number should be in MR-XXXXXXX-X format!
              </asp:RegularExpressionValidator>
        <!--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBox7"  ErrorMessage="RequiredFieldValidator">please enter gst no

        </asp:RequiredFieldValidator>-->
        <br />
        Email:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="expEmail" runat="server" ControlToValidate="TextBox8" 
ErrorMessage="valid email address required" 
ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$">
</asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="TextBox8" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
    </div>
 <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Cancel" CausesValidation="false" OnClick="Button2_Click" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </form>
</body>
</html>
