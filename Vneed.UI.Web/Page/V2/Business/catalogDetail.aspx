<%@ Page Title="" Language="C#" MasterPageFile="~/Template/SubTitleTemplate.master" AutoEventWireup="true" CodeBehind="catalogDetail.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.Business.catalogDetail" %>
<%@ Register src="../../../WebUserControl/V2/CatalogListControl.ascx" tagname="CatalogListControl" tagprefix="uc1" %>
<%@ Register src="../../../WebUserControl/V2/CatalogFilterControl.ascx" tagname="CatalogFilterControl" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
    <title>分类</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subHeadLeft" runat="server">
    <asp:Label ID="catalogDetailSubTitleLabel" runat="server" Text="" CssClass="subTitleFont"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subHeadRight" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="catalogDetailPageBg" class="contentBg">
        <div id="catalogDetailPageContentContainer" class="contentContainer">
            <div id="catalogDetailSideContentContainer">
                <div class="sideTabTitleContainer">
                    <div class="tabItemSelected">分类</div>
                </div>
                <div class="sideTabContentContainer">
                        <uc1:CatalogListControl ID="CatalogListControl1" runat="server" />
                </div>
            </div>
            <div id="catalogDetailMainContentContainer">
                <div class="catalogDetailMainContent">
                    <uc2:CatalogFilterControl ID="CatalogFilterControl1" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
