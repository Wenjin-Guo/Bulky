var dataTable;
$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    }
    else {
        if (url.includes("completed")){
            loadDataTable("completed");
        }
        else {
            if (url.includes("pending")) {
                loadDataTable("pending");
            }
            else {
                if (url.includes("approved")) {
                    loadDataTable("approved");
                }
                else {
                    loadDataTable("all");
                }
            }
        }
        
    }
    
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/order/getall?status='+status },
        "columns": [
            { data: 'id', "width": "3%" },
            { data: 'name', "width": "18%" },
            { data: 'phoneNumber', "width": "18%" },
            { data: 'applicationUser.email', "width": "23%" },
            { data: 'orderStatus', "width": "13%" },
            { data: 'orderTotal', "width": "13%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/admin/order/details?orderId=${data}" class="btn btn-primary mx-2">
                                        <i class="bi bi-pencil-square"></i>
                        </a>
                       
                        
                       
                    </div>`
                },
                "width": "12%",
            }
        ]
    });
}

