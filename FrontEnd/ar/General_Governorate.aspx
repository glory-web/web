<%@ Page Language="C#" MasterPageFile="~/FrontEnd/ar/AR_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="General_Governorate.aspx.cs" Inherits="ar_Governorate" Title="�������� ������" %>

<%@ Register Src="../AR_Controls/General_Department.ascx" TagName="General_Department"
    TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <h2 class="main_title">�������� ������</h2>
    <uc1:General_Department ID="General_Department1" runat="server" />
				       

</asp:Content>

