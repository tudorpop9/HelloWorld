// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#addMemberButtonId").click(function () {
        var newcomerName = $("#nameInputId").val();

        // Remember string interpolation
        $("#teamMembersList").append(`<li>${newcomerName}</li>`);

        $("#nameInputId").val("");
    })
});