using System;

namespace AR1xController
{
	public enum RegType
	{
		REG_TYPE_UNKNOWN = -1,
		REG_TYPE_BT_PHY,
		REG_TYPE_WLAN_PHY,
		REG_TYPE_WLAN_MAC,
		REG_TYPE_WLAN_DRPW,
		REG_TYPE_WLAN_TOP,
		REG_TYPE_NWP,
		REG_TYPE_NWP_SRAM,
		REG_TYPE_ACTL
	}
}
