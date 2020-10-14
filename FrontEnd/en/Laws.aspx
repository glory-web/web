<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Laws.aspx.cs" Inherits="en_Laws" Title="Laws Information" %>

<%@ Register Src="../EN_Controls/Laws.ascx" TagName="Laws" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2 class="main_title">Laws Information</h2>
<p><uc1:Laws ID="Laws1" runat="server" /></p>

			

</asp:Content>

