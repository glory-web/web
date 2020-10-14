<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlPanel.ascx.cs" Inherits="User_Controls_ControlPanel" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />
<! --------------------------From Here ------>
<div style="float: right; width:100%;">
      <br />
     <table cellpadding="0" cellspacing="0" class="blocks" id="blocks" width="100%" style="height:500px" dir="rtl">
    <tr>
        <td class="title" align="right" dir="rtl">
      لوحة التحكم الرئيسية
        </td>
    </tr>
    <tr>
        <td style="text-align:right;padding:10px">
            <br />
            
            
      <! --------------------------TO Here ------>&nbsp;
<table width="100%" dir="rtl">
    <tr><td colspan="2"></td></tr>
    <tr>
        <td>
            أسم المستخدم:
            <asp:Literal ID="LITAdminName" runat="server"></asp:Literal>
        </td>
        <td>
            أسم الجهة:
            <asp:Literal ID="LITAdminOrg" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr style="height=10px;"><td colspan="2" style="height: 10px"></td></tr>
    <tr style="height=10px;"><td colspan="2"></td></tr>
    <tr style="height=10px;"><td colspan="2"></td></tr>
    <tr><td colspan="2">
        <asp:GridView ID="AdministrationGV" runat="server" AutoGenerateColumns="False" ShowHeader="False" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="TaskName">
                    <ItemTemplate>
                        <asp:LinkButton ID="LBTNTask" runat="server" Text='<%# Bind("TaskName") %>' OnClick="Link_OnClick" ToolTip='<%# Eval("TaskLink") %>'></asp:LinkButton>
                    </ItemTemplate>
				    
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
    </td></tr>
    <tr><td colspan="2">
        <asp:UpdatePanel id="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="UserControlPlaceHolder" runat="server"></asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
    </td></tr>
</table>


<! --------------------------From Here ------></td>
    </tr>
    <tr>
        <td>
            </td>
    </tr>
</table>
  
</div>