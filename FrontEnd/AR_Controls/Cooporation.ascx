<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Cooporation.ascx.cs" Inherits="Cooporation" %>

<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="cooperation_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False">
    <Columns>
        <asp:TemplateField HeaderText="ÇáÊÚÇæä ãÚ ÇáÌåÇÊ ÇáÇÎÑí">
            <ItemTemplate>
                <asp:LinkButton CssClass="HighLightsItems" ID="LinkButton1" runat="server" Text ='<%# Bind("Coop_Arabic_Name") %>' OnClick="LinkButton1_Click" ></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
            <AlternatingRowStyle /><%--BackColor="#C0FFFF" --%>
</asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">
         <table class="front">
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label1" runat="server" Text="ÇÓã ÇáÊÚÇæä"></asp:Label></td>
                <td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Coop_Name" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label2" runat="server" Text="æÕÝ ÇáÊÚÇæä"></asp:Label></td>
                <td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Coop_Content" runat="server"></asp:Label></td>
            </tr>
             <tr>
                 <td class="bg">
                     <asp:Label ID="Label4" runat="server" CssClass="Label_form" Text="ÇáÏæá ÇáãÔÇÑßÉ"></asp:Label></td>
                 <td class="bg2">
                     <asp:GridView ID="contries_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False">
                         <Columns>
                             <asp:TemplateField HeaderText="ÇáÊÚÇæä ãÚ ÇáÌåÇÊ ÇáÇÎÑí">
                                 <ItemTemplate>
                                     <asp:Label ID="label1" runat="server"   Text='<%# Bind("Second_Org_Arabic_Name") %>'></asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateField>
                         </Columns>
                        <%-- <RowStyle BackColor="#FFE8EC"/>--%>
                         <AlternatingRowStyle BackColor="#FFE8EC"/>
                     </asp:GridView>
                 </td>
             </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label3" runat="server" Text="ÇáÊÇÑíÎ"></asp:Label></td>
                <td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Coop_Date" runat="server"></asp:Label></td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
