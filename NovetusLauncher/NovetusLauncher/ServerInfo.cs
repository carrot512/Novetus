﻿/*
 * Created by SharpDevelop.
 * User: BITL
 * Date: 5/14/2017
 * Time: 9:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;

namespace NovetusLauncher
{
	/// <summary>
	/// Description of ServerInfo.
	/// </summary>
	public partial class ServerInfo : Form
	{
		public ServerInfo()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ServerInfoLoad(object sender, EventArgs e)
		{
        	textBox1.AppendText("Client: " + GlobalVars.SelectedClient);
        	textBox1.AppendText(Environment.NewLine);
        	textBox1.AppendText("IP: " + GetExternalIPAddress());
        	textBox1.AppendText("Port: " + GlobalVars.RobloxPort.ToString());
        	textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText("Map: " + GlobalVars.Map);
        	textBox1.AppendText(Environment.NewLine);
        	textBox1.AppendText("Players: " + GlobalVars.PlayerLimit);
        	textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText("Version: Novetus " + GlobalVars.Version);
			textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText(Environment.NewLine);
			string[] lines = { 
				SecurityFuncs.Base64Encode(GetExternalIPAddress()),
				SecurityFuncs.Base64Encode(GlobalVars.RobloxPort.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.SelectedClient)
			};
			string URI = "novetus://" + SecurityFuncs.Base64Encode(string.Join("|",lines));
			textBox1.AppendText("Online URI Link:");
			textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText(URI);
			textBox1.AppendText(Environment.NewLine);
			string[] lines2 = { 
				SecurityFuncs.Base64Encode("localhost"),
				SecurityFuncs.Base64Encode(GlobalVars.RobloxPort.ToString()),
				SecurityFuncs.Base64Encode(GlobalVars.SelectedClient)
			};
			string URI2 = "novetus://" + SecurityFuncs.Base64Encode(string.Join("|",lines2));
			textBox1.AppendText("Local URI Link:");
			textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText(URI2);			
		}
		
		string GetExternalIPAddress()
		{
    		string ipAddress;
			using (WebClient wc = new WebClient())
			{
				try
  				{
    				ipAddress = wc.DownloadString("http://icanhazip.com/");
  				}
				catch (Exception)
  				{
    				ipAddress = "localhost" + Environment.NewLine;
  				}
			}

    		return ipAddress;
		}
	}
}
