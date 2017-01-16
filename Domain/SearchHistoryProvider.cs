using System;
using NHibernate;
using NHibernate.Criterion;

namespace myWebApplication.Domain
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