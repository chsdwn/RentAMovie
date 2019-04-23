$(document).ready(function () {
    $("#customers").DataTable({
        ajax: {
            url: "/api/customers",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, customer) {
                    return "<a href='/customers/edit/" + customer.id + "'>" + customer.name + "</a>";
                }
            },
            {
                data: "name"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn btn-link js-delete' data-customer-id=" + data + ">Delete</button>";
                }
            }
        ]
    });

    $("#customers").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm({
            message: "Are you sure you want to delete this customer?",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result) {
                    $.ajax({
                        url: "/api/customers/" + button.attr("data-customer-id"),
                        method: "DELETE",
                        success: function () {
                            button.parents("tr").remove();
                        }
                    });
                }
            }
        });
    });
});