using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CS = SqlCom.Test.Configuration.ConnectionStrings;

namespace SqlCom.Test
{
	[TestClass]
	public class DbTests
	{

		[TestMethod]
		public async Task CanRunStoredProcAsync()
		{
			var connStr = CS.TestDb;

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

		[TestMethod]
		public async Task CanConnectAndDisconnectAsync()
		{
			var connStr = CS.TestDb;

			using (SqlConnection connection = new SqlConnection(connStr))
			{
				await connection.OpenAsync();

				Assert.IsTrue(connection.State == ConnectionState.Open, $"Couldn't connect to {connStr}.");

				connection.Close();
				Assert.IsTrue(connection.State == ConnectionState.Closed, $"Couldn't disconnect from {connStr}.");
			}
		}
	}
}
