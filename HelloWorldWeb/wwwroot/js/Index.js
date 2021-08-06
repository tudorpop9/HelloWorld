// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {

    setDelete();

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

    $("#addMemberButtonId").click(function () {
        var newcomerName = $("#nameInputId").val();
        $.ajax({
            method: "GET",
            url: "/Home/GetTeamCount",

            success: (resultGet) => {
                $.ajax({
                    method: "POST",
                    url: "/Home/AddTeamMember",
                    data: {
                        "newTeammate": newcomerName
                    },
                    success: (resultPost) => {
                        $("#teamMembersList").append(
                            `<li class="member" id="${resultPost}">
                                <span class="name">${newcomerName}</span>
                                <span class="delete fa fa-remove" id="deleteMember"></span>
                                <span class="edit fa fa-pencil"></span>
                             </li>`);
                        $("#nameInputId").val("");
                        $('#addMemberButtonId').prop('disabled', true);
                        setDelete();
                    }
                })
            }
        });
    });

    $("#teamMembersList").on("click", ".edit", function () {
        var targetMemberTag = $(this).closest('li');

        var id = targetMemberTag.attr('id');

        var currentName = targetMemberTag.find(".name").text();

        $('#editClassmate').attr("member-id", id);
        $('#classmateName').val(currentName);
        $('#editClassmate').modal("show");

        
    })

    $("#editClassmate").on("click", "#submitEdit", function () {
        var targetMemberTag = $(this).closest('li');

        var memberId = $('#editClassmate').attr("member-id");
        var newName = $('#classmateName').val();

        $.ajax({
            method: "POST",
            url: "/Home/UpdateTeamMember",
            data: {
                "memberId": memberId,
                "memberName": newName
            },
            success: (resultPost) => {
                if (resultPost != -1) {
                    console.log('Update executed succesfuly ');
                    targetMemberTag.text(newName);
                }
            }
        })
        
    })


    $("#editClassmate").on("click", "#cancelEdit", function () {
        console.log('cancel changes');
    })


    

});

function setDelete() {
    $(".delete").off("click").click(function () {
        var id = $(this).parent().attr("id");

        $.ajax({
            method: "DELETE",
            url: "/Home/DeleteTeamMember",
            data: {
                "id": id
            },
            success: (result) => {
                $(this).parent().remove();
            }
        })
    }
    );
}