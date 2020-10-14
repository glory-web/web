<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Boxes.ascx.cs" Inherits="Books" %>
<asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
    <ItemTemplate>
        <div class="tablestyle" runat="server" visible='<%# Boolean.Parse( Eval("Visiblity").ToString() )%>'>
            <div class="rb">
                <div class="lb">
                    <div class="rt">
                        <div class="lt">
                            <div class="cont" style="text-align: justify">
                                <h2 class="title">
                                    <span class="spantitle">
                                        <%# Eval("BoxArabicTitle") %>
                                    </span>
                                </h2>
                                <p style="padding: 0px 8px 8px; margin: 0px; text-align: justify; font: normal 12px/22px arial">
                                    <span id="Label2">
                                        <asp:PlaceHolder ID="ContentPlaceHolder" runat="server">
                                        </asp:PlaceHolder>
                                    </span>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
    </ItemTemplate>
</asp:Repeater>
