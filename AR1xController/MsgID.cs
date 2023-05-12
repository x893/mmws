﻿using System;

namespace AR1xController
{
	public enum MsgID
	{
		RL_RF_RESP_ERROR_MSG,
		RL_RF_RESERVED0_MSG,
		RL_RF_RESERVED1_MSG,
		RL_RF_RESERVED2_MSG,
		RL_RF_STATIC_CONF_SET_MSG,
		RL_RF_STATIC_CONF_GET_MSG,
		RL_RF_INIT_MSG,
		RL_RF_RESERVED3_MSG,
		RL_RF_DYNAMIC_CONF_SET_MSG,
		RL_RF_DYNAMIC_CONF_GET_MSG,
		RL_RF_FRAME_TRIG_MSG,
		RL_RF_RESERVED4_MSG,
		RL_RF_ADVANCED_FEATURES_SET_MSG,
		RL_RF_ADVANCED_FEATURES_GET_MSG,
		RL_RF_MONITORING_CONF_SET_MSG,
		RL_RF_MONITORING_CONF_GET_MSG,
		RL_RF_STATUS_CLERL_SET_MSG,
		RL_RF_STATUS_GET_MSG,
		RL_RF_RESERVED5_MSG,
		RL_RF_MONITORING_REPO_GET_MSG,
		RL_RF_RESERVED6_MSG,
		RL_RF_RESERVED7_MSG,
		RL_RF_APLL_CL_CAL_SET_MSG,
		RL_RF_APLL_CL_CAL_GET_MSG,
		RL_RF_ORBIT_TEST_SET_MSG,
		RL_RF_RESERVED8_MSG,
		RL_RF_TEST_SOURCE_CONFIG_SET_MSG,
		RL_RF_TEST_SOURCE_CONFIG_GET_MSG,
		RL_RF_AE_POWERUP_DONE = 192,
		RL_RF_AE_APLL_CAL_DONE,
		RL_RF_AE_FLAGS_REPORT,
		RL_RF_AE_MON_BIST_REPORT,
		RL_RF_AE_RFFAULT_REPORT,
		RL_RF_MSG_MAX
	}
}