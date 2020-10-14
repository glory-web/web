<%@ Control Language="C#" AutoEventWireup="true" CodeFile="General_Department.ascx.cs" Inherits="AR_Controls_Governorate" %>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
<asp:GridView ID="governorate_grid" runat="server"  AutoGenerateColumns="False" ShowHeader="False">
    <Columns>
        <asp:TemplateField HeaderText="���������">
            <ItemTemplate>
                <asp:LinkButton CssClass="HighLightsItems" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Bind("ORG_Arabic_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">
        <table class="front">
            <tr>
                <td class="bg" style="height: 21px">
                    <asp:Label ID="Label6" runat="server" CssClass="Label_form" Text="��� �������"></asp:Label></td>
                <td class="bg2" style="height: 21px">
                    <asp:Label ID="lit_name" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="height: 21px">
                    <asp:Label ID="Label4" runat="server" CssClass="Label_form" Text="���� ��� �������"></asp:Label></td>
                <td class="bg2" style="height: 21px">
                    <asp:Image ID="Manger_Image" runat="server" Width="111px" Height="144px" /><br />
                    <asp:HyperLink ID="manger_HyperLink" runat="server"></asp:HyperLink>
                    <asp:Label ID="Label_Manager_Date" runat="server"></asp:Label></td>
            </tr>
           <tr>
                <td class="bg" style="height: 21px">
                    <asp:Label ID="Label8" runat="server" CssClass="Label_form" Text="����� �������"></asp:Label></td>
                <td class="bg2" style="height: 21px">
                    <asp:Label ID="lit_address" runat="server"></asp:Label></td>
            </tr>
          
            <tr>
                <td class="bg" style="height: 21px">
                    <asp:Label ID="Label3" runat="server" CssClass="Label_form" Text="����� ����������"></asp:Label></td>
                <td class="bg2" style="height: 21px">
                    <asp:Label ID="Lit_Telephone" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="height: 21px">
                    <asp:Label ID="Label5" runat="server" CssClass="Label_form" Text="������"></asp:Label></td>
                <td class="bg2" style="height: 21px">
                    <asp:Label ID="Lit_Fax" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="height: 21px">
                    <asp:Label ID="Label7" runat="server" CssClass="Label_form" Text="������ ���������� "
                        Width="128px"></asp:Label></td>
                <td class="bg2" style="height: 21px">
                    <asp:Label ID="Label_Mail" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg" style="height: 21px">
                    <asp:Label CssClass="Label_form" ID="Literal1" runat="server" Text="���������"></asp:Label></td>    
                <td class="bg2" style="height: 21px">
                    <asp:Label ID="Lit_Achivments" runat="server"></asp:Label></td>
            </tr>
            <tr>
                    <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Literal2" runat="server" Text="�������"></asp:Label></td>
                <td class="bg2">
                    <asp:Label ID="Lit_Activity" runat="server"></asp:Label></td>
            </tr>
            <tr>
                    <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Literal3" runat="server" Text="����� "></asp:Label></td>
                    <td class="bg2">
                    <asp:Label ID="Lit_Histoty" runat="server"></asp:Label></td>
            </tr>
            <tr>
                    <td class="bg" style="height: 21px">
                    <asp:Label CssClass="Label_form" ID="Literal5" runat="server" Text="�������"></asp:Label></td>
                <td class="bg2" style="height: 21px">
                    <asp:Label ID="Lit_Goals" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label1" runat="server" CssClass="Label_form" Text="������� ���� ������ "></asp:Label></td>
              <%--  <td class="bg2" dir="ltr">--%>
                 <td class="bg2" >
                    <asp:GridView ID="services_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False" ><%--Width="556px"--%>
                        <Columns>
                            <asp:TemplateField HeaderText="�������">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="links_form" OnClick="Service_Click"
                                        Text='<%# Bind("Service_Arabic_Name") %>'>LinkButton</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="bg">
                    <asp:Label ID="Label2" runat="server" CssClass="Label_form" Text="�������� ������� "></asp:Label></td>
               <%-- <td class="bg2" dir="ltr">--%>
                 <td class="bg2" >
                    <asp:GridView ID="gov_dep_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False" Width="605px">
                        <Columns>
                            <asp:TemplateField HeaderText="��������">
                                <ItemTemplate>
                                    <asp:Label ID="LinkButton1" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
