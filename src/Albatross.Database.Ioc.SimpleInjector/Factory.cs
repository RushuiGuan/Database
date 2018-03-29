﻿using SimpleInjector;
using System;

namespace Albatross.Database.Ioc.SimpleInjector {
	/// <summary>
	/// Use this factory class to locate the <see cref="Albatross.Database"/> interfaces.  This should only be used when the caller doesn't have an Ioc container.
	/// </summary>
	public class Factory {
		Container container = new Container();

		private Factory() {
			new SqlServerPackage().RegisterServices(container);
		}

		static readonly Lazy<Factory> lazy = new Lazy<Factory>(() => new Factory());

		public static T Create<T>() where T : class {
			return lazy.Value.container.GetInstance<T>();
		}
	}
}