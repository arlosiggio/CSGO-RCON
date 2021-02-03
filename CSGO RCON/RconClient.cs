using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CSGORCON
{
	class RconClient
	{
		TcpClient client;
		NetworkStream stream;
		byte[] buff = new byte[4096];
		public event EventHandler<RconPacket> RconPacketReceived;
		public RconClient(string ip, int port)
		{
			client = new TcpClient(ip, port)
			{
				NoDelay = true
			};
			stream = client.GetStream();
		}
		private void SendPacket(RconPacket packet)
		{
			var arr = packet.getBytes();
			stream.Write(arr, 0, arr.Length);
			foreach(byte b in arr)
			{
				Console.Write(b);
			}
			Console.Write('\n');
		}
		public void Auth(string password)
		{
			RconPacket auth = new RconPacket(0, PacketType.SERVERDATA_AUTH, password);
			SendPacket(auth);
			
			/*
				if (authresponse.Type == PacketType.SERVERDATA_AUTH_RESPONSE && authresponse.ID != -1)
					return true;
				else return false;
			 */
		}
		public void SendCommand(string command)
		{
			SendPacket(new RconPacket(1, PacketType.SERVERDATA_EXECCOMMAND, command));
		}
		public void StartRead()
		{
			stream.BeginRead(buff, 0, 4, new AsyncCallback(ReadSizeCallback), this);
			
		}
		private static void ReadSizeCallback(IAsyncResult ar)
		{
			try
			{
				RconClient client = (RconClient)ar.AsyncState;
				client.stream.EndRead(ar);
				int size = BitConverter.ToInt32(client.buff, 0);
				client.stream.BeginRead(client.buff, 4, size, new AsyncCallback(ReadCallback), client);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
		private static void ReadCallback(IAsyncResult ar)
		{
			try
			{
				RconClient client = (RconClient)ar.AsyncState;
				client.stream.EndRead(ar);
				RconPacket packet = RconPacket.readFromBytes(client.buff);
				client.RconPacketReceived(client, packet);
				Console.WriteLine(packet.Body);
				client.buff = new byte[4096];
				client.stream.BeginRead(client.buff, 0, 4, new AsyncCallback(ReadSizeCallback), client);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
	}
}
