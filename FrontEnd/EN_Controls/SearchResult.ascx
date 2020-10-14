<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchResult.ascx.cs" Inherits="AR_Controls_Search" %>
<asp:Label ID="NoResultLabel" runat="server" Text="No Result "
    Visible="False"></asp:Label>
<asp:LinkButton ID="link_history" runat="server" Visible="False">History</asp:LinkButton>
<asp:LinkButton ID="Link_Activity" runat="server" Visible="False" >Activity</asp:LinkButton>
<asp:LinkButton ID="link_Achivments" runat="server" Visible="False" >Achivments</asp:LinkButton>
<asp:LinkButton ID="Link_goals" runat="server" Visible="False">Mission </asp:LinkButton>
&nbsp; &nbsp;
<asp:GridView ID="Achivment_Grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="Achivments">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Achivment_Click" Text='<%# Bind("ORG_English_Name") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle BackColor="#C0FFFF" />
</asp:GridView>
<asp:GridView ID="History_Grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="History">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="History_Click" Text='<%# Bind("ORG_English_Name") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle BackColor="#C0FFFF" />
</asp:GridView>
<asp:GridView ID="Activity_Grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="Activity">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Activity_Click" Text='<%# Bind("ORG_English_Name") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle BackColor="#C0FFFF" />
</asp:GridView>
<asp:GridView ID="Goals_Grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="Mission">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Goals_Click" Text='<%# Bind("ORG_English_Name") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle BackColor="#C0FFFF" />
</asp:GridView>
<asp:GridView ID="book_grid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
     HorizontalAlign="Justify" OnPageIndexChanging="book_grid_PageIndexChanging"
    PageSize="20">
    <Columns>
        <asp:TemplateField HeaderText="Book name">
            <ItemTemplate>
            
                <asp:Literal ID="LIT_English_Book_Name" runat="server" Text='<%# Bind("Book_English_Name") %>'></asp:Literal><br />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Authour">
            <ItemTemplate>
                <asp:Literal ID="LIT_English_Authour_Name" runat="server" Text='<%# Bind("Authour_English_Name") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Publication_Year">
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
<asp:GridView ID="cooperation_grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="Cooperation">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Bind("Coop_English_Name") %>' OnClick="Cooperation_Click"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle BackColor="#C0FFFF" />
</asp:GridView>
<asp:GridView ID="Brochures_grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="Brochures">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Brochures_Click" Text='<%# Bind("Brochure_English_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:GridView ID="services_grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="Services">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Services_Click" Text='<%# Bind("Service_English_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:GridView ID="projects_grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="Projects">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Project_Click" Text='<%# Bind("Project_English_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:GridView ID="laws_grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="Laws">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Laws_Click" Text='<%# Bind("law_English_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

