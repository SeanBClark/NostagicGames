$(document).ready(function () {
    $("#adminCode").hide();
    $("#btnUser").hide();
    $(".alert alert - danger").hide();
});

function showAdminCodeDiv() {
    $("#btnAdmin").hide();
    $("#adminCode").slideDown();
    $("#btnUser").show();
}

function hideAdminCodeDiv() {
    $("#btnAdmin").show();
    $("#adminCode").slideUp();
    $("#btnUser").hide();
}

function validateEmail($email) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test($email);
}

if (!validateEmail(emailaddress)) {

}