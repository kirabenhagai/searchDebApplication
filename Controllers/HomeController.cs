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
using myWebApplication.Models;

namespace myWebApplication.Controllers
{
	public class HomeController : Controller
	{
		public LoginModel LoginModel { get; set; }

		public ProductProvider ProductProvider = new ProductProvider();
		[Route("Index")]
		public ActionResult Index(string search="tv")
		{
			var query = new SearchQueryBuilder();

			query.SearchModel = ProductProvider.SearchProducts(search, query);

			return View(query);
		}

		[Route("Search")]
		public ActionResult Search(string query)
		{
			var searchQueryBuilder = new SearchQueryBuilder();

			var searchModel = ProductProvider.SearchProducts(query, searchQueryBuilder);
			return Json(searchModel.Products, JsonRequestBehavior.AllowGet);
		}

		[Route("Product")]
		public ActionResult Product(int product)
		{
			var query = new SearchQueryBuilder();

			var productResult = ProductProvider.GetProduct(product, query);

			return View(productResult);
		}

	}
}