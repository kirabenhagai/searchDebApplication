using System;
using System.Collections.Generic;
using System.Security.Policy;
using myWebApplication.Api.Search;
using myWebApplication.Configurations;

namespace myWebApplication.Domain
{
	public class SearchQueryBuilder
	{
		public Uri SearchApiUrl { get; }
		public int Limit { get; }
		public string Token { get; }
		public string Hash { get; }
		public string Query { get; set; }

		private ApplicationSettings _settings = new ApplicationSettings();

		public SearchQueryBuilder()
		{
			SearchApiUrl = _settings.SearchApiUrl;
			Limit = _settings.Limit;
			Token = _settings.AppToken;
			Hash = _settings.AppHash;
		}

		public Uri GetSearchUri(string userSearch)
		{
			Query = userSearch;
			return new Uri($"{SearchApiUrl}?q={userSearch}&limit=20&token={Token}&hash={Hash}");
		}

		public Uri GetProductUrl(int productId)
		{
			return new Uri($"{_settings.GetProductUrl}?ids={productId}&token={Token}&hash={Hash}");
		}

		public ProductSearchResultModel SearchModel { get; set; }
	}
}