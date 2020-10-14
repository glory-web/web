<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NationalLinks.ascx.cs" Inherits="AR_Controls_NationalLinks" %>
<table style="clear: both; border-right: #1176a2 1px solid; border-top: #1176a2 1px solid;
    margin-bottom: 20px; border-left: #1176a2 1px solid; width: 100%; border-bottom: #1176a2 1px solid;
    text-decoration: none">
    <%--<tr class="GridViewH HighLightsHead">
        <td colspan="2" style="padding-right: 10px; font-weight: bold; font-size: 16px; float: right;
            direction: ltr; padding-top: 5px; height: 20px">
            Ì—«„Ã «·„‘—Ê⁄ «·ﬁÊ„Ì ·· —ﬁÌ„ Ê«· ”ÃÌ·&nbsp;
        </td>
    </tr>--%>
    <tr>
        <td colspan="2" style="height: 19px">
            <asp:HyperLink ID="HyperLink4" CssClass="HighLightsItems" runat="server" NavigateUrl="http://www.govs.gov.eg/bovis" Target= "_blank" >Bovis </asp:HyperLink></td>
    </tr>
    <tr>
        <td colspan="2" style="height: 19px">
            <asp:HyperLink ID="HyperLink5" CssClass="HighLightsItems" runat="server" NavigateUrl="http://www.govs.gov.eg/coding" Target= "_blank" >Goats </asp:HyperLink></td>
    </tr>
    <tr>
        <td colspan="2" style="height: 19px">
            <asp:HyperLink ID="HyperLink9" CssClass="HighLightsItems" runat="server" NavigateUrl="http://www.govs.gov.eg/poultrycoding" Target= "_blank" >Chicken</asp:HyperLink></td>
    </tr>
</table>
