var movies = new Bloodhound({
    datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
    queryTokenizer: Bloodhound.tokenizers.whitespace,
    remote: {
    url: '/api/movies?query=%QUERY',
    wildcard: '%QUERY'
    }
});

$('#movie').typeahead({
    minLength: 3,
    highlight: true
    }, {
    name: 'movies',
    display: 'name',
    source: movies
    }).on("typeahead:select", function (e, movie) {
});