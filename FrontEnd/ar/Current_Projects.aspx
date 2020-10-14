<%@ Page Language="C#" MasterPageFile="~/FrontEnd/ar/AR_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Current_Projects.aspx.cs" Inherits="ar_Current_Projects" Title="ÇáãÔÇÑíÚ ÇáÍÇáíÉ" %>

<%@ Register Src="../AR_Controls/Current_Projects.ascx" TagName="Current_Projects"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Current_Projects ID="Current_Projects1" runat="server" />
</asp:Content>

