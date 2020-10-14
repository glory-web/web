<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdvancedSearch.ascx.cs" Inherits="AR_Controls_AdvancedSearch" %>
<table dir="rtl" style="width: 266px">
    <tr>
        <td style="width: 93px">
            <asp:Label ID="Label1" runat="server" Text="��� �����"></asp:Label></td>
        <td>
            <asp:DropDownList ID="DDLType" runat="server">
                <asp:ListItem Value="0">����� ��� </asp:ListItem>
                <asp:ListItem Value="1">���� �� </asp:ListItem>
                <asp:ListItem Value="2">����� �� </asp:ListItem>
                <asp:ListItem Value="3">��� �����</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 93px">
            <asp:Label ID="Label2" runat="server" Text="����� ��" Width="59px"></asp:Label></td>
        <td>
            <asp:DropDownList ID="DDLWhere" runat="server">
                <asp:ListItem Value="0">����</asp:ListItem>
                <asp:ListItem Value="1">�������</asp:ListItem>
                <asp:ListItem Value="2">��������</asp:ListItem>
                <asp:ListItem Value="3">���������</asp:ListItem>
                <asp:ListItem Value="4">������� </asp:ListItem>
                <asp:ListItem Value="5">��������</asp:ListItem>
                <asp:ListItem Value="6">������� ������</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 93px">
            <asp:Label ID="Label3" runat="server" Text="����"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtSearch" runat="server" Width="204px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 93px">
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" OnClick="Search_Click" Text="����" Width="209px" /></td>
    </tr>
</table>
<br />
<asp:GridView ID="book_grid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    CellSpacing="10" HorizontalAlign="Justify" OnPageIndexChanging="book_grid_PageIndexChanging"
    PageSize="20">
    <Columns>
        <asp:TemplateField HeaderText="��� ������">
            <ItemTemplate>
                <asp:Literal ID="LIT_Arabic_Book_Name" runat="server" Text='<%# Bind("Book_Arabic_Name") %>'></asp:Literal><br />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="��� ������">
            <ItemTemplate>
                <asp:Literal ID="LIT_Arabic_Authour_Name" runat="server" Text='<%# Bind("Authour_Arabic_Name") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="��� �����">
            <ItemTemplate>
                <asp:Literal ID="LIT_Publication_Year" runat="server" Text='<%# Bind("Publication_Year") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Authour Name" Visible="False">
            <ItemTemplate>
                <asp:Literal ID="LIT_English_Authour_Name" runat="server" Text='<%# Bind("Authour_English_Name") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Book Name" Visible="False">
            <ItemTemplate>
                <asp:Literal ID="LIT_English_Book_Name" runat="server" Text='<%# Bind("Book_English_Name") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<br />
<asp:GridView ID="cooperation_grid" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="������� ������">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Cooperation_Click" Text='<%# Bind("Coop_Arabic_Name") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle BackColor="#C0FFFF" />
</asp:GridView>
<br />
<asp:GridView ID="Brochures_grid" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="���������">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Brochures_Click" Text='<%# Bind("Brochure_Arabic_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<br />
<asp:GridView ID="services_grid" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="�������">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Services_Click" Text='<%# Bind("Service_Arabic_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<br />
<asp:GridView ID="projects_grid" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="��������">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Project_Click" Text='<%# Bind("Project_Arabic_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<br />
<asp:GridView ID="laws_grid" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="��������">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Laws_Click" Text='<%# Bind("law_Arabic_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
