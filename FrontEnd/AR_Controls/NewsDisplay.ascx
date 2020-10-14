<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsDisplay.ascx.cs" Inherits="AR_Controls_NewsDetails" %>
<br />
&nbsp;<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="news_grid" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="«·«Œ»«—">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("News_Arabic_Title") %>'></asp:Label><br />
                        <asp:Label ID="Label2" runat="server" Text='<%# NewsContent(Eval("News_Arabic_Content").ToString()) %>'></asp:Label><br />
                        <asp:LinkButton CssClass="links_form" ID="LinkButton1" runat="server"  Text='«·„“Ìœ' OnClick ="LinkButton1_Click">«·„“Ìœ</asp:LinkButton>
                        <asp:Image runat="server" ImageUrl ='<%# String.Concat(ImagePath() ,Eval("ImagePath"))%>' Width="111px" Height="144px"> </asp:Image>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">
<asp:Literal ID="News_Title" runat="server"></asp:Literal><asp:Literal ID="News_Content" runat="server"></asp:Literal></asp:View>
</asp:MultiView>
