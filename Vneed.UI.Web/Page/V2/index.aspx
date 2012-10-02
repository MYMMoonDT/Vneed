<%@ Page Title="" Language="C#" MasterPageFile="~/Template/HomeTemplate.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Vneed.UI.Web.Page.V2.index" %>
<%@ Register src="../../WebUserControl/V2/ProductImageShow.ascx" tagname="ProductImageShow" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>首页</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:ProductImageShow ID="ProductImageShow1" runat="server" />
    <div id="indexContentBg" class="contentBg">
        <div id="indexContentContainer" class="contentContainer">
            <div id="indexSideContentContainer">
                <div class="sideTabTitleContainer">
                    <div class="tabItemSelected">排行</div>
                    <div class="tabItem">分类</div>
                </div>
                <div class="sideTabContentContainer">
                
                </div>
            </div>
            <div id="indexMainContentContainer">
                <div class="indexMainContent">
                
                </div>
            </div>
        </div>
    </div>
</asp:Content>
