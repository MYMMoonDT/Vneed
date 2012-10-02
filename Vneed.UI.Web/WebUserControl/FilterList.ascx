<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilterList.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.FilterList" %>

<div class="catalogMainAreaRightContentSelectDiv">
<asp:DropDownList ID="DropDownListAttributeA" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownListAttributeA_SelectedIndexChanged">
</asp:DropDownList>
<asp:DropDownList ID="DropDownListAttributeB" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownListAttributeA_SelectedIndexChanged">
</asp:DropDownList>
<asp:DropDownList ID="DropDownListAttributeC" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownListAttributeA_SelectedIndexChanged">
</asp:DropDownList>
</div>

<p>
    <asp:Table ID="Table" runat="server">
    </asp:Table>
</p>


