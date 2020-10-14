<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" CodeFile="NationalPrograms.aspx.cs" Inherits="FrontEnd_en_NationalPrograms" %>

<%@ Register Src="~/FrontEnd/EN_Controls/NationalLinks.ascx"  TagName="NationalLinks" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="main_title">National Programe</h2>
    <uc1:NationalLinks ID="NationalLinks1" runat="server" />
</asp:Content> 