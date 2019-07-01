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
	[GuidAttribute("ADF0D549-D67B-4598-A15E-5B2333E35FB6")]
	public class SqlParameterCollectionCom : ServicedComponent
	{
		public SqlParameterCollection SqlParameterCollection { get; }

		public SqlParameterCollectionCom(SqlParameterCollection collection)
		{
			SqlParameterCollection = collection;
		}

		public SqlParameterCollectionCom()
		{
			// parameter-less constructor only available for COM interop
			throw new Exception($"{nameof(SqlParameterCollectionCom)} should not be initialized directly");
		}

		public SqlParameterCom AddParameter(SqlParameterCom parameter)
		{
			SqlParameterCollection.Add(parameter.SqlParameter);
			return parameter;
		}

		public SqlParameterCom Add(
			string parameterName = default,
			SqlDbType sqlDbType = default,
			int size = default,
			ParameterDirection direction = default,
			object value = default)
		{
			var newParamCom = new SqlParameterCom()
			{
				ParameterName = parameterName,
				SqlDbType = sqlDbType,
				Size = size,
				Direction = direction,
				Value = value
			};

			SqlParameterCollection.Add(newParamCom.SqlParameter);
			return newParamCom;
		}

		public void RemoveParameter(SqlParameterCom parameter) =>
			SqlParameterCollection.Remove(parameter.SqlParameter);

		public void RemoveAtName(string parameterName) =>
			SqlParameterCollection.RemoveAt(parameterName);

		public void RemoveAtIndex(int index) =>
			SqlParameterCollection.RemoveAt(index);
	}
}
