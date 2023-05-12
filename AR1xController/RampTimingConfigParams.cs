using System;

namespace AR1xController
{
	public class RampTimingConfigParams
	{
		public uint ADCFullRateEnable;

		public uint ADCHalfRateEnable;

		public uint ProgFiltEnable;

		public uint DFEMode;

		public float Slope;

		public uint ADCSamples;

		public uint SampleRate;

		public double IdleTime;

		public double IdleTime95;

		public double TxStartTime;

		public double ADCStartTime95;

		public double RampEndTime;

		public double RampEndTime95;

		public double DFELat;

		public char HPF1;

		public char HPF2;

		public double DFEPipe;

		public double Tsynth_rampdown;

		public double TpipeCapped;

		public double RampTimeDFELag;
	}
}
