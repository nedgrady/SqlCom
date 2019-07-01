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
	[GuidAttribute("ADA0D549-D67B-4598-A15E-5B22A1E35FB6")]
	public class SqlConnectionCom : ServicedComponent
	{
		public SqlConnection SqlConnection { get; private set; } = new SqlConnection();

		public string ConnectionString
		{
			get => SqlConnection.ConnectionString;
			set => SqlConnection.ConnectionString = value;
		}
	}
}
