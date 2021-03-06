# Albatross Database Schema Api

## Summary
A set of C# APIs that can read database schema metadata.

## Description
This repo contains a set of projects that reads metadata from a database server.  It defines C# objects that map to database objects such as table, view, stored procedure etc.  It also contains interfaces and implementations to retrieve those objects from the database.  For example, [IListTableColumn](xref:Albatross.Database.IListTableColumn) will return all [Column](xref:Albatross.Database.Column) defined by a database table.  [IListProcedureParameter](xref:Albatross.Database.IListProcedureParameter) will return all parameters defined by a stored procedure.

## Projects
* [Albatross.Database](xref:Albatross.Database) - Class and interface definition
* [Albatross.Database.SqlServer](xref:Albatross.Database.SqlServer) - Sql server implementation
* [Albatross.Database.SqlServer.SimpleInjector](xref:Albatross.Database.SqlServer.SimpleInjector) - Ioc using SimpleInjector
* [Albatross.Database.UnitTest](xref:Albatross.Database.UnitTest) - Unit test using NUnit

## How to use the Api
* Reference [Albatross.Database](xref:Albatross.Database), [Albatross.Database.SqlServer](xref:Albatross.Database.SqlServer) and [Albatross.Database.SqlServer.SimpleInjector](xref:Albatross.Database.SqlServer.SimpleInjector)
* Use the static Create method of the [Factory](xref:Albatross.Database.SqlServer.SimpleInjector.Factory) class to retrive and use the following interfaces.
	* [IGetProcedure](xref:Albatross.Database.IGetProcedure)
	* [IGetSqlType](xref:Albatross.Database.IGetSqlType)
	* [IGetTable](xref:Albatross.Database.IGetTable)
	* [IGetSqlType](xref:Albatross.Database.IGetSqlType)
	* [IGetTableColumnType](xref:Albatross.Database.IGetTableColumnType)
	* [IGetView](xref:Albatross.Database.IGetView)
	* [IListProcedureParameter](xref:Albatross.Database.IListProcedureParameter)
	* [IListSqlType](xref:Albatross.Database.IListSqlType)
	* [IListTableColumn](xref:Albatross.Database.IListTableColumn)
	* [IListTableIndex](xref:Albatross.Database.IListTableIndex)
	* [IListTableIndexColumn](xref:Albatross.Database.IListTableIndexColumn)
	
	```csharp
		/// getting interface using the Factory class.
		Database db = new Database {
			DataSource = "localhost",
			InitialCatalog = "DatabaseName",
			SSPI = true,
		};
		var handle = Albatross.Database.SqlServer.SimpleInjector.Factory.Create<Albatross.Database.IGetTable>();
		Table table = handle.Get(db, "dbo", "TableName");
	```
* If an Ioc container is used.
	* If the project is using SimpleInjector for Ioc, Reference [Albatross.Database.SqlServer.SimpleInjector](xref:Albatross.Database.SqlServer.SimpleInjector) and use class [Albatross.Database.SqlServer.SimpleInjector.Pack](xref:Albatross.Database.SqlServer.SimpleInjector.Pack) to register the container correctly.
	* If another container is used, register the interface in the [Albatross.Database](xref:Albatross.Database) and the implementation in [Albatross.Database.SqlServer](xref:Albatross.Database.SqlServer) manually.  Use the registration class [Albatross.Database.SqlServer.SimpleInjector.Pack](xref:Albatross.Database.SqlServer.SimpleInjector.Pack) as code sample.  There is no need to reference assembly [Albatross.Database.SqlServer.SimpleInjector](xref:Albatross.Database.SqlServer.SimpleInjector).
	* Once registered with a container, the interfaces can be used directly as dependencies.  No need to use the [Factory](xref:Albatross.Database.SqlServer.SimpleInjector.Factory) class.