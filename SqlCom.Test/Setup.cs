using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Data;
using System.Data.SqlClient;

namespace SqlCom.Test
{

	[SetUpFixture]
	class Setup
	{
		public static string TestDbConnectionString
		{
			get;
			private set;
		}

		public static string[] TestDbConnectionStringEnumerable
			=> new string[] { TestDbConnectionString };

		[OneTimeSetUp]
		public static void SetUp()
		{

		}

		static Setup()
		{
			const string TestDb = "TestDb";
			const string AppSettingsFile = "appsettings.test.json";

			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile(AppSettingsFile, optional: true, reloadOnChange: true);

			IConfigurationRoot configuration = builder.Build();

			TestDbConnectionString = configuration.GetConnectionString(TestDb);

			//Assert.IsFalse(
			//	string.IsNullOrWhiteSpace(TestDbConnectionString),
			//	$@"Please add ConnectionStrings.{TestDb} to {AppSettingsFile}");
		}

		[OneTimeTearDown]
		public static void TearDown()
		{

		}
	}
}
