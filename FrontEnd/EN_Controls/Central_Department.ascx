<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Central_Department.ascx.cs" Inherits="AR_Controls_Governorate" %>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
<asp:GridView ID="governorate_grid" runat="server"  AutoGenerateColumns="False" ShowHeader="False">
    <Columns>
        <asp:TemplateField HeaderText="Governorate">
            <ItemTemplate>
                <asp:LinkButton CssClass="HighLightsItems" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Bind("ORG_English_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <table class="front">
            <tr>
                <td class="bg" style="width: 177px">
                    <asp:Label ID="Label3" runat="server" CssClass="Label_form" Text="Department Name"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Lit_name" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="width: 177px">
                    <asp:Label ID="Label1" runat="server" CssClass="Label_form" Text="Department Manger"></asp:Label></td>
                <td class="bg2">
                    <asp:Image ID="Manger_Image" runat="server" /><br />
                    <asp:HyperLink ID="manger_HyperLink" runat="server"></asp:HyperLink>
                    <asp:Label ID="Lit_Manger_Name" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="width: 177px">
                    <asp:Label CssClass="Label_form" ID="Literal1" runat="server" Text="Telephone"></asp:Label></td>    
                <td class="bg2">
                    <asp:Label ID="Lit_Telephone" runat="server"></asp:Label></td>
            </tr>
            <tr>
                    <td class="bg" style="width: 177px; height: 21px;">
                    <asp:Label CssClass="Label_form" ID="Literal2" runat="server" Text="Fax "></asp:Label></td>
                <td class="bg2" style="height: 21px">
                    <asp:Label ID="Lit_Fax" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="width: 177px; height: 21px">
                    <asp:Label ID="Label6" runat="server" CssClass="Label_form" Text="Mail   "
                        Width="128px"></asp:Label></td>
                <td class="bg2" style="height: 21px">
                    <asp:Label ID="Label_Mail" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="width: 177px">
                    <asp:Label ID="Label2" runat="server" CssClass="Label_form" Text="Department Related To   "></asp:Label></td>
                <td class="bg2" dir="ltr">
                    <asp:GridView ID="gov_dep_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False">
                        <Columns>
                            <asp:TemplateField HeaderText="ÇáÎÏãÇÊ">
                                <ItemTemplate>
                                    <asp:Label  ID="LinkButton1" runat="server" 
                                        Text='<%# Bind("ORG_English_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
