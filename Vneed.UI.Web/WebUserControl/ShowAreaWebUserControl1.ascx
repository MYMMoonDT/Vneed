<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowAreaWebUserControl1.ascx.cs" Inherits="Vneed.UI.Web.WebUserControl.ShowAreaWebUserControl1" %>
<link href="../Resource/CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(document).ready(function () {
        (function () {

        })();
        $("#showAreaLeftButtonDiv").click(function () {
            showAreaMovePic("left");
        });
        $("#showAreaRightButtonDiv").click(function () {
            showAreaMovePic("right");
        });
        function showAreaMovePic(type) {
            if (type == "left") {
                alert("left");
            } else {
                alert("right");
            }
        }
    });
</script>
<div id="showAreaDiv">
    <div id="showAreaContentDiv">
        <div id="showAreaLeftButtonDiv"></div>
        <div id="showAreaRightButtonDiv"></div>
        <div id="showAreaPicsDiv">
            <div id="showAreaLeftPicDiv"></div>
            <div id="showAreaCenterPicDiv"></div>
            <div id="showAreaRightPicDiv"></div>
        </div>
        <div id="showAreaBottomButtonsDiv">
            <div id="showAreaBottomLeftButtonDiv"></div>
            <div id="showAreaBottomCenterButtonDiv"></div>
            <div id="showAreaBottomRightButtonDiv"></div>
        </div>
    </div>
</div>