$(document).ready(function () {
    $("#leftAreaTabsDiv").children().click(function () {
        leftAreaTabsClick(this.id);
    });
});
function leftAreaTabsClick(tabId) {
    tabId = "#" + tabId;
    var tabIdContent = tabId + "Content";
    $(tabId).removeClass("tabItem").addClass("tabItemSelected");
    $(tabId).siblings().removeClass("tabItemSelected").addClass("tabItem");
    $(tabIdContent).show();
    $(tabIdContent).siblings().hide();
}