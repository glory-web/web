<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Publications.aspx.cs" Inherits="en_Publications" Title="Brochures" %>

<%@ Register Src="../EN_Controls/Brochures.ascx" TagName="Brochures" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2 class="main_title">Brochures</h2>
				        <p><uc1:Brochures ID="Brochures1" runat="server" /></p>
</asp:Content>

