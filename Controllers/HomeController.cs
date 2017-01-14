﻿using System;
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
		public ApplicationSettings settings = new ApplicationSettings();
		public ProductProvider ProductProvider = new ProductProvider();
		public ProductSearchResultModel ProductSearchResultModel { get; set; }

		[Route("Index")]
		public ActionResult Index(string search="tv")
		{
			var query = new SearchQueryBuilder();

			ProductSearchResultModel = ProductProvider.SearchProducts(settings, search);

			return View();
		}

		[Route("Search")]
		public ActionResult Search(string query)
		{
			var searchModel = ProductProvider.SearchProducts(settings, query);
			var searchHistoryProvider = new SearchHistoryProvider();
			searchHistoryProvider.AddToHistory(query);
			return Json(searchModel.Products, JsonRequestBehavior.AllowGet);
		}

		[Route("Product")]
		public ActionResult Product(int product)
		{
			var query = new SearchQueryBuilder();

			var productResult = ProductProvider.GetProduct(product, settings);

			return View(productResult);
		}

		[Route("SearchHistoryList")]
		public ActionResult SearchHistoryList()
		{
			var searchHistoryProvider = new SearchHistoryProvider();

			var searchHistoryResult = searchHistoryProvider.GetHistory();

			return View(searchHistoryResult);
		}

		[Route("SearchHistory")]
		public ActionResult SearchHistory()
		{
			var searchHistoryProvider = new SearchHistoryProvider();

			var searchHistoryResult = searchHistoryProvider.GetHistory();

			return Json(searchHistoryResult.Histories, JsonRequestBehavior.AllowGet);
		}

	}
}