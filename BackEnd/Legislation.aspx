<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="Legislation.aspx.cs" Inherits="BackEnd_Legislation" Title="ÇáÞÑÇÑÇÊ" %>

<%@ Register Src="UserControls/Legislation.ascx" TagName="Legislation" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Legislation ID="Legislation1" runat="server" />
</asp:Content>

