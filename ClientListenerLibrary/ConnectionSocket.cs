using System;
using System.Net.Sockets;
using System.Net;

namespace ClientListenerLibrary
{
	internal class ConnectionSocket : ClientListenerSocket
	{
		// Create socket and connect to it
		public Socket CreateConnectionSocket(string host, int port, out IPEndPoint endPoint)
		{
			Socket connectSocket = null;
			IPHostEntry hostEntry = Dns.GetHostEntry(host);
			endPoint = new IPEndPoint(hostEntry.AddressList [0], port);

			connectSocket = new Socket (endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

			return connectSocket;
		}
	}
}

