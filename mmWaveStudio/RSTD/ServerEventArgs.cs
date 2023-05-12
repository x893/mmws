using System;

namespace RSTD
{

	public class ServerEventArgs : EventArgs
	{

		public ServerEventArgs(ServerState state)
		{
			this.m_State = state;
		}



		public ServerState State
		{
			get
			{
				return this.m_State;
			}
		}


		private ServerState m_State;
	}
}
