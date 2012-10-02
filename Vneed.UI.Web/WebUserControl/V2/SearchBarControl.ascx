<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBarControl.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.V2.SearchBarControl" %>
<div class="searchBarContainer">
    <table>   
        <tr>
            <td>
                <asp:TextBox ID="SearchBarTextBox" runat="server" CssClass="searchBarText"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="SearchBarButton" runat="server" Text="搜索" CssClass="searchBarButton"></asp:Button>
            </td>
        <tr>
    </table>
</div>