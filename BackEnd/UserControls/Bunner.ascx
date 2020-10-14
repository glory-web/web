<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Bunner.ascx.cs" Inherits="UserControls_Bunner" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />

<div style="float: right; width:100%;" dir="ltr">
<table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td align="right" class="title" dir="rtl">
            <center>
                الشعار الخاص بالموقع</center>
        </td>
    </tr>
    <tr>
        <td dir="rtl" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
            padding-top: 10px; text-align: right">
            <br />
            <! --------------------------TO Here ------><table width="100%">
                <tr>
                    <td>
                        <asp:Literal ID="Literal1" runat="server" Text="أسم الصورة"></asp:Literal>
                        </td>
                    <td><asp:FileUpload ID="FUBunner" runat="server" /></td>
                    <td style="width: 7px">
                        <asp:CheckBox ID="CHBShow" runat="server" Text="عرض" /></td>
                    <td>
                        <asp:Button ID="BTNUpload" runat="server" Text="رفع الصورة" OnClick="BTNUpload_Click" /></td>
                        
                </tr>
                <tr>
                    <td colspan="4"><hr /></td>
                </tr>
                 <tr>
                    <td colspan="4">
                        <asp:GridView ID="GVBunners" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" ShowHeader="False" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="الصورة">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("BunnerName") %>' Width="250px" Height="50px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="عرض">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CHBShowBunner" runat="server" Checked='<%# Bind("Show") %>' AutoPostBack="True" OnCheckedChanged="CHBShowBunner_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الأجراءات">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LBTNDelete" runat="server" OnClick="LBTNDelete_Click" OnClientClick="return confirm('هل تريد الحذف ؟');">حذف</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <center>
                                    <asp:Literal ID="Literal2" runat="server" Text="لا يوجد صور"></asp:Literal>
                                </center>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
             <! --------------------------From Here ------></td>
    </tr>
    <tr>
        <td>
        </td>
    </tr>
</table>
</div>