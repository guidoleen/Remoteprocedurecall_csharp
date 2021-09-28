using System;

namespace ClientListenerLibrary
{
	public class ClientListenerService<T>
	{
		// SocketServer
		public ClientListenerService<T> StartServer(string host, int port, int maxConnections, bool IsCancelled)
		{
			ServerSocket.StartSocketServer (host, port, maxConnections, IsCancelled);
			return this;
		}

		public void StopServer()
		{
			ServerSocket.StopSocketServer ();
		}

		public ClientListenerService<T> AddServerActions(IServerActionHandler serverActionHandler)
		{
			ServerSocket.AddServerActions (serverActionHandler);
			return this;
		}

		// ClientSocket
		public ClientListenerService<T> SendTestBytes(string host, int port, string data = "TestActionHandler")
		{
			ClientSocket<T>.SendToSocket (host, port, data);
			return this;
		}

		public ClientListenerService<T> RecieveData(string host, int port, string data = "TestBytesAsAString")
		{
			ClientSocket<T>.SendToSocket (host, port, data);
			return this;
		}

		public ClientListenerService<T> Build()
		{
			Console.WriteLine (ServerSocket.ServerSocketExeption.ToString() ?? "Server started");
			return this;
		}
	}
}

