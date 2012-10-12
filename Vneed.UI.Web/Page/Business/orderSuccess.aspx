<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template3.master" AutoEventWireup="true" CodeBehind="orderSuccess.aspx.cs" Inherits="Vneed.UI.Web.Page.Business.orderSuccess" %>
<%@ Register src="../../WebUserControl/OrderProcessWebUserControl.ascx" tagname="OrderProcessWebUserControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
    <span>提交订单</span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div class="contentWrapperDiv orderSuccessContentWrapperDiv">
    <uc1:OrderProcessWebUserControl ID="OrderProcessWebUserControl1" runat="server" />
    <div class="orderSuccessContentDiv">
       <div class="orderSuccessTitle">
            <table>
                <tr>
                    <td><span>恭喜您，提交订单成功！</span></td>
                    <td><img src="../../Resource/Image/register/success_register.png" alt="提交成功"/></td>
                </tr>
            </table>
       </div>
       <div class="orderSuccessMessage">
            <table>
                <tr><td><span>您可以点击“继续购物”按钮继续购物，也可以点击“我的Vneed”按钮查看订单情况。</span></td></tr>
                <tr>
                    <td>
                        <div class="orderSuccessMessageButtonDiv">
                            <asp:Button ID="Button1" runat="server" Text="继续购物" CssClass="button orderSuccessButton"/>
                            <asp:Button ID="Button2" runat="server" Text="我的Vneed" 
                                CssClass="button orderSuccessButton" onclick="Button2_Click"/>
                        </div>
                    </td>
                </tr>
            </table>
       </div>
    </div>
</div>
</asp:Content>
