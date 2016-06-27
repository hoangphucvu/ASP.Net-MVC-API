$(".detailsBtn").click(function () {
    var id = $(this).data('id');
    $.ajax({
        url: '/api/EmployeeApi/' + id,
        type: 'GET',
        data: { id: id }
    })
    .error(function () {
        alert("Internal error,please try again");
    })
    .success(function (data) {
        var gender;
        var dob = data.BirthDayShort;
        var startDate = data.StartDateShort;
        if (data.Gender) {
            gender = "Male";
        }
        else {
            gender = "Female";
        }
        $("#pageContent").html(
            '<div class="panel panel-primary"><div class="panel-heading">'+
            '<h3 class="panel-title">User Details</h3>'+
            '</div> <div class="panel-body"><p> Firstname: '
            + data.FirstName + '</p><p> Middle name: '
            + data.MiddleName + '</p><p> Lastname: '
            + data.LastName + '</p><p> Date of birth: '
            + dob + '</p><p> Gender: '
            + gender + '</p><p> Start date: '
            + startDate +
            '</p></div> </div>');
    });
});

$("#btnDelete").click(function () {
    var confirmMess = confirm('Are you sure ?');
    if (confirmMess) {
        var id = [];
        $.each($("input[name='employeeID']:checked"),function () {
            id.push($(this).val());
        });

        $.ajax({
            url: '/api/EmployeeApi/' + id,
            type: "DELETE",
            dataType: "json"
        })
        .error(function () {
            alert("Internal error please try again");
        })
        .success(function () {
            alert("Delete successful");
            location.reload();
        });
    }
    else {
        return false;
    }
});

$("#addNewEmployee").click(function () {
    var data = $("#addNewEmployeeForm").serialize();
    $.ajax({
        url: '/api/EmployeeApi/',
        type: 'POST',
        data: data,
    })
    .error(function() {
        alert("Internal error please try again");
    })
    .success(function () {
        alert("Add successful");
        location.reload();
    });
    
});
$("#updateEmployee").click(function () {
    var data = $("#updateEmployeeForm").serialize();
    var id = $("#employeeID").val();
    $.ajax({
        url: '/api/EmployeeApi/' + id,
        type: 'PUT',
        data: data,
    })
    .error(function () {
        alert("Internal error please try again");
    })
    .success(function () {
        alert("Update successful");
        location.reload();
    });

});

//$(document).ready(function () {
//    $('.date').datepicker({ dateFormat: "dd/mm/yy" });
//});