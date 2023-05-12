using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using LuaInterface;
using RstdNet;

namespace RSTD
{

	public class RstdServer
	{



		public event ServerEventHandler StateChanged;



		internal ServerState State
		{
			get
			{
				return this.m_State;
			}
		}



		public string ClientIP
		{
			get
			{
				if (this.m_socWorker != null)
				{
					return ((IPEndPoint)this.m_socWorker.RemoteEndPoint).ToString();
				}
				return null;
			}
		}



		public int Port
		{
			get
			{
				return this.m_Port;
			}
		}


		public RstdServer(int port)
		{
			this.m_State = ServerState.Disconnected;
			this.m_Port = port;
		}


		public void OnClientConnect(IAsyncResult asyn)
		{
			try
			{
				this.m_socWorker = this.m_socListener.EndAccept(asyn);
				this.iUpdateState(ServerState.Connected);
				this.WaitForData(this.m_socWorker);
			}
			catch (ObjectDisposedException)
			{
				GuiCore.AlwaysPrint("OnClientConnection: Socket has been closed\n");
			}
			catch (SocketException se)
			{
				this.iHandleRemoteDisconnect(se);
			}
		}


		public void OnDataReceived(IAsyncResult asyn)
		{
			try
			{
				CSocketPacket csocketPacket = (CSocketPacket)asyn.AsyncState;
				string lua_err = "";
				int num = csocketPacket.thisSocket.EndReceive(asyn);
				if (num > 0)
				{
					RstdNetObject rstdNetObject = new RstdNetObject();
					rstdNetObject = rstdNetObject.DeSerialize(csocketPacket.dataBuffer, num);
					object[] res_arr;
					int lua_res = this.iExecuteNetCmdSafe(rstdNetObject, out res_arr, out lua_err);
					this.iSendNetRes(lua_res, res_arr, lua_err);
					if (!this.IsConnected())
					{
						this.ResetConnection();
					}
					else
					{
						this.WaitForData(this.m_socWorker);
					}
				}
				else
				{
					this.ResetConnection();
				}
			}
			catch (ObjectDisposedException)
			{
				GuiCore.ErrorMessage("OnDataReceived: Socket has been closed\n");
			}
			catch (SocketException se)
			{
				this.iHandleRemoteDisconnect(se);
			}
			catch (Exception ex)
			{
				GuiCore.ErrorMessage(string.Format("OnDataReceived: {0}\nStack:\n{1}\n", ex.Message, ex.StackTrace));
			}
		}


		public int OpenConnection()
		{
			int result;
			try
			{
				this.m_socListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				IPEndPoint localEP = new IPEndPoint(IPAddress.Any, this.m_Port);
				this.m_socListener.Bind(localEP);
				this.m_socListener.Listen(int.MaxValue);
				this.ResetConnection();
				result = 0;
			}
			catch (SocketException ex)
			{
				GuiCore.ErrorMessage(string.Format("In RstdServer: {0}\n", ex.Message));
				result = 1;
			}
			return result;
		}


		private void iUpdateState(ServerState state)
		{
			this.m_State = state;
			if (this.StateChanged != null)
			{
				this.StateChanged(this, new ServerEventArgs(this.m_State));
			}
		}


		public void WaitForData(Socket soc)
		{
			try
			{
				if (this.IsConnected())
				{
					if (this.pfnWorkerCallBack == null)
					{
						this.pfnWorkerCallBack = new AsyncCallback(this.OnDataReceived);
					}
					CSocketPacket csocketPacket = new CSocketPacket();
					csocketPacket.thisSocket = soc;
					soc.BeginReceive(csocketPacket.dataBuffer, 0, csocketPacket.dataBuffer.Length, SocketFlags.None, this.pfnWorkerCallBack, csocketPacket);
				}
			}
			catch (SocketException se)
			{
				this.iHandleRemoteDisconnect(se);
			}
		}


		private void iResizeBuffer(ref byte[] buffer)
		{
			byte[] array = new byte[buffer.Length * 2];
			Array.Copy(buffer, array, buffer.Length);
			buffer = array;
		}


		private int iExecuteNetCmdSafe(RstdNetObject net_cmd, out object[] res_arr, out string lua_err)
		{
			int result = -1;
			res_arr = null;
			lua_err = "";
			if (Monitor.TryEnter(RstdServer.SyncObject, RstdServer.SyncTimeout))
			{
				try
				{
					return this.iExecuteNetCmd(net_cmd, out res_arr, out lua_err);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					Monitor.Exit(RstdServer.SyncObject);
				}
			}
			result = -2;
			lua_err = "command sync timed out";
			return result;
		}


		private int iExecuteNetCmd(RstdNetObject net_cmd, out object[] res_arr, out string lua_err)
		{
			int num = 0;
			res_arr = null;
			lua_err = "";
			if (net_cmd.ID == RstdNetCmdID.ScriptCommand)
			{
				num = GuiCore.MainForm.LuaOps.API_DoString(net_cmd.Script, out res_arr, out lua_err);
				if (num == 0 && res_arr != null)
				{
					for (int i = 0; i < res_arr.Length; i++)
					{
						if (res_arr[i] is LuaTable)
						{
							res_arr[i] = this.iConvertLuaTableToArray((LuaTable)res_arr[i]);
						}
					}
				}
			}
			else if (net_cmd.ID == RstdNetCmdID.StopScriptCommand)
			{
				GuiCore.MainForm.StopScript();
			}
			else if (net_cmd.ID == RstdNetCmdID.RunScriptCommand)
			{
				GuiCore.MainForm.bStartScript(net_cmd.Script);
			}
			else if (net_cmd.ID == RstdNetCmdID.RunScriptDebug)
			{
				GuiCore.MainForm.StartDebug(net_cmd.Script, true);
			}
			return num;
		}


		private object[] iConvertLuaTableToArray(LuaTable table)
		{
			object[] array = new object[2];
			ArrayList arrayList = new ArrayList(table.Keys);
			ArrayList arrayList2 = new ArrayList(table.Values);
			array[0] = arrayList.ToArray();
			array[1] = arrayList2.ToArray();
			return array;
		}


		private void iSendNetRes(int lua_res, object[] res_arr, string lua_err)
		{
			this.SendNetRes(new RstdNetObject
			{
				Version = RstdNetConsts.RSTD_NET_VERSION,
				ID = RstdNetCmdID.ScriptResult,
				LuaRes = lua_res,
				LuaErr = lua_err,
				ResArray = res_arr
			});
		}


		public void SendNetRes(RstdNetObject net_res)
		{
			try
			{
				this.m_socWorker.Send(net_res.Serialize());
			}
			catch (SocketException ex)
			{
				if (ex.SocketErrorCode != SocketError.ConnectionReset && ex.SocketErrorCode != SocketError.ConnectionAborted)
				{
					GuiCore.ErrorMessage(string.Format("In RstdServer: {0}\n", ex.Message));
				}
			}
		}


		private void iHandleRemoteDisconnect(SocketException se)
		{
			if (se.SocketErrorCode == SocketError.ConnectionReset || se.SocketErrorCode == SocketError.ConnectionAborted)
			{
				this.ResetConnection();
				return;
			}
			GuiCore.ErrorMessage(string.Format("In RstdServer: {0}\n", se.Message));
		}


		public void ResetConnection()
		{
			if (this.m_socListener == null)
			{
				return;
			}
			this.m_socListener.BeginAccept(new AsyncCallback(this.OnClientConnect), null);
			this.iUpdateState(ServerState.Listening);
		}


		public bool IsConnected()
		{
			bool result;
			try
			{
				if (this.m_socWorker == null)
				{
					result = false;
				}
				else
				{
					result = (!this.m_socWorker.Poll(1, SelectMode.SelectRead) || this.m_socWorker.Available != 0);
				}
			}
			catch (SocketException)
			{
				result = false;
			}
			return result;
		}


		public int Close()
		{
			int result;
			try
			{
				if (this.m_socListener == null)
				{
					result = 0;
				}
				else
				{
					this.m_socListener.Close();
					this.iUpdateState(ServerState.Disconnected);
					result = 0;
				}
			}
			catch (SocketException ex)
			{
				GuiCore.ErrorMessage(string.Format("In RstdServer: {0}\n", ex.Message));
				result = 1;
			}
			return result;
		}


		private Socket m_socListener;


		private Socket m_socWorker;


		private AsyncCallback pfnWorkerCallBack;


		private ServerState m_State;


		private int m_Port;


		public static object SyncObject = new object();


		public static int SyncTimeout = 3000;
	}
}
