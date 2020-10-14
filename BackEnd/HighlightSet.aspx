<%@ Page Language="C#" MasterPageFile="~/BackEnd/Master.master" AutoEventWireup="true" CodeFile="HighlightSet.aspx.cs" Inherits="BackEnd_HighlightSet" Title="ÇÚÏÇÏÇÊ ÇáãæÇÖíÚ ÇáåÇãÉ" %>

<%@ Register Src="UserControls/HighlightSet.ascx" TagName="HighlightSet" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TopNav" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:HighlightSet id="HighlightSet1" runat="server"></uc1:HighlightSet>
</asp:Content>

