$(document).ready(function () {
    var table = $('#SupplierTable').DataTable({
        "columnDefs": [{
            "orderable": false,
            "targets": 2
        }],
        "ajax": loadSupplier(),
        "responsive": true
    });
});
function ClearScreen() {
    $('#Id').val('');
    $('#suppliername').val('');
    $('#joindate').val('');
    $('#Update').hide();
    $('#Save').show();
}
function loadSupplier() {
    $.ajax({
        url: "/Suppliers/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            debugger;
            var html = '';
            $.each(result, function (key, Supplier) {
                joinDate = moment(Supplier.joinDate).format('DD MMMM YYYY');
                html += '<tr>';
                html += '<td>' + Supplier.name + '</td>';
                html += '<td>' + joinDate + '</td>';
                html += '<td><a href="#" class="fa fa-pencil" data-toggle="tooltip" title="Edit" id="Update" onclick="return GetbyId(' + Supplier.id + ')"></a> |';
                html += ' <a href="#" class="fa fa-trash" data-toggle="tooltip" title="Delete" id="Delete" onclick="return Delete(' + Supplier.id + ')" ></button ></td > ';
                html += '</tr>';
                html += '</tr>';
                html += '</tr>';
            });
            $('.supplierbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Save() {
    var Supplier = new Object();
    Supplier.id = $('#Id').val();
    Supplier.name = $('#suppliername').val();
    Supplier.joinDate = $('#joindate').val();
    $.ajax({
        type: 'POST',
        url: '/Suppliers/InsertOrUpdate/',
        data: Supplier
    }).then((result) => {
        //debugger;
        if (result.statusCode == 200) {
            Swal.fire({
                position: 'center',
                type: 'success',
                title: 'Insert Successfully'
            });
            //ResetTable();
            window.location.href = "/Suppliers";
        }
        else {
            Swal.fire('Error', 'Insert Fail', 'error');
            ClearScreen();
        }
    });
}
function GetbyId(id) {
    debugger;
    $.ajax({
        url: "/Suppliers/GetbyId",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        data: { id: id },
        success: function (result) {
            debugger;
            $('#Id').val(result.id);
            $('#suppliername').val(result.name);
            $('#joindate').val(result.joinDate);
            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function Update() {
    debugger;
    var data = new Object();
    data.id = $('#Id').val();
    data.name = $('#suppliername').val();
    data.joinDate = $('#joindate').val();
    $.ajax({
        url: "/Suppliers/InsertOrUpdate/",
        data: data
    }).then((result) => {
        debugger;
        $('#myModal').hide();
        if (result.statusCode == 200) {
            Swal.fire({
                position: 'center',
                type: 'success',
                title: 'Update Successfully',
                showConfirmButton: false,
                timer: 1500
            });
            window.location.href = "/Suppliers";
        }
        else {
            Swal.fire('Error', 'Update Fail', 'error');
            ClearScreen();
        }
    });
}
function Delete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            //debugger;
            $.ajax({
                url: "/Suppliers/Delete/",
                type: "Get",
                //contentType: "application/json;charset=UTF-8",
                dataType: "json",
                data: { id: id },
            }).then((result) => {
                debugger;
                if (result.statusCode == 200) {
                    Swal.fire({
                        position: 'center',
                        type: 'success',
                        title: 'Delete Successfully'
                    });
                    window.location.href = "/Suppliers";
                }
                else {
                    Swal.fire('Error', 'Failed to Delete', 'error');
                    ClearScreen();
                }
            });
        }
    });
}