<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyVneedSideNavBarControl.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.V2.MyVneedSideNavBarControl" %>
<div id="myVneedSideNavBarContainer">
    <div class="myVneedSideNavBarTitle">&nbsp;交易管理</div>
    <div class="myVneedSideNavBarSubTitle">
        <asp:HyperLink ID="myVneedOrderHyperLink" runat="server" NavigateUrl="~/Page/V2/MyVneed/myVneedMyOrder.aspx">我的订单</asp:HyperLink>
    </div>
    <div class="myVneedSideNavBarSubTitle">
        <asp:HyperLink ID="myVneedCollectionHyperLink" runat="server">我的收藏</asp:HyperLink>
    </div>
<%--    <div class="myVneedSideNavBarSubTitle"></div>
    <div class="myVneedSideNavBarSubTitle"></div>--%>

    <div class="myVneedSideNavBarTitle">&nbsp;个人资料</div>
    <div class="myVneedSideNavBarSubTitle">
        <asp:HyperLink ID="myVneedPersonalDetailHyperLink" runat="server">个人信息</asp:HyperLink>
    </div>
    <div class="myVneedSideNavBarSubTitle">
        <asp:HyperLink ID="myVneedPasswordManagementHyperLink" runat="server">密码管理</asp:HyperLink>
    </div>
<%--    <div class="myVneedSideNavBarSubTitle"></div>
    <div class="myVneedSideNavBarSubTitle"></div>--%>
</div>