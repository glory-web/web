<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Cooperation.aspx.cs" Inherits="en_Cooperation" Title="Cooperations" %>

<%@ Register Src="../EN_Controls/Cooporation.ascx" TagName="Cooporation" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2 class="main_title">Cooperations</h2>
<p><uc1:Cooporation ID="Cooporation1" runat="server" /></p>
</asp:Content>

