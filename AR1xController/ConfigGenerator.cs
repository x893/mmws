using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class ConfigGenerator
	{
		public string createdBy { get; set; }
		public DateTime createdOn { get; set; }
		public int isConfigIntermediate { get; set; }
		public int isConfigured { get; set; }
	}
}
