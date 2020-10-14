<%@ Page Language="C#" MasterPageFile="~/FrontEnd/ar/AR_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ar_Default" Title="«бен∆… «бЏ«г… ббќѕг«  «б»нЎ—н…" %>

<%@ Register Src="../AR_Controls/ExepertLinks.ascx" TagName="ExepertLinks" TagPrefix="uc5" %>

<%@ Register Src="../AR_Controls/Books.ascx" TagName="Books" TagPrefix="uc3" %>
<%@ Register Src="../AR_Controls/Boxes.ascx" TagName="Boxes" TagPrefix="uc4" %>

<%@ Register Src="../AR_Controls/Links.ascx" TagName="Links" TagPrefix="uc2" %>

<%@ Register Src="../AR_Controls/CurrentManager.ascx" TagName="CurrentManager" TagPrefix="uc1" %>

<%@ Register Src="../AR_Controls/HighLights.ascx" TagName="HighLights" TagPrefix="uc11" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<uc11:HighLights ID="HighLights1" runat="server" />
		
		<!--
					<div class="cont">
					<h2 class="main_title">гёѕг…</h2>
					<img src="img/logo.gif" alt="logo" style="float:left; margin:0 4px;;" />
					<p>√д‘∆  «бен∆… «бЏ«г… ббќѕг«  «б»нЎ—н… »ё—«— —∆н” ћгеж—н… г’— «бЏ—»н… —ёг 187 б”д… 1984 Ц ЌнЋ  еѕЁ «бен∆… ≈бм Ќг«н… «бЋ—ж… «бЌнж«дн…, жгд ћ« е« Џд Ў—нё жё«н… е–е «бЋ—ж… «бёжгн… гд «б√г—«÷ «бгЏѕн… ж«бж»«∆н…- я–бя Џб«ћ е–е «бЋ—ж… гд «бЌ«б«  «бЏ«—÷… ж«б√г—«÷ «б д«”бн… ж«б√г—«÷ «б н  ƒѕм ≈бм  ѕеж— ≈д «ћн е«. «б√г— «б–н нƒѕм ≈бм  дгн… «б«ё ’«ѕ «бёжгн ж«б«— Ё«Џ »гЏѕб«  «б≈д «ћ ЌнЋ нёб  ѕ—нћн« «б«Џ г«ѕ Џбм «” н—«ѕ «ббЌжг жгд ћ« е« гд ќ«—ћ «б»б«ѕ.  Џгб √ће“… «бен∆… «бг Џѕѕ… »г« н жЁ— бѕне« гд ≈гя«дн«  г«ѕн… ж»‘—н… Џбм “н«ѕ… «бѕќб «бёжгн- жЁм ”»нб –бя   Џѕѕ «б√д‘Ў… «б»нЎ—н… «б н  ƒѕне« «бен∆… </p></div>
			-->	
   <br /> 
  
  <!-- 
    <table style="border:1px solid #1176A2; width:100%; text-decoration:none;margin-bottom:20px;clear:both">
       <tr style="background-color:#157BCB"><%--#5CC3F0--%>
           <td colspan="2" style="text-align:right; float:right; padding-right:10px;font-weight:bold;font-size:16px;height:20px;padding-top:5px;">
               н—«гћ «бг‘—жЏ «бёжгн бб —ёнг ж«б ”ћнб
               </td>
       </tr>
       <tr>
           <td colspan=2 style="height: 19px">
              <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://www.govs.gov.eg/bovis">дў«г  —ёнг «бћ«гж” ж«б«»ё«—</asp:HyperLink></td>
       </tr>
          <tr>
           <td colspan=2 style="height:19px; background-color:#ACD5F9;"><%-- #ccffff--%>
               <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="http://www.govs.gov.eg/coding">дў«г  —ёнг «б«џд«г ж«бг«Џ“ </asp:HyperLink></td>
       </tr>
              <tr>
           <td colspan=2 style="height: 19px">
               <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="http://www.govs.gov.eg/poultrycoding">дў«г  —ёнг «бд‘«Ў «бѕ«ћдм</asp:HyperLink></td>
       </tr>
       
   
   </table> 
                
            
    <uc5:ExepertLinks ID="ExepertLinks1" runat="server" /> -->
            
     
          
         
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <uc1:CurrentManager id="CurrentManager2" runat="server">
    </uc1:CurrentManager>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder4">
   <%-- <uc4:Boxes ID="Boxes1" runat="server" />--%>
   <uc2:Links ID="Links1" runat="server" />
</asp:Content>

