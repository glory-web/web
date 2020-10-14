<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" StylesheetTheme="style" AutoEventWireup="true" CodeFile="NewsDetails.aspx.cs" Inherits="en_NewsDetails" Title="News Details" %>

<%@ Register Src="../EN_Controls/NewsDetails.ascx" TagName="NewsDetails" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:NewsDetails id="NewsDetails1" runat="server">
    </uc1:NewsDetails>
   
</asp:Content>

