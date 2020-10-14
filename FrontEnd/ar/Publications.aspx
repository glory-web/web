<%@ Page Language="C#" MasterPageFile="~/FrontEnd/ar/AR_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Publications.aspx.cs" Inherits="ar_Publications" Title="ÇáãØÈæÚÇÊ" %>

<%@ Register Src="../AR_Controls/Brochures.ascx" TagName="Brochures" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


	<h2 class="main_title" >ÇáãØÈæÚÇÊ</h2>
    <p> <uc1:Brochures ID="Brochures1" runat="server" /></p>

</asp:Content>

