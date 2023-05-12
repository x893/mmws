using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RSTD
{

	internal class RemoteManager
	{



		public List<LuaExportedOperations> RemoteObjects
		{
			get
			{
				return this.m_RemoteObjects;
			}
			set
			{
				this.m_RemoteObjects = value;
			}
		}


		public RemoteManager()
		{
			this.m_RemoteObjects = new List<LuaExportedOperations>();
			this.m_ListenPorts = new List<int>();
		}


		public bool RegisterServer(int port)
		{
			try
			{
				ChannelServices.RegisterChannel(new TcpServerChannel("RtttChannel" + ChannelServices.RegisteredChannels.Length, port), false);
				RemotingConfiguration.RegisterWellKnownServiceType(typeof(LuaExportedOperations), "RtttRemoting", WellKnownObjectMode.Singleton);
				this.m_ListenPorts.Add(port);
			}
			catch (Exception ex)
			{
				GuiCore.AlwaysPrint(ex.Message + "\n");
				return false;
			}
			return true;
		}


		public bool RegisterClient(string ip_address, int port, string table_name)
		{
			if (!this.IsAddressValid(ip_address, port))
			{
				return false;
			}
			try
			{
				string text = string.Format("tcp://{0}:{1}/RtttRemoting", ip_address, port);
				LuaExportedOperations luaExportedOperations = (LuaExportedOperations)Activator.GetObject(typeof(LuaExportedOperations), text);
				this.m_RemoteObjects.Add(luaExportedOperations);
				LuaWrapperUtils.LuaWrapper.RegisterLuaFunctions(table_name, luaExportedOperations, "Module For running Rttt functions remotely on " + text);
				LuaWrapperUtils.LuaWrapper.LuaVM.DoString(string.Format("{0}.ip = '{1}'; {0}.port = {2}", table_name, ip_address, port));
			}
			catch (Exception ex)
			{
				GuiCore.AlwaysPrint(ex.Message + "\n");
				return false;
			}
			return true;
		}


		private bool IsAddressValid(string ip, int port)
		{
			try
			{
				IPAddress[] hostAddresses = Dns.GetHostAddresses(ip);
				IPAddress[] hostAddresses2 = Dns.GetHostAddresses(Dns.GetHostName());
				if (this.m_ListenPorts.Contains(port))
				{
					foreach (IPAddress ipaddress in hostAddresses)
					{
						if (IPAddress.IsLoopback(ipaddress))
						{
							GuiCore.AlwaysPrint("Can't connect to self\n");
							return false;
						}
						foreach (IPAddress obj in hostAddresses2)
						{
							if (ipaddress.Equals(obj))
							{
								GuiCore.AlwaysPrint("Can't connect to self\n");
								return false;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				GuiCore.AlwaysPrint(ex.Message + "\n");
				return false;
			}
			return true;
		}


		private List<LuaExportedOperations> m_RemoteObjects;


		private List<int> m_ListenPorts;
	}
}
