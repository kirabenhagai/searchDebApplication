using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Criterion;
using NHibernate.Mapping.ByCode;

namespace myWebApplication.Models
{
	public class SearchHistoryProvider
	{
		public SearchHistoryList GetHistory()
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				var searchHistory = session.CreateCriteria<SearchHistory>().AddOrder(Order.Desc("Time")).SetMaxResults(5).List<SearchHistory>();
				return new SearchHistoryList(searchHistory);
			}
		}

		public void AddToHistory(string query)
		{
			using (ISession session = NHibernateHelper.OpenSession())
			{
				using (ITransaction trans = session.BeginTransaction())
				{
					var searchHistory = new SearchHistory() {SearchTerm = query, Time = DateTime.Now};
					session.SaveOrUpdate(searchHistory);
					trans.Commit();
				}
			}
		}
	}
}