<%@ Page Language="C#" MasterPageFile="~/FrontEnd/ar/AR_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="NewsDetails.aspx.cs" Inherits="ar_NewsDetails" Title="ÊÝÇÕíá ÇáÇÎÈÇÑ" %>

<%@ Register Src="../AR_Controls/NewsDetails.ascx" TagName="NewsDetails1" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:NewsDetails1 ID="NewsDetails1" runat="server" />
</asp:Content>

