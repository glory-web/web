<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="en_Books" Title="Library" %>

<%@ Register Src="../EN_Controls/Books.ascx" TagName="Books" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2 class="main_title">Library</h2>
				        <p><uc1:Books ID="Books1" runat="server" /></p>

</asp:Content>

