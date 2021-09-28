using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ClientListenerLibrary
{
	internal class ServerSocket : ClientListenerSocket
	{
		public static Exception ServerSocketExeption;
		private static Socket _socketServer;
		private static bool _isCancelled = false;
		private static Dictionary<string, IServerActionHandler> _serverActions = new Dictionary<string, IServerActionHandler>();

		// Start server as a socket listener
		public static void StartSocketServer(string host, int port, int maxConnections, bool isCancelled)
		{
			_isCancelled = isCancelled;

			try
			{
				IPEndPoint endPoint;
				_socketServer = new ConnectionSocket().CreateConnectionSocket(host, port, out endPoint);
				_socketServer.Bind (endPoint);
				_socketServer.Listen (maxConnections);

				while(true && !_isCancelled)
				{
					Socket clientSocketHandler = _socketServer.Accept();
					Task.Run(() => { new ServerSocket().HandleClientSocket(clientSocketHandler); });
				}
			}
			catch(Exception e) 
			{
				ServerSocketExeption = e;
			}
		}

		// SocketHandler for receiving and sending data
		private void HandleClientSocket(Socket clientSocketHandler)
		{
			byte[] buffer = new byte[BufferSize];

			if(clientSocketHandler.Receive(buffer) > 0)
			{
				var serverActionHandlerName = Encoding.UTF8.GetString(buffer);
				if(_serverActions.ContainsKey(serverActionHandlerName))
				{
					// Testing
					#region 
					Console.WriteLine (serverActionHandlerName);
					#endregion

					var serverActionHandler = (IServerActionHandler)_serverActions[serverActionHandlerName];
					clientSocketHandler.Send(Encoding.UTF8.GetBytes(serverActionHandler.GetActionResult ().ToString()));
				}
			}
			clientSocketHandler.Close ();
		}

		// Stop server
		public static void StopSocketServer()
		{
			_isCancelled = true;
		}

		// Inject server action handlers
		public static void AddServerActions(IServerActionHandler serverActionHandler)
		{
			_serverActions.Add (serverActionHandler.GetType().Name.ToString(), serverActionHandler);
		}
	}
}

