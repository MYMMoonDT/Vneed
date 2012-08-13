function EndRequestHandler2() {
    $("#RegisterNameTextBox").focus(function () {
        if ($("#RegisterNameTextBox").val() == "用户名")
            $("#RegisterNameTextBox").val("");
    }).blur(function () {
        if ($("#RegisterNameTextBox").val() == "")
            $("#RegisterNameTextBox").val("用户名");
    });
    $("#RegisterPasswordTextBox").focus(function () {
        if ($("#RegisterPasswordTextBox").val() == "设置密码") {
            $("#RegisterPasswordTextBox").val("");
            document.getElementById("RegisterPasswordTextBox").type = "password";
        }
    }).blur(function () {
        if ($("#RegisterPasswordTextBox").val() == "") {
            $("#RegisterPasswordTextBox").val("设置密码");
            document.getElementById("RegisterPasswordTextBox").type = "text";
        }
    });
    $("#RegisterPasswordAgainTextBox").focus(function () {
        if ($("#RegisterPasswordAgainTextBox").val() == "重复一遍密码") {
            $("#RegisterPasswordAgainTextBox").val("");
            document.getElementById("RegisterPasswordAgainTextBox").type = "password";
        }
    }).blur(function () {
        if ($("#RegisterPasswordAgainTextBox").val() == "") {
            $("#RegisterPasswordAgainTextBox").val("重复一遍密码");
            document.getElementById("RegisterPasswordAgainTextBox").type = "text";
        }
    });
    $("#RegisterEmailTextBox").focus(function () {
        if ($("#RegisterEmailTextBox").val() == "邮箱")
            $("#RegisterEmailTextBox").val("");
    }).blur(function () {
        if ($("#RegisterEmailTextBox").val() == "")
            $("#RegisterEmailTextBox").val("邮箱");
    });
}
function RegisterValidationFunc() {
    $("#registerNameError").html("");
    $("#registerPasswordError").html("");
    $("#registerPassword2Error").html("");
    $("#registerEmailError").html("");
    if ($("#RegisterNameTextBox").val() == "" || $("#RegisterNameTextBox").val() == "用户名") {
        $("#registerNameError").html("<div class='error'>请输入用户名</div>");
        return false;
    }
    if ($("#RegisterNameTextBox").val().length < 6 || $("#RegisterNameTextBox").val().length > 16) {
        $("#registerNameError").html("<div class='error'>用户名长度必须在6~16个字符之间</div>");
        return false;
    }
    if ($("#RegisterPasswordTextBox").val() == "" || $("#RegisterPasswordTextBox").val() == "设置密码") {
        $("#registerPasswordError").html("<div class='error'>请输入密码</div>");
        return false;
    }
    if ($("#RegisterPasswordTextBox").val().length < 6 || $("#RegisterPasswordTextBox").val().length > 16) {
        $("#registerPasswordError").html("<div class='error'>密码长度必须在6~16个字符之间</div>");
        return false;
    }
    if ($("#RegisterPasswordAgainTextBox").val() == "" || $("#RegisterPasswordAgainTextBox").val() == "重复一遍密码") {
        $("#registerPassword2Error").html("<div class='error'>请输入密码</div>");
        return false;
    }
    if ($("#RegisterPasswordAgainTextBox").val() != $("#RegisterPasswordTextBox").val()) {
        $("#registerPassword2Error").html("<div class='error'>两次密码不一致</div>");
        return false;
    }
    if ($("#RegisterEmailTextBox").val() == "" || $("#RegisterEmailTextBox").val() == "邮箱") {
        $("#registerEmailError").html("<div class='error'>请输入电子邮箱地址</div>");
        return false;
    }
    if (!$("#RegisterEmailTextBox").val().match(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/)) {
        $("#registerEmailError").html("<div class='error'>请输入正确的邮箱地址</div>");
        return false;
    }
}

$(document).ready(function () {
    $("#RegisterNameTextBox").focus(function () {
        if ($("#RegisterNameTextBox").val() == "用户名")
            $("#RegisterNameTextBox").val("");
    }).blur(function () {
        if ($("#RegisterNameTextBox").val() == "")
            $("#RegisterNameTextBox").val("用户名");
    });
    $("#RegisterPasswordTextBox").focus(function () {
        if ($("#RegisterPasswordTextBox").val() == "设置密码") {
            $("#RegisterPasswordTextBox").val("");
            document.getElementById("RegisterPasswordTextBox").type = "password";
        }
    }).blur(function () {
        if ($("#RegisterPasswordTextBox").val() == "") {
            $("#RegisterPasswordTextBox").val("设置密码");
            document.getElementById("RegisterPasswordTextBox").type = "text";
        }
    });
    $("#RegisterPasswordAgainTextBox").focus(function () {
        if ($("#RegisterPasswordAgainTextBox").val() == "重复一遍密码") {
            $("#RegisterPasswordAgainTextBox").val("");
            document.getElementById("RegisterPasswordAgainTextBox").type = "password";
        }
    }).blur(function () {
        if ($("#RegisterPasswordAgainTextBox").val() == "") {
            $("#RegisterPasswordAgainTextBox").val("重复一遍密码");
            document.getElementById("RegisterPasswordAgainTextBox").type = "text";
        }
    });
    $("#RegisterEmailTextBox").focus(function () {
        if ($("#RegisterEmailTextBox").val() == "邮箱")
            $("#RegisterEmailTextBox").val("");
    }).blur(function () {
        if ($("#RegisterEmailTextBox").val() == "")
            $("#RegisterEmailTextBox").val("邮箱");
    });
});
        
    