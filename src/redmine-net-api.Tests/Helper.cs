﻿using System.Configuration;

namespace redmine.net.api.Tests
{
	internal static class Helper
	{
		public static string Uri { get; private set; }

		public static string ApiKey { get; private set; }

		public static string Username { get; private set; }

		public static string Password { get; private set; }

		static Helper()
		{
			
		}
	}
}

