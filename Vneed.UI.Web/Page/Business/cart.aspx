<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template3.master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="Vneed.UI.Web.Page.Business.cart" %>
<%@ Register src="../../WebUserControl/OrderProcessWebUserControl.ascx" tagname="OrderProcessWebUserControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
    <span>购物车</span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div class="contentWrapperDiv cartContentWrapperDiv">
    <uc1:OrderProcessWebUserControl ID="OrderProcessWebUserControl1" runat="server" />
    <div class="cartContentDiv">
        <asp:Table ID="cartTable" runat="server" CellPadding="0" CellSpacing="0" ClientIDMode="Static">
            
        </asp:Table>
        <%--<table id="cartTable" cellpadding="0" cellspacing="0">
            <tr class="cartTitleTR">
                <th class="carTitleProductTH">商品</th>
                <th class="carTitleOtherTH">数量</th>
                <th class="carTitleOtherTH">Vneed价</th>
                <th class="carTitleOtherTH">操作</th>
            </tr>
            
            <tr class="cartContentTR">
                <td class="cartContentTD">
                    <div class="cartProductDiv">
                        <div class="cartProductImage">
                            <asp:Image ID="cartProductImage" runat="server" ImageUrl="~/Image/ItemImage/default.jpg" />
                        </div>
                        <div class="cartProductTitle"><span>新东方高考英语考前点题走读个性化</span></div>
                    </div>
                </td>
                <td class="cartContentTD">1</td>
                <td class="cartContentTD">$XXXX</td>
                <td class="cartContentTD"></td>
            </tr>
            <tr class="cartContentTR">
                <td class="cartContentTD">
                    <div class="cartProductDiv">
                        <div class="cartProductImage">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/ItemImage/default.jpg" />
                        </div>
                        <div class="cartProductTitle"><span>新东方高考英语考前点题走读个性化</span></div>
                    </div>
                </td>
                <td class="cartContentTD">1</td>
                <td class="cartContentTD">$XXXX</td>
                <td class="cartContentTD"></td>
            </tr>
            <tr class="cartContentTR">
                <td class="cartContentTD">
                    <div class="cartProductDiv">
                        <div class="cartProductImage">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/ItemImage/default.jpg" />
                        </div>
                        <div class="cartProductTitle"><span>新东方高考英语考前点题走读个性化</span></div>
                    </div>
                </td>
                <td class="cartContentTD">1</td>
                <td class="cartContentTD">$XXXX</td>
                <td class="cartContentTD"></td>
            </tr>
        </table>--%>
        <div class="cartClearingDiv">
            <div class="cartClearingPriceDiv">
                <span>合计:&nbsp</span>
                <span>$XXXX</span>
                <%--<asp:Label ID="TotalPriceLabel" runat="server" Text=""></asp:Label>--%>
            </div>
            <div class="cartClearingOptionDiv">
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="cartOptionLink" NavigateUrl="#">继续购物&gt</asp:HyperLink>
                <asp:Button ID="Button1" runat="server" Text="更新" CssClass="button cartOptionButton"/>
                <asp:Button ID="Button2" runat="server" Text="结算" CssClass="button cartOptionButton"/>
            </div>
        </div>
    </div>
</div>
</asp:Content>
