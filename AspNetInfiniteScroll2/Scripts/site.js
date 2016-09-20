var pageSize = 10;
var pageIndex = 0;

$(document).ready(function () {
    GetData();

    $(window).scroll(function () {
        if ($(window).scrollTop() ===
            $(document).height() - $(window).height()) {
            GetData();
        }
    });
});

function GetData() {
    $.ajax({
        type: 'GET',
        url: '/home/GetData',
        data: { "pageindex": pageIndex, "pagesize": pageSize },
        dataType: 'json',
        success: function (data) {
            if (data != null) {
                for (var i = 0; i < data.length; i++) {
                    $("#container").append("<h2>" + data[i].CompanyName + "</h2>");
                }
                pageIndex++;
            }
        },
        beforeSend: function () {
            $("#progress").show();
        },
        complete: function () {
            $("#progress").hide();
        },
        error: function () {
            alert("Error while retrieving data.");
        }
    });
}