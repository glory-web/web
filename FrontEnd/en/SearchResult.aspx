<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="ar_SearchResult" Title="Search Result" %>

<%@ Register Src="../EN_Controls/SearchResult.ascx" TagName="SearchResult" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:SearchResult id="SearchResult1" runat="server">
    </uc1:SearchResult>
</asp:Content>

