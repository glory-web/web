<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Decs.ascx.cs" Inherits="Decs" %>
<table>    
    <tr>
        <td colspan="3">
            <asp:Label ID="test" runat="server" Text="test" Visible="false"></asp:Label>
            <asp:Label ID="WLawDec" runat="server" Text="WLawDec" Visible="false"></asp:Label>
            <asp:Label ID="ALawDec" runat="server" Text="ALawDec" Visible="false"></asp:Label>
            <asp:Label ID="LawDec" runat="server" Text="LawDec" Visible="false"></asp:Label>
        </td>
    </tr>
    <tr style="width: 300px">
        <td>
            <asp:Label ID="YearL" runat="server" Text="Óäå ÇáÇÕÏÇÑ"></asp:Label>
            <br />
        </td>
        <td >
        </td>
        <td>
            <asp:DropDownList ID="DDLYear" runat="server" AutoPostBack="True" Width="249px">
            </asp:DropDownList>
            <br />
        </td>
    </tr>
    
    <tr style="width: 300px">
        <td>
            <asp:Label ID="DepL" runat="server" Text="ÇáÇÏÇÑÉ"></asp:Label>
        </td>
        <td style="width: 10px">
        </td>
        <td>
            <asp:DropDownList ID="DDLDepart" runat="server" AutoPostBack="True" Width="249px">
            </asp:DropDownList></td>
    </tr>
</table>
<br />
<asp:MultiView ID="MultiView1" runat="server">
    <br />  
    <%--maryam--%>
    <asp:View ID="View3" runat="server">
        <asp:GridView ID="decs_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False">
            <Columns>
                <asp:TemplateField HeaderText="ÇáÞÑÇÑÇÊ">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButtonD" runat="server" CssClass="HighLightsItems" OnClick="LinkButtonD_Click"
                            Text='<%# Bind("law_Arabic_Name") %>'>LinkButton</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="View4" runat="server">
        <table class="front">
            <tr>
                <td class="bg">
                    <asp:Label ID="Label5" runat="server" CssClass="Label_form" Text="ÇÓã ÇáÞÑÇÑ"></asp:Label>
                </td>
                <td class="bg2">
                    <asp:Label ID="Label_Decs_Name" runat="server" CssClass="Label_details"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label7" runat="server" CssClass="Label_form" Text="ãáÎÕ ÇáÞÑÇÑ"></asp:Label>
                </td>
                <td class="bg2">
                    <asp:Label ID="Label_Decs_Title" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label9" runat="server" CssClass="Label_form" Text="ÓäÉ ÇÕÏÇÑ ÇáÞÑÇÑ"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Label_Decs_date" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label10" runat="server" CssClass="Label_form" Text="ÊÇÑíÎ ÇáÇÕÏÇÑ"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Label_Decs_date2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label13" runat="server" CssClass="Label_form" Text="ÊÇÑíÎ ÇáäÔÑ ÈÇáæÞÇÆÚ ÇáãÕÑíÉ"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Label_Decs_date3" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label15" runat="server" CssClass="Label_form" Text="ÇáÌåÉ"></asp:Label></td>
                <td class="bg2">
                    <%--<asp:Label ID="Label_Decs_D" runat="server"></asp:Label>--%>
                    <asp:Repeater ID="Repeater4" runat="server">
                        <ItemTemplate>
                            <%--<asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_Arabic_Name") %>' NavigateUrl='<%#string.Concat(FilePath(), Eval("File_Arabic_Name")) %>'>HyperLink</asp:HyperLink></br>--%>
                            <asp:Label ID="Label_Laws_D" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'> </asp:Label></br>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label19" runat="server" CssClass="Label_form" Text="Êã ÇáÇáÛÇÁ ÈÞÑÇÑ ÑÞã "
                        Visible="false"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Label_Decs_Cancel" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label11" runat="server" CssClass="Label_form" Text="ãáÝÇÊ ÇáÞÑÇÑ"></asp:Label>
                </td>
                <td class="bg2">
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <%--<asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_Arabic_Name") %>' NavigateUrl='<%#string.Concat(FilePath(), Eval("File_Arabic_Name")) %>'>HyperLink</asp:HyperLink></br>--%>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_Path") %>' NavigateUrl='<%#string.Concat(FilePath(), Eval("File_Path")) %>' Target= "_blank">HyperLink</asp:HyperLink></br>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </asp:View>
    <%--maryam--%>
</asp:MultiView>
