<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CatalogFilterControl.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.V2.CatalogFilterControl" %>
<div id="catalogFilterControlContainer">
    <div class="catalogFilterContentSelectContainer">
        <asp:DropDownList ID="DropDownListAttributeA" runat="server" 
            AutoPostBack="true" 
            onselectedindexchanged="DropDownListAttributeA_SelectedIndexChanged"
            CssClass="catalogFilterContentSelector">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListAttributeB" runat="server" 
            AutoPostBack="true" 
            onselectedindexchanged="DropDownListAttributeB_SelectedIndexChanged"
            CssClass="catalogFilterContentSelector">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListAttributeC" runat="server" 
            AutoPostBack="true" 
            onselectedindexchanged="DropDownListAttributeC_SelectedIndexChanged"
            CssClass="catalogFilterContentSelector">
        </asp:DropDownList>
    </div>
    <asp:Panel ID="catalogFilterContentResultContainerPanel" runat="server" CssClass="catalogFilterContentResultContainer">
    
    </asp:Panel>
    <asp:Panel ID="catalogFilterPageLinkContainerPanel" runat="server" CssClass="catalogFilterPageLinkContainer">
    </asp:Panel>
    <%--<div class="catalogFilterContentResultContainer">
        <table>
        <tr>
            <td>
                <div class="catalogFilterResultItemContainer">
                    <div class="catalogFilterResultItemImgContainer"></div>
                    <div class="catalogFilterResultItemTextContainer">
                        <div class="catalogFilterResultItemTitleContainer">
                            
                        </div>
                    </div>
                </div>
            </td>
            <td>
                <div class="catalogFilterResultItemContainer">
                    <div class="catalogFilterResultItemImgContainer"></div>
                    <div class="catalogFilterResultItemTextContainer">
                        <div class="catalogFilterResultItemTitleContainer">
                            
                        </div>
                    </div>
                </div>
            </td>
            <td>
                <div class="catalogFilterResultItemContainer">
                    <div class="catalogFilterResultItemImgContainer"></div>
                    <div class="catalogFilterResultItemTextContainer">
                        <div class="catalogFilterResultItemTitleContainer">
                            
                        </div>
                    </div>
                </div>
            </td>
            <td>
                <div class="catalogFilterResultItemContainer">
                    <div class="catalogFilterResultItemImgContainer"></div>
                    <div class="catalogFilterResultItemTextContainer">
                        <div class="catalogFilterResultItemTitleContainer">
                            
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        </table>
    </div>--%>
</div>