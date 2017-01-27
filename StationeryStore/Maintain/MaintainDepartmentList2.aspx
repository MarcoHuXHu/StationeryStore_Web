<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="MaintainDepartmentList2.aspx.cs" Inherits="MaintainDepartmentList2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


 <div>
    Department Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator">please enter 
            department code
        </asp:RequiredFieldValidator>
        <br />
        
        Department Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="RequiredFieldValidator">please enter 
            Department Name
        </asp:RequiredFieldValidator>
        <br />
     Contact Person ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox8" ErrorMessage="RequiredFieldValidator">
            please enter Contact Person ID</asp:RequiredFieldValidator>
        <br />
       ContactName:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="TextBox4" runat="server" ReadOnly="True" Text='<%# Eval("contactName")%>'></asp:TextBox>
       
        <br />
        <br />
        Telephone Number:&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="TextBox5" ErrorMessage="RequiredFieldValidator">please enter telephone number</asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                   ErrorMessage="RegularExpressionValidator" ControlToValidate="TextBox5"
ValidationExpression="[8,9][0-9]{6}">tel should have exactly 7 digits, start with either
                  8 or 9
              </asp:RegularExpressionValidator>
        <br />
     Head Name ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ControlToValidate="TextBox9" ErrorMessage="RequiredFieldValidator">please enter head ID</asp:RequiredFieldValidator>
        <br />
        HeadName:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox6" runat="server" ReadOnly="True"></asp:TextBox>
        
        <br />
     RepName ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TextBox10" ErrorMessage="RequiredFieldValidator">please enter repID</asp:RequiredFieldValidator>
        <br />
       RepName:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:TextBox ID="TextBox7" runat="server" ReadOnly="True"></asp:TextBox>
       
        <br />
        
       Collection Point:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList1" runat="server"
            AutoPostBack="True" ViewStateMode="Enabled">
         <asp:ListItem>Stationery Store</asp:ListItem>
         <asp:ListItem>Science School</asp:ListItem>
         <asp:ListItem>Management School</asp:ListItem>
         <asp:ListItem>Engineering School</asp:ListItem>
         <asp:ListItem>Medical School</asp:ListItem>
     </asp:DropDownList>
        &nbsp;<br />
        


    </div>
        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" CssClass="buttonm" />
        &nbsp;<asp:Button ID="Button2" runat="server" Text="Cancel" CausesValidation="false" OnClick="Button2_Click" CssClass="buttonm" />
        &nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Search User" CssClass="buttonm" />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
</asp:Content>