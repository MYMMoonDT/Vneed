<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopBarControl.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.V2.TopBarControl" %>
<%@ Register src="SearchBarControl.ascx" tagname="SearchBarControl" tagprefix="searchBar" %>
<div id="topBarBg">
    <div id="topBarContainer">
        <div id="topBarLogo">
            <asp:HyperLink ID="topBarLogoHyperLink" runat="server" NavigateUrl="~/Page/V2/index.aspx">
                <asp:Image ID="topBarLogoImage" runat="server" ImageUrl="~/Resource/Image/header/header_logo.png"/>
            </asp:HyperLink>
        </div>
        <div class="topBarDivider"></div>
        <div id="topBarSearchContainer">
            <searchBar:SearchBarControl ID="SearchBarControl1" runat="server" />  
        </div>
        <div class="topBarDivider"></div>
        <div id="topBarMyVneedContainer">
            <asp:Panel ID="topBarMyVneedLoginContainer" runat="server" CssClass="topBarMyVneedLoginContainer">
                <table>
                    <tr>
                        <td><asp:HyperLink ID="GoToMyVneedHyperLink" runat="server" NavigateUrl="~/Page/V2/MyVneed/myVneedMyOrder.aspx">我的Vneed</asp:HyperLink></td>
                        <td rowspan="2">
                            <asp:UpdatePanel ID="ProductInCartNumUpdatePanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:HyperLink ID="GoToMyCartHyperLink" runat="server" NavigateUrl="~/Page/V2/Business/cartDetail.aspx">
                                        <asp:Image ID="ProductInCartNumImage" runat="server"/>
                                    </asp:HyperLink>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>      
                    <tr>
                        <td>
                            <asp:Button ID="LogoutVneedButton" runat="server" Text="退出" 
                                CssClass="logoutButton" onclick="LogoutVneedButton_Click"/>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="topBarMyVneedLogoutContainer" runat="server" CssClass="topBarMyVneedLogoutContainer">
                <asp:HyperLink ID="LoginVneedHyperLink" runat="server" NavigateUrl="javascript:void(0);">登陆</asp:HyperLink>
                <asp:HyperLink ID="RegisterVneedHyperLink" runat="server" NavigateUrl="~/Page/V2/Account/register.aspx">注册</asp:HyperLink>
            </asp:Panel>
        </div>
        <div id="topBarSNSContactContainer">
            <asp:HyperLink ID="VneedRenRenHyperLink" runat="server" Target="_blank" NavigateUrl="http://page.renren.com/601126132">
                <asp:Image ID="RenRenImage" runat="server" ImageUrl="~/Resource/Image/icon/btn-renren.png" />
            </asp:HyperLink>
            <asp:HyperLink ID="VneedWeiboHyperLink" runat="server" Target="_blank" NavigateUrl="http://weibo.com/vneed2011">
                <asp:Image ID="WeiboImage" runat="server" ImageUrl="~/Resource/Image/icon/btn-weibo.png" />
            </asp:HyperLink>
        </div>
    </div>
</div>
<div id="loginDialogContainer">
    <asp:UpdatePanel ID="loginUpdatePanel" runat="server">
    <ContentTemplate>
    <div id="loginDialogTextContainer">
        <asp:TextBox ID="loginNameTextBox" runat="server" CssClass="loginContentTextBox"></asp:TextBox>
        <asp:TextBox ID="loginPasswordTextBoxShow" runat="server" CssClass="loginContentTextBox"></asp:TextBox>
        <asp:TextBox ID="loginPasswordTextBoxHide" runat="server" CssClass="loginContentTextBox" style="display:none;" TextMode="Password"></asp:TextBox>
    </div>
    <div id="loginDialogOptionContainer">
        <asp:Button ID="loginVneedButton" runat="server" Text="登陆" 
            CssClass="loginContentButton" 
            onclick="loginVneedButton_Click" 
            OnClientClick="return LoginDialog.Validation();"
            ValidationGroup="loginGroup"/>
        <asp:HyperLink ID="registerNowHyperLink" runat="server" CssClass="loginContentLink" NavigateUrl="~/Page/V2/Account/register.aspx">还没有注册</asp:HyperLink>
        <div id="loginDialogErrorContainer">
            <asp:CustomValidator ID="CustomValidatorLogin" runat="server" 
                ErrorMessage="用户名或密码错误" 
                Display="Dynamic" 
                ValidationGroup="loginGroup" 
                onservervalidate="CustomValidatorLogin_ServerValidate">
                <div class="error">用户名或密码错误</div>
            </asp:CustomValidator>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</div>
<script type="text/javascript">
    function TopBarControl() {
        this.parentID = "TopBarControl1";
        this.loginLinkID = "LoginVneedHyperLink";
        this.loginDialogInst = new LoginDialog(this.parentID);
        this.Init();
    }
    TopBarControl.prototype.Init = function () {
        var loginLinkFullID = "#" + this.parentID + "_" + this.loginLinkID;
        $(loginLinkFullID).click(function () {
            var loginDialogFullID = "#" + "loginDialogContainer";
            $(loginDialogFullID).modal({
                appendTo: 'form',
                opacity: 50,
                overlayCss: { backgroundColor: "#000" },
                closeHTML: '<a class="ModalDialogClose" title="关闭"></a>'
            });
        });
    };
    function LoginDialog(parentID) {
        this.parentID = parentID;
        this.loginNameTextBoxID = "loginNameTextBox";
        this.loginPasswordTextBoxID = "loginPasswordTextBox";

        this.loginNameTextBoxFullID = "#" + this.parentID + "_" + this.loginNameTextBoxID;
        this.loginPasswordTextBoxFullID = "#" + this.parentID + "_" + this.loginPasswordTextBoxID;

        this.Init();
    }
    LoginDialog.Validation = function () {

        var parentID = "TopBarControl1";
        var loginNameTextBoxID = "loginNameTextBox";
        var loginPasswordTextBoxHideID = "loginPasswordTextBoxHide";

        var loginNameTextBoxFullID = "#" + parentID + "_" + loginNameTextBoxID;
        var loginPasswordTextBoxHideFullID = "#" + parentID + "_" + loginPasswordTextBoxHideID;

        var loginNameRequiredValidation = new Validator({
            id: loginNameTextBoxFullID,
            type: "required",
            defaultStr: "请输入您的用户名"
        });

        var loginPasswordRequiredValidation = new Validator({
            id: loginPasswordTextBoxHideFullID,
            type: "required"
        });

        var loginNameRangeValidation = new Validator({
            id: loginNameTextBoxFullID,
            type: "range",
            minLength: 6,
            maxLength: 16
        });

        var loginPasswordRangeValidation = new Validator({
            id: loginPasswordTextBoxHideFullID,
            type: "range",
            minLength: 6,
            maxLength: 16
        });

        if (!loginNameRequiredValidation.Validation()) {
            $("#loginDialogErrorContainer").html("<div class='error'>用户名不能为空</div>");
            return false;
        }
        if (!loginPasswordRequiredValidation.Validation()) {
            $("#loginDialogErrorContainer").html("<div class='error'>密码不能为空</div>");
            return false;
        }
        if (!loginNameRangeValidation.Validation()) {
            $("#loginDialogErrorContainer").html("<div class='error'>用户名长度在6~16个字符之间</div>");
            return false;
        }
        if (!loginPasswordRangeValidation.Validation()) {
            $("#loginDialogErrorContainer").html("<div class='error'>密码长度为6~16个字符之间</div>");
            return false;
        }


        return true;
    };
    LoginDialog.prototype.Init = function () {
        this.loginNameTextBox = new TextBox({
            id: this.loginNameTextBoxFullID,
            defaultStr: "请输入您的用户名",
            type: "text"
        });
        this.loginPasswordTextBox = new TextBox({
            id: this.loginPasswordTextBoxFullID,
            defaultStr: "请输入您的密码",
            type: "password"
        });
    };
</script>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
        var TopBarControlInst = new TopBarControl();
    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        var TopBarControlInst = new TopBarControl();
    });
</script>
