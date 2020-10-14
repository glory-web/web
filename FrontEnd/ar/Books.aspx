<%@ Page Language="C#" MasterPageFile="~/FrontEnd/ar/AR_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="ar_Books" Title="«·„ﬂ »…" %>

<%@ Register Src="../AR_Controls/Books.ascx" TagName="Books" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="main_title">«·„ﬂ »…</h2>
    <p><uc1:Books ID="Books1" runat="server" /></p><br />
</asp:Content>

