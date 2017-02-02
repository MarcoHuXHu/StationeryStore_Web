<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"AutoEventWireup="true" CodeFile="MaintainCatalogueList2.aspx.cs" Inherits="MaintainCatalogueList2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
    Item Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator">
          please enter item code</asp:RequiredFieldValidator> 
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
ErrorMessage="RegularExpressionValidator" ControlToValidate="TextBox1"
ValidationExpression="[C,E,F,H,P,S,T]{1,1}[0-9][0-9][0-9]"
ForeColor="Red">please enter correct format! start with letter, then 3 digits!</asp:RegularExpressionValidator>
        <br />
        Category:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList1" runat="server"
            AutoPostBack="True" ViewStateMode="Enabled"></asp:DropDownList>
        &nbsp;<br />
        Description:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="RequiredFieldValidator">please enter 
            description
        </asp:RequiredFieldValidator>
        <br />
        ReorderLevel:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="RequiredFieldValidator">
            please enter reorder level</asp:RequiredFieldValidator>
         <asp:RangeValidator ID="RangeValidator1" runat="server"
ErrorMessage="RangeValidator" ControlToValidate="TextBox4"
ForeColor="Red" Type="Integer"
MaximumValue="999" MinimumValue="1">please input positive integer!</asp:RangeValidator>
        <br />
        Reorder Qty:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="TextBox5" ErrorMessage="RequiredFieldValidator">please enter reorder qty</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator2" runat="server"
ErrorMessage="RangeValidator" ControlToValidate="TextBox5"
ForeColor="Red" Type="Integer"
MaximumValue="999" MinimumValue="1">please input positive integer!</asp:RangeValidator>
        <br />
        Unit of Measure: <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
            <asp:ListItem>Box</asp:ListItem>
            <asp:ListItem>Dozen</asp:ListItem>
            <asp:ListItem>Each</asp:ListItem>
            <asp:ListItem>Packet</asp:ListItem>
            <asp:ListItem>Set</asp:ListItem>
        </asp:DropDownList>
        <br />
         Bin No: <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
  
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
ErrorMessage="RegularExpressionValidator" ControlToValidate="TextBox7"
ValidationExpression="[C,E,F,H,P,S,T][1-9][0-9]{0,1}"
ForeColor="Red">Invalid format. Please Enter first alphabet of category followed by 1 or 2-digit number!

        </asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TextBox7" ErrorMessage="RequiredFieldValidator">please enter bin no</asp:RequiredFieldValidator>
        <br />
        


    </div>
        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" CssClass="buttonm" />
        &nbsp;<asp:Button ID="Button2" runat="server" Text="Cancel" CausesValidation="false" OnClick="Button2_Click" CssClass="buttonm" />

</asp:Content>