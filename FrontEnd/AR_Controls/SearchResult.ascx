<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchResult.ascx.cs" Inherits="AR_Controls_Search" %>
<asp:Label ID="NoResultLabel" runat="server" Text="·« ÌÊÃœ ‰ «∆Ã »ÕÀ ·Â–Â «·ﬂ·„…"
    Visible="False"></asp:Label>
<asp:LinkButton ID="link_history" runat="server" Visible="False"> «—ÌŒ «·ÂÌ∆…</asp:LinkButton>
<asp:LinkButton ID="Link_Activity" runat="server" Visible="False" >√‰‘ÿ… «·ÂÌ∆…</asp:LinkButton>
<asp:LinkButton ID="link_Achivments" runat="server" Visible="False" >«‰Ã«“«  «·ÂÌ∆…</asp:LinkButton>
<asp:LinkButton ID="Link_goals" runat="server" Visible="False">√Âœ«› «·ÂÌ∆…</asp:LinkButton>
&nbsp; &nbsp;
<asp:GridView ID="Achivment_Grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="«‰Ã«“«  «·ÂÌ∆«  Ê«·«œ«—« ">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Achivment_Click" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle BackColor="#C0FFFF" />
</asp:GridView>
<asp:GridView ID="History_Grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText=" «—ÌŒ «·ÂÌ∆«  Ê«·«œ«—« ">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="History_Click" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle BackColor="#C0FFFF" />
</asp:GridView>
<asp:GridView ID="Activity_Grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="√‰‘ÿ… «·ÂÌ∆«  Ê«·«œ«—« ">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Activity_Click" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle BackColor="#C0FFFF" />
</asp:GridView>
<asp:GridView ID="Goals_Grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="√Âœ«› «·ÂÌ∆«  Ê«·«œ«—« ">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Goals_Click" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle BackColor="#C0FFFF" />
</asp:GridView>
<asp:GridView ID="book_grid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
     HorizontalAlign="Justify" OnPageIndexChanging="book_grid_PageIndexChanging"
    PageSize="20">
    <Columns>
        <asp:TemplateField HeaderText="«”„ «·ﬂ «»">
            <ItemTemplate>
            
                <asp:Literal ID="LIT_Arabic_Book_Name" runat="server" Text='<%# Bind("Book_Arabic_Name") %>'></asp:Literal><br />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="«”„ «·„ƒ·›">
            <ItemTemplate>
                <asp:Literal ID="LIT_Arabic_Authour_Name" runat="server" Text='<%# Bind("Authour_Arabic_Name") %>'></asp:Literal>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="”‰… «·‰‘—">
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
        <asp:TemplateField HeaderText="«· ⁄«Ê‰ «·œÊ·Ì">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# Bind("Coop_Arabic_Name") %>' OnClick="Cooperation_Click"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <AlternatingRowStyle BackColor="#C0FFFF" />
</asp:GridView>
<asp:GridView ID="Brochures_grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="«·„ÿ»Ê⁄« ">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Brochures_Click" Text='<%# Bind("Brochure_Arabic_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:GridView ID="services_grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="«·Œœ„« ">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Services_Click" Text='<%# Bind("Service_Arabic_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:GridView ID="projects_grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="«·„‘«—Ì⁄">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Project_Click" Text='<%# Bind("Project_Arabic_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:GridView ID="laws_grid" runat="server" AutoGenerateColumns="False" >
    <Columns>
        <asp:TemplateField HeaderText="«·ﬁÊ«‰Ì‰">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Laws_Click" Text='<%# Bind("law_Arabic_Name") %>'>LinkButton</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

