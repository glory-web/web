<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="BookCategory.aspx.cs" Inherits="BookCategory" Title="ÊÕäíÝÇÊ ÇáßÊÈ" %>

<%@ Register Src="UserControls/BookCategory.ascx" TagName="BookCategory" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:BookCategory ID="BookCategory1" runat="server" />
</asp:Content>

