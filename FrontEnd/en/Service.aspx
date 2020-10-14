<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Service.aspx.cs" Inherits="en_Service" Title="Services" %>

<%@ Register Src="~/FrontEnd/EN_Controls/Services.ascx" TagName="Services" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2 class="main_title">Services</h2>
				        <p><uc1:Services id="Services1" runat="server"></uc1:services></p>

</asp:Content>

