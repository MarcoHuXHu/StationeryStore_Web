<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"AutoEventWireup="true" CodeFile="AssignRole.aspx.cs" Inherits="AssignRole" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="../Stylesheet/StyleSheet.css" rel="stylesheet" />
</asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="width:100%;">
 
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Covering Head:"></asp:Label>
                </td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" CausesValidation="false">
        </asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="Start Date:"></asp:Label>
                </td>
                <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="TextBox5_CalendarExtender" runat="server" TargetControlID="TextBox5" />
                </td>
            </tr>
                        <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label5" runat="server" Text="End Date:"></asp:Label>
                            </td>
                <td>
        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox5" Format="dd/MM/yyyy"/>
                    <asp:TextBox ID="TextBox6" runat="server" ></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="TextBox6_CalendarExtender" runat="server" TargetControlID="TextBox6" Format="dd/MM/yyyy"/>
                </td>
            </tr>
            <tr>
                <td>
                    
                    &nbsp;</td>
                <td>
                    
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                    
                </td>
            </tr>
                        <tr>
                <td>
                    
                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" Height="26px" Width="90px" CssClass="buttonm" />
                    
                </td>
                <td>
        <asp:Button ID="Button2" runat="server" Text="Revoke Delegate" OnClick="Button2_Click" Height="26px" Width="146px" CssClass="buttonm" />
    
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
            
        <br />
        <br />
        
    
</asp:Content>
