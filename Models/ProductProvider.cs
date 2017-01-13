using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using myWebApplication.Api.Products;
using myWebApplication.Api.Search;
using myWebApplication.Configurations;
using myWebApplication.Domain;
using Newtonsoft.Json;

namespace myWebApplication.Models
{
	public class ProductProvider
	{
		UriProvider uriProvider = new UriProvider();
		public ProductSearchResultModel SearchProducts(ApplicationSettings settings, string search)
		{
			using (WebClient client = new WebClient())
			{
				var json = client.DownloadString(uriProvider.GetSearchUri(search, settings));
				return JsonConvert.DeserializeObject<ProductSearchResultModel>(json);
			}
		}

		public ProductModel GetProduct(int productId, ApplicationSettings settings)
		{
			using (WebClient client = new WebClient())
			{
				var json = client.DownloadString(uriProvider.GetProductUrl(productId, settings));
				var list = JsonConvert.DeserializeObject<IList<ProductModel>>(json);
				return list.Single();
			}
		}
	}
}