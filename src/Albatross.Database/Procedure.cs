﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Albatross.Database
{
    public class Procedure
    {
		public Database Database { get; set; }

		public string Name { get; set; }
		public string Schema{ get; set; }

		public IEnumerable<Variable> Parameters { get; set; }
	}
}
