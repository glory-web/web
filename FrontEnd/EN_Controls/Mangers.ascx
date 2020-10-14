<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Mangers.ascx.cs" Inherits="Mangers" %>
<h2 class="main_title">
    <span  id="MList" runat="server">Chairmen List</span></h2>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:GridView SkinID="mangers_grid"  ID="mangers_grid" runat="server" AutoGenerateColumns="False" ShowHeader="false">
            <Columns>
                <asp:TemplateField HeaderText="Mangers">
                    <ItemTemplate>
                        <%--<ul class="mangerList"> <li>--%> 
                          <%--<a runat="server" href='<%# string.Concat(CVPath(),Eval("Man_CV_Path")) %>'>
                                <asp:Image ID="Manger_Image" runat="server" ImageUrl='<%#string.Concat(ImagePath(), Eval("Man_Photo_Path"))  %>'
                                    Visible='<%#System.IO.File.Exists(Server.MapPath (string.Concat(ImagePath(), Eval("Man_Photo_Path")))) %>'  Width="111px" Height="144px" />
                                </a>--%>
                               <asp:LinkButton CssClass="mangerList_link" ID="Link_Manger_Name" runat="server" Text='<%# Bind("Man_English_Name") %>'
                                    OnClick="LinkButton1_Click" /></br>
                              <%--   </li>  </ul>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton CssClass="mangerList_link" ID="Link_Manger_Name" runat="server" Text='<%# Bind("Man_English_Name") %>'
                            OnClick="LinkButton1_Click" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            
            <Columns>
            <asp:TemplateField >
            <ItemTemplate >
               <%-- <a id="A1" runat="server" href='<%# string.Concat(CVPath(Eval("Man_ID").ToString()),Eval("Man_CV_Path")) %>'>--%>
                    <asp:Image ID="Manger_Image" runat="server" ImageUrl='<%#string.Concat(ImagePath(Eval("Man_ID").ToString()), Eval("Man_Photo_Path"))  %>'
                     Visible='<%#System.IO.File.Exists(Server.MapPath (string.Concat(ImagePath(), Eval("Man_Photo_Path")))) %>'  Width="111px" Height="144px" />
            <%--    </a>--%>
              <%--<asp:LinkButton CssClass="mangerList_link" ID="Link_Manger_Name" runat="server" Text='<%# Bind("Man_English_Name") %>'
                            OnClick="LinkButton1_Click" />--%>
            </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>
    
    <asp:View ID="View2" runat="server">
        <table class="front">
            <tr>
                <td class="bg">
                    <asp:Label ID="Label1" CssClass="Label_form" runat="server" Text="Manger Name "></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Label_Manger_Name" runat="server"></asp:Label></td>
                <td rowspan="6" align="center" class="mangerList_img">
                    <asp:Image ID="Mager_Image" runat="server" Width="111px" Height="144px"/></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label2" CssClass="Label_form" runat="server" Text=" Start Date "
                        Width="116px"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Label_Manger_StartDate" runat="server" Width="176px"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label3" CssClass="Label_form" runat="server" Text="End Date"
                        Width="128px"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Label_Manger_EndDate" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label4" CssClass="Label_form" runat="server" Text="Telephone " Width="128px"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Label_Manger_Phone" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="height: 30px">
                    <asp:Label ID="Label6" CssClass="Label_form" runat="server" Text="Mail  "
                        Width="128px"></asp:Label></td>
                <td class="bg2" style="height: 30px">
                    <asp:Label ID="Label_Manger_Mail" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label5" runat="server" CssClass="Label_form" Text="CV "
                        Width="128px"></asp:Label></td>
                <td class="bg2">
                    <asp:HyperLink ID="CV_Link" Target="_blank"  runat="server">CV Dwonload</asp:HyperLink></td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
