<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditOrder.aspx.cs" Inherits="Order_EditOrder" %>


<asp:Content ID="Content3" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type = "text/javascript" >
        function preventBack(){window.history.forward();}
        setTimeout("preventBack()", 0);
        window.onunload=function(){null};
    </script> 

     <table>
        <tr>
         <td class="auto-style10">
            &nbsp;
              <asp:Label ID="Label5" runat="server" Text="Order ID"></asp:Label></td> 
        <td class="auto-style11">:</td>
          <td class="auto-style18">
             <asp:Label ID="OrderIDLbl" runat="server" Text="Label"></asp:Label></td>
     </tr>
     <tr>
         <td class="auto-style13">
            &nbsp;
              <asp:Label ID="Label1" runat="server" Text="Item ID"></asp:Label></td> 
        <td class="auto-style12">:</td>
          <td class="auto-style19">
             <asp:Label ID="ItemIDLbl" runat="server" Text="Label"></asp:Label></td>
     </tr>
      <tr>
         <td class="auto-style14">
            &nbsp; <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label></td>
         <td class="auto-style15">:</td>
          <td class="auto-style20" valign="top">
             <asp:Label ID="DescriptionLbl" runat="server" Text="Label"></asp:Label></td>
     </tr>
      <tr>
         <td class="auto-style16">
             <asp:Label ID="Label3" runat="server" Text="*Quantity"></asp:Label></td>
        <td class="auto-style17">:</td>
           <td class="auto-style21">
             <asp:TextBox ID="QuantityTextBox" runat="server" Width="50px" MaxLength="3"></asp:TextBox>                       
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="QuantityTextBox" Display="Dynamic" ErrorMessage="Quantity must be a number greater than 0!" ForeColor="Red" Operator="GreaterThan" Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="QuantityTextBox" Display="Dynamic" ErrorMessage="Quantity cannot be null!" ForeColor="Red"></asp:RequiredFieldValidator>
         </td>
     </tr>
      <tr>
         <td class="auto-style23"  Valign="top">
           &nbsp;
             <asp:Label ID="Label4" runat="server" Text="Justification" Font-Overline="False" ></asp:Label></td>
        <td Valign="top" class="auto-style24">:</td>
           <td class="auto-style25">
             <asp:TextBox ID="JustificationTextBox" runat="server" Height="93px" TextMode="MultiLine" Width="250px"></asp:TextBox></td>
     </tr>
      <tr>
          <td colspan="2" class="auto-style26"></td>
         <td class="auto-style27">
             <asp:Button ID="SubmitBtn" runat="server" Text="Submit" OnClick="SubmitBtn_Click" CssClass="button"/>
             &nbsp;<asp:Button ID="CancelBtn" runat="server" Text="Cancel Order" OnClick="CancelBtn_Click" CssClass="button" />
             </td>
     </tr>
 </table>
</asp:Content>

