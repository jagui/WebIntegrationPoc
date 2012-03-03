$(document).ready(function () {
    jQuery.support.cors = true;

    // Add the page method call as an onclick handler for the div.
    $("#Scan").click(function () {
        var json = '{"context":"' + $("#Context").val() + '"}';
        $.ajax({
            type: "POST",
            url: "http://localhost:2996/Service.svc/Scan",
            data: json,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            error: function (xhr, status) {
                $("#Result").val(xhr.statusText);
            },
            success: function (msg) {
                // Replace the div's content with the page method's return.
                $("#Result").val(msg.d);
            }
        });
    });
});