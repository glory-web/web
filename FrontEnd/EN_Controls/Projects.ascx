<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Projects.ascx.cs" Inherits="Projects" %>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="projects_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False">
            <Columns>
                <asp:TemplateField HeaderText="Projects">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="links_form" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Bind("Project_English_Name") %>'>LinkButton</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <table class="front">
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label1" runat="server" Text="Project Name" ></asp:Label><%--Width="78px"--%>
                </td>
                <td class="bg2">
                    <asp:Label ID="Label_Proj_Name" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label2" runat="server" Text="Project Description "></asp:Label><%-- Width="86px"--%>
                </td>
                <td class="bg2">
                    <asp:Label ID="Label_Proj_Discreption" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label3" runat="server" Text="Start Date"></asp:Label><%-- Width="108px"--%>
                </td>
                <td class="bg2">
                    <asp:Label ID="Label_Project_StartDate" runat="server" Width="170px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label4" runat="server" Text="õEnd Date"></asp:Label><%-- Width="108px"--%>
                </td>
                <td class="bg2">
                    <asp:Label ID="Label_Project_EndDate" runat="server"></asp:Label><%-- Width="170px"--%>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label5" runat="server" Text="Project Link "></asp:Label><%-- Width="108px"--%>
                 </td>
                <td class="bg2">
                    <asp:HyperLink ID="Project_Link" runat="server" Target="_blank"  >Click Here</asp:HyperLink></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label6" runat="server" Text="Project Files "></asp:Label><%-- Width="108px"--%>
                </td>
                <%--<td class="bg2">
                    <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate >
                        <asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_English_Name")%>'  NavigateUrl='<%#string.Concat(FilePath(), Eval("File_English_Name")) %>'>HyperLink</asp:HyperLink></br>
                    </ItemTemplate>
                    </asp:Repeater>
                </td>--%>
                <td class="bg2" style="height: 21px">
                  <asp:HyperLink ID="Project_Files" runat="server" NavigateUrl="~/FrontEnd/en/ProjectFiles.aspx">Files</asp:HyperLink>
                  </td>
            </tr>
        </table>
        </asp:View>
</asp:MultiView>
        <asp:Label ID="NoProject" runat="server" Text="No Future Projects    " Visible="False"
            Width="175px"></asp:Label>
