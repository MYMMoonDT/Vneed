<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBarControl.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.V2.SearchBarControl" %>
<div class="searchBarContainer">
    <table>   
        <tr>
            <td>
                <asp:TextBox ID="SearchBarTextBox" runat="server" CssClass="searchBarText"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="SearchBarButton" runat="server" 
                    Text="搜索" 
                    CssClass="searchBarButton"
                    OnClientClick="return SearchBarControl.Validation();" 
                    onclick="SearchBarButton_Click"></asp:Button>
            </td>
        </table>
</div>
<script type="text/javascript">
    function SearchBarControl() {

    }
    SearchBarControl.Validation = function () {
        var parentID = "TopBarControl1_SearchBarControl1";
        var searchBarTextBoxID = "SearchBarTextBox";
        var searchBarTextBoxFullID = "#" + parentID + "_" + searchBarTextBoxID;
        if ($(searchBarTextBoxFullID).val() == "") {
            return false;
        }
        return true;
    };
</script>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
        var SearchBarControlInst = new SearchBarControl();
    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        var SearchBarControlInst = new SearchBarControl();
    });
</script>