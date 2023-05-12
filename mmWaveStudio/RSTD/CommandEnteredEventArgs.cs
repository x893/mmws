using System;

namespace RSTD
{
	public class CommandEnteredEventArgs : EventArgs
	{
		public string Command
		{
			get
			{
				return this.command;
			}
		}

		public CommandEnteredEventArgs(string command)
		{
			this.command = command;
		}

		private string command;
	}
}
