<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Organigram2.ascx.cs" Inherits="AR_Controls_Organigram_1" %>
<asp:TreeView ID="TreeView1" runat="server">
</asp:TreeView>
<table>
    <tr>
        <td style="width: 110px">
            <asp:Label ID="Label1" runat="server" Text="ãÏíÑíÉ"></asp:Label></td>
        <td style="width: 156px">
<asp:DropDownList ID="DDLGovernate" runat="server" OnSelectedIndexChanged="DDLGovernate_SelectedIndexChanged" >
</asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 110px">
            <asp:Label ID="Label2" runat="server" Text="ÇÏÇÑå"></asp:Label></td>
        <td style="width: 156px">
<asp:DropDownList ID="DDLDirectorate" runat="server" OnSelectedIndexChanged="DDLDirectorate_SelectedIndexChanged">
</asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 110px">
            <asp:Label ID="Label3" runat="server" Text="æÍÏå"></asp:Label></td>
        <td style="width: 156px">
<asp:DropDownList ID="DDLUnit" runat="server" OnSelectedIndexChanged="DDLUnit_SelectedIndexChanged">
</asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 110px">
            <asp:Label ID="Label4" runat="server" Text="ãÌÒÑ"></asp:Label></td>
        <td style="width: 156px">
<asp:DropDownList ID="DDLSlaughter" runat="server" OnSelectedIndexChanged="DDLSlaughter_SelectedIndexChanged">
</asp:DropDownList></td>
    </tr>
</table>
<br />
<a href="../en/img/ArabicChart.jpg"><img src="../ar/img/ArabicChart.jpg" width="95%" height="95%" /></a>
