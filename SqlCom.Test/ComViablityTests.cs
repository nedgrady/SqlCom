using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CS = SqlCom.Test.Configuration.ConnectionStrings;
using System.Diagnostics;
using SqlCom;

namespace SqlCom.Test
{
	[TestClass]
	public class ComViablityTests
	{
		[TestMethod]
		public void Test()
		{
			// Get the directory for RegSvcs.exe, e.g. C:\Windows\Microsoft.NET\Framework\v4.0.30319
			var frameworkDir = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();

			var startInfo = new ProcessStartInfo
			{
				FileName = frameworkDir + "RegSvcs.exe",
				Arguments  = "SqlCom.dll",
				Verb = "runas",
				RedirectStandardOutput = true,
				CreateNoWindow = true,
				UseShellExecute  = false
			};

			var process = Process.Start(startInfo);
			var output = process.StandardOutput.ReadToEnd();

			process.WaitForExit();

			Assert.AreEqual(process.ExitCode, 0, $"RegSvcs.exe reported the following errors:\n{output}");
		}
	}
}
