using System;
using System.Collections.Generic;
using System.ComponentModel;
using myWebApplication.Api.Products;
using Newtonsoft.Json;

namespace myWebApplication.Api.Search
{
	public class ProductSearchResultModel
	{
		[Description("Total products count")]
		public long Count { get; private set; }
//		[Description("Search result facets. will be present only if requested via the metadata parameter. the List of Facets depends on the search results. for each result there can be different facets")]
//		public IList<FacetModel> Facets { get; set; }
		[Description("Products matching the search request")]
		public IList<ProductModel> Products { get; set; }
	}
}