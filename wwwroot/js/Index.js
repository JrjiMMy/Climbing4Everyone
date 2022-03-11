var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/route/GetShared",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "routeName", "width": "20%" },
            { "data": "routeDifficulty", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/RouteList/Details?id=${data}" class='btn btn-info text-white' style='cursor:pointer; width:70px;'>
                            Details
                        </a>
                        &nbsp;
                    </div>`
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}