<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Login" %>

<%@ Register Src="~/footer.ascx" TagPrefix="uc1" TagName="footer" %>


<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   

    <link href="../Stylesheet/simple-sidebar.css" rel="stylesheet" />
    <link href="./Stylesheet/StyleSheet.css" rel="stylesheet" />
    
    <style type="text/css">
       .auto-style1 {
            width: 126px;
        }
        .auto-style2 {
            width: 129px;
            height: 500px;
            background-color:#558C89; color: white;
        }
        .auto-style3 {
            width: 8%;
            height: 93px;
            vertical-align:top;
            background-color:#558C89; color: white;
        }
        .auto-style4 {
            width: 129px;
            height: 93px;
            background-color:#558C89; color: white;
        }
        .auto-style5 {
            height: 93px;
            width: 687px;
            background-color:#558C89; color: white;
            font-family: 'Comic Sans MS';
            font-size: 20px;
        }
        .auto-style6 {
            height: 335px;
            vertical-align: top;
            width: 687px;
        }
        .auto-style7 {
            height: 93px;
            background-color:#558C89; color: white;
            width: 10%;
            padding-left:0em ;
            padding-right:0em;
        }

        .auto-style8 {
            width: 100%;
        }
           .newStyle1 {
         font-family: Arial;
         font-size: 12px;
         color: #FFFFFF;
         text-decoration:none;
         font-weight: 700;
     }
     
        .newStyle2 {
         width: 17%;
         font-family: Arial;
         font-size: 12px;
         color: #FFFFFF;
     }

        .auto-style9 {
            width: 45px;
            height: 30px;
            margin-left: 9px;
        }

       
        .button { 
            background-color: #D9853B; 
            border: none;
            color: white; 
            padding: 15px 15px; 
            text-align: center; 
            text-decoration: none; 
            font-size: 14px;
}

           .buttonsmall { 
            background-color: #D9853B; 
            border: none;
            color: white; 
            text-align: center; 
            text-decoration: none; 
            font-size: 10px;
}

    </style>

</head>


<body>
        <form id="form1" runat="server">
    <div>
        <table class="auto-style8">
            <tr>
                <td class="auto-style4">
                    
                    <img src="Image/icon1.gif" /> 
                </td>
                <td class="auto-style5">STATIONERY STORE INVENTORY SYSTEM</td>
                <td class="auto-style7" > 
                      <asp:Label ID="lblusername" runat="server" Text=" " CssClass="newStyle2"></asp:Label>
                      <asp:LoginName ID="LoginName1" runat="server" FormatString="Welcome {0}" />
                </td>

                <td class="auto-style3" > 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <!-- userguide here <a href="Image/User Filled.png" target="_blank" /> -->
                    <img alt="Help" class="auto-style9" src="Image/questionmark.gif" /><br />
                    <br />
                </td>
            </tr>

            <tr>
                <td class="auto-style2" valign="top">
                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>

                </td>
                <td class="auto-style6" colspan="3">
       

         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/User Filled.png" />
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style10" colspan =" 3">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" CssClass="button" />
                    <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        

        </table>
     </table>
    </div>
    </form>
            <div> 
           <uc1:footer ID="footer1" runat="server" />
        </div>
</body>
</html>
