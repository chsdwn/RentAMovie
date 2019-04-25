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

    $("#newRental").submit(function (e) {
        e.preventDefault();

        $.ajax({
            url: "/api/newRentals",
            method: "post",
            data: viewModel
        })
        .done(function () {
            console.log("done");
        })
        .fail(function () {
            console.log("fail");
        });
    });
});