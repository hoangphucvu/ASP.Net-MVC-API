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
        var dob = new Date(data.DOB);
        var startDate = new Date(data.StartDate);
        if (data.Gender) {
            gender = "Male";
        }
        else {
            gender = "Female";
        }
        $("#pageContent").html('<div class="panel panel-primary"><div class="panel-heading"><h3 class="panel-title">User Details</h3> </div> <div class="panel-body"><p> Firstname: '
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
        var id = new Array();
        $("input:checked").each(function () {
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

