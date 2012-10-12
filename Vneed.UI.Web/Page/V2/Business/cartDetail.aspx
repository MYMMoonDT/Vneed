<%@ Page Title="" Language="C#" MasterPageFile="~/Template/OrderProcessTemplate.master" AutoEventWireup="true" CodeBehind="cartDetail.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.Business.cartDetail" %>
<%@ Register src="../../../WebUserControl/V2/OrderProcessStepControl.ascx" tagname="OrderProcessStepControl" tagprefix="uc1" %>
<%@ Register src="../../../WebUserControl/V2/CartTableControl.ascx" tagname="CartTableControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head3" runat="server">
    <title>购物车</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subTitle" runat="server">
    <div class="subTitleFont">购物车</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OrderProcessMainContentPlaceHolder" runat="server"> 
    <uc1:OrderProcessStepControl ID="OrderProcessStepControl1" runat="server" />
    <uc2:CartTableControl ID="CartTableControl" runat="server" />
</asp:Content>
