// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#addMemberButtonId").click(function () {
        var newcomerName = $("#nameInputId").val();

        $.ajax({
            method: "POST",
            url: "https://localhost:44337/Home/AddTeamMember",
            data: {
                "newTeammate": newcomerName
            },
            success: (result) => {
                $("#teamMembersList").append(`<li>${newcomerName}</li>`);
                $("#nameInputId").val("");
            }
        })
    })
});