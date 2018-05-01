﻿using Albatross.Database;
using System.Management.Automation;

namespace Albatross.Database.PowerShell {

	[Cmdlet(VerbsCommon.New, "Table")]
	public class NewTable : Cmdlet {

		[Parameter(Position = 0, Mandatory = true)]
		public string Name { get; set; }

		[Parameter(Position = 1, Mandatory = true)]
		public string Schema { get; set; }

		public Albatross.Database.Database Database { get; set; }


		protected override void ProcessRecord() {
			var table = new Table {
				Name = Name,
				Schema = Schema,
				Database = Database,
			};
			WriteObject(table);
		}
	}
}