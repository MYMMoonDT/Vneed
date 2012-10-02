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
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="catalogListBox">
                            <asp:ListItem>Test</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="catalogListBox"></asp:DropDownList>
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="catalogListBox"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <%--<div id="mainAreaDiv">
        	<div id="mainAreaContentDiv">
            	
                <div id="leftAreaDiv">
                	<div id="leftAreaTabsDiv">
                        <div id="classTab" class="tabItemSelected">
                        	<span>分类</span>
                        </div>
                    </div>
                    <div id="dividerDiv2"></div>
                    <div id="leftAreaContentDiv">
                        
                    </div>
                </div>

                <div id="rightAreaDiv">
                	<div id="dividerDiv3"></div>
                    <div id="rightAreaContentDiv">
                    	<div id="rightAreaItemContainer">                
                            
                        </div>
                    </div>
                </div>

            </div>
        </div>--%>

    </div>
</asp:Content>
