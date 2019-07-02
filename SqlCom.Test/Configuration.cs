using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SqlCom.Test
{
	static class Configuration
	{
		public static class ConnectionStrings
		{
			public static string TestDb { get; } = ConfigurationManager.ConnectionStrings[nameof(TestDb)].ConnectionString;
		}
	}
}
