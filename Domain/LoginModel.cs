using System;
using System.Collections.Generic;
using myWebApplication.Api.Products;
using myWebApplication.Api.Search;

namespace myWebApplication.Domain
{
	public class LoginModel
	{
		public long AppId { get; set; }
		public string Token { get; set; }
		public string Hash { get; set; }
		public Uri SecureApiUrl { get; set; }

		public List<ProductModel> ProductModel { get; set; }
		public List<ProductSearchResultModel> SearchModel { get; set; }

//		public Uri GetProductsUrl()
//		{
//			return new Uri(SecureApiUrl, $"/products/get?ids=194623649,48634108&token={Token}&hash={Hash}");
//		}


	}
}