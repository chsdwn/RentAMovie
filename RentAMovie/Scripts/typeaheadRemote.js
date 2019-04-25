$(document).ready(function () {
    var viewModel = {
        movieIds: []
    };

    var customers = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/customers?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    var movies = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/movies?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#customer').typeahead({
        minLength: 3,
        highlight: true
    }, {
        name: 'customers',
        display: 'name',
        source: customers
    }).on("typeahead:select", function (e, customer) {
        viewModel.customerId = customer.id;
    });

    $('#movie').typeahead({
        minLength: 3,
        highlight: true
    }, {
        name: 'movies',
        display: 'name',
        source: movies
    }).on("typeahead:select", function (e, movie) {
        $("#movies").append("<li class='list-group-item'>" + movie.name + "</li>");
        $("#movie").typeahead("val", "");
        viewModel.movieIds.push(movie.id);
    });

    $.validator.addMethod("validCustomer", function () {
        return viewModel.customerId && viewModel.customerId !== 0;  
    }, "Please select a valid customer.");

    $.validator.addMethod("atLeastOneMovie", function () {
        return viewModel.movieIds.length > 0;
    }, "Please select at least one movie.");

    var validator = $("#newRental").validate({
        submitHander: function () {
            $.ajax({
                url: "/api/newRentals",
                method: "post",
                data: viewModel
            })
            .done(function () {
                toastr.success("Rentals successfully recorded.");

                // Clear form
                $("#customer").typeahead("val", "");
                $("#movie").typeahead("val", "");
                $("#movies").empty();

                viewModel = { movieIds =[] };

                validator.resetForm();
            })
            .fail(function () {
                toastr.error("Rentals successfully failed.");
            });

            return false;
        }
    });
});