<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/en_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Central_Governorate.aspx.cs" Inherits="ar_Governorate" Title="Central Governorate" %>

<%@ Register Src="../en_Controls/Central_Department.ascx" TagName="Central_Department"
    TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <h2 class="main_title">Central Department</h2>
    <uc1:Central_Department ID="Central_Department1" runat="server" />
				      

</asp:Content>

