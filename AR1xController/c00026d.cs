using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[CompilerGenerated]
internal sealed class c00026d
{
    internal static uint ComputeStringHash(string p0)
    {
        uint num = 0;
        if (p0 != null)
        {
            num = 2166136261U;
            for (int i = 0; i < p0.Length; i++)
            {
                num = ((uint)p0[i] ^ num) * 16777619U;
            }
        }
        return num;
    }
/*
    public static readonly c00026d.struct02bc f000517;

    internal static readonly c00026d.struct02bc f000518;

    internal static readonly c00026d.struct02bc f000519;

    internal static readonly c00026d.struct02bc f00051a;

    internal static readonly c00026d.struct02bc f00051b;

    internal static readonly c00026d.struct02bc f00051c;

    internal static readonly c00026d.struct02bc f00051d;

    internal static readonly c00026d.struct02bc f00051e;

    internal static readonly c00026d.struct02bc f00051f;

    internal static readonly c00026d.struct02ba f000520;

    internal static readonly c00026d.struct02bc f000521;

    internal static readonly c00026d.struct02b9 f000522;

    internal static readonly c00026d.struct02bc f000523;

    internal static readonly c00026d.struct02bc f000524;

    internal static readonly c00026d.struct02bc f000525;

    internal static readonly c00026d.struct02bc f000526;

    internal static readonly c00026d.struct02ba f000527;

    internal static readonly c00026d.struct02bc f000528;

    internal static readonly c00026d.struct02bc f000529;

    internal static readonly c00026d.struct02ba f00052a;

    internal static readonly c00026d.struct02ba f00052b;

    internal static readonly c00026d.struct02bc f00052c;

    internal static readonly c00026d.struct02bc f00052d;

    internal static readonly c00026d.struct02bc f00052e;

    internal static readonly c00026d.struct02bc f00052f;

    internal static readonly c00026d.struct02bc f000530;

    internal static readonly c00026d.struct02bc f000531;

    internal static readonly c00026d.struct02bc f000532;

    internal static readonly c00026d.struct02bc f000533;

    internal static readonly c00026d.struct02bc f000534;

    internal static readonly c00026d.struct02bc f000535;

    internal static readonly c00026d.struct02bc f000536;

    internal static readonly c00026d.struct02bc f000537;

    internal static readonly c00026d.struct02bc f000538;

    internal static readonly c00026d.struct02b9 f000539;

    internal static readonly c00026d.struct02bb f00053a;

    internal static readonly c00026d.struct02bc f00053b;

    internal static readonly c00026d.struct02bc f00053c;
*/
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 16)]
    public struct struct02b9
    {
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 48)]
    public struct struct02ba
    {
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 56)]
    public struct struct02bb
    {
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 96)]
    public struct struct02bc
    {
    }
}
