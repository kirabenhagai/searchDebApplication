using System;

namespace myWebApplication.Models
{
	public class SearchHistory
	{
		public virtual long Id { get; set; }
		public virtual DateTime Time { get; set; }
		public virtual string SearchTerm { get; set; }
	}
}