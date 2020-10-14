<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DBHelperM.aspx.cs" Inherits="DBHelperM"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>test</title>
        <meta http-equiv="Content-Type" content="text/html; charset=windows-1256">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <table style="width: 386px">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txt_UserName" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txt_Password" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:LinkButton ID="btn_Ok" runat="server" OnClick="btn_Ok_Click">Ok</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lbl_Err" runat="server" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
                </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:TextBox ID="txt_Sql" runat="server" Height="100px" TextMode="MultiLine" Width="700px"></asp:TextBox><br />
                <br />
                <table style="width: 456px; text-align: right">
                    <tr>
                        <td>
                            <asp:RadioButton ID="Radio_Selection" runat="server" Text="Selection" GroupName="G1" /></td>
                    </tr>
                    <tr>
                        <td style="height: 22px">
                            <asp:RadioButton ID="Radio_Trans" runat="server" GroupName="G1" Text="Transaction" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="btn_Execute" runat="server" OnClick="btn_Execute_Click">Do</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label></td>
                    </tr>
                </table>
                <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                    BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                    <FooterStyle BackColor="Tan" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                </asp:GridView>
            </asp:View>
        </asp:MultiView></div>
    </form>
</body>
</html>
