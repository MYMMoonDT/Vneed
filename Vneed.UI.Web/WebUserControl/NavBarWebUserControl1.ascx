<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBarWebUserControl1.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.NavBarWebUserControl1" %>
    <script type="text/javascript">
        function EndRequestHandler1() {
            var loginInfo = [["#NavBarWebUserControl11_loginName", "请输入您的用户名", "focus", "text"],
                             ["#NavBarWebUserControl11_loginPassword", "请输入您的密码", "focus", "password"],
                             ["#NavBarWebUserControl11_loginName", "请输入您的用户名", "blur", "text"],
                             ["#NavBarWebUserControl11_loginPassword", "请输入您的密码", "blur", "password"]];
            for (var i = 0; i < loginInfo.length; i++) {
                (function () {
                    var loginItem = loginInfo[i];
                    if (loginItem[2] == "focus") {
                        $(loginItem[0]).focus(function () {
                            if ($(loginItem[0]).val() == loginItem[1]) {
                                $(loginItem[0]).val("").removeClass("loginFont1").addClass("loginFont2");
                                if (loginItem[3] == "password")
                                    document.getElementById(loginItem[0].substr(1)).type = "password";
                            }
                        });
                    } else if (loginItem[2] == "blur") {
                        $(loginItem[0]).blur(function () {
                            if ($(loginItem[0]).val() == "") {
                                $(loginItem[0]).val(loginItem[1]).removeClass("loginFont2").addClass("loginFont1");
                                if (loginItem[3] == "password")
                                    document.getElementById(loginItem[0].substr(1)).type = "text";
                            }
                        });
                    }
                })();
            }
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
            EndRequestHandler1();
        });
        function LoginValidationFunc() {
            $("#loginErrorDiv").html("");
            var loginInfo = [["#NavBarWebUserControl11_loginName", "请输入您的用户名", "用户名不能为空", "null"],
                             ["#NavBarWebUserControl11_loginPassword", "请输入您的密码", "密码不能为空", "null"],
                             ["#NavBarWebUserControl11_loginName", "", "用户名长度在6~16个字符之间", "length"],
                             ["#NavBarWebUserControl11_loginPassword", "", "密码长度为6~16个字符之间", "length"]];
            for (var i = 0; i < loginInfo.length; i++) {
                if (loginInfo[i][3] == "null") {
                    if ($(loginInfo[i][0]).val() == loginInfo[i][1] || $(loginInfo[i][0]).val() == "") {
                        $("#loginErrorDiv").html("<div class='error'>" + loginInfo[i][2] + "</div>");
                        return false;
                    }
                } else if (loginInfo[i][3] == "length") {
                    if ($(loginInfo[i][0]).val().length < 6 || $(loginInfo[i][0]).val().length > 16) {
                        $("#loginErrorDiv").html("<div class='error'>"+ loginInfo[i][2] +"</div>");
                        return false;
                    }
                }
            }
            return true;
        }
    </script>

    <div id="headDiv1">
    	<div id="headDiv2">
        	<div id="headLogoDiv">
                <asp:HyperLink ID="HomepageHyperLink" runat="server" NavigateUrl="~/Page/index.aspx">
                    <asp:Image ID="headLogoImage" runat="server" ImageUrl="~/Resource/Image/header/header_logo.png" />
                </asp:HyperLink>
            </div>
            <div class="headDividerDiv" style="left:230px;"></div>
            <div class="headDividerDiv" style="left:750px;"></div>
            <div id="headSearchTextDiv">
            	<div id="headSearchTextDiv1">
                    <table cellspacing="0" cellpadding="0">
                        <tr>
                            <td><asp:TextBox ID="searchContent" runat="server" CssClass="text searchText"></asp:TextBox></td>
                            <td><asp:Button ID="searchButton" runat="server" Text="搜索" 
                            CssClass="button searchButton"/></td>
                        </tr>
                    </table>
                </div>
       	  	</div>
          	<div id="headMyVneedDiv">
                  <asp:Panel ID="headMyVneedDiv1" runat="server" ClientIDMode="Static">
                  <asp:HyperLink ID="MyVneedHyperLink" runat="server" CssClass="font1 headFont1" NavigateUrl="~/Page/User/orderList.aspx">我的Vneed</asp:HyperLink>
                  <asp:HyperLink ID="MyCartHyperLink" runat="server" NavigateUrl="~/Page/Business/cart.aspx">
                    <asp:Image ID="ProductNumImage" runat="server" CssClass="headImg1" ImageUrl="~/Resource/Image/header/header_cartlogo_1.png" />
                  </asp:HyperLink>
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
            <asp:TextBox ID="loginPassword" runat="server" CssClass="text loginText1 loginFont1" autocomplete="off">请输入您的密码</asp:TextBox>
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
        <script type="text/javascript">
            EndRequestHandler1();
        </script>
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
    