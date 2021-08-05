// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    $('#nameInputId').on('input change', function () {
        if ($(this).val() != '') {
            $('#addMemberButtonId').prop('disabled', false);
        } else {
            $('#addMemberButtonId').prop('disabled', true);
        }
    });

    $("#clearButton").click(function () {
        $("#nameInputId").val("");
        $('#addMemberButtonId').prop('disabled', true);
    });

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
                $("#teamMembersList").append(
                `<li class="member">
                    <span class="name">${newcomerName}</span>
                    <span class="delete fa fa-remove"></span>
                    <span class="edit fa fa-pencil"></span>
                </li>`
                );
                $("#nameInputId").val("");
                $('#addMemberButtonId').prop('disabled', true);
            }
        })
    })

   
   
});