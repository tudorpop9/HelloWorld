// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#addMemberButtonId").click(function () {
        var newcomerName = $("#nameInputId").val();

        $.ajax({
            method: "POST",
            url: "/Home/AddTeamMember",
            data: {
                "newTeammate": newcomerName
            },
            success: (result) => {
                $("#teamMembersList").append(`<li class="member">
                <span class="name">${newcomerName}</span>
                <span class="delete fa fa-remove"></span>
                <span class="edit fa fa-pencil"></span>
            </li>`);
                $("#nameInputId").val("");
            }
        })
    })
});