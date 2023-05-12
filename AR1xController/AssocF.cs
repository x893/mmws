using System;

namespace AR1xController
{
	[Flags]
	public enum AssocF
	{
		f0002d5 = 1,
		Init_ByExeName = 2,
		Open_ByExeName = 2,
		Init_DefaultToStar = 4,
		Init_DefaultToFolder = 8,
		NoUserSettings = 16,
		NoTruncate = 32,
		Verify = 64,
		RemapRunDll = 128,
		NoFixUps = 256,
		IgnoreBaseClass = 512
	}
}
