<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Services.ascx.cs" Inherits="Services" %>

<asp:Label ID="Label6" runat="server" Text="áãä ÊÞÏã ÇáÎÏãÉ"></asp:Label>

<asp:DropDownList CssClass="dropdown_form center" ID="DDL_services" 
    runat="server" AutoPostBack="True" 
    OnSelectedIndexChanged="DDL_services_SelectedIndexChanged" Height="25px" 
    Width="609px">
</asp:DropDownList>
<br />
<br />
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="services_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False">
            <Columns>
                <asp:TemplateField HeaderStyle-CssClass="HighLightsHead" HeaderText="ÇáÎÏãÇÊ">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="HighLightsItems" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Bind("Service_Arabic_Name") %>'>LinkButton</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
       
    </asp:View>
    <asp:View ID="View2" runat="server">
            <table class="front">
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label1" runat="server" Text="ÇÓã ÇáÎÏãÉ" ></asp:Label>
                </td><td class="bg2"> 
                    <asp:Label ID="Label_Services_Name" runat="server"></asp:Label>
            </td></tr>
            <tr>
                <td class="bg">
               
                    <asp:Label CssClass="Label_form" ID="Label3" runat="server" Text="ÇáÌåÉ ÇáÊí ÊÞÏãåÇ" ></asp:Label>
               </td><td class="bg2"> 
                    <asp:Label ID="Label_Services_Provider" runat="server"></asp:Label>
            </td></tr>
            <tr>
                <td class="bg">
                
                    <asp:Label CssClass="Label_form" ID="Label2" runat="server" Text="ÔÑæØ ÇáÎÏãÉ " ></asp:Label>
               </td><td class="bg2">  
                    <asp:Label ID="Label_Services_Conditions" runat="server"></asp:Label>
            </td></tr>
            <tr>
                <td class="bg">
               
                    <asp:Label CssClass="Label_form" ID="Label4" runat="server" Text="ÇÌÑÇÁÊ ÇáÎÏãÉ" ></asp:Label>
                </td><td class="bg2"> 
                    <asp:Label ID="Label_Service_Procedures" runat="server" ></asp:Label>
            </td></tr>
            <tr>
                <td class="bg">
               
                    <asp:Label CssClass="Label_form" ID="Label5" runat="server" Text="ãáÝÇÊ ÇáÎÏãÉ"></asp:Label>
                </td>
                <td class="bg2"> 
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate >
                             <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("File_Arabic_Name") %>' NavigateUrl='<%#string.Concat(FilePath() + Eval("ORG_ID")+ "_Files/Services/", Eval("File_Path")) %>' Target= "_blank">HyperLink</asp:HyperLink>
                        </ItemTemplate>
                    </asp:Repeater>                  
               
            </td>
            </tr>
            </table>
        
    </asp:View>
</asp:MultiView>
