﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albatross.Database {
	public class Database {
		public string DataSource { get; set; }
		public string InitialCatalog { get; set; }
		public bool SSPI { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }

		public string ConnectionString { get; set; }
	}
}
