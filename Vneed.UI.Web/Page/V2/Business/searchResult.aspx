<%@ Page Title="" Language="C#" MasterPageFile="~/Template/SubTitleTemplate.master" AutoEventWireup="true" CodeBehind="searchResult.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.Business.searchResult" %>
<%@ Register src="../../../WebUserControl/V2/SearchResultControl.ascx" tagname="SearchResultControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
    <title>搜索结果</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="subHeadLeft" runat="server">
    <asp:Label ID="searchResultSubTitleLabel" runat="server" Text="" CssClass="subTitleFont"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subHeadRight" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="contentBg">
        <div id="searchResultContentContainer" class="contentContainer"> 
            <uc1:SearchResultControl ID="SearchResultControl1" runat="server" />
        </div>
        <div class="searchResultBottomDivider"></div>
    </div>
</asp:Content>
