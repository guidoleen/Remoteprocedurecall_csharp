using System;
using ClientListenerLibrary;

namespace InvoiceService
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Begin start socket server");
			var microService = new ClientListenerService<Object>()
				.AddServerActions(new TestActionHandler())
				.StartServer(host: "192.168.178.14", // localhost
							port: 1101,
							maxConnections: 10,
							IsCancelled: false)
				.Build();
		}

		public class TestActionHandler : IServerActionHandler
		{
			public object GetActionResult()
			{
				return "ThisIsAnTestActionResult";
			}
		}
	}
}

// /Users/guidoleen/Projects/InvoiceService/InvoiceService/bin/Debug