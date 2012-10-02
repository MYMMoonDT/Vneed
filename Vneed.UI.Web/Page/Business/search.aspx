<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template4.master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Vneed.UI.Web.Page.Business.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
    <asp:Label ID="SearchContentLabel" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="contentWrapperDiv searchContentWrapperDiv">
        <table id="searchResultTable" class="searchResultTable" cellpadding="0" cellspacing="0">
            <tr class="searchResultTitleTR">
                <th class="searchResultTitleProductTH">商品名称</th>
                <th class="searchResultTitleDescriptionTH">商品简介</th>
                <th class="searchResultTitlePriceTH">Vneed价</th>  
            </tr>
            <tr class="searchResultContentTR">
                <td class="searchResultContentTD">
                    <div class="searchResultProductDiv">
                        <div class="searchResultProductImageDiv">
                            <asp:Image ID="searchResultProductImage" runat="server" ImageUrl="~/Image/ItemImage/default.jpg" />
                        </div>
                        <div class="searchResultProductTitleDiv"><span>个性前点题走读个性化</span></div>
                    </div>
                </td>
                <td class="searchResultContentTD">这是一个神奇的商品这是一个神奇的商品这是一个神奇的商品这是一个神奇的商品</td>
                <td class="searchResultContentTD">￥XXX</td>
            </tr>
        </table>
    </div>
</asp:Content>
