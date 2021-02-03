using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CSGORCON
{
	public partial class Form1 : Form
	{
		Regex ipregex = new Regex(@"^((?:(?:25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){3}(?:25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2}))(?:(?::)([0-9]{1,5})){0,1}$",
			RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);
		RconClient client;
		public delegate void AppendText(string text);
		AppendText textbox3del;

		public Form1()
		{
			InitializeComponent();
			textbox3del = new AppendText(textBoxLog.AppendText);
		}

		private void textBoxIP_TextChanged(object sender , EventArgs e)
		{
			var tb = sender as TextBox;
			Match match = ipregex.Match(tb.Text);
			if (match.Success)
			{
				if (match.Groups[2].Length!=0)
				{
					int port = int.Parse(match.Groups[2].Value);
					if (port < 65536)
						tb.BackColor = Color.Green;
					else tb.BackColor = System.Drawing.SystemColors.WindowFrame;
				}
				else tb.BackColor = Color.Green;
			}
			else tb.BackColor = System.Drawing.SystemColors.WindowFrame;
		}

		private void loginButton_Click(object sender, EventArgs e)
		{
			Match match = ipregex.Match(textBoxIP.Text);
			if (match.Success)
			{
				int port = 27015;
				if (match.Groups[2].Length != 0)
				{
					port = int.Parse(match.Groups[2].Value);
					port = port<65536? port :27015;
				}
				try { 
					client = new RconClient(match.Groups[1].Value, port);
					client.Auth(textBoxPassword.Text);
					client.RconPacketReceived += new EventHandler<RconPacket>(RconPacketReceived);
					client.StartRead();
					loggedpanel.Visible = true;
					loginPanel.Visible = false;
				}
				catch(System.Net.Sockets.SocketException err)
				{
					MessageBox.Show(err.Message);
				}
				
			}
		}
		private void RconPacketReceived(object client, RconPacket rconPacket)
		{
			if (rconPacket.Type == PacketType.SERVERDATA_AUTH_RESPONSE)
			{
				if (rconPacket.ID != -1)
					textBoxLog.Invoke(textbox3del,new object[] { "Logged in" + Environment.NewLine });
			}
			else if (rconPacket.Type == PacketType.SERVERDATA_RESPONSE_VALUE)
			{
				if(rconPacket.Body.Length>0)
					textBoxLog.Invoke(textbox3del,new object[] { rconPacket.Body + Environment.NewLine });
			}
		}
		private void sendCmdButton_Click(object sender, EventArgs e)
		{
			client.SendCommand(textBoxCommand.Text);
			textBoxCommand.Clear();
		}

		private void textBoxCommand_TextChanged(object sender, EventArgs e)
		{
			var textbox = sender as TextBox;
			var txt = textbox.Text.ToLower();
			if (txt.Length > 2)
			{
				textBoxCmdDesc.Clear();
				var commandsfiltered = CommandList.Commands.FindAll(command => command.command.StartsWith(txt));
				if (commandsfiltered.Count > 3)
				{
					string s = "";
					foreach (Command comm in commandsfiltered)
					{
						s += $"{comm.command} ";
					}
					textBoxCmdDesc.Text = s;
				}
				else
				{
					string s = "";
					foreach (Command comm in commandsfiltered)
					{
						if (comm.type == CommandType.cmd)
						{
							if (comm.description.Length != 0)
								s += $"{comm.command} ( {comm.description} ){Environment.NewLine}";
							else s += $"{comm.command}{Environment.NewLine}";
						}
						else
						{
							if (comm.description.Length != 0)
								s += $"{comm.command} {comm.defaultvalue} ( {comm.description} ){Environment.NewLine}";
							else s += $"{comm.command} {comm.defaultvalue}{Environment.NewLine}";
						}
					}
					textBoxCmdDesc.Text = s;
				}
			}
		}

		private void textBoxCommand_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				sendCmdButton.PerformClick();
				e.Handled = true;
			}
		}
	}
}
