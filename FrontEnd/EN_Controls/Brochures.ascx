<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Brochures.ascx.cs" Inherits="Brochures" %>
<asp:Label ID="Label4" runat="server" Text="Category" Width="70px"></asp:Label>
<asp:DropDownList ID="DDLCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCategory_SelectedIndexChanged">
</asp:DropDownList>
<asp:Label ID="Label5" runat="server" Text="Brochures Place" Width="130px"></asp:Label>
<asp:DropDownList ID="DDLPLace" runat="server" AutoPostBack="True">
</asp:DropDownList>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="Brochures_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False">
            <Columns>
                <asp:TemplateField HeaderText="Brochures">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="HighLightsItems" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"
                            Text='<%# Bind("Brochure_English_Name") %>'>LinkButton</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <table class="front">
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label1" runat="server" Text="Brochures Name "></asp:Label>
                </td>
                <td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Brochures_Name" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label6" runat="server" CssClass="Label_form" Text="Brochures Place"></asp:Label>
                </td>
                <td class="bg2">
                    <asp:Label ID="Label_Brochures_place" runat="server" CssClass="Label_details"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label7" runat="server" CssClass="Label_form" Text="Brochures Price"></asp:Label>
                </td>
                <td class="bg2">
                    <asp:Label ID="Label_Brochures_Price" runat="server" CssClass="Label_details"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label2" runat="server" Text="Brochures Date"></asp:Label>
                </td>
                <td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Brochures_Date" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label3" runat="server" Text="Brochures Download"></asp:Label>
                </td>
                <td class="bg2">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("File_Path") %>' NavigateUrl='<%#string.Concat(FilePath(), Eval("File_Path")) %>'>HyperLink</asp:HyperLink>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
