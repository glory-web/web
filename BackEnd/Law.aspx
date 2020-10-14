<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Law.aspx.cs" Inherits="Law" Title="ÇáÞæÇäíä" %>

<%@ Register Src="UserControls/Law.ascx" TagName="Law" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Law ID="Law1" runat="server" />
</asp:Content>

