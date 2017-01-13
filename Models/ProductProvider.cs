using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using myWebApplication.Api.Products;
using myWebApplication.Api.Search;
using myWebApplication.Domain;
using Newtonsoft.Json;

namespace myWebApplication.Models
{
	public class ProductProvider
	{
		public ProductSearchResultModel SearchProducts(string inputSearchString, SearchQueryBuilder searchQueryBuilder)
		{
			using (WebClient client = new WebClient())
			{
				var json = client.DownloadString(searchQueryBuilder.GetSearchUri(inputSearchString));
				return JsonConvert.DeserializeObject<ProductSearchResultModel>(json);
			}
		}

		public ProductModel GetProduct(int productId, SearchQueryBuilder searchQueryBuilder)
		{
			using (WebClient client = new WebClient())
			{
				var json = client.DownloadString(searchQueryBuilder.GetProductUrl(productId));
				var list = JsonConvert.DeserializeObject<IList<ProductModel>>(json);
				return list.Single();
			}
		}
	}
}