using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using myWebApplication.Configurations;

namespace myWebApplication.Models
{
	public class UriProvider
	{
		public Uri GetSearchUri(string search, ApplicationSettings settings)
		{

			//		public Uri GetSearchUri(string userSearch)
			//		{
			//			Query = userSearch;
			//			return new Uri($"{SearchApiUrl}?q={userSearch}&limit=20&token={Token}&hash={Hash}");
			//		}
			//
			//		public Uri GetProductUrl(int productId)
			//		{
			//			return new Uri($"{_settings.GetProductUrl}?ids={productId}&token={Token}&hash={Hash}");
			//		}

			var debug = $"{settings.SearchApiUrl}?q={search}&limit=20&token={settings.AppToken}&hash={settings.AppHash}";
			return new Uri($"{settings.SearchApiUrl}?q={search}&limit=20&token={settings.AppToken}&hash={settings.AppHash}");
		}

		public Uri GetProductUrl(int productId, ApplicationSettings settings)
		{
			return new Uri($"{settings.GetProductUrl}?ids={productId}&token={settings.AppToken}&hash={settings.AppHash}");
		}
	}
}