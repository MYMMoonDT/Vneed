<%@ Page Title="" Language="C#" MasterPageFile="~/Template/SubTitleTemplate.master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.Account.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
    <title>注册</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subHeadLeft" runat="server">
    <asp:Label ID="RegisterVneedLabel" runat="server" Text="注册新用户" CssClass="subTitleFont"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subHeadRight" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="registerContentBg" class="contentBg">
        <div id="registerContentContainer" class="contentContainer">
            <div id="registerTableContainer">
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="RegisterNameTextBox" runat="server" CssClass="registerContentTextBox"></asp:TextBox>
                    </td>
                    <td>
                        <div id="registerNameErrorContainer">
                            <asp:CustomValidator ID="RegisterNameCustomValidator" runat="server" 
                                ErrorMessage="该用户名已经存在"
                                ControlToValidate="RegisterNameTextBox" Display="Dynamic"
                                ValidationGroup="RegisterGroup" 
                                onservervalidate="RegisterNameCustomValidator_ServerValidate">
                                <div class="error">该用户名已经存在</div>
                            </asp:CustomValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="RegisterPasswordTextBoxShow" runat="server" CssClass="registerContentTextBox"></asp:TextBox>
                        <asp:TextBox ID="RegisterPasswordTextBoxHide" runat="server" CssClass="registerContentTextBox" style="display:none;" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <div id="registerPasswordErrorContainer"></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="RegisterPasswordAgainTextBoxShow" runat="server" CssClass="registerContentTextBox"></asp:TextBox>
                        <asp:TextBox ID="RegisterPasswordAgainTextBoxHide" runat="server" CssClass="registerContentTextBox" style="display:none;" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <div id="registerPasswordAgainErrorContainer"></div>
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:TextBox ID="RegisterEmailTextBox" runat="server" CssClass="registerContentTextBox"></asp:TextBox> 
                    </td>
                    <td>
                        <div id="registerEmailErrorContainer">
                            <asp:CustomValidator ID="RegisterEmailCustomValidator" runat="server" 
                                ErrorMessage="该邮箱地址已经被使用" 
                                ControlToValidate="RegisterEmailTextBox" Display="Dynamic"
                                ValidationGroup="RegisterGroup" 
                                onservervalidate="RegisterEmailCustomValidator_ServerValidate">
                                <div class="error">该邮箱地址已经被使用</div>
                            </asp:CustomValidator>
                        </div>
                    </td>
                </tr>
            </table>
            </div>
            <div id="registerAgreementTableContainer">
                <table>
                <tr>
                    <td>
                        <div class="registerAgreementContainer">
                            <asp:Label ID="RegisterAgreementLabel" runat="server" Text=""></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="RegisterButton" runat="server" Text="同意以上协议并注册" 
                            CssClass="registerContentButton" onclick="RegisterButton_Click" 
                            OnClientClick="return RegisterForm.Validation();"
                            ValidationGroup="RegisterGroup"/>
                    </td>
                </tr>
                </table>
            </div>
        </div>
    </div>
<script type="text/javascript">
    function RegisterForm() {
        this.parentID = "ContentPlaceHolder1_ContentPlaceHolder2";

        this.registerNameTextBoxID = "RegisterNameTextBox";
        this.registerPasswordTextBoxID = "RegisterPasswordTextBox";
        this.registerPasswordAgainTextBoxID = "RegisterPasswordAgainTextBox";
        this.registerEmailTextBoxID = "RegisterEmailTextBox";

        this.registerNameTextBoxFullID = "#" + this.parentID + "_" + this.registerNameTextBoxID;
        this.registerPasswordTextBoxFullID = "#" + this.parentID + "_" + this.registerPasswordTextBoxID;
        this.registerPasswordAgainTextBoxFullID = "#" + this.parentID + "_" + this.registerPasswordAgainTextBoxID;
        this.registerEmailTextBoxFullID = "#" + this.parentID + "_" + this.registerEmailTextBoxID;

        this.Init();
    }
    RegisterForm.Validation = function () {
        $("#registerNameErrorContainer").html("");
        $("#registerPasswordErrorContainer").html("");
        $("#registerPasswordAgainErrorContainer").html("");
        $("#registerEmailErrorContainer").html("");

        var parentID = "ContentPlaceHolder1_ContentPlaceHolder2";

        var RegisterNameTextBoxID = "RegisterNameTextBox";
        var RegisterPasswordTextBoxHideID = "RegisterPasswordTextBoxHide";
        var RegisterPasswordAgainTextBoxHideID = "RegisterPasswordAgainTextBoxHide";
        var RegisterEmailTextBoxID = "RegisterEmailTextBox";

        var RegisterNameTextBoxFullID = "#" + parentID + "_" + RegisterNameTextBoxID;
        var RegisterPasswordTextBoxHideFullID = "#" + parentID + "_" + RegisterPasswordTextBoxHideID;
        var RegisterPasswordAgainTextBoxHideFullID = "#" + parentID + "_" + RegisterPasswordAgainTextBoxHideID;
        var RegisterEmailTextBoxFullID = "#" + parentID + "_" + RegisterEmailTextBoxID;

        var RegisterNameRequiredValidation = new Validator({
            id: RegisterNameTextBoxFullID,
            type: "required",
            defaultStr: "用户名"
        });
        var RegisterNameRangeValidation = new Validator({
            id: RegisterNameTextBoxFullID,
            type: "range",
            minLength: 6,
            maxLength: 16
        });
        var RegisterPasswordRequiredValidation = new Validator({
            id: RegisterPasswordTextBoxHideFullID,
            type: "required"
        });
        var RegisterPasswordRangeValidation = new Validator({
            id: RegisterPasswordTextBoxHideFullID,
            type: "range",
            minLength: 6,
            maxLength: 16
        });

        var RegisterPasswordAgainRequiredValidation = new Validator({
            id: RegisterPasswordAgainTextBoxHideFullID,
            type: "required"
        });
        var RegisterPasswordAgainCompareValidation = new Validator({
            id: RegisterPasswordAgainTextBoxHideFullID,
            compareId: RegisterPasswordTextBoxHideFullID,
            type: "compare"
        });
        var RegisterEmailRequiredValidation = new Validator({
            id: RegisterEmailTextBoxFullID,
            type: "required",
            defaultStr: "邮箱"
        });
        var RegisterEmailRegExpValidation = new Validator({
            id: RegisterEmailTextBoxFullID,
            type: "regexp",
            regexp: /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/
        });

        if (!RegisterNameRequiredValidation.Validation()) {
            $("#registerNameErrorContainer").html("<div class='error'>请输入用户名</div>");
            return false;
        }

        if (!RegisterNameRangeValidation.Validation()) {
            $("#registerNameErrorContainer").html("<div class='error'>用户名长度必须在6~16个字符之间</div>");
            return false;
        }

        if (!RegisterPasswordRequiredValidation.Validation()) {
            $("#registerPasswordErrorContainer").html("<div class='error'>请输入密码</div>");
            return false;
        }

        if (!RegisterPasswordRangeValidation.Validation()) {
            $("#registerPasswordErrorContainer").html("<div class='error'>密码长度必须在6~16个字符之间</div>");
            return false;
        }

        if (!RegisterPasswordAgainRequiredValidation.Validation()) {
            $("#registerPasswordAgainErrorContainer").html("<div class='error'>请输入密码</div>");
            return false;
        }

        if (!RegisterPasswordAgainCompareValidation.Validation()) {
            $("#registerPasswordAgainErrorContainer").html("<div class='error'>两次密码不一致</div>");
            return false;
        }

        if (!RegisterEmailRequiredValidation.Validation()) {
            $("#registerEmailErrorContainer").html("<div class='error'>请输入电子邮箱地址</div>");
            return false;
        }

        if (!RegisterEmailRegExpValidation.Validation()) {
            $("#registerEmailErrorContainer").html("<div class='error'>请输入正确的邮箱地址</div>");
            return false;
        }

        return true;
    };
    RegisterForm.prototype.Init = function () {
        this.registerNameTextBox = new TextBox({
            id: this.registerNameTextBoxFullID,
            defaultStr: "用户名",
            type: "text"
        });
        this.registerPasswordTextBox = new TextBox({
            id: this.registerPasswordTextBoxFullID,
            defaultStr: "设置密码",
            type: "password"
        });
        this.registerPasswordAgainTextBox = new TextBox({
            id: this.registerPasswordAgainTextBoxFullID,
            defaultStr: "重复一遍密码",
            type: "password"
        });
        this.registerEmailTextBox = new TextBox({
            id: this.registerEmailTextBoxFullID,
            defaultStr: "邮箱",
            type: "text"
        });
    };
</script>
<%--<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
        var registerForm = new RegisterForm();
    });
</script>--%>
<script type="text/javascript">
    $(document).ready(function () {
        var registerForm = new RegisterForm();
    });
</script>
</asp:Content>
