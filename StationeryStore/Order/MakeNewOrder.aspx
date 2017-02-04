<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MakeNewOrder.aspx.cs" Inherits="Order_MakeNewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style10 {
            width: 4px;
        }
        .auto-style11 {
            width: 256px;
        }
        .auto-style12 {
            width: 97px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type = "text/javascript" >
        function preventBack(){window.history.forward();}
        setTimeout("preventBack()", 0);
        window.onunload=function(){null};
    </script> 

    <table class="auto-style25">
     <tr>
         <td class="auto-style12">
            &nbsp;
              <asp:Label ID="Label1" runat="server" Text="Item ID"></asp:Label></td> 
        <td class="auto-style10">&nbsp;:</td>
          <td class="auto-style11">
             &nbsp;&nbsp;&nbsp;
             <asp:Label ID="ItemIDLbl" runat="server" Text="Label"></asp:Label></td>
     </tr>
      <tr>
         <td class="auto-style12" valign="top">
            &nbsp; <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label></td>
         <td class="auto-style10">:</td>
          <td class="auto-style11">
             &nbsp;&nbsp;&nbsp;
             <asp:Label ID="DescriptionLbl" runat="server" Text="Label"></asp:Label></td>
     </tr>
      <tr>
         <td class="auto-style12">
             <asp:Label ID="Label3" runat="server" Text="*Quantity"></asp:Label></td>
        <td class="auto-style10">:</td>
           <td class="auto-style11">
             &nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="QuantityTextBox" runat="server" Width="50px" MaxLength="3"></asp:TextBox>                       
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="QuantityTextBox" Display="Dynamic" ErrorMessage="Quantity must be an integer greater than 0!" ForeColor="Red" Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="QuantityTextBox" Display="Dynamic" ErrorMessage="Quantity cannot be null!" ForeColor="Red"></asp:RequiredFieldValidator>
         </td>
          <td class="auto-style19">
                &nbsp;</td>
     </tr>
      <tr>
         <td class="auto-style12"  valign="top">
           &nbsp;
             <asp:Label ID="Label4" runat="server" Text="Justification" Font-Overline="False" ></asp:Label></td>
        <td valign="top" class="auto-style10">:</td>
           <td class="auto-style11">
             &nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="JustificationTextBox" runat="server" Height="93px" TextMode="MultiLine"></asp:TextBox></td>
     </tr>
      <tr>
         <td align="right" colspan="3">
             <asp:Button ID="SubmitBtn" runat="server" Text="Submit" OnClick="SubmitBtn_Click" CssClass="button"/>
             </td>
     </tr>
 </table>
</asp:Content>

