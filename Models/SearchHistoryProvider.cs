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
using NHibernate.Mapping.ByCode;

namespace myWebApplication.Models
{
	public class SearchHistoryProvider
	{
		public IEnumerable<SearchHistory> GetHistory()
		{
			var configuration = new Configuration();
			configuration.Configure();
			var mapper = new ModelMapper();
			mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
			HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
			configuration.AddMapping(mapping);

			ISessionFactory sessionFactory = configuration.BuildSessionFactory();
			using (ISession session = sessionFactory.OpenSession())
			{
				var searchHistory = session.CreateCriteria<SearchHistory>().List<SearchHistory>();
				return searchHistory;
			}
		}
	}
}