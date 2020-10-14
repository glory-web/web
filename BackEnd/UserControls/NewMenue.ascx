<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewMenue.ascx.cs" Inherits="UserControls_NewMenue" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<table cellpadding="0" cellspacing="0" runat="server" id="blocks" class="blocks" width="100%">
    <tr>
        <td class="title" style="height: 19px"><center>
            <%=Title %></center>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="TopImage" ImageUrl="<%=ImageName %>" runat="server" />
            <table style="width: 100%; margin-top: 0" id="leftnav" cellspacing="0" cellpadding="0">
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="LinkUpdatePanel" runat="server">
                                    <ContentTemplate>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
                                                      TargetControlID="DetailsPanel"
                                                      ExpandControlID="HeaderPanel" 
                                                      CollapseControlID="HeaderPanel" 
                                                      Collapsed="True"
                                                      TextLabelID="LITTitle" 
                                                      ImageControlID="Image1" 
                                                      ExpandedImage="~/Images/collapse.jpg" 
                                                      CollapsedImage="~/Images/expand.jpg"
                                                      SuppressPostBack="true">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <asp:Panel ID="HeaderPanel" runat="server"><center>
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/expand.jpg" />
                                        <asp:Label ID="LITTitle" runat="server" Text='<%# Eval("GroupTitle") %>'></asp:Label></center>
                                    </asp:Panel>
                                    <asp:Panel ID="DetailsPanel" runat="server">
                                        <asp:Repeater ID="ItemsRepeater" runat="Server">
                                            <ItemTemplate>
                                                <center>
                                                <a href='<%# Eval("Path") %>'>
                                                <asp:Label ID="LITItem" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                                    </a>
                                                 </center>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
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
          