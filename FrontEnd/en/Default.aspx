<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="en_Default" Title="General Organization Veterinary Services" %>

<%@ Register Src="../EN_Controls/ExepertLinks.ascx" TagName="ExepertLinks" TagPrefix="uc3" %>

<%@ Register Src="../EN_Controls/Links.ascx" TagName="Links" TagPrefix="uc2" %>

<%@ Register Src="../EN_Controls/CurrentManager.ascx" TagName="CurrentManager" TagPrefix="uc1" %>
<%@ Register Src="../EN_Controls/HighLights.ascx" TagName="HighLights" TagPrefix="uc11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc11:HighLights ID="HighLights1" runat="server" />
		
   <br />
    <%--<div class="cont">
        <h2 class="main_title">Introduction</h2>
		<img src="img/logo.gif" alt="logo" style="float:left; margin:0 4px;;" />
		<p>General Authority for Veterinary Services, the decision of the President of the Arab Republic of Egypt No. 187 of 1984 - where the Commission aims to protect livestock and their products through the protection of this national wealth of communicable and infectious diseases - as well as treatment of this wealth of cases, the bar and sexually transmitted diseases and diseases that lead to the deterioration of productivity . Which lead to the development of national economy and increase production rates, where less and less reliance on imported meat and meat products from outside the country. The multi-function devices available, including its potential human and material to increase the national income - In order that multiple activities performed by the Veterinary Authority </p>
        <p>&nbsp;</p>
                
        <table dir=ltr style="direction:ltr; border:1px solid #1176A2; width:100%; text-decoration:none;margin-bottom:20px;clear:both; text-align: left;" border="5" cellpadding="5" cellspacing="5">
            <tr style="background-color:#5CC3F0">
                <td colspan="2" style="height: 16px; text-align: left;">
                    <span style="color: #000066"><strong>Expert systems&nbsp;</strong></span>
               </td>
            </tr>
            <tr>
                <td colspan=2 style="height: 19px; text-align: left;">
                    &nbsp;&nbsp;<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://www1.govs.gov.eg/poultrycare/Chekencare.aspx">poultry Care Expert System </asp:HyperLink></td>
            </tr>
            <tr>
                <td colspan=2 style="height: 19px; background-color: #ccffff; text-align: left;">
                    &nbsp;&nbsp;<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="http://www.govs.gov.eg/poultrydiagnosis/">Poultry Diagnosis Expert System </asp:HyperLink></td>
            </tr>
            <tr>
                <td colspan=2 style="height: 19px; text-align: left;">
                    &nbsp;&nbsp;<asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="http://nerakin.claes.sci.eg/poultry/">Poultry Feeding Expert System </asp:HyperLink></td>
            </tr>
        </table>
        
        <uc3:ExepertLinks ID="ExepertLinks1" runat="server" />
                
    </div>--%>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <uc1:CurrentManager id="CurrentManager2" runat="server">
    </uc1:CurrentManager><br />
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder4">
   <%-- <uc4:Boxes ID="Boxes1" runat="server" />--%>
   <uc2:Links ID="Links1" runat="server" />
</asp:Content>

