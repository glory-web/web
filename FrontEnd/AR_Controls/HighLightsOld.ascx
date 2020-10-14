<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HighLights.ascx.cs" Inherits="AR_Controls_HighLights" %>
<asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
<ItemTemplate >
               
                    <asp:PlaceHolder ID="ContentPlaceHolder" runat="server"></asp:PlaceHolder>
               
</ItemTemplate>
</asp:Repeater>
