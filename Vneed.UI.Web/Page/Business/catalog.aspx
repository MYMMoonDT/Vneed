<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template4.master" AutoEventWireup="true" CodeBehind="catalog.aspx.cs" Inherits="Vneed.UI.Web.Page.Business.catalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="server">
    <asp:Label ID="CatalogContentLabel" runat="server" Text="培训课"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="contentWrapperDiv catalogContentWrapperDiv">
        <div class="catalogMainAreaDiv">
            <div class="catalogMainAreaLeftDiv">
                <div class="catalogMainAreaLeftTabsDiv">
                    <div class="tabItemSelected">
                        <span>分类</span>
                    </div>
                </div>
                <div class="catalogMainAreaLeftContentDiv"></div>
            </div>
            <div class="catalogMainAreaRightDiv">
                <div class="catalogMainAreaRightContentDiv">
                    <div class="catalogMainAreaRightContentSelectDiv">
                        <div class="dropdownListBox">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
