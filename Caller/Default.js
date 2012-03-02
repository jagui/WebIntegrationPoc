$(document).ready(function () {
    // Add the page method call as an onclick handler for the div.
    $("#Scan").click(function () {
        jQuery.support.cors = true;
        $.ajax({
            type: "GET",
            url: "http://localhost:2995/Service.svc/Scan",
            data: "{}",
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