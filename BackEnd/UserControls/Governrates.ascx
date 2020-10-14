<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Governrates.ascx.cs" Inherits="UserControls_Organization" %>
<link href="../../CSS_JAVA/main.css" rel="stylesheet" type="text/css" />
<! --------------------------From Here ------><div style="float: right; width:100%;">
      <br />
     <table id="blocks" cellpadding="0" cellspacing="0" class="blocks" dir="rtl" style="height: 500px"
    width="100%">
    <tr>
        <td class="title" align="right" dir="rtl"><center>
      ����� � ����� ��������� ������� ������&nbsp;</center></td>
    </tr>
    <tr>
        <td dir="rtl" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
            padding-top: 10px; text-align: right; height: 1850px;">
            <br />
            
            
      <! --------------------------TO Here ------><table width="100%">
      <tr><td colspan="2">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <asp:GridView ID="org_grid" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                        Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="��� ��������(����� �������)">
                                <ItemTemplate>
                                    <asp:Literal ID="LIT_Arabic_Name" runat="server" Text='<%# Bind("ORG_Arabic_Name") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="��� ��������(����� ����������)">
                                <ItemTemplate>
                                    <asp:Literal ID="LIT_English_Name" runat="server" Text='<%# Bind("ORG_English_Name") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="���������">
                                <FooterTemplate>
                                    <asp:LinkButton ID="add_btn" runat="server" OnClick="add_btn_Click">�����</asp:LinkButton>
                                </FooterTemplate>
                                <ItemTemplate>
                                    &nbsp;<asp:LinkButton ID="Dlt_btn" runat="server" OnClick="Dlt_btn_Click" OnClientClick="return confirm('�� ���� ����� �');">���</asp:LinkButton>
                                    |
                                    <asp:LinkButton ID="Update_btn" runat="server" OnClick="Edit_btn_Click">�����</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <table width="100%">
                        <tr style="display:none">
                            <td style="width: 137px">
                                <asp:Label ID="Label15" runat="server" Text="�����" Width="91px"></asp:Label></td>
                            <td style="width: 334px">
                                <asp:DropDownList ID="DDLOrganizationType" runat="server" DataTextField="Type_Arabic_Name"
                                    DataValueField="Org_Type_ID">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 36px;">
                                <asp:Label ID="Label6" runat="server" Text="����� (������)" Width="91px"></asp:Label></td>
                            <td style="width: 334px; height: 36px;">
                                    
                                <asp:TextBox ID="TXT_Arabic_Name" runat="server" TabIndex="1" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TXT_Arabic_Name"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ORGVG"></asp:RequiredFieldValidator>
                                 </td>                                 
                        </tr>
                        <tr>
                            <td style="width: 137px">
                                <asp:Label ID="Label5" runat="server" Text="����� (����������)" Width="91px"></asp:Label></td>
                            <td style="width: 334px">
                                <asp:TextBox ID="TXT_English_Name" runat="server" TabIndex="2" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TXT_English_Name"
                                    Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ORGVG"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="width: 137px">
                                <asp:Label ID="Label1" runat="server" Text="������" Width="91px"></asp:Label></td>
                            <td style="width: 334px">
                                <asp:TextBox ID="TXT_Phone" runat="server" Width="441px" TabIndex="3"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px">
                                <asp:Label ID="Label2" runat="server" Text="����" Width="95px"></asp:Label></td>
                            <td style="width: 334px">
                                <asp:TextBox ID="TXT_Fax" runat="server" Width="441px" TabIndex="4"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px">
                                <asp:Label ID="Label3" runat="server" Text="������� (������)" Width="94px"></asp:Label></td>
                            <td style="width: 334px">
                                <asp:TextBox ID="TXT_Arabic_Address" runat="server" TabIndex="5" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label4" runat="server" Text="������� (����������)" Width="103px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                <asp:TextBox ID="TXT_English_Address" runat="server" TabIndex="6" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="SingleLine" Height="88px" />
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label16" runat="server" Text="������ ����������" Width="103px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                <asp:TextBox ID="TXTEMail" runat="server" Font-Names="Verdana" Font-Size="10pt" onfocus="tb_focus(this)"
                                    Style="overflow: auto" TabIndex="7" TextMode="SingleLine" Width="441px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label7" runat="server" Text="������� (����� �������)" Width="141px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                <asp:TextBox ID="TXT_Arabic_Goals" runat="server" TabIndex="8" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label8" runat="server" Text="������� (����� ����������)" Width="158px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                
                                <asp:TextBox ID="TXT_English_Goals" runat="server" TabIndex="9" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label9" runat="server" Text="��������� (����� �������)" Width="157px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                <asp:TextBox ID="TXT_Arabic_Achivments" runat="server" TabIndex="10" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label12" runat="server" Text="��������� (����� ����������)" Width="172px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                
                                 <asp:TextBox ID="TXT_English_Achivments" runat="server" TabIndex="11" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label10" runat="server" Text="������� (����� �������)" Width="141px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                 <asp:TextBox ID="TXT_Arabic_History" runat="server" TabIndex="12" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label13" runat="server" Text="�������  (����� ����������)" Width="158px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                
                                 <asp:TextBox ID="TXT_English_History" runat="server" TabIndex="13" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label11" runat="server" Text="������� (����� �������)" Width="141px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                
                                <asp:TextBox ID="TXT_Arabic_Activity" runat="server" TabIndex="14" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                
                                </td>
                        </tr>
                        <tr>
                            <td style="width: 137px; height: 18px">
                                <asp:Label ID="Label14" runat="server" Text="������� (����� ����������)" Width="158px"></asp:Label></td>
                            <td style="width: 334px; height: 18px">
                                
                                 <asp:TextBox ID="TXT_English_Activity" runat="server" TabIndex="15" Font-Names="Verdana" Font-Size="10pt" style="overflow:auto;" onFocus="tb_focus(this)" Width="441px" TextMode="MultiLine" Height="110px" />
                                 
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 29px"><center>
                                <asp:Button ID="Save" runat="server" OnClick="Save_Click1" Text="�����" Width="93px" ValidationGroup="ORGVG" TabIndex="16" />
                                <asp:Button ID="Cancel_Btn" runat="server" OnClick="Cancel_Click" Text="�����" Width="86px" TabIndex="17" /></center></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 29px">
                            </td>
                        </tr>
                    </table>
                </asp:View>
                &nbsp;&nbsp;
            </asp:MultiView>
          &nbsp;
      </td></tr>
      </table>
            <! --------------------------From Here ------></td>
    </tr>
    <tr>
        <td>
            </td>
    </tr>
</table>
  
</div>