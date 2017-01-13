using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using myWebApplication.Configurations;
using System.Net;
using Newtonsoft.Json;
using myWebApplication.Api.Products;
using myWebApplication.Api.Search;
using myWebApplication.Domain;

namespace myWebApplication.Controllers
{
	public class HomeController : Controller
	{
		public LoginModel LoginModel { get; set; }

		[Route("Index")]
		public ActionResult Index(string search="tv")
		{
			var query = new SearchQueryBuilder();

			query.SearchModel = SearchProducts(search, query);

			return View(query);
		}

		[Route("Search")]
		public ActionResult Search(string query)
		{
			var searchQueryBuilder = new SearchQueryBuilder();

			var searchModel = SearchProducts(query, searchQueryBuilder);
			return Json(searchModel.Products, JsonRequestBehavior.AllowGet);
		}

		private ProductSearchResultModel SearchProducts(string inputSearchString, SearchQueryBuilder searchQueryBuilder)
		{
			using (WebClient client = new WebClient())
			{
				var json = client.DownloadString(searchQueryBuilder.GetSearchUri(inputSearchString));
				return JsonConvert.DeserializeObject<ProductSearchResultModel>(json);
			}
		}

		private ProductModel GetProduct(int productId, SearchQueryBuilder searchQueryBuilder)
		{
			using (WebClient client = new WebClient())
			{
				var json = client.DownloadString(searchQueryBuilder.GetProductUrl(productId));
				var list = JsonConvert.DeserializeObject<IList<ProductModel>>(json);
				return list.Single();
			}
		}

		[Route("Product")]
		public ActionResult Product(int product)
		{
			var query = new SearchQueryBuilder();

			var productResult = GetProduct(product, query);

			return View(productResult);
		}

	}
}