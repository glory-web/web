<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Show.ascx.cs" Inherits="Show" %>
<table width="100%">
    <tr>
        <td align="left" valign="top" dir="ltr"><%-- style="width: 311px"--%>
            <asp:Image ID="News_Image" runat="server" Height="130px" Width="135px" />
        </td>
        <td style="width:15px">
        </td>
        <td class="FirstNews">
            <%--<asp:HyperLink ID="NewsTitleLink" runat="server">
                <asp:TextBox CssClass="NewsTitle" ID="News_Title" runat="server" BorderStyle="None" width="100%" Style="background-color: transparent;"/>            
            </asp:HyperLink>--%>
            <asp:LinkButton ID="NewsTitleLink" CssClass="HighLightsItems" runat="server" ></asp:LinkButton>
                       
            <div runat="server" class="NewsContentM" id="News_Content"/>
        </td>
    </tr>
    <tr >
    <td style="height:11px" colspan="3"></td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:GridView CssClass="HighLights" ID="cooperation_grid" runat="server" AutoGenerateColumns="False"
                ShowHeader="false" ShowFooter="false">
                <Columns>
                    <asp:TemplateField>
                        <HeaderStyle CssClass="HighLightsHead" />
                        <ItemTemplate>
                            <%--<asp:LinkButton ID="LinkButton1" CssClass="HighLightsItems" runat="server" Text ='<%# Bind("Coop_Arabic_Name") %>' PostBackUrl='<%#string.Concat("~//FrontEnd//ar//Cooperation.aspx?id=",Eval("Coop_ID")) %>'></asp:LinkButton>--%>
                            <asp:LinkButton ID="LinkButton1" CssClass="HighLightsItems" runat="server" Text='<%# Bind("News_English_Title") %>'
                                PostBackUrl='<%#string.Concat("~//FrontEnd//en//Show.aspx?id=",Eval("News_ID"),"&type=", Eval("Type")) %>'></asp:LinkButton>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%--<asp:LinkButton ID="LinkButton1" CssClass="MoreButton" runat="server" PostBackUrl="~/FrontEnd/ar/Cooperation.aspx">«·„“Ìœ</asp:LinkButton>--%>
                            <asp:LinkButton ID="LinkButton1" CssClass="MoreButton" runat="server" PostBackUrl="">&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; </asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
