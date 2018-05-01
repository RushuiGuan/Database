﻿using SimpleInjector;
using System.Management.Automation;

namespace Albatross.Database.PowerShell {

	[Cmdlet(VerbsCommon.Get, "Table")]
	public class GetTable : PSCmdlet {
		const string DefaultServer = "localhost";
		const string ByName = "ByName";
		const string ByObject = "ByObject";

		[Parameter(Position = 0)]
		public string Criteria { get; set; }

		[Parameter(Position = 1, Mandatory = true, ParameterSetName = ByName)]
		public string DbName { get; set; }

		[Parameter(Position = 1, Mandatory = false, ParameterSetName = ByName)]
		public string Server { get; set; }

		[Parameter(Position = 2, ValueFromPipeline = true, Mandatory = true, ParameterSetName = ByObject)]
		public Database Database { get; set; }

		protected override void BeginProcessing() {
			base.BeginProcessing();
			new AssemblyRediret().Register<Container>();
		}

		protected override void ProcessRecord() {
			Database db;

			if (base.ParameterSetName == ByName) {
				db = new Database {
					SSPI = true,
					DataSource = DefaultServer,
					InitialCatalog = DbName,
				};
			} else {
				db = Database;
			}

			var items = Ioc.Get<IListTable>().Get(db, Criteria);
			foreach (var item in items) {
				WriteObject(item);
			}
		}
	}
}
