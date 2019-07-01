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
	[GuidAttribute("ADF0D549-D84B-4598-A15E-5B22C1E35FB6")]
	public class SqlParameterCom : ServicedComponent
	{
		public SqlParameter SqlParameter { get; private set; } = new SqlParameter();


		public object Value
		{
			get => SqlParameter.Value;
			set => SqlParameter.Value = value;
		}

		public SqlDbType SqlDbType
		{
			get => SqlParameter.SqlDbType;
			set => SqlParameter.SqlDbType = value;
		}

		public ParameterDirection Direction
		{
			get => SqlParameter.Direction;
			set => SqlParameter.Direction = value;
		}

		public int Size
		{
			get => SqlParameter.Size;
			set => SqlParameter.Size = value;
		}

		public string ParameterName
		{
			get => SqlParameter.ParameterName;
			set => SqlParameter.ParameterName = value;
		}
	}
}
