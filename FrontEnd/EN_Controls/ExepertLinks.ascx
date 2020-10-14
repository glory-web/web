<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExepertLinks.ascx.cs"
    Inherits="Links" %>

<table style="border: 1px solid #1176A2; width: 100%; text-decoration: none; margin-bottom: 20px;
    clear: both">
    <%--<tr class="tableheader"> style="background-color: #5CC3F0"
        <td colspan="2" style="text-align: right; float: right; padding-right: 10px; font-weight: bold;
            font-size: 16px; height: 20px; padding-top: 5px;">
            «·‰Ÿ„ «·Œ»Ì—… ··’Õ… «·ÕÌÊ«‰Ì…</td>
    </tr>--%>
    <tr>
        <td colspan="2">
            <asp:GridView ID="links_grid" CssClass="Links_style" runat="server" AutoGenerateColumns="False" ShowHeader="true" ShowFooter="true"
                Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Expert System For Animal" HeaderStyle-CssClass="HighLightsHead">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" CssClass="HighLightsItems" runat="server" Text='<%# Bind("ESEnglishTitle") %>'
                                NavigateUrl='<%# Bind("ESURL")%>' Target= "_blank" >HyperLink</asp:HyperLink>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <asp:HyperLink ID="HyperLink1" CssClass="HighLightsItems" runat="server" Text='<%# Bind("ESEnglishTitle") %>'
                                NavigateUrl='<%# Bind("ESURL")%>' Target= "_blank" >HyperLink</asp:HyperLink>
                        </AlternatingItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="AlterRow" /><%-- BackColor="#CCFFFF"--%>
            </asp:GridView>
            
        </td>
    </tr>
</table>
