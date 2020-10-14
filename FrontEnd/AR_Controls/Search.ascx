<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="AR_Controls_Search" %>

<table dir="ltr" style="width:180px">
    <tr>
        <td align="center" colspan="2" style="height:9px">
         <%--<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click">ﬂ· «·«Œ»«—</asp:LinkButton>--%></td>
    </tr>
    <%--<tr style="height:2px"><td colspan="2"></td></tr>--%>
    <tr >
        <td style="width:120px" align="center" class="search_intd">
           <asp:TextBox CssClass="search_in" ID="txtSearch" runat="server" Width="120px"></asp:TextBox>&nbsp;
          </td>
        <td valign="middle" style="padding-bottom:12px">
         <asp:Button CssClass="search_btn" ID="Button1" runat="server" OnClick="Button1_Click" Text="«»ÕÀ" />
        </td>
    </tr>
    <tr>
    <td>
            <asp:RegularExpressionValidator ID="regexpSSN" runat="server"         
                                    ErrorMessage="" 
                                    ControlToValidate="txtSearch"         
                                    ValidationExpression="^[a-zA-Z0-9.\s¡-Ì]{1,100}$" /></td>
    </tr>
    
</table>
