using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SqlCom
{
	[GuidAttribute("ADF0D549-D67B-4598-A15E-5B22C1E35FB6")]
	public class SqlCommandCom : ServicedComponent
	{
		public SqlCommand SqlCommand { get; private set; } = new SqlCommand()
		{
			CommandType = CommandType.StoredProcedure
		};

		public string CommandText
		{
			get => SqlCommand.CommandText;
			set => SqlCommand.CommandText = value;
		}

		public int CommandTimeout
		{
			get => SqlCommand.CommandTimeout;
			set => SqlCommand.CommandTimeout = value;
		}

		public CommandType CommandType
		{
			get => SqlCommand.CommandType;
			set => SqlCommand.CommandType = value;
		}


		public SqlConnectionCom SqlConnection
		{
			set
			{
				SqlCommand.Connection = value.SqlConnection;
			}
		}

		public void Execute()
		{
			SqlCommand.Connection.Open();

			using (SqlCommand.ExecuteReader())
			{
			}
		}

		public void Add(SqlScalarParameterCom parameterCom) => SqlCommand.Parameters.Add(parameterCom.SqlParameter);

	}
}
