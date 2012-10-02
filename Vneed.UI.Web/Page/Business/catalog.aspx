<%@ Page Title="" Language="C#" MasterPageFile="~/Template/Template4.master" AutoEventWireup="true" CodeBehind="catalog.aspx.cs" Inherits="Vneed.UI.Web.Page.Business.catalog" %>
<%@ Register src="../../WebUserControl/CatalogList.ascx" tagname="CatalogList" tagprefix="uc1" %>
<%@ Register src="../../WebUserControl/FilterList.ascx" tagname="FilterList" tagprefix="uc2" %>
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
                <div class="catalogMainAreaLeftContentDiv">
                    <uc1:CatalogList ID="CatalogList1" runat="server" />
                </div>
            </div>
            <div class="catalogMainAreaRightDiv">
                <div class="catalogMainAreaRightContentDiv">
                    <uc2:FilterList ID="FilterList1" runat="server" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>
