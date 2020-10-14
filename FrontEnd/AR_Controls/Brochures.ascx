<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Brochures.ascx.cs" Inherits="Brochures" %>
        
<asp:Label id="Label4" runat="server" Text="ÇáÊÕäíÝÇÊ" Width="70px"></asp:Label>
<asp:DropDownList id="DDLCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCategory_SelectedIndexChanged"></asp:DropDownList>
&nbsp;&nbsp;
<asp:Label ID="Label5" runat="server" Text="ãÕÏÑ ÇáäÔÑ" Width="75px" 
    Visible="False"></asp:Label>
<asp:DropDownList
    ID="DDLPLace" runat="server" AutoPostBack="True" Visible="False">
</asp:DropDownList><asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="Brochures_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False">
            <Columns>
                <asp:TemplateField HeaderText="ÇáãØÈæÚÇÊ">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="HighLightsItems" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Bind("Brochure_Arabic_Name") %>'>LinkButton</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <table class="front">
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label1" runat="server" Text="ÇÓã ÇáãØÈæÚ"></asp:Label></td>
                <td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Brochures_Name" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label6" runat="server" CssClass="Label_form" Text="ÌåÉ ÇáäÔÑ"
                        Width="103px"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Label_Brochures_place" runat="server" CssClass="Label_details"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="height: 21px">
                    <asp:Label ID="Label7" runat="server" CssClass="Label_form" Text="Ëãä ÇáãØÈæÚ"></asp:Label></td>
                <td class="bg2" style="height: 21px">
                    <asp:Label ID="Label_Brochures_Price" runat="server" CssClass="Label_details"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label2" runat="server" Text="ÊÇÑíÎ ÇáäÔÑ"></asp:Label></td>
                <td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Brochures_Date" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label3" runat="server" Text="ÊÍãíá ÇáãØÈæÚÇÊ"></asp:Label></td>
               <td class="bg2"> 
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate >
                             <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("File_Path") %>' NavigateUrl='<%#string.Concat(FilePath(), Eval("File_Path")) %>' Target= "_blank">HyperLink</asp:HyperLink>
                        </ItemTemplate>
                    </asp:Repeater>
                    
               
            </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
