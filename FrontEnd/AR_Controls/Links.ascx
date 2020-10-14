<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Links.ascx.cs" Inherits="Links" %>
<%--<table style="border:1px solid #1176A2; width:100%; text-decoration:none;margin-bottom:20px;clear:both" border>
        <tr >
            <asp:Repeater ID="Repeater1" runat="server">
              <ItemTemplate>
                <td>
                  <center><asp:Image  id = "Image" runat= "server" ImageUrl =  '<%# String.Concat(ImagePath() ,Eval("Link_Logo_Path"))%>' Height = "35px" Width = "35px" Visible ='<%#System.IO.File.Exists(Server.MapPath (string.Concat(ImagePath(), Eval("Link_Logo_Path")))) %>' />
               </center></td>
              </ItemTemplate>
            </asp:Repeater>
        </tr>
            
            
        <tr>
            <asp:Repeater ID="Repeater2" runat="server">           
              <ItemTemplate>
                <td>
                 <center>
                 <asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("Link_Arabic_Name") %>' NavigateUrl='<%# Bind("Link_URL")%>'  >HyperLink</asp:HyperLink>
                </center></td> 
              </ItemTemplate>
            </asp:Repeater>
        </tr>
          
</table>
  --%>
<asp:GridView ID="links_grid" SkinID="links_grid" CssClass="Links_style" runat="server" AutoGenerateColumns="False"
    ShowHeader="true" ShowFooter="true"><%-- Width="90%"--%>
    <Columns>
        <asp:TemplateField HeaderText="ÑæÇÈØ ÐÇÊ ÕáÉ">
        
            <ItemTemplate>
            <table>
                 <tr>
                <td><asp:Image CssClass="LinksImage"  id = "Image" runat= "server" ImageUrl =  '<%# String.Concat(ImagePath() ,Eval("Link_Logo_Path"))%>' Height = "35px" Width = "35px" Visible ='<%#System.IO.File.Exists(Server.MapPath (string.Concat(ImagePath(), Eval("Link_Logo_Path")))) %>' />   </td>
                <td><asp:HyperLink ID="HyperLink1" CssClass="LinksItems" runat="server" Text='<%# Bind("Link_Arabic_Name") %>'
                    NavigateUrl='<%# Bind("Link_URL")%>' Target="_blank">HyperLink</asp:HyperLink></td>
                </tr>
                </table>
            
            </ItemTemplate>
            <AlternatingItemTemplate>
            <table>
            <tr>
            <td>
            <asp:Image CssClass="LinksImage"  id = "Image" runat= "server" ImageUrl =  '<%# String.Concat(ImagePath() ,Eval("Link_Logo_Path"))%>' Height = "35px" Width = "35px" Visible ='<%#System.IO.File.Exists(Server.MapPath (string.Concat(ImagePath(), Eval("Link_Logo_Path")))) %>' />
                </td>
                <td>
                <asp:HyperLink ID="HyperLink1" CssClass="LinksItems" runat="server" Text='<%# Bind("Link_Arabic_Name") %>'
                    NavigateUrl='<%# Bind("Link_URL")%>' Target="_blank">HyperLink</asp:HyperLink>
            </td>
            </tr>
            </table>
            </AlternatingItemTemplate>
            <HeaderStyle CssClass="HighLightsHead" />
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle CssClass="AlterRow" />
</asp:GridView> 
