<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Services.ascx.cs" Inherits="UserControls_Services" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />

<script language="javascript" type="text/javascript">
    function openupload(CV)
    {
        var WinSettings = "left=150,top=150,width=530px,menubar=no,location=no,resizable=no,scrollbars=yes,status=no"
	    window.open("UserControls/UploadFiles.aspx?FileType="+CV, "Child", WinSettings);
	}
</script>
<! --------------------------From Here ------><div style="float: right; width:100%;" dir="ltr">
      <br />
     <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td class="title" align="right" dir="rtl"><center>
            الخدمات التي تقدمها الهيئات</center></td>
    </tr>
    <tr>
        <td style="text-align:right;padding:10px" dir="rtl">
            <br />
            
            
      <! --------------------------TO Here ------><table width="100%">
        <tr>
            <td colspan="2">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="اسم الخدمة">
                                    <ItemTemplate>
                                        <asp:Literal ID="LITCoopArabicName" runat="server" Text='<%# Bind("Service_Arabic_Name") %>'></asp:Literal>
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
                                        <asp:LinkButton ID="LBTNDelete" runat="server" OnClick="LBTNDelete_Click" OnClientClick="return confirm('هل تريد الحذف ؟');">حذف</asp:LinkButton>&nbsp;
                                        |
                                        <asp:LinkButton ID="LBTNShowDetails" runat="server" OnClick="LBTNShowDetails_Click">التفاصيل</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الظهور فى الصفحة الرئيسية">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CHBHighlight" runat="server" AutoPostBack="True" OnCheckedChanged="CHBHighlight_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table width="100%">
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="LITCoopAraic" runat="server" Text="اسم الخدمة باللغة العربية"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TXTServiceArabicName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" Height="88px" />
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal3" runat="server" Text="اسم الخدمة باللغة الإنجليزية"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TXTServiceEnglishName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" Height="88px" />
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px; width: 175px;">
                                                <asp:Literal ID="Literal4" runat="server" Text="شروط نقديم الخدمة باللغة العربية"></asp:Literal></td>
                                            <td style="height: 15px" colspan="2">
                                                <asp:TextBox ID="TXTServiceAraicConditions" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="140px" TextMode="multiLine" />
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal2" runat="server" Text="شروط تقديم الخدمة باللغة الإنجليزية"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TXTServiceEnglishConditions" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="140px" TextMode="multiLine" />
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 175px">
                                                <asp:Literal ID="Literal6" runat="server" Text="إجراءات الحصول على الخدمة باللغة العربية"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TXTServiceArabicProcedures" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="140px" TextMode="multiLine" />
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="Literal7" runat="server" Text="إجراءات الحصول على الخدمة باللغة الإنجليزية"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:TextBox ID="TXTServiceEnglishProcedures" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" Height="140px" TextMode="multiLine" />
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Literal ID="Literal5" runat="server" Text="المستفيد من الخدمة"></asp:Literal></td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="Service_Type_Arabic_Name" DataValueField="Type_ID">
                                                </asp:DropDownList></td>
                                        </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal8" runat="server" Text="اسم نموذج الخدمة باللغة العربية"></asp:Literal></td>
                                <td colspan="2">
                                    <asp:TextBox ID="TXTFileName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" />
                                                
                                </td>
                                    
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal10" runat="server" Text="اسم نموذج الخدمة باللغة الإنجليزية"></asp:Literal></td>
                                <td colspan="2">
                                    <asp:TextBox ID="TXTEnglishFileName" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="singleLine" />
                                                
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal9" runat="server" Text="رفع نموذج الخدمة"></asp:Literal></td>
                                <td style="width: 446px">
                                    <asp:FileUpload ID="FUServiceFile" runat="server" Width="280px" /></td>
                                <td>
                                    <asp:Literal ID="LITFileName" runat="server" Visible="False"></asp:Literal>
                                    <asp:Button ID="FileDel" runat="server" onclick="FileDel_Click" 
                                        Text="إلغاء الملف" Visible="False" Width="96px" />
                                </td>
                            </tr>
                                        <tr>
                                            <td colspan="3">
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
                                                        <asp:Literal ID="Literal7" runat="server" Text="اسم الخدمة باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal8" runat="server" Text='<%#Bind("Service_Arabic_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal9" runat="server" Text="اسم الخدمة باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal10" runat="server" Text='<%#Bind("Service_English_Name") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal11" runat="server" Text="شروط تقديم الخدمة باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal12" runat="server" Text='<%#Bind("Service_Arabic_Conditions") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal13" runat="server" Text="شروط تقديم الخدمة باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal14" runat="server" Text='<%#Bind("Service_English_Conditions") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal15" runat="server" Text="إجراءات الحصول علي الخدمة باللغة العربية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal16" runat="server" Text='<%#Bind("Service_Arabic_Procedures") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal19" runat="server" Text="إجراءات الحصول علي الخدمة باللغة الإنجليزية"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="Literal20" runat="server" Text='<%#Bind("Service_English_Procedures") %>'></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Literal ID="Literal17" runat="server" Text="نموذج الخدمة"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Repeater ID="Repeater2" runat="server">
                                                            <ItemTemplate>
                                                                <a href='../GovsFiles/ORG_<%#Eval("ORG_ID") %>_Files/Services/<%# Eval("File_Path") %>'><%#Eval("File_Arabic_Name") %></a>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <center>
                                        <asp:LinkButton ID="LBTNClose" runat="server" OnClick="LBTNClose_Click">Close</asp:LinkButton></center>
                    </asp:View>
                    &nbsp;
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