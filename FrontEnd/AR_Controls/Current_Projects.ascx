<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Current_Projects.ascx.cs" Inherits="Projects" %>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="projects_grid" runat="server" AutoGenerateColumns="False" ShowHeader="true">
            <Columns>
                <asp:TemplateField HeaderText="«·„‘«—Ì⁄ «·Õ«·Ì…">
                <HeaderStyle CssClass="HighLightsHead"/>
                    <ItemTemplate>
                        <asp:LinkButton CssClass="HighLightsItems" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Bind("Project_Arabic_Name") %>'>LinkButton</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <table class="front">
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label1" runat="server" Text="«”„ «·„‘—Ê⁄"></asp:Label></td>
                <td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Proj_Name" runat="server"></asp:Label></td>
            </tr>
           <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label2" runat="server" Text="Ê’› «·„‘—Ê⁄"></asp:Label></td>
                 <td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Proj_Discreption" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label3" runat="server" Text=" «—ÌŒ »œ«Ì… «·„‘—Ê⁄" ></asp:Label></td>
                 <td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Project_StartDate" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label4" runat="server" Text=" «—ÌŒ ‰Â«Ì… «·„‘—Ê⁄" ></asp:Label></td>
                 <td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Project_EndDate" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label5" runat="server" Text="—«»ÿ «·„‘—Ê⁄"></asp:Label></td>
                <td class="bg2">
                    <asp:HyperLink CssClass="Label_details" ID="Project_Link" runat="server" Target="_blank">«÷€ÿ Â‰«</asp:HyperLink></td>
            </tr>
            <tr>
               <td class="bg">
                   <asp:Label ID="Label6" runat="server" CssClass="Label_form" Text="„·›«  «·„‘—Ê⁄"></asp:Label></td>
               <td class="bg2">
                   <asp:HyperLink ID="Project_Files" runat="server" NavigateUrl="~/FrontEnd/ar/ProjectFiles.aspx" Target= "_blank">«·„·›« </asp:HyperLink></td>
           </tr>
           <%-- <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label6" runat="server" Text="„·›«  «·„‘—Ê⁄" ></asp:Label></td>
                 <td class="bg2">
                    <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate >
                        <asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_Arabic_Name") %>' NavigateUrl='<%#string.Concat(FilePath(), Eval("File_Arabic_Name")) %>'>HyperLink</asp:HyperLink></br>
                    </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>--%>
        </table>
        </asp:View>
</asp:MultiView>
        <asp:Label ID="NoProject" runat="server" Text="·« ÌÊÃœ „‘«—Ì⁄ Õ«·Ì…" Visible="False"
            Width="175px"></asp:Label>
