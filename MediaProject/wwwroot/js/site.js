var dataTable;
const uriMedia = 'api/mediaType';

$(document).ready(function () {
    GetInformation();
    dataTable = GetDataTable();
});

function GetDataTable() {
    return $('#bootstrap-table').DataTable({
        "pagingType": "full_numbers",
        "columnDefs": [
            { "orderable": false, "targets": [0, 2] }
        ],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.19/i18n/Russian.json"
        }
    });
}

$("form").submit(function(e) {
    e.preventDefault();
    var format = this.elements["format"].value;
    GetInformation(format);
});


function GetInformation(foramt) {
    var format = foramt === undefined ? "application/json" : foramt;
    $.ajax({
        type: 'GET',
        url: uriMedia,
        contentType: format,
        success: function (data) {
            dataTable.clear().draw();
            $.each(data,
                function (key, item) {
                    var rData = [
                        item.mediaType,
                        item.lastUpdate,
                        item.deleted
                    ];
                    dataTable.row.add(rData).draw().node().id = item.id;
                });
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
}