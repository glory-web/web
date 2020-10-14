<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Books" Title="ÇáãßÊÈÉ" %>

<%@ Register Src="UserControls/Books.ascx" TagName="Books" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Books ID="Books1" runat="server" />
</asp:Content>

