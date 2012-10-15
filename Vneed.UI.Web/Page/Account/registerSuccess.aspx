<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template1.Master" AutoEventWireup="true" CodeBehind="registerSuccess.aspx.cs" Inherits="Vneed.UI.Web.Page.Account.registerSuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="contentMainDiv">
        <div id="registerSuccessContentWrapperDiv" class="contentWrapperDiv">
            <div id="registerSuccessContentDiv">
            <div id="registerSuccessDiv">
                <div style="position: absolute; top: 64px; left:30px;">
                    <span class="registerSuccessFont">恭喜您，注册成功！</span>
                </div>
                <div style="position: absolute; left: 256px; top: 8px;">
                    <asp:Image ID="Image1" runat="server" 
                        ImageUrl="~/Resource/Image/register/success_register.png" />
                </div>
                <div style="position: absolute; top: 151px; left: 50px;">
                    3秒后跳转到主页,你也可以点击下面的按钮直接跳转到主页...
                </div>
                <div style="position: absolute; top: 182px; left: 130px;">
                    <asp:Button ID="Button1" runat="server" Text="跳转到主页" 
                        CssClass="button registerSuccessButton" Height="36px" onclick="Button1_Click" 
                        Width="185px"/>
                </div>
            </div>
            </div>
        </div>
    </div>
    <%--<%
        Response.AddHeader("refresh","3;url=/Page/index.aspx");
    %>--%>
</asp:Content>
