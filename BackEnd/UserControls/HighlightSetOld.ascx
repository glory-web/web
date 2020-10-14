<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HighlightSet.ascx.cs" Inherits="BackEnd_UserControls_HighlightSet" %>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1256">
</head>
<body>
<br />
<br />
<table>
    <tr align="center">
        <td>
            المعروض فى الصفحة الرئيسية</td>
        <td style="vertical-align: middle" valign="middle">
        </td>
        <td>
            المواضيع الهامة</td>
    </tr>
<tr align="center">
<td>
    <asp:ListBox ID="ListHSet" runat="server" Height="300px"></asp:ListBox></td>
<td style="width: 11px; vertical-align:middle" valign="middle">
<br />
<br />
<br />
    <asp:Button ID="Add" runat="server" Text="<<" Width="52px" OnClick="Add_Click"/><br />
    <asp:Button ID="Del" runat="server" Text=">>" OnClick="Del_Click" Width="48px"/>
</td>
<td>
<asp:ListBox ID="ListHall" runat="server"  AutoPostBack="true" Height="300px"></asp:ListBox>
</td>
</tr>
<tr>
<td colspan="3"   align="center">
<asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click"/>
    </td>
</tr>
    <tr>
        <td colspan="3"   align="center">
    <asp:TextBox ID="test" runat="server" BorderColor="Transparent" BorderStyle="None"></asp:TextBox></td>
    </tr>

</table>
<asp:GridView ID="GridView1" runat="server">
</asp:GridView>
</body>