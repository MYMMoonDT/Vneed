<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBarWebUserControl1.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.NavBarWebUserControl1" %>
    <script type="text/javascript">
        function EndRequestHandler1() {
            $("#NavBarWebUserControl11_loginName").focus(function () {
                if ($("#NavBarWebUserControl11_loginName").val() == "请输入您的用户名")
                    $("#NavBarWebUserControl11_loginName").val("").removeClass("loginFont1").addClass("loginFont2");
            });
            $("#NavBarWebUserControl11_loginPassword").focus(function () {
                if ($("#NavBarWebUserControl11_loginPassword").val() == "请输入您的密码") {
                    $("#NavBarWebUserControl11_loginPassword").val("").removeClass("loginFont1").addClass("loginFont2");
                    document.getElementById("NavBarWebUserControl11_loginPassword").type = "password";
                }
            });
            $("#NavBarWebUserControl11_loginName").blur(function () {
                if ($("#NavBarWebUserControl11_loginName").val() == "")
                    $("#NavBarWebUserControl11_loginName").val("请输入您的用户名").removeClass("loginFont2").addClass("loginFont1");
            });
            $("#NavBarWebUserControl11_loginPassword").blur(function () {
                if ($("#NavBarWebUserControl11_loginPassword").val() == "") {
                    $("#NavBarWebUserControl11_loginPassword").val("请输入您的密码").removeClass("loginFont2").addClass("loginFont1");
                    document.getElementById("NavBarWebUserControl11_loginPassword").type = "text";
                }
            });
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#loginLink").click(function () {
                $("#loginDialogDiv").modal({
                    appendTo: 'form',
                    opacity: 50,
                    overlayCss: { backgroundColor: "#000" },
                    closeHTML: '<a class="modalCloseImg" title="关闭"></a>'
                });
            });
            $("#NavBarWebUserControl11_loginName").focus(function () {
                if ($("#NavBarWebUserControl11_loginName").val() == "请输入您的用户名")
                    $("#NavBarWebUserControl11_loginName").val("").removeClass("loginFont1").addClass("loginFont2");
            });
            $("#NavBarWebUserControl11_loginPassword").focus(function () {
                if ($("#NavBarWebUserControl11_loginPassword").val() == "请输入您的密码") {
                    $("#NavBarWebUserControl11_loginPassword").val("").removeClass("loginFont1").addClass("loginFont2");
                    document.getElementById("NavBarWebUserControl11_loginPassword").type = "password";
                }
            });
            $("#NavBarWebUserControl11_loginName").blur(function () {
                if ($("#NavBarWebUserControl11_loginName").val() == "")
                    $("#NavBarWebUserControl11_loginName").val("请输入您的用户名").removeClass("loginFont2").addClass("loginFont1");
            });
            $("#NavBarWebUserControl11_loginPassword").blur(function () {
                if ($("#NavBarWebUserControl11_loginPassword").val() == "") {
                    $("#NavBarWebUserControl11_loginPassword").val("请输入您的密码").removeClass("loginFont2").addClass("loginFont1");
                    document.getElementById("NavBarWebUserControl11_loginPassword").type = "text";
                }
            });
        });
        function LoginValidationFunc() {
            $("#loginErrorDiv").html("");
            if ($("#NavBarWebUserControl11_loginName").val() == "请输入您的用户名" || $("#NavBarWebUserControl11_loginName").val() == "") {
                $("#loginErrorDiv").html("<div class='error'>用户名不能为空</div>");
                return false;
            }
            if ($("#NavBarWebUserControl11_loginPassword").val() == "请输入您的密码" || $("#NavBarWebUserControl11_loginPassword").val() == "") {
                $("#loginErrorDiv").html("<div class='error'>密码不能为空</div>");
                return false;
            }
            if ($("#NavBarWebUserControl11_loginName").val().length < 6 || $("#NavBarWebUserControl11_loginName").val().length > 16) {
                $("#loginErrorDiv").html("<div class='error'>用户名长度在6~16个字符之间</div>");
                return false;
            }
            if ($("#NavBarWebUserControl11_loginPassword").val().length < 6 || $("#NavBarWebUserControl11_loginPassword").val().length > 16) {
                $("#loginErrorDiv").html("<div class='error'>密码长度为6~16个字符之间</div>");
                return false;
            }
            return true;
        }
    </script>
    <div id="headDiv1">
    	<div id="headDiv2">
        	<div id="headLogoDiv"></div>
            <div class="headDividerDiv" style="left:230px;"></div>
            <div class="headDividerDiv" style="left:750px;"></div>
            <div id="headSearchTextDiv">
            	<div id="headSearchTextDiv1">
                    <asp:TextBox ID="searchContent" runat="server" CssClass="text searchText"></asp:TextBox>
                    <asp:Button ID="searchButton" runat="server" Text="搜索" 
                        CssClass="button searchButton"/>
                </div>
       	  	</div>
          	<div id="headMyVneedDiv">
                  <asp:Panel ID="headMyVneedDiv1" runat="server" ClientIDMode="Static">
                    <a href=""><span class="font1 headFont1">我的Vneed</span></a>
                    <asp:Image ID="ProductNumImage" runat="server" CssClass="headImg1" ImageUrl="~/Resource/Image/header/header_cartlogo_1.png" />
                  </asp:Panel>
                  <asp:Panel ID="headMyVneedDiv2" runat="server" ClientIDMode="Static">
                    <asp:HyperLink ID="RegisterHyperLink" CssClass="font1 headFont2" runat="server" 
                        NavigateUrl="~/Page/Account/register.aspx">注册</asp:HyperLink>
                    <span id="loginLink" class="font1 headFont2">登陆</span>
                  </asp:Panel>     
          </div>
    	</div>
	</div>

    
    <div id="loginDialogDiv">
        <asp:UpdatePanel ID="LoginUpdatePanel" runat="server">
        <ContentTemplate>
    	<div id="loginTextDiv">
            <asp:TextBox ID="loginName" runat="server" CssClass="text loginText1 loginFont1">请输入您的用户名</asp:TextBox>
            <div style="height:10px;"></div>
            <asp:TextBox ID="loginPassword" runat="server" CssClass="text loginText1 loginFont1" >请输入您的密码</asp:TextBox>
            <div style="height:10px;"></div>
            <asp:Button ID="loginButton" runat="server" Text="登陆" 
                CssClass="button loginButton1" OnClientClick="return LoginValidationFunc();" 
                ValidationGroup="loginGroup" onclick="loginButton_Click" />
            <a href="../Page/Account/register.aspx" class="registerLink">还没有注册</a>
            <div id="loginErrorDiv">
                <asp:CustomValidator ID="CustomValidatorLogin" runat="server" ErrorMessage="用户名或密码错误" Display="Dynamic" 
                    onservervalidate="CustomValidatorLogin_ServerValidate" ValidationGroup="loginGroup">
                    <div class="error">用户名或密码错误</div>
                </asp:CustomValidator>
            </div>
            
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <div style="height:10px;"></div>
        <div id="loginSelectDiv">
        	<div class="loginFont3"><span>使用其他账号登陆</span></div>
            <div class="loginSelectItem"><asp:Image ID="Image1" runat="server" ImageUrl="~/Resource/Image/pop_up/login/pop-up_collection_logo_renren.png" /></div>
            <div style="width:10px;float:left;height:10px;"></div>
            <div class="loginSelectItem"><asp:Image ID="Image2" runat="server" ImageUrl="~/Resource/Image/pop_up/login/pop-up_collection_logo_weibo.png" /></div>
        </div>
    </div>
    