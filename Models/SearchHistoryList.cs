using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWebApplication.Models
{
	public class SearchHistoryList
	{
		public SearchHistoryList(IEnumerable<SearchHistory> histories)
		{
			this.Histories = histories;
		}
		public IEnumerable<SearchHistory> Histories { get; set; }
	}
}