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
function loadSupplier() {
    $.ajax({
        url: "/Suppliers/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            //debugger;
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