var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/order/getall' },
        "columns": [
            { data: 'id', "width": "13%" },
            { data: 'name', "width": "13%" },
            { data: 'phoneNumber', "width": "13%" },
            { data: 'applicationUser.email', "width": "13%" },
            { data: 'orderStatus', "width": "13%" },
            { data: 'orderTotal', "width": "13%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/admin/order/details?orderId=${data}" class="btn btn-primary mx-2">
                                        <i class="bi bi-pencil-square"></i>
                       
                        
                       
                    </div>`
                },
                "width": "22%",
            }
        ]
    });
}

