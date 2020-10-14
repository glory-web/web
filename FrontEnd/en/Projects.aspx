<%@ Page Language="C#" MasterPageFile="~/FrontEnd/en/EN_MasterPage.master" Theme="style" AutoEventWireup="true" CodeFile="Projects.aspx.cs" Inherits="en_Projects" Title="Projects" %>

<%@ Register Src="../EN_Controls/Projects.ascx" TagName="Projects" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
     <div class="tablestyle">
				<%--<div class="rb"><div class="lb"><div class="rt"><div class="lt">--%>
					
					<%--<h2 class="title"><span class="spantitle">Projects</span></h2>--%>
				        <p><uc1:Projects ID="Projects1" runat="server" /></p>
					
				<%--</div></div>--%>
                   <%--</div></div>--%>
			</div>
			
</asp:Content>

