<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AfterUserLogIn.ascx.cs" Inherits="BackEnd_UserControls_AfterUserLogIn" %>
<span style="text-decoration: underline;color: #669900">
  <strong>  Member Data:</strong></span><br />

    <br />
<div id="div1" runat="server">
<table>
     <tr>
        <td class="rt" colspan="2">
            <img src="../images/Icon_reg.jpg" />
        </td>
    </tr>
    
    
    <tr>
        <td>
            <img src="../images/bullet2.gif" /> Name:   </td>
        <td>
            <asp:Literal ID="LITUserFullName" runat="server"></asp:Literal></td>
        
    </tr>
    <tr>
        <td>
            <img src="../Images/bullet2.gif" /> Organization:   </td>
        <td >
            <asp:Literal ID="LITUserOrganization" runat="server"></asp:Literal></td>
        
    </tr>
</table>
</div>