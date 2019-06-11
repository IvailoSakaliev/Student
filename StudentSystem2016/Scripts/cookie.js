$(document).ready(function () {
    if (sessionStorage.getItem('cookie') != "true") {
        $(".notificationForCookies").css("display", "block");
    }
    else {
        $(".notificationForCookies").css("display", "none");
    }

    $("#closeCookieWindowNotification").click(function () {
        $(".notificationForCookies").fadeOut(400);
        $(".notificationForCookies").css("display", "none");
        sessionStorage.setItem("cookie", "true");
    });
});