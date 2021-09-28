using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientListenerLibrary
{
	internal class ClientSocket<T> : ClientListenerSocket
	{
		// Create connectionSocket for sending and receiving data
		public static void SendToSocket(string host, int port, string data)
		{
			try
			{
				IPEndPoint endpoint;


				byte[] buffer = Encoding.UTF8.GetBytes(data);

				using(Socket socket = new ConnectionSocket().CreateConnectionSocket(host, port, out endpoint))
				{
					socket.Connect(endpoint);
					if(socket == null) return;

					socket.Send(buffer);

					// Testing
					#region
					byte[] buffer2 = new byte[1024];
					if(socket.Receive(buffer2) > 0)
						Console.WriteLine (Encoding.UTF8.GetString(buffer2));
					#endregion
				}
			}
			catch(Exception e) {
				Console.WriteLine ("No connection Possible: " + e.ToString());
			}
		}
	}
}

