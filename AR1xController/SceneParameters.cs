using System;
using System.Runtime.CompilerServices;

namespace AR1xController
{
	public class SceneParameters
	{
		public int ambientTemperature_degC { get; set; }
		public int maxDetectableRange_m { get; set; }
		public int rangeResolution_cm { get; set; }
		public int maxVelocity_kmph { get; set; }
		public int velocityResolution_kmph { get; set; }
		public int measurementRate { get; set; }
		public int typicalDetectedObjectRCS { get; set; }
	}
}
