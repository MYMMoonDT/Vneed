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
                        <td><asp:HyperLink ID="GoToMyVneedHyperLink" runat="server">我的Vneed</asp:HyperLink></td>
                        <td rowspan="2">
                            <asp:HyperLink ID="GoToMyCartHyperLink" runat="server">
                                <asp:Image ID="ProductInCartNumImage" runat="server" ImageUrl="~/Resource/Image/header/header_cartlogo_0.png"/>
                            </asp:HyperLink>
                        </td>
                    </tr>      
                    <tr>
                        <td>
                            <asp:Button ID="LogoutVneedButton" runat="server" Text="退出" CssClass="logoutButton"/>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="topBarMyVneedLogoutContainer" runat="server" CssClass="topBarMyVneedLogoutContainer">
                <asp:HyperLink ID="LoginVneedHyperLink" runat="server">登陆</asp:HyperLink>
                <asp:HyperLink ID="RegisterVneedHyperLink" runat="server">注册</asp:HyperLink>
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