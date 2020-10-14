<%@ Control Language="C#" AutoEventWireup="true" CodeFile="login.ascx.cs" Inherits="login" %>

<span style="text-decoration: underline;color: #669900">
  <strong>  Members login:</strong></span><br />

    <br />
<div id="div1" runat="server">
<table cellpadding="0" cellspacing="0" >
     <tr id="LoginImagenew" runat="server" >
        <td class="rt" rowspan="4" style="padding-right: 15px; width: 139px">
            <img src="../images/Icon_reg.jpg" />
        </td>
    </tr>
    <tr>
        <td class="lt mdl" style="width: 40px; height: 10px">
            <img src="../images/bullet2.gif" />&nbsp;Username:</td>
        <td style="height: 10px" class="mdl lt">
            &nbsp;<asp:TextBox ID="txtUser" runat="server" Width="75px"></asp:TextBox></td>
        <td style="height: 10px">
        </td>
    </tr>
    <tr>
        <td class="top lt" style="width: 40px; padding-top: 5px">
            <img src="../Images/bullet2.gif" />&nbsp;Password:
            
        </td>
        <td style="height: 13px" class="top lt">
            &nbsp;<asp:TextBox ID="txtPass" runat="server" Width="75px" TextMode="Password"></asp:TextBox>&nbsp;
            <asp:ImageButton ID="lnkLogin" runat="server" ImageUrl="~/Images/btn_login.gif" OnClick="lnkLogin_Click" /></td>
        <td style="height: 13px">
        </td>
    </tr>
    <tr>
        <td style="width: 40px; height: 6px;">
        </td>
        <td style="height: 6px">
        </td>
        <td style="height: 6px">
        </td>
    </tr>
    <tr id="RemembrMe" runat="server" >
        <td class="cntr btm" colspan="1" style="width: 139px; height: 38px">
        </td>
        <td class="lt btm" colspan="3" style="height: 38px">
            <img src="../images/bullet2.gif" />&nbsp; Forgot my password<br />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember me next time" />&nbsp;&nbsp;<br />&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            </td>
        <td style="height: 38px">
        </td>
    </tr>
    <tr  id="LoggedInRow" runat="server" >
        <td class="cntr btm" colspan="3" style="height: 38px">
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="litName" runat="server"></asp:Label>
            &nbsp; &nbsp;
            <asp:LinkButton ID="lnkLogout" runat="server" Visible="False" OnClick="lnkLogout_Click" >[Logout]</asp:LinkButton>
            <asp:Label ID="lblUserStatus" runat="server" Font-Bold="True" ForeColor="Red"
                Width="56%"></asp:Label></td>
        <td style="height: 38px">
        </td>
    </tr>
    <tr id="loginfailedRow" runat="server">
        <td runat="server" id="failedrow" class="cntr btm" colspan="3" style="height: 38px" dir="ltr">
<asp:Label ID="Label3" runat="server" Width="56%"
    ForeColor="Red" Font-Bold="True" Visible="False">Login Failed</asp:Label><br />
            </td>
        <td style="height: 38px">
        </td>
    </tr>
</table>
</div>

