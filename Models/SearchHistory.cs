﻿using System;

namespace KirasShop.Models
{
	public class SearchHistory
	{
		public Guid Id { get; set; }
		public DateTime Time { get; set; }
		public string SearchTerm { get; set; }
	}
}