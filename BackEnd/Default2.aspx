<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<script language="javascript" type="text/javascript">
function Button2_onclick() {
document.getElementById('<%=Button1.ClientID %>').click();
location.replace(
}

</script>    
    <meta http-equiv="Content-Language" content="ar-eg">
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1256">
    <meta name="Keywords" content="الهيئة العامة للخدمات البطرية, بيطرية,الهيئة">
    <meta name="Description" content="لوحة التحكم الأساسية لموقع الهيئة العامة للخدمات البطرية">
    <title>لوحة التحكم الأساسية لموقع الهيئة العامة للخدمات البطرية</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <input id="Button2" type="button" value="HtmlButton" onclick="return Button2_onclick()" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></div>
    </form>
</body>
</html>
