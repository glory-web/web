<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Books.ascx.cs" Inherits="Books" %>

<asp:Label id="Label1" runat="server" Text="Category" Width="70px"></asp:Label>
<asp:DropDownList id="DDLCategory" runat="server" AutoPostBack="True"></asp:DropDownList>
<asp:Label id="Label2" runat="server" Text="Book Place " Width="95px"></asp:Label>
<asp:DropDownList id="DDLPLace" runat="server" AutoPostBack="True"></asp:DropDownList>

<asp:GridView SkinID="GridView_Style_1" ID="book_grid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    HorizontalAlign="Justify" OnPageIndexChanging="book_grid_PageIndexChanging" PageSize="20" CellSpacing="0" >
    <Columns>
        <asp:TemplateField HeaderText="Book Name ">
            <ItemTemplate>
               <asp:Label Width="250" ID="LIT_English_Book_Name" runat="server" Text='<%# Bind("Book_English_Name") %>'></asp:Label><br />
            </ItemTemplate>
        </asp:TemplateField>
         
        <asp:TemplateField HeaderText="Authour Name">
            <ItemTemplate>
                <asp:Label Width="250" ID="LIT_English_Authour_Name" runat="server" Text='<%# Bind("Authour_English_Name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Publication Year">
            <ItemTemplate>
                <asp:Label Width="70" ID="LIT_Publication_Year" runat="server" Text='<%# Bind("Publication_Year") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Book Places  ">
            <ItemTemplate>
                <asp:Label Width="150px" Font-Size="10" ID="LIT_English_Authour_Name" runat="server" Text='<%#book_place ( Eval("Org_ID").ToString()) %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
       
        
        
    </Columns>
</asp:GridView>
