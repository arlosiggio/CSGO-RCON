using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace CSGORCON
{
	public enum PacketType: int
	{
		SERVERDATA_AUTH = 3,
		SERVERDATA_AUTH_RESPONSE = 2,
		SERVERDATA_EXECCOMMAND = 2,
		SERVERDATA_RESPONSE_VALUE = 0
	}
	class RconPacket
	{
		public int Size, ID;
		public PacketType Type;
		public string Body;
		private char End;
		public RconPacket(int ID, PacketType type, string body)
		{
			this.ID = ID;
			this.Type = type;
			this.Body = body;
			this.Size = body.Length + 10;
			this.End = '\0';
		}
		public byte[] getBytes()
		{
			byte[] bytes = new byte[Size + 4];
			BitConverter.GetBytes(Size).CopyTo(bytes, 0);
			BitConverter.GetBytes(ID).CopyTo(bytes, 4);
			BitConverter.GetBytes((int)Type).CopyTo(bytes, 8);
			Encoding.UTF8.GetBytes(Body).CopyTo(bytes, 12);
			BitConverter.GetBytes(End).CopyTo(bytes, Size+2);
			return bytes;
		}
		public static RconPacket readFromBytes(byte[] array)
		{
			int size = BitConverter.ToInt32(array, 0);
			int id = BitConverter.ToInt32(array, 4);
			int packettype = BitConverter.ToInt32(array, 8);
			string body = "";
			if(size-2 > 8)
				body = Encoding.UTF8.GetString(array, 12, size - 10);
			return new RconPacket(id, (PacketType)packettype, body);
		}
	}
}
