<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage_res.master" AutoEventWireup="true" CodeFile="publishingMaster.aspx.cs" Inherits="Form_publishingMaster" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
google.load("elements", "1", {packages: "transliteration"});
function onLoad() 
{
var options = {sourceLanguage: 'en', destinationLanguage: ['mr'], shortcutKey: 'ctrl+g',transliterationEnabled: true }; 
var control = new google.elements.transliteration.TransliterationControl(options);
  control.makeTransliteratable(['<%=txt_ptype.ClientID%>']);
  }
google.setOnLoadCallback(onLoad);
function show_control()
{
document.getElementById('ctl00_ContentPlaceHolder1_txt_ptype').value='';

document.getElementById('ctl00_ContentPlaceHolder1_btn_add').disabled =false;
document.getElementById('ctl00_ContentPlaceHolder1_btn_del').disabled =false;
document.getElementById('ctl00_ContentPlaceHolder1_btn_update').disabled = true;
}
</script>
    <table style="width: 90%">
        <tr>
            <td style="width: 5%; height: 17px">
            </td>
            <td style="width: 5%; height: 17px">
            </td>
            <td style="width: 5%; height: 17px">
            </td>
            <td style="width: 5%; height: 17px">
            </td>
            <td style="width: 5%; height: 17px">
            </td>
            <td style="width: 5%; height: 17px">
            </td>
            <td style="width: 5%; height: 17px">
            </td>
            <td colspan="6" style="height: 17px">
             <center>   <asp:Label ID="Label1" runat="server" Text="प्रसिद्धीचा प्रकार"></asp:Label></center></td>
            <td style="width: 5%; height: 17px">
            </td>
            <td style="width: 5%; height: 17px">
            </td>
            <td style="width: 5%; height: 17px">
            </td>
            <td style="width: 5%; height: 17px">
            </td>
            <td style="width: 5%; height: 17px">
            </td>
            <td style="width: 5%; height: 17px">
            </td>
            <td style="width: 5%; height: 17px">
            </td>
        </tr>
        <tr>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td colspan="3" style="text-align: left">
                <asp:Label ID="Label2" runat="server" Text="प्रसिद्धीचा तपशिल" Width="141px"></asp:Label></td>
            <td colspan="5" style="text-align: left">
                <asp:TextBox ID="txt_ptype" runat="server" Width="78%"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ptype"
                    Display="Dynamic" ErrorMessage="**" ValidationGroup="a"></asp:RequiredFieldValidator></td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
        </tr>
        <tr>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td colspan="2" style="height: 26px">
                <asp:Button ID="btn_add" runat="server" OnClick="btn_add_Click" Text="Add" ValidationGroup="a" /></td>
            <td colspan="2" style="height: 26px">
                <asp:Button ID="btn_update" runat="server" OnClick="btn_update_Click" Text="Update"
                    ValidationGroup="a" /></td>
            <td colspan="2" style="height: 26px">
                <asp:Button ID="btn_reset" runat="server" OnClick="btn_reset_Click" Text="Reset" /></td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td colspan="8" style="height: 26px">
                <center> <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>
<asp:Label id="lblmsg" runat="server" Width="90%" ForeColor="Red" Font-Size="X-Small" __designer:wfdid="w3"></asp:Label> <asp:UpdateProgress id="UpdateProgress1" runat="server" __designer:wfdid="w4"><ProgressTemplate>
<IMG src="../Form/progessbar.gif" width=30 /><BR /><asp:Label id="Label3" runat="server" Text="Please wait..." __designer:wfdid="w5"></asp:Label> 
</ProgressTemplate>
</asp:UpdateProgress> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btn_add" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btn_del" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="btn_update" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel> </center> </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
            <td style="width: 5%; height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 5%; height: 19px">
            </td>
            <td style="width: 5%; height: 19px">
            </td>
            <td style="width: 5%; height: 19px">
            </td>
            <td style="width: 5%; height: 19px">
            </td>
            <td style="width: 5%; height: 19px">
            </td>
            <td style="width: 5%; height: 19px">
            </td>
            <td colspan="10" style="height: 19px">
                <asp:UpdatePanel id="UpdatePanel2" runat="server">
                    <contenttemplate>
<asp:DataGrid id="datagrid" runat="server" Width="395px"  ForeColor="#333333" Font-Size="10pt" Font-Names="Verdana" PageSize="5" OnSelectedIndexChanged="datagrid_SelectedIndexChanged" OnPageIndexChanged="datagrid_PageIndexChanged" CellPadding="4" AutoGenerateColumns="False" AllowPaging="True" __designer:wfdid="w2">
                    <FooterStyle BackColor="#5D7B9D"  ForeColor="White" />
                    <EditItemStyle BackColor="#999999" />
                    <SelectedItemStyle BackColor="#E2DED6"  ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:ButtonColumn CommandName="Select" HeaderText="Edit" Text="Edit"></asp:ButtonColumn>
                        <asp:BoundColumn DataField="p_type" HeaderText="p_type" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ptype" HeaderText="प्रसिद्धीचा प्रकार"></asp:BoundColumn>
                    </Columns>
                    <HeaderStyle BackColor="#5D7B9D"  Font-Names="Verdana" Font-Size="Small"
                        ForeColor="White" />
                </asp:DataGrid> 
</contenttemplate>
                    <triggers>
<asp:PostBackTrigger ControlID="datagrid"></asp:PostBackTrigger>
</triggers>
                </asp:UpdatePanel></td>
            <td style="width: 5%; height: 19px">
            </td>
            <td style="width: 5%; height: 19px">
            </td>
            <td style="width: 5%; height: 19px">
            </td>
            <td style="width: 5%; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td colspan="2">
                <asp:Button ID="btn_del" runat="server" OnClick="btn_del_Click" Text="Delete" /></td>
            <td colspan="5">
                <asp:HiddenField ID="hf_ptypeId" runat="server" />
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
        </tr>
        <tr>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
            <td style="width: 5%">
            </td>
        </tr>
    </table>

</asp:Content>

