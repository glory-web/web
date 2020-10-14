<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Laws.ascx.cs" Inherits="WebUserControl" %>
    <table> 
     <tr><td colspan="3">
    <asp:Label ID="test" Text="test" runat="server"  Visible="false"/>
    <asp:Label ID="WLawDec" Text="WLawDec" runat="server"  Visible="false"/>
    <asp:Label ID="ALawDec" Text="ALawDec" runat="server" Visible="false"/>
    <asp:Label ID="LawDec" Text="LawDec" runat="server" Visible="false"/>
 
    </td>
    </tr>
    
    <tr style="width: 300px;"> 
    <td>
    <asp:Label ID="YearL" Text="Óäå ÇáÇÕÏÇÑ" runat="server" />
    <br />
    </td>
    <td  style="width:10px" ></td>
    <td>
    <asp:DropDownList id="DDLYear" runat="server" Width="249px" AutoPostBack="True">
    </asp:DropDownList>
    </td></tr>
    <tr style="width: 300px;">
    <td>
    <asp:Label ID="DepL" Text="ÇáÇÏÇÑÉ" runat="server" />
    </td>
    <td  style="width:10px" ></td>
    <td><asp:DropDownList id="DDLDepart" runat="server" Width="249px" AutoPostBack="True">
    </asp:DropDownList></td></tr>
    </table>
    <br />
<asp:MultiView ID="MultiView1" runat="server">
    

    <br/>
    <asp:View ID="View1" runat="server">
        <asp:GridView ID="laws_grid" runat="server" AutoGenerateColumns="False" ShowHeader="False">
            <Columns>
                <asp:TemplateField HeaderText="ÇáÞæÇäíä">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="HighLightsItems" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Bind("law_Arabic_Name") %>'>LinkButton</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="View2" runat="server">

        <table class="front">
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label1" runat="server" Text="ÇÓã ÇáÞÇäæä"></asp:Label>
               </td><td class="bg2">
                    <asp:Label CssClass="Label_details" ID="Label_Laws_Name" runat="server"></asp:Label>
                </td>
            </tr>
           <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label2" runat="server" Text="ãáÎÕ ÇáÞÇäæä"></asp:Label>
                    </td>
                   <td class="bg2"> <asp:Label ID="Label_Laws_Title" runat="server" ></asp:Label>
            </td>
            </tr>
           <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label4" runat="server" Text="ÓäÉ ÇÕÏÇÑ ÇáÞÇäæä"></asp:Label></td>
                
                    <td class="bg2"><asp:Label ID="Label_Laws_date" runat="server"></asp:Label>
             </td>
            </tr>
            
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label6" runat="server" Text="ÊÇÑíÎ ÇáÇÕÏÇÑ"></asp:Label></td>
                
                    <td class="bg2"><asp:Label ID="Label_Laws_date2" runat="server"></asp:Label>
             </td>
            </tr>
            
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label12" runat="server" Text="ÊÇÑíÎ ÇáäÔÑ ÈÇáæÞÇÆÚ ÇáãÕÑíÉ"></asp:Label></td>
                
                    <td class="bg2"><asp:Label ID="Label_Laws_date3" runat="server"></asp:Label>
             </td>
            </tr>
            
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label16" runat="server" Text="ÇáÌåÉ"></asp:Label></td>
                
                    <td class="bg2"><%--<asp:Label ID="Label_Laws_D" runat="server"></asp:Label>--%>
                    
                    <asp:Repeater ID="Repeater3" runat="server">
                    <ItemTemplate >
                          <%--<asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_Arabic_Name") %>' NavigateUrl='<%#string.Concat(FilePath(), Eval("File_Arabic_Name")) %>'>HyperLink</asp:HyperLink></br>--%>
                          <asp:Label ID="Label_Laws_D" runat="server" Text ='<%# Bind("ORG_Arabic_Name") %>' > </asp:Label></br>
                    </ItemTemplate>
                    </asp:Repeater>
                    </td>
            </tr>                                 
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label18" runat="server" Text="Êã ÇáÇáÛÇÁ ÈÞÇäæä ÑÞã " Visible="false"></asp:Label></td>
                
                    <td class="bg2"><asp:Label ID="Label_Laws_Cancel" runat="server" Visible="false"></asp:Label>
             </td>
            </tr>
            
            <tr>
                <td class="bg">
                    <asp:Label CssClass="Label_form" ID="Label3" runat="server" Text="ãáÝÇÊ ÇáÞÇäæä"></asp:Label>
               </td>
                   <td class="bg2">
                    <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate >
                          <%--<asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_Arabic_Name") %>' NavigateUrl='<%#string.Concat(FilePath(), Eval("File_Arabic_Name")) %>'>HyperLink</asp:HyperLink></br>--%>
                          <asp:HyperLink ID="HyperLink1" runat="server" Text ='<%# Bind("File_Path") %>' NavigateUrl='<%#string.Concat(FilePath(), Eval("File_Path")) %>' Target= "_blank">HyperLink</asp:HyperLink></br>
                    </ItemTemplate>
                    </asp:Repeater>
             </td>
            </tr>
            </table>
    </asp:View>
    
  
  
    
</asp:MultiView>
