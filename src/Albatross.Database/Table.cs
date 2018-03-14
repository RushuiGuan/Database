﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database
{
    public class Table {
		public Server Server { get; set; }
		public string Name { get; set; }
		public string Schema { get; set; }

		public IEnumerable<Column> Columns { get; set; }
	}
}
