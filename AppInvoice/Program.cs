using System;
using ClientListenerLibrary;

namespace AppInvoice
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Start send bytes");

			Console.WriteLine ("Send Bytes");

			new ClientListenerService<Object> ()
				.SendTestBytes (host: "192.168.178.14",
					port: 1101);

			while (true) {
			}
		}
	}
}

// /Users/guidoleen/Projects/InvoiceService/AppInvoice/bin/Debug
// mono-sgen ./AppInvoice.exe