using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace SqlCom.Test
{
	
	class DbTests
	{
		[TestCaseSource(typeof(Setup), nameof(Setup.TestDbConnectionStringEnumerable))]
		public static async Task CanConnectAndDisconnect(string connStr)
		{
			using (SqlConnection connection = new SqlConnection(connStr))
			{
				await connection.OpenAsync();

				Assert.IsTrue(connection.State == ConnectionState.Open, $"Couldn't connect to {connStr}.");

				connection.Close();
				Assert.IsTrue(connection.State == ConnectionState.Closed, $"Couldn't disconnect from {connStr}.");
			}
		}

		[TestCaseSource(typeof(Setup), nameof(Setup.TestDbConnectionStringEnumerable))]
		public static async Task CanRunStoredProc(string connStr)
		{
			using (SqlConnection connection = new SqlConnection(connStr))
			using (SqlCommand command = new SqlCommand("sp_who2", connection)
			{
				CommandType = CommandType.StoredProcedure
			})
			{
				await connection.OpenAsync();
				var result = await command.ExecuteReaderAsync();
				Assert.IsTrue(result.HasRows);
			}

		}
	}
}
