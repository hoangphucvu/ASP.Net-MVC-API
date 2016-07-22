$("#btnDelete").click(function () {
    var confirmMess = confirm('Are you sure ?');
    if (confirmMess) {
        var id = [];
        $.each($("input[name='employeeID']:checked"), function () {
            id.push($(this).val());
        });

        $.ajax({
            url: '/api/Employee/' + id,
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
        url: '/api/Employee/',
        type: 'POST',
        data: data
    })
    .error(function (data) {
        console.log(data);
        var validationResult = $.parseJSON(data.responseText);
        console.log(validationResult);
        var errors = {};
        for (var key in validationResult.ModelState) {
            errors[key.replace('employee.', '')] = validationResult.ModelState[key][0];
        }
        var validator = $('#addNewEmployeeForm').validate();
        validator.showErrors(errors);
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
        url: '/api/Employee/' + id,
        type: 'PUT',
        data: data
    })
    .error(function (data) {
        console.log(data);
        alert('Please check your input again');
        var validationResult = $.parseJSON(data.responseText);
        var errors = {};
        for (var key in validationResult.ModelState) {
            errors[key.replace('employee.', '')] = validationResult.ModelState[key][0];
        }
        var validator = $('#updateEmployeeForm').validate();
        validator.showErrors(errors);
    })
    .success(function () {
        alert("Update successful");
        location.reload();
    });
});