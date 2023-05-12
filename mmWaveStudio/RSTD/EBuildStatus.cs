using System;

namespace RSTD
{

	[Flags]
	public enum EBuildStatus
	{
		AL_UnBuilt = 0,
		AL_Built = 1,
		AL_Init = 2,
		AL_Reset = 4,
		Client_Built = 8,
		Client_Init = 16,
		Client_Reset = 32
	}
}
