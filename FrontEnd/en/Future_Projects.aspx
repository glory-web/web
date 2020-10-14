<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Future_Projects.aspx.cs" Inherits="ar_Future_Projects" Title="Future Projects" %>

<%@ Register Src="../EN_Controls/Future_Projects.ascx" TagName="Future_Projects"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Future_Projects ID="Future_Projects1" runat="server" />
</asp:Content>

