<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Governorate.ascx.cs" Inherits="AR_Controls_Governorate" %>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="governorate_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False">
            <Columns>
                <asp:TemplateField HeaderText="«·„œÌ—Ì« ">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="HighLightsItems" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"
                            Text='<%# Bind("ORG_Arabic_Name") %>'>LinkButton</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <table class="front" width="100%">
            <tr>
                <td class="bg" style="width: 177px">
                    <asp:Label ID="Label1" runat="server" CssClass="Label_form" Text="«”„  «·„œÌ—Ì…"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Lit_name" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="width: 177px">
                    <asp:Label ID="Label6" runat="server" CssClass="Label_form" Text="„œÌ— «·„œÌ—Ì…"></asp:Label></td>
                <td class="bg2">
                    <%--<asp:Image ID="Manger_Image" runat="server" Width="111px" Height="144px" />--%>
                    <asp:HyperLink ID="manger_HyperLink" runat="server"></asp:HyperLink>
                    <asp:Label ID="Lit_manger_name" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="width: 177px">
                    <asp:Label CssClass="Label_form" ID="Literal1" runat="server" Text="«—ﬁ«„ «· ·Ì›Ê‰« "></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Lit_Telephone" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="width: 177px">
                    <asp:Label CssClass="Label_form" ID="Literal2" runat="server" Text="—ﬁ„ «·›«ﬂ”"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Lit_Fax" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="width: 177px">
                    <asp:Label ID="Label3" runat="server" CssClass="Label_form" Text="«·»—Ìœ «·«·ﬂ —Ê‰Ì "
                        Width="128px"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Label_Mail" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="width: 177px">
                    <asp:Label ID="Label5" runat="server" CssClass="Label_form" Text="«·⁄‰Ê«‰"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Lit_Addreess" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="width: 177px">
                    <asp:Label ID="Label7" runat="server" CssClass="Label_form" Text=" «—ÌŒ «·„œÌ—Ì…"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Lit_History" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="width: 177px">
                    <asp:Label ID="Label2" runat="server" CssClass="Label_form" Text="«·«œ«—«  «· «»⁄… "></asp:Label></td>
                <td class="bg2">
                 <asp:GridView ID="gov_dep_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                                Width="60%">
                                <Columns>
                                    <asp:TemplateField HeaderText="«·«œ—« ">
                                        <ItemTemplate>
                                            <asp:Label ID="OrgIdLbe" runat="server" Visible="false" Text='<%# Bind("Parent_ORG_ID") %>'></asp:Label>
                                            <asp:Label ID="DepIdLbe" runat="server" Visible="false" Text='<%# Bind("ORG_ID") %>'></asp:Label>
                                            <asp:Label ID="LinkButton1" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%--<asp:Label ID="OrgIdLbe" runat="server" Visible="false" Text='<%# Bind("Parent_ORG_ID") %>'></asp:Label>
                                            <asp:Label ID="DepIdLbe" runat="server" Visible="false" Text='<%# Bind("ORG_ID") %>'></asp:Label>
                                            <asp:Label ID="LinkButton1" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:Label>--%>
                                            <asp:LinkButton ID="Link_Sluter" runat="server" OnClick="Link_Sluter_Click">„Ã«“—</asp:LinkButton>
                                           <%-- <asp:LinkButton ID="Link_Unit" runat="server" OnClick="Link_Unit_Click">ÊÕœ« </asp:LinkButton>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <%--<asp:Label ID="OrgIdLbe" runat="server" Visible="false" Text='<%# Bind("Parent_ORG_ID") %>'></asp:Label>
                                            <asp:Label ID="DepIdLbe" runat="server" Visible="false" Text='<%# Bind("ORG_ID") %>'></asp:Label>
                                            <asp:Label ID="LinkButton1" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:Label>
                                            <asp:LinkButton ID="Link_Sluter" runat="server" OnClick="Link_Sluter_Click">„Ã«“—</asp:LinkButton>--%>
                                            <asp:LinkButton ID="Link_Unit" runat="server" OnClick="Link_Unit_Click">ÊÕœ« </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                    <asp:MultiView ID="MultiView2" runat="server">
                        <asp:View ID="View3" runat="server">
                           
                        </asp:View>
                        <asp:View ID="View4" runat="server">
                        <table class="SubWindow">
                        <tr><td>
                          <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Underline="True"></asp:Label>
                            <asp:GridView ID="Grid_unit_sluter" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                                Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="«·„œÌ—Ì« ">
                                        <ItemTemplate>
                                            <asp:Label ID="Lable_org_name" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'>LinkButton</asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:LinkButton ID="Link_Close" runat="server" OnClick="Link_Close_Click">«€·«ﬁ</asp:LinkButton>
                            </td></tr></table>
                            </asp:View>
                    </asp:MultiView></td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
