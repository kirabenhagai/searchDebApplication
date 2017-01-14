$(document).ready(function () {
	function search() {
		var query = $("#search-query").val();
		var results = $.getJSON("/Home/Search?query=" + encodeURI(query),
			function (data) {
				var items = [];
				$.each(data,
					function (key, val) {

						items.push('<div class="product-div">' +
								'<a href="./home/Product?product=' + val.Id + '" target="_blank">' +
									'<div class="product-properties"> <img class="some-name" src="' + val.ImageUrl +
										'" alt="" style="width: 190px; height: 190px">' +
										'<span><br>Name: ' +
										val.Name +
										'</span>' +
										'<span><br>Price: ' +
										val.Price +
										'</span></div></a></div>');
					});
				$('#search-result').html(items.join(""));
			}).error(function (err) {
				$('#search-result').html("Error occured while searching your results.");
			});
		return false;
	}

	$("#search-button").click(search);
	$("#search-query").keyup(function (event) {
		if (event.keyCode == 13) {
			$("#search-button").click();
		}
	});
	$("#search-query")
		.ready(function (event) {
			$.getJSON("/Home/SearchHistory", function (data) {
				var items = [];
				$.each(data,
					function (key, val) {
						var option = $('<option value="' + val.SearchTerm + '"></option>');
						$('#last-searches').append(option);
					});
			});
		});
});
