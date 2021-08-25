// This JS file now uses jQuery. Pls see here: https://jquery.com/
'use strict';
$(document).ready(function () {

    var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();
    setDelete();

    connection.start().then(function () {
        console.log("signalr connected");
    });
    connection.on("NewTeamMemberAdded", createNewcomer);
    connection.on("DeleteTeamMember", deleteMember);
    connection.on("UpdatedTeamMember", updateMember);

   

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
            method: "POST",
            url: "/Home/AddTeamMember",
            data: {
                "newTeammate": newcomerName
            },
        })
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
        })
    }
    );
}

function createNewcomer(name, id) {
    // Remember string interpolation in js: `text ${variable}`
    $("#teamMembersList").append(
        `<li class="member" id="${id}">
                <span class="name">${name}</span>
                <span class="delete fa fa-remove" id="deleteMember"></span>
                <span class="edit fa fa-pencil"></span>
         </li>`);

    $("#nameInputId").val("");
    $('#addMemberButtonId').prop('disabled', true);
    setDelete();
}

var deleteMember = (id) => {
    $(`li[id=${id}]`).remove();
};

var updateMember = (id, name) => {
    $(`li[id=${id}]`).find(".name").text(name);
}