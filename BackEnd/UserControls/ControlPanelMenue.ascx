 <%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlPanelMenue.ascx.cs" Inherits="UserControls_ControlPanelMenue" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<div style="float: right; width:100%;" dir="ltr">
<table cellpadding="0" cellspacing="0" runat="server" id="blocks" class="blocks">
    <tr>
        <td class="title">
            <%=Title %>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="TopImage" ImageUrl="<%=ImageName %>" runat="server" />
            <table style="width: 100%; margin-top: 0" id="leftnav" cellspacing="0" cellpadding="0">
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <a href='<%# Eval("Path") %>'><%# Eval("Title") %></a>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </td>
    </tr>
    <tr>
        <td>
        </td>
    </tr>
</table>
</div>