using System;

namespace RSTD
{

	public class RecordItem
	{

		public RecordItem(DateTime timestamp, string module_name, string op_name, string command)
		{
			this.TimeStamp = timestamp;
			this.ModuleName = module_name;
			this.OpName = op_name;
			this.Command = command;
			this.Deleted = false;
		}


		public bool Deleted;


		public DateTime TimeStamp;


		public string ModuleName;


		public string OpName;


		public string Command;
	}
}
