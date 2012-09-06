<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderProcessWebUserControl.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.OrderProcessWebUserControl" %>
<link href="../Resource/CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
<div class="orderProcessWrapper">
    <div class="orderProcessDiv">
        <div class="orderProcessContentDiv">
            <asp:Panel ID="orderProcessPanel" runat="server" CssClass="orderProcessStepContainer">
                <asp:Panel ID="orderProcessStep1Panel" runat="server" ClientIDMode="Static">
                    <asp:Label ID="orderProcessStep1Label" runat="server" Text="" ClientIDMode="Static"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="orderProcessStep1to2Panel" runat="server" ClientIDMode="Static"></asp:Panel>
                <asp:Panel ID="orderProcessStep2Panel" runat="server" ClientIDMode="Static">
                    <asp:Label ID="orderProcessStep2Label" runat="server" ClientIDMode="Static"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="orderProcessStep2to3Panel" runat="server" ClientIDMode="Static"></asp:Panel>
                <asp:Panel ID="orderProcessStep3Panel" runat="server" ClientIDMode="Static">
                    <asp:Label ID="orderProcessStep3Label" runat="server" ClientIDMode="Static"></asp:Label>
                </asp:Panel>
            </asp:Panel>
        </div>
        <div class="orderProcessTextDiv">
            <div class="orderProcessLeftRightItem">购物车</div>
            <div class="orderProcessCenterItem">确认订单信息</div>
            <div class="orderProcessLeftRightItem">成功提交订单</div>
        </div>
    </div>
</div>