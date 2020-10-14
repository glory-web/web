<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Governorate.aspx.cs" Inherits="en_Governorate" Title="Directorates" %>

<%@ Register Src="../EN_Controls/Governorate.ascx" TagName="Governorate" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
      <h2 class="main_title">Directorates</h2>
				        <p>  <uc1:governorate id="Governorate1" runat="server"></uc1:governorate></p>

</asp:Content>

