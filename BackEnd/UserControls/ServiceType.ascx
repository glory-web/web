<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ServiceType.ascx.cs" Inherits="UserControls_ServiceType" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />
<! --------------------------From Here ------><div style="float: right; width:100%;" dir="ltr">
      <br />
     <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td class="title" align="right" dir="rtl"><center>
            المستفيد من الخدمة</center></td>
    </tr>
    <tr>
        <td style="text-align:right;padding:10px" dir="rtl">
            <br />
            
            
      <! --------------------------TO Here ------><table width="100%">
        <tr>
            <td colspan="2" style="height: 455px">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="نوع الخدمة">
                                    <ItemTemplate>
                                        <asp:Literal ID="LITCoopArabicName" runat="server" Text='<%# Bind("Service_Type_Arabic_Name") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الإجراءات">
                                    <EditItemTemplate>
                                        &nbsp;
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:LinkButton ID="LBTNAdd" runat="server" OnClick="LBTNAdd_Click">إضافة</asp:LinkButton>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LBTNEdit" runat="server" OnClick="LBTNEdit_Click">تعديل</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="LBTNDelete" runat="server" OnClick="LBTNDelete_Click" OnClientClick="return confirm('هل تريد الحذف ؟');">حذف</asp:LinkButton>
                                        |
                                        <asp:LinkButton ID="LBTNShowDetails" runat="server" OnClick="LBTNShowDetails_Click">التفاصيل</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table width="100%">
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="LITCoopAraic" runat="server" Text="المستفيد من الخدمة باللغة العربية"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTServiceTypeArabicName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" Height="88px" />
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal3" runat="server" Text="المستفيد من الخدمة باللغة الإنجليزية"></asp:Literal></td>
                                            <td>
                                                <asp:TextBox ID="TXTServiceTypeEnglishName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" Height="88px" />
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            <center>
                                                <asp:Button ID="BTNAdd" runat="server" OnClick="BTNAdd_Click" Text="إضافة" Visible="False" />
                                                <asp:Button ID="BTNUpdate" runat="server" OnClick="BTNUpdate_Click" Text="تعديل"
                                                    Visible="False" />
                                                <asp:Button ID="BTNCancel" runat="server" OnClick="BTNCancel_Click" Text="إلغاء"
                                                    Width="36px" /></center></td>
                                        </tr>
                                        
                                    </table>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                         <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                        <ItemTemplate>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal7" runat="server" Text="المستفيد من الخدمة باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal8" runat="server" Text='<%#Bind("Service_Type_Arabic_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal9" runat="server" Text="المستفيد من الخدمة باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal10" runat="server" Text='<%#Bind("Service_Type_English_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <center>
                                        <asp:LinkButton ID="LBTNClose" runat="server" OnClick="LBTNClose_Click">Close</asp:LinkButton></center>
                    </asp:View>
                    
                </asp:MultiView>
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