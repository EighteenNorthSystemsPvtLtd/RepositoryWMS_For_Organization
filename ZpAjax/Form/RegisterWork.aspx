<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage_res.master" AutoEventWireup="true" CodeFile="RegisterWork.aspx.cs" Inherits="Form_RegisterWork" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
    
    
             <div id="content">
        <div id="content-header">
        
        </div>
        <div class="container-fluid">
            <div class="row-fluid">
                <div class="span12">
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon"><i class="icon-align-justify"></i></span>
                            <h5 >
                                कामाची नोंद </h5>
                                
                        </div>
                        <div class="widget-content nopadding">
                        
                          
  <script type="text/javascript">
google.load("elements", "1", {packages: "transliteration"});
function onLoad() 
{
var options = {sourceLanguage: 'en', destinationLanguage: ['mr'], shortcutKey: 'ctrl+g',transliterationEnabled: true }; 
var control = new google.elements.transliteration.TransliterationControl(options);
  control.makeTransliteratable(['<%=txt_wrkName.ClientID%>']);
  }
google.setOnLoadCallback(onLoad);
</script>

         

                <%--                <div class="span5">
            <div class="control-group">
            
                <asp:Label ID="Label2" runat="server" Text="तालुका" CssClass="control-label"></asp:Label>
            <div class="controls ">
                <asp:DropDownList ID="ddl_Taluka" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_Taluka_SelectedIndexChanged"
                   >
                </asp:DropDownList><span class="ipsForm_required"> * </span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="a" ControlToValidate="ddl_Taluka"
                        Display="none" InitialValue="0" runat="server" ErrorMessage="तालुका निवडा" ></asp:RequiredFieldValidator>
            </div>
                                </div>
                                    </div>--%>
    
                     <%--           <div class="span5">    
 <div class="control-group">
                <asp:Label ID="Label3" runat="server" Text="गाव" CssClass="control-label"></asp:Label>
            <div class="controls ">
               
<asp:DropDownList id="ddl_gav" runat="server" ></asp:DropDownList><span class="ipsForm_required"> * </span>
          
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="a" ControlToValidate="ddl_gav"
                        Display="none" InitialValue="0" runat="server" ErrorMessage="गाव निवडा" ></asp:RequiredFieldValidator>
            
               
                                                                           </div>
</div>
                                    </div>--%>

                                <div class="span5">
 <div class="control-group">
              <asp:Label ID="Label4" runat="server" Text="कामाचा प्रकार" CssClass="control-label"></asp:Label>
            <div class="controls ">
                <asp:DropDownList ID="ddl_wrkType" runat="server">
                </asp:DropDownList><span class="ipsForm_required"> * </span>
            
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="a" ControlToValidate="ddl_wrkType"
                        Display="none" InitialValue="0" runat="server" ErrorMessage="कामाचा प्रकार निवडा" ></asp:RequiredFieldValidator>
            </div></div>
                                    </div>

                                <div class="span5">
            <div class="control-group">
                <asp:Label ID="Label5" runat="server" Text="कामाचे नाव" CssClass="control-label"></asp:Label>
            <div class="controls ">
                <asp:TextBox ID="txt_wrkName" runat="server" TextMode="MultiLine" CssClass="txtbox"></asp:TextBox>
                 <span class="ipsForm_required"> * </span>
           
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="a" ControlToValidate="txt_wrkName"
                        Display="None" runat="server" ErrorMessage="कामाचे नाव भरा" ></asp:RequiredFieldValidator>
                </div></div></div>

                           
                           <div class="control-group">
             <div class="controls ">
                  <asp:HiddenField ID="HiddenField1" runat="server" />
                                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="a" ShowMessageBox="True" ShowSummary="False" />
                  </div></div>

                              <div class="span12">
                                <div class="control-group" style="text-align:center">
                                    
         
               
                                  <asp:Button ID="btn_save" runat="server" OnClick="btn_save_Click" Text="Save" ValidationGroup="a" class="btn btn-success" />
                  </div></div>
                                  
                           
                             <div class="control-group" style="text-align:center;visibility:hidden" id="fillstage" runat="server">
            <asp:Label ID="Label1" runat="server" CssClass="control-label"></asp:Label>

                                  <asp:Label ID="Label7" runat="server"   CssClass="control-label" ></asp:Label>
              <asp:Label ID="Label6" runat="server" Text="Do you want to fill stages?" CssClass="control-label" ></asp:Label>
            <div class="controls " style="text-align:center">
              <asp:Button ID="ButtonYes" runat="server" OnClick="ButtonYes_Click" Text="Yes" class="btn btn-success" />
                  <asp:Button ID="ButtonNo" runat="server" OnClick="ButtonNo_Click" Text="No" class="btn btn-success" />
                
                <asp:Label ID="lbl1" runat="server"  width="200px" />
                
                  </div></div>

                                
                            
                              
                                  


</div></div></div></div></div></div> 
        <%-- </ContentTemplate>
         </asp:UpdatePanel>--%>
</asp:Content>