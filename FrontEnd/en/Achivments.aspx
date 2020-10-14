<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Achivments.aspx.cs" Inherits="en_Achivments" Title="Achievements" %>

<%@ Register Src="../en_Controls/Achivments.ascx" TagName="Achivments" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <h2 class="main_title">Achievements</h2>
				        <p><uc1:Achivments ID="Achivments1" runat="server" /></p>
    
</asp:Content>

