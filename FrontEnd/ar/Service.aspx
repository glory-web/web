<%@ Page Language="C#" MasterPageFile="~/FrontEnd/ar/AR_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Service.aspx.cs" Inherits="ar_Service" Title="«бќѕг« " %>

<%@ Register Src="~/FrontEnd/AR_Controls/Services.ascx" TagName="Services" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
  <h2 class="main_title">ќѕг«  «бен∆…</h2>
				        <p><uc1:Services id="Services1" runat="server"></uc1:services><br /></p>
					

</asp:Content>

