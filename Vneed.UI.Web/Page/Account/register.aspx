<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Vneed.UI.Web.Page.Account.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <script src="../../Resource/JS/register.js" type="text/javascript"></script>
    <div class="titleMainDiv">
        <div class="titleWrapperDiv">
            <div id="registerTitleDiv1">
                <span>注册新用户</span>
            </div>
        </div>
    </div>
    <div class="divider1"></div>
    <div class="contentMainDiv">
        <div id="registerContentWrapperDiv" class="contentWrapperDiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div id="registerContentTextDiv">
                <asp:TextBox ID="RegisterNameTextBox" runat="server" 
                    CssClass="registerContentTextBox text" ClientIDMode="Static" ValidationGroup="RegisterGroup">用户名</asp:TextBox>
                <asp:TextBox ID="RegisterPasswordTextBox" runat="server" 
                    CssClass="registerContentTextBox text" ClientIDMode="Static" ValidationGroup="RegisterGroup">设置密码</asp:TextBox>
                <asp:TextBox ID="RegisterPasswordAgainTextBox" runat="server" 
                    CssClass="registerContentTextBox text" ClientIDMode="Static" ValidationGroup="RegisterGroup">重复一遍密码</asp:TextBox>
                <asp:TextBox ID="RegisterEmailTextBox" runat="server" 
                    CssClass="registerContentTextBox text" ClientIDMode="Static" ValidationGroup="RegisterGroup">邮箱</asp:TextBox>
                <asp:Button ID="RegisterButton" runat="server" Text="同意以下协议并注册" 
                    CssClass="registerContentButton button" ClientIDMode="Static" 
                    ValidationGroup="RegisterGroup" 
                    OnClientClick="return RegisterValidationFunc();" 
                    onclick="RegisterButton_Click" />
            </div>
            <div id="registerContentErrorDiv">
                <div id="registerNameError" class="registerContentError">
                    <asp:CustomValidator ID="RegisterNameCustomValidator" runat="server" 
                        ErrorMessage="该用户名已经存在" ControlToValidate="RegisterNameTextBox" 
                        EnableClientScript="False" ValidationGroup="RegisterGroup" 
                        onservervalidate="RegisterNameCustomValidator_ServerValidate" Display="Dynamic">
                        <div class="error">该用户名已经存在</div>
                    </asp:CustomValidator>
                </div>
                <div id="registerPasswordError" class="registerContentError">
                    
                </div>
                <div id="registerPassword2Error" class="registerContentError">
                    
                </div>
                <div id="registerEmailError" class="registerContentError">
                    <asp:CustomValidator ID="RegisterEmailCustomValidator" runat="server" 
                        ErrorMessage="该邮箱地址已经被使用" ControlToValidate="RegisterEmailTextBox" 
                        EnableClientScript="False" ValidationGroup="RegisterGroup" 
                        onservervalidate="RegisterEmailCustomValidator_ServerValidate" Display="Dynamic">
                        <div class="error">该邮箱地址已经被使用</div>
                    </asp:CustomValidator>
                </div>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
            <div id="registerContentAgreementDiv">
                <asp:TextBox ID="AgreementTextBox" runat="server" 
                    CssClass="registerAgreementTextbox" ReadOnly="True" 
                    TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
