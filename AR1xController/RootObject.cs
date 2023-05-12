using System.Collections.Generic;

namespace AR1xController
{
    public class RootObject
	{
		public ConfigGenerator configGenerator { get; set; }
		public CurrentVersion currentVersion { get; set; }
		public LastBackwardCompatibleVersion lastBackwardCompatibleVersion { get; set; }
		public RegulatoryRestrictions regulatoryRestrictions { get; set; }
		public SystemConfig systemConfig { get; set; }
		public List<MmWaveDevice> mmWaveDevices { get; set; }
		public ProcessingChainConfig processingChainConfig { get; set; }

	}
}
