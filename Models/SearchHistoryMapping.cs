using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode.Conformist;

namespace myWebApplication.Models
{
	public class SearchHistoryMapping : ClassMapping<SearchHistory>
	{
			public SearchHistoryMapping()
			{
				this.Table("search_history");
				this.Id(p => p.Id, map => map.Column("id"));
				this.Property(p => p.Time, map => map.Column("time"));
				this.Property(p => p.SearchTerm, map => map.Column("search_term"));
			}
	}
}