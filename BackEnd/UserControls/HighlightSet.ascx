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
            ������� �� ������ ��������</td>
        <td style="vertical-align: middle" valign="middle">
        </td>
        <td>
            �������� ������</td>
    </tr>
<tr align="center">
<td>
    <asp:ListBox ID="ListHSet" runat="server" Height="300px"></asp:ListBox></td>
<td style="width: 30px; vertical-align:middle" valign="middle">
<br />
<br />
<br />
    <asp:Button ID="UP" runat="server" Text=" ���� ����� " Width="65px" OnClick="UP_Click"/><br />
    <asp:Button ID="Down" runat="server" Text=" ���� ����� " Width="65px" OnClick="Down_Click"/><br />
    <asp:Button ID="Add" runat="server" Text=" ��� " Width="65px" OnClick="Add_Click"/><br />
    <asp:Button ID="Del" runat="server" Text=" ���� " OnClick="Del_Click" Width="65px"/>
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
        <asp:TextBox ID="test" runat="server" AutoPostBack="true" BorderColor="Transparent" BorderStyle="None" Visible="false">test</asp:TextBox>

    </td>
    </tr>

</table>
<asp:GridView ID="GridView1" runat="server">
</asp:GridView>
</body>