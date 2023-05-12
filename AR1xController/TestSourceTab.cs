using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AR1xController.Properties;

namespace AR1xController
{
	public class TestSourceTab : UserControl
	{
		public TestSourceTab()
		{
			this.InitializeComponent();
			this.PostInitialization();
			this.m_MainForm = this.m_GuiManager.MainTsForm;
			this.m_TestSourceParams = this.m_GuiManager.TsParams.TestSourceParams;
			this.UpdateTestSourceData();
			this.m_grpTs1TxAntPos.Visible = false;
		}

		public bool UpdateTestSourceConfig(RootObject jobject, int p1)
		{
			bool result;
			try
			{
				if (jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.isConfigured == 0)
				{
					string msg = string.Format("Missing Test Source Configuration for Device {0}. Skipping..", p1);
					GlobalRef.LuaWrapper.PrintWarning(msg);
				}
				else
				{
					this.m_nudTs1Obj1PosX.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.posX_m;
					this.m_nudTs1Obj1PosY.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.posY_m;
					this.m_nudTs1Obj1PosZ.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.posZ_m;
					this.m_nudTs1Obj1VelX.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.velX_m_sec;
					this.m_nudTs1Obj1VelY.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.velY_m_sec;
					this.m_nudTs1Obj1VelZ.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.velZ_m_sec;
					this.m_nudTs1Obj1BoundMinX.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.posXMin_m;
					this.m_nudTs1Obj1BoundMinY.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.posYMin_m;
					this.m_nudTs1Obj1BoundMinZ.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.posZMin_m;
					this.m_nudTs1Obj1BoundMaxX.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.posXMax_m;
					this.m_nudTs1Obj1BoundMaxY.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.posYMax_m;
					this.m_nudTs1Obj1BoundMaxZ.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.posZMax_m;
					this.m_nudTs1Obj1Sig.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[0].rlTestSourceObject_t.sigLvl_dBFS;
					this.m_nudTs1Obj2PosX.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.posX_m;
					this.m_nudTs1Obj2PosY.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.posY_m;
					this.m_nudTs1Obj2PosZ.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.posZ_m;
					this.m_nudTs1Obj2VelX.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.velX_m_sec;
					this.m_nudTs1Obj2VelY.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.velY_m_sec;
					this.m_nudTs1Obj2VelZ.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.velZ_m_sec;
					this.m_nudTs1Obj2BoundMinX.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.posXMin_m;
					this.m_nudTs1Obj2BoundMinY.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.posYMin_m;
					this.m_nudTs1Obj2BoundMinZ.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.posZMin_m;
					this.m_nudTs1Obj2BoundMaxX.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.posXMax_m;
					this.m_nudTs1Obj2BoundMaxY.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.posYMax_m;
					this.m_nudTs1Obj2BoundMaxZ.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.posZMax_m;
					this.m_nudTs1Obj2Sig.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceObjects[1].rlTestSourceObject_t.sigLvl_dBFS;
					this.m_nudTs1AntPosRx1X.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceRxAntPos[0].rlTestSourceAntPos_t.antPosX;
					this.m_nudTs1AntPosRx1Z.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceRxAntPos[0].rlTestSourceAntPos_t.antPosZ;
					this.m_nudTs1AntPosRx2X.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceRxAntPos[1].rlTestSourceAntPos_t.antPosX;
					this.m_nudTs1AntPosRx2Z.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceRxAntPos[1].rlTestSourceAntPos_t.antPosZ;
					this.m_nudTs1AntPosRx3X.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceRxAntPos[2].rlTestSourceAntPos_t.antPosX;
					this.m_nudTs1AntPosRx3Z.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceRxAntPos[2].rlTestSourceAntPos_t.antPosZ;
					this.m_nudTs1AntPosRx4X.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceRxAntPos[3].rlTestSourceAntPos_t.antPosX;
					this.m_nudTs1AntPosRx4Z.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceRxAntPos[3].rlTestSourceAntPos_t.antPosZ;
					this.m_nudTs1AntPosTx1X.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceTxAntPos[0].rlTestSourceAntPos_t.antPosX;
					this.m_nudTs1AntPosTx1Z.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceTxAntPos[0].rlTestSourceAntPos_t.antPosZ;
					this.m_nudTs1AntPosTx2X.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceTxAntPos[1].rlTestSourceAntPos_t.antPosX;
					this.m_nudTs1AntPosTx2Z.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceTxAntPos[1].rlTestSourceAntPos_t.antPosZ;
					this.m_nudTs1AntPosTx3X.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceTxAntPos[2].rlTestSourceAntPos_t.antPosX;
					this.m_nudTs1AntPosTx3Z.Value = (decimal)jobject.mmWaveDevices[p1].rfConfig.rlTestSource_t.rlTestSourceTxAntPos[2].rlTestSourceAntPos_t.antPosZ;
				}
				result = true;
			}
			catch
			{
				string msg2 = string.Format("Test Source Tab Configuration for device {0} is incorrect.", p1);
				GlobalRef.LuaWrapper.PrintError(msg2);
				result = false;
			}
			return result;
		}

		public bool UpdateTestSourceData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateTestSourceData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_TestSourceParams.obj1PosX = (float)this.m_nudTs1Obj1PosX.Value;
				this.m_TestSourceParams.obj1PosY = (float)this.m_nudTs1Obj1PosY.Value;
				this.m_TestSourceParams.obj1PosZ = (float)this.m_nudTs1Obj1PosZ.Value;
				this.m_TestSourceParams.obj1VelX = (float)this.m_nudTs1Obj1VelX.Value;
				this.m_TestSourceParams.obj1VelY = (float)this.m_nudTs1Obj1VelY.Value;
				this.m_TestSourceParams.obj1VelZ = (float)this.m_nudTs1Obj1VelZ.Value;
				this.m_TestSourceParams.obj1BMinX = (float)this.m_nudTs1Obj1BoundMinX.Value;
				this.m_TestSourceParams.obj1BMinY = (float)this.m_nudTs1Obj1BoundMinY.Value;
				this.m_TestSourceParams.obj1BMinZ = (float)this.m_nudTs1Obj1BoundMinZ.Value;
				this.m_TestSourceParams.obj1BMaxX = (float)this.m_nudTs1Obj1BoundMaxX.Value;
				this.m_TestSourceParams.obj1BMaxY = (float)this.m_nudTs1Obj1BoundMaxY.Value;
				this.m_TestSourceParams.obj1BMaxZ = (float)this.m_nudTs1Obj1BoundMaxZ.Value;
				this.m_TestSourceParams.obj1Sig = (float)this.m_nudTs1Obj1Sig.Value;
				this.m_TestSourceParams.obj2PosX = (float)this.m_nudTs1Obj2PosX.Value;
				this.m_TestSourceParams.obj2PosY = (float)this.m_nudTs1Obj2PosY.Value;
				this.m_TestSourceParams.obj2PosZ = (float)this.m_nudTs1Obj2PosZ.Value;
				this.m_TestSourceParams.obj2VelX = (float)this.m_nudTs1Obj2VelX.Value;
				this.m_TestSourceParams.obj2VelY = (float)this.m_nudTs1Obj2VelY.Value;
				this.m_TestSourceParams.obj2VelZ = (float)this.m_nudTs1Obj2VelZ.Value;
				this.m_TestSourceParams.obj2BMinX = (float)this.m_nudTs1Obj2BoundMinX.Value;
				this.m_TestSourceParams.obj2BMinY = (float)this.m_nudTs1Obj2BoundMinY.Value;
				this.m_TestSourceParams.obj2BMinZ = (float)this.m_nudTs1Obj2BoundMinZ.Value;
				this.m_TestSourceParams.obj2BMaxX = (float)this.m_nudTs1Obj2BoundMaxX.Value;
				this.m_TestSourceParams.obj2BMaxY = (float)this.m_nudTs1Obj2BoundMaxY.Value;
				this.m_TestSourceParams.obj2BMaxZ = (float)this.m_nudTs1Obj2BoundMaxZ.Value;
				this.m_TestSourceParams.obj2Sig = (float)this.m_nudTs1Obj2Sig.Value;
				this.m_TestSourceParams.obj1AntPosRx1X = (float)this.m_nudTs1AntPosRx1X.Value;
				this.m_TestSourceParams.obj1AntPosRx1Z = (float)this.m_nudTs1AntPosRx1Z.Value;
				this.m_TestSourceParams.obj1AntPosRx2X = (float)this.m_nudTs1AntPosRx2X.Value;
				this.m_TestSourceParams.obj1AntPosRx2Z = (float)this.m_nudTs1AntPosRx2Z.Value;
				this.m_TestSourceParams.obj1AntPosRx3X = (float)this.m_nudTs1AntPosRx3X.Value;
				this.m_TestSourceParams.obj1AntPosRx3Z = (float)this.m_nudTs1AntPosRx3Z.Value;
				this.m_TestSourceParams.obj1AntPosRx4X = (float)this.m_nudTs1AntPosRx4X.Value;
				this.m_TestSourceParams.obj1AntPosRx4Z = (float)this.m_nudTs1AntPosRx4Z.Value;
				this.m_TestSourceParams.obj1AntPosTx1X = (float)this.m_nudTs1AntPosTx1X.Value;
				this.m_TestSourceParams.obj1AntPosTx1Z = (float)this.m_nudTs1AntPosTx1Z.Value;
				this.m_TestSourceParams.obj1AntPosTx2X = (float)this.m_nudTs1AntPosTx2X.Value;
				this.m_TestSourceParams.obj1AntPosTx2Z = (float)this.m_nudTs1AntPosTx2Z.Value;
				this.m_TestSourceParams.obj1AntPosTx3X = (float)this.m_nudTs1AntPosTx3X.Value;
				this.m_TestSourceParams.obj1AntPosTx3Z = (float)this.m_nudTs1AntPosTx3Z.Value;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UdateEnbTstSrcData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UdateEnbTstSrcData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool UpdateTestSourceDataFrmCmdSrc()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.UpdateTestSourceDataFrmCmdSrc);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				this.m_nudTs1Obj1PosX.Value = (decimal)this.m_TestSourceParams.obj1PosX;
				this.m_nudTs1Obj1PosY.Value = (decimal)this.m_TestSourceParams.obj1PosY;
				this.m_nudTs1Obj1PosZ.Value = (decimal)this.m_TestSourceParams.obj1PosZ;
				this.m_nudTs1Obj1VelX.Value = (decimal)this.m_TestSourceParams.obj1VelX;
				this.m_nudTs1Obj1VelY.Value = (decimal)this.m_TestSourceParams.obj1VelY;
				this.m_nudTs1Obj1VelZ.Value = (decimal)this.m_TestSourceParams.obj1VelZ;
				this.m_nudTs1Obj1BoundMinX.Value = (decimal)this.m_TestSourceParams.obj1BMinX;
				this.m_nudTs1Obj1BoundMinY.Value = (decimal)this.m_TestSourceParams.obj1BMinY;
				this.m_nudTs1Obj1BoundMinZ.Value = (decimal)this.m_TestSourceParams.obj1BMinZ;
				this.m_nudTs1Obj1BoundMaxX.Value = (decimal)this.m_TestSourceParams.obj1BMaxX;
				this.m_nudTs1Obj1BoundMaxY.Value = (decimal)this.m_TestSourceParams.obj1BMaxY;
				this.m_nudTs1Obj1BoundMaxZ.Value = (decimal)this.m_TestSourceParams.obj1BMaxZ;
				this.m_nudTs1Obj1Sig.Value = (decimal)this.m_TestSourceParams.obj1Sig;
				this.m_nudTs1Obj2PosX.Value = (decimal)this.m_TestSourceParams.obj2PosX;
				this.m_nudTs1Obj2PosY.Value = (decimal)this.m_TestSourceParams.obj2PosY;
				this.m_nudTs1Obj2PosZ.Value = (decimal)this.m_TestSourceParams.obj2PosZ;
				this.m_nudTs1Obj2VelX.Value = (decimal)this.m_TestSourceParams.obj2VelX;
				this.m_nudTs1Obj2VelY.Value = (decimal)this.m_TestSourceParams.obj2VelY;
				this.m_nudTs1Obj2VelZ.Value = (decimal)this.m_TestSourceParams.obj2VelZ;
				this.m_nudTs1Obj2BoundMinX.Value = (decimal)this.m_TestSourceParams.obj2BMinX;
				this.m_nudTs1Obj2BoundMinY.Value = (decimal)this.m_TestSourceParams.obj2BMinY;
				this.m_nudTs1Obj2BoundMinZ.Value = (decimal)this.m_TestSourceParams.obj2BMinZ;
				this.m_nudTs1Obj2BoundMaxX.Value = (decimal)this.m_TestSourceParams.obj2BMaxX;
				this.m_nudTs1Obj2BoundMaxY.Value = (decimal)this.m_TestSourceParams.obj2BMaxY;
				this.m_nudTs1Obj2BoundMaxZ.Value = (decimal)this.m_TestSourceParams.obj2BMaxZ;
				this.m_nudTs1Obj2Sig.Value = (decimal)this.m_TestSourceParams.obj2Sig;
				this.m_nudTs1AntPosRx1X.Value = (decimal)this.m_TestSourceParams.obj1AntPosRx1X;
				this.m_nudTs1AntPosRx1Z.Value = (decimal)this.m_TestSourceParams.obj1AntPosRx1Z;
				this.m_nudTs1AntPosRx2X.Value = (decimal)this.m_TestSourceParams.obj1AntPosRx2X;
				this.m_nudTs1AntPosRx2Z.Value = (decimal)this.m_TestSourceParams.obj1AntPosRx2Z;
				this.m_nudTs1AntPosRx3X.Value = (decimal)this.m_TestSourceParams.obj1AntPosRx3X;
				this.m_nudTs1AntPosRx3Z.Value = (decimal)this.m_TestSourceParams.obj1AntPosRx3Z;
				this.m_nudTs1AntPosRx4X.Value = (decimal)this.m_TestSourceParams.obj1AntPosRx4X;
				this.m_nudTs1AntPosRx4Z.Value = (decimal)this.m_TestSourceParams.obj1AntPosRx4Z;
				this.m_nudTs1AntPosTx1X.Value = (decimal)this.m_TestSourceParams.obj1AntPosTx1X;
				this.m_nudTs1AntPosTx1Z.Value = (decimal)this.m_TestSourceParams.obj1AntPosTx1Z;
				this.m_nudTs1AntPosTx2X.Value = (decimal)this.m_TestSourceParams.obj1AntPosTx2X;
				this.m_nudTs1AntPosTx2Z.Value = (decimal)this.m_TestSourceParams.obj1AntPosTx2Z;
				this.m_nudTs1AntPosTx3X.Value = (decimal)this.m_TestSourceParams.obj1AntPosTx3X;
				this.m_nudTs1AntPosTx3Z.Value = (decimal)this.m_TestSourceParams.obj1AntPosTx3Z;
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool LoadTestSourceData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.LoadTestSourceData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				float obj1PosX = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1PosX"));
				float obj1PosY = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1PosY"));
				float obj1PosZ = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1PosZ"));
				float obj1VelX = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1VelX"));
				float obj1VelY = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1VelY"));
				float obj1VelZ = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1VelZ"));
				float obj1BMinX = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1BMinX"));
				float obj1BMinY = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1BMinY"));
				float obj1BMinZ = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1BMinZ"));
				float obj1BMaxX = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1BMaxX"));
				float obj1BMaxY = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1BMaxY"));
				float obj1BMaxZ = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1BMaxZ"));
				float obj1Sig = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1Sig"));
				float obj2PosX = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2PosX"));
				float obj2PosY = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2PosY"));
				float obj2PosZ = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2PosZ"));
				float obj2VelX = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2VelX"));
				float obj2VelY = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2VelY"));
				float obj2VelZ = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2VelZ"));
				float obj2BMinX = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2BMinX"));
				float obj2BMinY = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2BMinY"));
				float obj2BMinZ = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2BMinZ"));
				float obj2BMaxX = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2BMaxX"));
				float obj2BMaxY = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2BMaxY"));
				float obj2BMaxZ = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2BMaxZ"));
				float obj2Sig = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj2Sig"));
				float obj1AntPosRx1X = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosRx1X"));
				float obj1AntPosRx1Z = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosRx1Z"));
				float obj1AntPosRx2X = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosRx2X"));
				float obj1AntPosRx2Z = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosRx2Z"));
				float obj1AntPosRx3X = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosRx3X"));
				float obj1AntPosRx3Z = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosRx3Z"));
				float obj1AntPosRx4X = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosRx4X"));
				float obj1AntPosRx4Z = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosRx4Z"));
				float obj1AntPosTx1X = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosTx1X"));
				float obj1AntPosTx1Z = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosTx1Z"));
				float obj1AntPosTx2X = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosTx2X"));
				float obj1AntPosTx2Z = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosTx2Z"));
				float obj1AntPosTx3X = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosTx3X"));
				float obj1AntPosTx3Z = Convert.ToSingle(ConfigurationManager.GetTestSourceConfigKeyVal("obj1AntPosTx3Z"));
				this.m_GuiManager.ScriptOps.UpdateTestSrcData(obj1PosX, obj1PosY, obj1PosZ, obj1VelX, obj1VelY, obj1VelZ, obj1BMinX, obj1BMinY, obj1BMinZ, obj1BMaxX, obj1BMaxY, obj1BMaxZ, obj1Sig, obj2PosX, obj2PosY, obj2PosZ, obj2VelX, obj2VelY, obj2VelZ, obj2BMinX, obj2BMinY, obj2BMinZ, obj2BMaxX, obj2BMaxY, obj2BMaxZ, obj2Sig, obj1AntPosRx1X, obj1AntPosRx1Z, obj1AntPosRx2X, obj1AntPosRx2Z, obj1AntPosRx3X, obj1AntPosRx3Z, obj1AntPosRx4X, obj1AntPosRx4Z, obj1AntPosTx1X, obj1AntPosTx1Z, obj1AntPosTx2X, obj1AntPosTx2Z, obj1AntPosTx3X, obj1AntPosTx3Z);
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public bool SaveTestSourceData()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.SaveTestSourceData);
				return (bool)base.Invoke(method);
			}
			bool result;
			try
			{
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1PosX", this.m_nudTs1Obj1PosX.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1PosY", this.m_nudTs1Obj1PosY.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1PosZ", this.m_nudTs1Obj1PosZ.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1VelX", this.m_nudTs1Obj1VelX.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1VelY", this.m_nudTs1Obj1VelY.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1VelZ", this.m_nudTs1Obj1VelZ.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1BMinX", this.m_nudTs1Obj1BoundMinX.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1BMinY", this.m_nudTs1Obj1BoundMinY.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1BMinZ", this.m_nudTs1Obj1BoundMinZ.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1BMaxX", this.m_nudTs1Obj1BoundMaxX.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1BMaxY", this.m_nudTs1Obj1BoundMaxY.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1BMaxZ", this.m_nudTs1Obj1BoundMaxZ.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1Sig", this.m_nudTs1Obj1Sig.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2PosX", this.m_nudTs1Obj2PosX.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2PosY", this.m_nudTs1Obj2PosY.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2PosZ", this.m_nudTs1Obj2PosZ.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2VelX", this.m_nudTs1Obj2VelX.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2VelY", this.m_nudTs1Obj2VelY.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2VelZ", this.m_nudTs1Obj2VelZ.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2BMinX", this.m_nudTs1Obj2BoundMinX.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2BMinY", this.m_nudTs1Obj2BoundMinY.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2BMinZ", this.m_nudTs1Obj2BoundMinZ.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2BMaxX", this.m_nudTs1Obj2BoundMaxX.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2BMaxY", this.m_nudTs1Obj2BoundMaxY.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2BMaxZ", this.m_nudTs1Obj2BoundMaxZ.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj2Sig", this.m_nudTs1Obj2Sig.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosRx1X", this.m_nudTs1AntPosRx1X.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosRx1Z", this.m_nudTs1AntPosRx1Z.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosRx2X", this.m_nudTs1AntPosRx2X.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosRx2Z", this.m_nudTs1AntPosRx2Z.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosRx3X", this.m_nudTs1AntPosRx3X.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosRx3Z", this.m_nudTs1AntPosRx3Z.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosRx4X", this.m_nudTs1AntPosRx4X.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosRx4Z", this.m_nudTs1AntPosRx4Z.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosTx1X", this.m_nudTs1AntPosTx1X.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosTx1Z", this.m_nudTs1AntPosTx1Z.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosTx2X", this.m_nudTs1AntPosTx2X.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosTx2Z", this.m_nudTs1AntPosTx2Z.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosTx3X", this.m_nudTs1AntPosTx3X.Value.ToString());
				ConfigurationManager.SetTestSourceConfigKeyVal("obj1AntPosTx3Z", this.m_nudTs1AntPosTx3Z.Value.ToString());
				result = true;
			}
			catch (Exception ex)
			{
				this.m_GuiManager.Error(ex.Message, ex.StackTrace);
				result = false;
			}
			return result;
		}

		public void iSetEnableBtnText(string text)
		{
			if (base.InvokeRequired)
			{
				del_v_s method = new del_v_s(this.iSetEnableBtnText);
				base.Invoke(method, new object[]
				{
					text
				});
			}
		}

		public string iGetEnableBtnText()
		{
			if (base.InvokeRequired)
			{
				del_s_v method = new del_s_v(this.iGetEnableBtnText);
				return (string)base.Invoke(method);
			}
			return string.Empty;
		}

		private int iEnableTestSource_Internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iEnableTestSource_Impl();
		}

		private void iEnableTestSource()
		{
			this.iEnableTestSource_Internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		private void m_grpTestSource1_Enter(object sender, EventArgs p1)
		{
		}

		private void TestSourceTab_Load(object sender, EventArgs p1)
		{
		}

		private void iEnableTestSourceAsync()
		{
			new del_v_v(this.iEnableTestSource).BeginInvoke(null, null);
		}

		private void m_btnTsEnable_Click(object sender, EventArgs p1)
		{
			this.iEnableTestSourceAsync();
		}

		private int iSetTestSource_internal(bool is_starting_op, bool is_ending_op)
		{
			return this.m_GuiManager.ScriptOps.iSetTestSource_Gui(is_starting_op, is_ending_op);
		}

		private void iSetTestSource()
		{
			this.iSetTestSource_internal(true, false);
			this.m_MainForm.GuiOpEnd(true);
		}

		public void iSetTestSourceAsync()
		{
			new del_v_v(this.iSetTestSource).BeginInvoke(null, null);
		}

		private void m_btnTs1Set_Click(object sender, EventArgs p1)
		{
			this.iSetTestSourceAsync();
		}

		public bool iDisableTstSrcTabBtns()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.iDisableTstSrcTabBtns);
				return (bool)base.Invoke(method);
			}
			this.m_btnTs1Set.Enabled = false;
			return true;
		}

		public bool iEnableTstSrcTabBtns()
		{
			if (base.InvokeRequired)
			{
				del_b_v method = new del_b_v(this.iEnableTstSrcTabBtns);
				return (bool)base.Invoke(method);
			}
			this.m_btnTs1Set.Enabled = true;
			return true;
		}

		private void m_nudTs1Obj2Sig_ValueChanged(object sender, EventArgs p1)
		{
		}

		private void Rx2AntennaPosxValueChanged(object sender, EventArgs p1)
		{
			double num = (double)this.m_nudTs1AntPosRx2X.Value * 1000.0;
			double num2;
			if ((int)(num % 125.0) > 63)
			{
				num2 = (double)(((int)(num / 125.0) + 1) * 125);
			}
			else
			{
				num2 = (double)((int)(num / 125.0) * 125);
			}
			this.m_nudTs1AntPosRx2X.Value = (decimal)(num2 / 1000.0);
		}

		private void Rx2AntennaPosZValueChanged(object sender, EventArgs p1)
		{
			double num = (double)this.m_nudTs1AntPosRx2Z.Value * 1000.0;
			double num2;
			if ((int)(num % 125.0) > 63)
			{
				num2 = (double)(((int)(num / 125.0) + 1) * 125);
			}
			else
			{
				num2 = (double)((int)(num / 125.0) * 125);
			}
			this.m_nudTs1AntPosRx2Z.Value = (decimal)(num2 / 1000.0);
		}

		private void Rx3AntennaPosXValueChanged(object sender, EventArgs p1)
		{
			double num = (double)this.m_nudTs1AntPosRx3X.Value * 1000.0;
			double num2;
			if ((int)(num % 125.0) > 63)
			{
				num2 = (double)(((int)(num / 125.0) + 1) * 125);
			}
			else
			{
				num2 = (double)((int)(num / 125.0) * 125);
			}
			this.m_nudTs1AntPosRx3X.Value = (decimal)(num2 / 1000.0);
		}

		private void Rx3AntennaPosZValueChanged(object sender, EventArgs p1)
		{
			double num = (double)this.m_nudTs1AntPosRx3Z.Value * 1000.0;
			double num2;
			if ((int)(num % 125.0) > 63)
			{
				num2 = (double)(((int)(num / 125.0) + 1) * 125);
			}
			else
			{
				num2 = (double)((int)(num / 125.0) * 125);
			}
			this.m_nudTs1AntPosRx3Z.Value = (decimal)(num2 / 1000.0);
		}

		private void Rx4AntennaPosXValueChanged(object sender, EventArgs p1)
		{
			double num = (double)this.m_nudTs1AntPosRx4X.Value * 1000.0;
			double num2;
			if ((int)(num % 125.0) > 63)
			{
				num2 = (double)(((int)(num / 125.0) + 1) * 125);
			}
			else
			{
				num2 = (double)((int)(num / 125.0) * 125);
			}
			this.m_nudTs1AntPosRx4X.Value = (decimal)(num2 / 1000.0);
		}

		private void Rx4AntennaPosZValueChanged(object sender, EventArgs p1)
		{
			double num = (double)this.m_nudTs1AntPosRx4Z.Value * 1000.0;
			double num2;
			if ((int)(num % 125.0) > 63)
			{
				num2 = (double)(((int)(num / 125.0) + 1) * 125);
			}
			else
			{
				num2 = (double)((int)(num / 125.0) * 125);
			}
			this.m_nudTs1AntPosRx4Z.Value = (decimal)(num2 / 1000.0);
		}

		private void Rx1AntennaPosXValueChanged(object sender, EventArgs p1)
		{
			double num = (double)this.m_nudTs1AntPosRx1X.Value * 1000.0;
			double num2;
			if ((int)(num % 125.0) > 63)
			{
				num2 = (double)(((int)(num / 125.0) + 1) * 125);
			}
			else
			{
				num2 = (double)((int)(num / 125.0) * 125);
			}
			this.m_nudTs1AntPosRx1X.Value = (decimal)(num2 / 1000.0);
		}

		private void Rx1AntennaPosZValueChanged(object sender, EventArgs p1)
		{
			double num = (double)this.m_nudTs1AntPosRx1Z.Value * 1000.0;
			double num2;
			if ((int)(num % 125.0) > 63)
			{
				num2 = (double)(((int)(num / 125.0) + 1) * 125);
			}
			else
			{
				num2 = (double)((int)(num / 125.0) * 125);
			}
			this.m_nudTs1AntPosRx1Z.Value = (decimal)(num2 / 1000.0);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TestSourceTab));
			this.m_grpTestSource1 = new GroupBox();
			this.textBox1 = new TextBox();
			this.pictureBox1 = new PictureBox();
			this.label3 = new Label();
			this.label4 = new Label();
			this.label5 = new Label();
			this.m_btnTs1Set = new Button();
			this.m_grpTs1TxAntPos = new GroupBox();
			this.m_lblTs1AntPosTx3 = new Label();
			this.m_nudTs1AntPosTx3Z = new NumericUpDown();
			this.m_lblTs1AntPosTx2 = new Label();
			this.m_nudTs1AntPosTx3X = new NumericUpDown();
			this.m_nudTs1AntPosTx2Z = new NumericUpDown();
			this.m_nudTs1AntPosTx2X = new NumericUpDown();
			this.m_lblTs1AntPosTx1 = new Label();
			this.m_nudTs1AntPosTx1Z = new NumericUpDown();
			this.m_nudTs1AntPosTx1X = new NumericUpDown();
			this.m_grpTs1RxAntPos = new GroupBox();
			this.m_lblTs1AntPosRx4 = new Label();
			this.m_nudTs1AntPosRx4Z = new NumericUpDown();
			this.m_nudTs1AntPosRx4X = new NumericUpDown();
			this.m_lblTs1AntPosRx3 = new Label();
			this.m_nudTs1AntPosRx3Z = new NumericUpDown();
			this.label2 = new Label();
			this.m_lblTs1AntPosRx2 = new Label();
			this.label1 = new Label();
			this.m_nudTs1AntPosRx3X = new NumericUpDown();
			this.m_nudTs1AntPosRx2Z = new NumericUpDown();
			this.m_nudTs1AntPosRx2X = new NumericUpDown();
			this.m_lblTs1AntPosRx1 = new Label();
			this.m_nudTs1AntPosRx1Z = new NumericUpDown();
			this.m_nudTs1AntPosRx1X = new NumericUpDown();
			this.m_grpTs1Obj2 = new GroupBox();
			this.m_nudTs1Obj2Sig = new NumericUpDown();
			this.m_lblTs1Obj2Sig = new Label();
			this.m_lblTs1Obj2BoundMax = new Label();
			this.m_lblTs1Obj2Pos1 = new Label();
			this.m_nudTs1Obj2PosZ = new NumericUpDown();
			this.m_nudTs1Obj2BoundMaxY = new NumericUpDown();
			this.m_nudTs1Obj2PosX = new NumericUpDown();
			this.m_nudTs1Obj2BoundMaxX = new NumericUpDown();
			this.m_nudTs1Obj2PosY = new NumericUpDown();
			this.m_nudTs1Obj2BoundMaxZ = new NumericUpDown();
			this.m_lblTs1Obj2Vel1 = new Label();
			this.m_nudTs1Obj2VelZ = new NumericUpDown();
			this.m_nudTs1Obj2BoundMinY = new NumericUpDown();
			this.m_nudTs1Obj2VelX = new NumericUpDown();
			this.m_nudTs1Obj2BoundMinX = new NumericUpDown();
			this.m_nudTs1Obj2VelY = new NumericUpDown();
			this.m_nudTs1Obj2BoundMinZ = new NumericUpDown();
			this.m_lblTs1Obj2BoundMin = new Label();
			this.m_lblTsZ = new Label();
			this.m_grpTs1Obj1 = new GroupBox();
			this.m_nudTs1Obj1Sig = new NumericUpDown();
			this.m_lblTs1Obj1Sig = new Label();
			this.m_nudTs1Obj1BoundMaxY = new NumericUpDown();
			this.m_nudTs1Obj1BoundMaxX = new NumericUpDown();
			this.m_lblTs1Obj1Pos1 = new Label();
			this.m_nudTs1Obj1BoundMaxZ = new NumericUpDown();
			this.m_nudTs1Obj1PosZ = new NumericUpDown();
			this.m_lblTs1Obj1BoundMax = new Label();
			this.m_nudTs1Obj1PosX = new NumericUpDown();
			this.m_nudTs1Obj1BoundMinY = new NumericUpDown();
			this.m_nudTs1Obj1PosY = new NumericUpDown();
			this.m_nudTs1Obj1BoundMinX = new NumericUpDown();
			this.m_lblTs1Obj1Vel1 = new Label();
			this.m_nudTs1Obj1BoundMinZ = new NumericUpDown();
			this.m_nudTs1Obj1VelZ = new NumericUpDown();
			this.m_lblTs1Obj1BoundMin = new Label();
			this.m_nudTs1Obj1VelX = new NumericUpDown();
			this.m_nudTs1Obj1VelY = new NumericUpDown();
			this.m_lblTsY = new Label();
			this.m_lblTsX = new Label();
			this.m_grpTestSource1.SuspendLayout();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			this.m_grpTs1TxAntPos.SuspendLayout();
			((ISupportInitialize)this.m_nudTs1AntPosTx3Z).BeginInit();
			((ISupportInitialize)this.m_nudTs1AntPosTx3X).BeginInit();
			((ISupportInitialize)this.m_nudTs1AntPosTx2Z).BeginInit();
			((ISupportInitialize)this.m_nudTs1AntPosTx2X).BeginInit();
			((ISupportInitialize)this.m_nudTs1AntPosTx1Z).BeginInit();
			((ISupportInitialize)this.m_nudTs1AntPosTx1X).BeginInit();
			this.m_grpTs1RxAntPos.SuspendLayout();
			((ISupportInitialize)this.m_nudTs1AntPosRx4Z).BeginInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx4X).BeginInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx3Z).BeginInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx3X).BeginInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx2Z).BeginInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx2X).BeginInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx1Z).BeginInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx1X).BeginInit();
			this.m_grpTs1Obj2.SuspendLayout();
			((ISupportInitialize)this.m_nudTs1Obj2Sig).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj2PosZ).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj2BoundMaxY).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj2PosX).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj2BoundMaxX).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj2PosY).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj2BoundMaxZ).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj2VelZ).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj2BoundMinY).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj2VelX).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj2BoundMinX).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj2VelY).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj2BoundMinZ).BeginInit();
			this.m_grpTs1Obj1.SuspendLayout();
			((ISupportInitialize)this.m_nudTs1Obj1Sig).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj1BoundMaxY).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj1BoundMaxX).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj1BoundMaxZ).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj1PosZ).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj1PosX).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj1BoundMinY).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj1PosY).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj1BoundMinX).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj1BoundMinZ).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj1VelZ).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj1VelX).BeginInit();
			((ISupportInitialize)this.m_nudTs1Obj1VelY).BeginInit();
			base.SuspendLayout();
			this.m_grpTestSource1.Controls.Add(this.textBox1);
			this.m_grpTestSource1.Controls.Add(this.pictureBox1);
			this.m_grpTestSource1.Controls.Add(this.label3);
			this.m_grpTestSource1.Controls.Add(this.label4);
			this.m_grpTestSource1.Controls.Add(this.label5);
			this.m_grpTestSource1.Controls.Add(this.m_btnTs1Set);
			this.m_grpTestSource1.Controls.Add(this.m_grpTs1TxAntPos);
			this.m_grpTestSource1.Controls.Add(this.m_grpTs1RxAntPos);
			this.m_grpTestSource1.Controls.Add(this.m_grpTs1Obj2);
			this.m_grpTestSource1.Controls.Add(this.m_lblTsZ);
			this.m_grpTestSource1.Controls.Add(this.m_grpTs1Obj1);
			this.m_grpTestSource1.Controls.Add(this.m_lblTsY);
			this.m_grpTestSource1.Controls.Add(this.m_lblTsX);
			this.m_grpTestSource1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_grpTestSource1.Location = new Point(2, 2);
			this.m_grpTestSource1.Margin = new Padding(2);
			this.m_grpTestSource1.Name = "m_grpTestSource1";
			this.m_grpTestSource1.Padding = new Padding(2);
			this.m_grpTestSource1.Size = new Size(1102, 779);
			this.m_grpTestSource1.TabIndex = 1;
			this.m_grpTestSource1.TabStop = false;
			this.m_grpTestSource1.Text = "Test Source";
			this.m_grpTestSource1.Enter += this.m_grpTestSource1_Enter;
			this.textBox1.BackColor = SystemColors.Menu;
			this.textBox1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.textBox1.Location = new Point(6, 25);
			this.textBox1.Margin = new Padding(4, 4, 4, 4);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(1089, 123);
			this.textBox1.TabIndex = 65;
			this.textBox1.Text = componentResourceManager.GetString("textBox1.Text");
			this.pictureBox1.Image = Resources.TestSourceNew1;
			this.pictureBox1.Location = new Point(641, 415);
			this.pictureBox1.Margin = new Padding(4, 4, 4, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(394, 340);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 64;
			this.pictureBox1.TabStop = false;
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label3.Location = new Point(964, 152);
			this.label3.Margin = new Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new Size(16, 17);
			this.label3.TabIndex = 63;
			this.label3.Text = "z";
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label4.Location = new Point(856, 152);
			this.label4.Margin = new Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new Size(15, 17);
			this.label4.TabIndex = 62;
			this.label4.Text = "y";
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label5.Location = new Point(749, 152);
			this.label5.Margin = new Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new Size(15, 17);
			this.label5.TabIndex = 61;
			this.label5.Text = "x";
			this.m_btnTs1Set.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_btnTs1Set.Location = new Point(425, 571);
			this.m_btnTs1Set.Margin = new Padding(2);
			this.m_btnTs1Set.Name = "m_btnTs1Set";
			this.m_btnTs1Set.Size = new Size(104, 34);
			this.m_btnTs1Set.TabIndex = 43;
			this.m_btnTs1Set.Text = "Set";
			this.m_btnTs1Set.UseVisualStyleBackColor = true;
			this.m_btnTs1Set.Click += this.m_btnTs1Set_Click;
			this.m_grpTs1TxAntPos.Controls.Add(this.m_lblTs1AntPosTx3);
			this.m_grpTs1TxAntPos.Controls.Add(this.m_nudTs1AntPosTx3Z);
			this.m_grpTs1TxAntPos.Controls.Add(this.m_lblTs1AntPosTx2);
			this.m_grpTs1TxAntPos.Controls.Add(this.m_nudTs1AntPosTx3X);
			this.m_grpTs1TxAntPos.Controls.Add(this.m_nudTs1AntPosTx2Z);
			this.m_grpTs1TxAntPos.Controls.Add(this.m_nudTs1AntPosTx2X);
			this.m_grpTs1TxAntPos.Controls.Add(this.m_lblTs1AntPosTx1);
			this.m_grpTs1TxAntPos.Controls.Add(this.m_nudTs1AntPosTx1Z);
			this.m_grpTs1TxAntPos.Controls.Add(this.m_nudTs1AntPosTx1X);
			this.m_grpTs1TxAntPos.Location = new Point(20, 629);
			this.m_grpTs1TxAntPos.Margin = new Padding(2);
			this.m_grpTs1TxAntPos.Name = "m_grpTs1TxAntPos";
			this.m_grpTs1TxAntPos.Padding = new Padding(2);
			this.m_grpTs1TxAntPos.Size = new Size(601, 126);
			this.m_grpTs1TxAntPos.TabIndex = 53;
			this.m_grpTs1TxAntPos.TabStop = false;
			this.m_grpTs1TxAntPos.Text = "TX Antenna Position";
			this.m_lblTs1AntPosTx3.AutoSize = true;
			this.m_lblTs1AntPosTx3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1AntPosTx3.Location = new Point(335, 89);
			this.m_lblTs1AntPosTx3.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1AntPosTx3.Name = "m_lblTs1AntPosTx3";
			this.m_lblTs1AntPosTx3.Size = new Size(55, 17);
			this.m_lblTs1AntPosTx3.TabIndex = 53;
			this.m_lblTs1AntPosTx3.Text = "TX3 (λ)";
			this.m_nudTs1AntPosTx3Z.DecimalPlaces = 3;
			this.m_nudTs1AntPosTx3Z.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosTx3Z.Location = new Point(521, 86);
			this.m_nudTs1AntPosTx3Z.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosTx3Z = this.m_nudTs1AntPosTx3Z;
			int[] array = new int[4];
			array[0] = 32;
			nudTs1AntPosTx3Z.Maximum = new decimal(array);
			this.m_nudTs1AntPosTx3Z.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosTx3Z.Name = "m_nudTs1AntPosTx3Z";
			this.m_nudTs1AntPosTx3Z.Size = new Size(72, 25);
			this.m_nudTs1AntPosTx3Z.TabIndex = 40;
			this.m_lblTs1AntPosTx2.AutoSize = true;
			this.m_lblTs1AntPosTx2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1AntPosTx2.Location = new Point(332, 55);
			this.m_lblTs1AntPosTx2.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1AntPosTx2.Name = "m_lblTs1AntPosTx2";
			this.m_lblTs1AntPosTx2.Size = new Size(55, 17);
			this.m_lblTs1AntPosTx2.TabIndex = 51;
			this.m_lblTs1AntPosTx2.Text = "TX2 (λ)";
			this.m_nudTs1AntPosTx3X.DecimalPlaces = 3;
			this.m_nudTs1AntPosTx3X.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosTx3X.Location = new Point(414, 86);
			this.m_nudTs1AntPosTx3X.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosTx3X = this.m_nudTs1AntPosTx3X;
			int[] array2 = new int[4];
			array2[0] = 32;
			nudTs1AntPosTx3X.Maximum = new decimal(array2);
			this.m_nudTs1AntPosTx3X.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosTx3X.Name = "m_nudTs1AntPosTx3X";
			this.m_nudTs1AntPosTx3X.Size = new Size(72, 25);
			this.m_nudTs1AntPosTx3X.TabIndex = 39;
			this.m_nudTs1AntPosTx2Z.DecimalPlaces = 3;
			this.m_nudTs1AntPosTx2Z.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosTx2Z.Location = new Point(521, 52);
			this.m_nudTs1AntPosTx2Z.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosTx2Z = this.m_nudTs1AntPosTx2Z;
			int[] array3 = new int[4];
			array3[0] = 32;
			nudTs1AntPosTx2Z.Maximum = new decimal(array3);
			this.m_nudTs1AntPosTx2Z.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosTx2Z.Name = "m_nudTs1AntPosTx2Z";
			this.m_nudTs1AntPosTx2Z.Size = new Size(72, 25);
			this.m_nudTs1AntPosTx2Z.TabIndex = 38;
			this.m_nudTs1AntPosTx2X.DecimalPlaces = 3;
			this.m_nudTs1AntPosTx2X.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosTx2X.Location = new Point(414, 52);
			this.m_nudTs1AntPosTx2X.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosTx2X = this.m_nudTs1AntPosTx2X;
			int[] array4 = new int[4];
			array4[0] = 32;
			nudTs1AntPosTx2X.Maximum = new decimal(array4);
			this.m_nudTs1AntPosTx2X.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosTx2X.Name = "m_nudTs1AntPosTx2X";
			this.m_nudTs1AntPosTx2X.Size = new Size(72, 25);
			this.m_nudTs1AntPosTx2X.TabIndex = 37;
			this.m_lblTs1AntPosTx1.AutoSize = true;
			this.m_lblTs1AntPosTx1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1AntPosTx1.Location = new Point(44, 80);
			this.m_lblTs1AntPosTx1.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1AntPosTx1.Name = "m_lblTs1AntPosTx1";
			this.m_lblTs1AntPosTx1.Size = new Size(55, 17);
			this.m_lblTs1AntPosTx1.TabIndex = 48;
			this.m_lblTs1AntPosTx1.Text = "TX1 (λ)";
			this.m_nudTs1AntPosTx1Z.DecimalPlaces = 3;
			this.m_nudTs1AntPosTx1Z.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosTx1Z.Location = new Point(234, 78);
			this.m_nudTs1AntPosTx1Z.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosTx1Z = this.m_nudTs1AntPosTx1Z;
			int[] array5 = new int[4];
			array5[0] = 32;
			nudTs1AntPosTx1Z.Maximum = new decimal(array5);
			this.m_nudTs1AntPosTx1Z.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosTx1Z.Name = "m_nudTs1AntPosTx1Z";
			this.m_nudTs1AntPosTx1Z.Size = new Size(72, 25);
			this.m_nudTs1AntPosTx1Z.TabIndex = 36;
			this.m_nudTs1AntPosTx1X.DecimalPlaces = 3;
			this.m_nudTs1AntPosTx1X.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosTx1X.Location = new Point(125, 78);
			this.m_nudTs1AntPosTx1X.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosTx1X = this.m_nudTs1AntPosTx1X;
			int[] array6 = new int[4];
			array6[0] = 32;
			nudTs1AntPosTx1X.Maximum = new decimal(array6);
			this.m_nudTs1AntPosTx1X.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosTx1X.Name = "m_nudTs1AntPosTx1X";
			this.m_nudTs1AntPosTx1X.Size = new Size(72, 25);
			this.m_nudTs1AntPosTx1X.TabIndex = 35;
			this.m_grpTs1RxAntPos.Controls.Add(this.m_lblTs1AntPosRx4);
			this.m_grpTs1RxAntPos.Controls.Add(this.m_nudTs1AntPosRx4Z);
			this.m_grpTs1RxAntPos.Controls.Add(this.m_nudTs1AntPosRx4X);
			this.m_grpTs1RxAntPos.Controls.Add(this.m_lblTs1AntPosRx3);
			this.m_grpTs1RxAntPos.Controls.Add(this.m_nudTs1AntPosRx3Z);
			this.m_grpTs1RxAntPos.Controls.Add(this.label2);
			this.m_grpTs1RxAntPos.Controls.Add(this.m_lblTs1AntPosRx2);
			this.m_grpTs1RxAntPos.Controls.Add(this.label1);
			this.m_grpTs1RxAntPos.Controls.Add(this.m_nudTs1AntPosRx3X);
			this.m_grpTs1RxAntPos.Controls.Add(this.m_nudTs1AntPosRx2Z);
			this.m_grpTs1RxAntPos.Controls.Add(this.m_nudTs1AntPosRx2X);
			this.m_grpTs1RxAntPos.Controls.Add(this.m_lblTs1AntPosRx1);
			this.m_grpTs1RxAntPos.Controls.Add(this.m_nudTs1AntPosRx1Z);
			this.m_grpTs1RxAntPos.Controls.Add(this.m_nudTs1AntPosRx1X);
			this.m_grpTs1RxAntPos.Location = new Point(30, 421);
			this.m_grpTs1RxAntPos.Margin = new Padding(2);
			this.m_grpTs1RxAntPos.Name = "m_grpTs1RxAntPos";
			this.m_grpTs1RxAntPos.Padding = new Padding(2);
			this.m_grpTs1RxAntPos.Size = new Size(360, 185);
			this.m_grpTs1RxAntPos.TabIndex = 52;
			this.m_grpTs1RxAntPos.TabStop = false;
			this.m_grpTs1RxAntPos.Text = "RX Antenna Position";
			this.m_lblTs1AntPosRx4.AutoSize = true;
			this.m_lblTs1AntPosRx4.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1AntPosRx4.Location = new Point(44, 149);
			this.m_lblTs1AntPosRx4.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1AntPosRx4.Name = "m_lblTs1AntPosRx4";
			this.m_lblTs1AntPosRx4.Size = new Size(57, 17);
			this.m_lblTs1AntPosRx4.TabIndex = 56;
			this.m_lblTs1AntPosRx4.Text = "RX4 (λ)";
			this.m_nudTs1AntPosRx4Z.DecimalPlaces = 3;
			this.m_nudTs1AntPosRx4Z.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosRx4Z.Location = new Point(249, 146);
			this.m_nudTs1AntPosRx4Z.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosRx4Z = this.m_nudTs1AntPosRx4Z;
			int[] array7 = new int[4];
			array7[0] = 32;
			nudTs1AntPosRx4Z.Maximum = new decimal(array7);
			this.m_nudTs1AntPosRx4Z.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosRx4Z.Name = "m_nudTs1AntPosRx4Z";
			this.m_nudTs1AntPosRx4Z.Size = new Size(82, 25);
			this.m_nudTs1AntPosRx4Z.TabIndex = 34;
			this.m_nudTs1AntPosRx4Z.ValueChanged += this.Rx4AntennaPosZValueChanged;
			this.m_nudTs1AntPosRx4X.DecimalPlaces = 3;
			this.m_nudTs1AntPosRx4X.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosRx4X.Location = new Point(125, 146);
			this.m_nudTs1AntPosRx4X.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosRx4X = this.m_nudTs1AntPosRx4X;
			int[] array8 = new int[4];
			array8[0] = 32;
			nudTs1AntPosRx4X.Maximum = new decimal(array8);
			this.m_nudTs1AntPosRx4X.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosRx4X.Name = "m_nudTs1AntPosRx4X";
			this.m_nudTs1AntPosRx4X.Size = new Size(82, 25);
			this.m_nudTs1AntPosRx4X.TabIndex = 33;
			this.m_nudTs1AntPosRx4X.Value = new decimal(new int[]
			{
				15,
				0,
				0,
				65536
			});
			this.m_nudTs1AntPosRx4X.ValueChanged += this.Rx4AntennaPosXValueChanged;
			this.m_lblTs1AntPosRx3.AutoSize = true;
			this.m_lblTs1AntPosRx3.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1AntPosRx3.Location = new Point(44, 116);
			this.m_lblTs1AntPosRx3.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1AntPosRx3.Name = "m_lblTs1AntPosRx3";
			this.m_lblTs1AntPosRx3.Size = new Size(57, 17);
			this.m_lblTs1AntPosRx3.TabIndex = 53;
			this.m_lblTs1AntPosRx3.Text = "RX3 (λ)";
			this.m_nudTs1AntPosRx3Z.DecimalPlaces = 3;
			this.m_nudTs1AntPosRx3Z.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosRx3Z.Location = new Point(249, 114);
			this.m_nudTs1AntPosRx3Z.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosRx3Z = this.m_nudTs1AntPosRx3Z;
			int[] array9 = new int[4];
			array9[0] = 32;
			nudTs1AntPosRx3Z.Maximum = new decimal(array9);
			this.m_nudTs1AntPosRx3Z.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosRx3Z.Name = "m_nudTs1AntPosRx3Z";
			this.m_nudTs1AntPosRx3Z.Size = new Size(82, 25);
			this.m_nudTs1AntPosRx3Z.TabIndex = 32;
			this.m_nudTs1AntPosRx3Z.ValueChanged += this.Rx3AntennaPosZValueChanged;
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label2.Location = new Point(276, 20);
			this.label2.Margin = new Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new Size(16, 17);
			this.label2.TabIndex = 59;
			this.label2.Text = "z";
			this.m_lblTs1AntPosRx2.AutoSize = true;
			this.m_lblTs1AntPosRx2.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1AntPosRx2.Location = new Point(44, 81);
			this.m_lblTs1AntPosRx2.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1AntPosRx2.Name = "m_lblTs1AntPosRx2";
			this.m_lblTs1AntPosRx2.Size = new Size(57, 17);
			this.m_lblTs1AntPosRx2.TabIndex = 51;
			this.m_lblTs1AntPosRx2.Text = "RX2 (λ)";
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.label1.Location = new Point(159, 20);
			this.label1.Margin = new Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(15, 17);
			this.label1.TabIndex = 58;
			this.label1.Text = "x";
			this.m_nudTs1AntPosRx3X.DecimalPlaces = 3;
			this.m_nudTs1AntPosRx3X.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosRx3X.Location = new Point(125, 114);
			this.m_nudTs1AntPosRx3X.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosRx3X = this.m_nudTs1AntPosRx3X;
			int[] array10 = new int[4];
			array10[0] = 32;
			nudTs1AntPosRx3X.Maximum = new decimal(array10);
			this.m_nudTs1AntPosRx3X.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosRx3X.Name = "m_nudTs1AntPosRx3X";
			this.m_nudTs1AntPosRx3X.Size = new Size(82, 25);
			this.m_nudTs1AntPosRx3X.TabIndex = 31;
			NumericUpDown nudTs1AntPosRx3X2 = this.m_nudTs1AntPosRx3X;
			int[] array11 = new int[4];
			array11[0] = 1;
			nudTs1AntPosRx3X2.Value = new decimal(array11);
			this.m_nudTs1AntPosRx3X.ValueChanged += this.Rx3AntennaPosXValueChanged;
			this.m_nudTs1AntPosRx2Z.DecimalPlaces = 3;
			this.m_nudTs1AntPosRx2Z.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosRx2Z.Location = new Point(248, 79);
			this.m_nudTs1AntPosRx2Z.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosRx2Z = this.m_nudTs1AntPosRx2Z;
			int[] array12 = new int[4];
			array12[0] = 32;
			nudTs1AntPosRx2Z.Maximum = new decimal(array12);
			this.m_nudTs1AntPosRx2Z.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosRx2Z.Name = "m_nudTs1AntPosRx2Z";
			this.m_nudTs1AntPosRx2Z.Size = new Size(82, 25);
			this.m_nudTs1AntPosRx2Z.TabIndex = 30;
			this.m_nudTs1AntPosRx2Z.ValueChanged += this.Rx2AntennaPosZValueChanged;
			this.m_nudTs1AntPosRx2X.DecimalPlaces = 3;
			this.m_nudTs1AntPosRx2X.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosRx2X.Location = new Point(125, 79);
			this.m_nudTs1AntPosRx2X.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosRx2X = this.m_nudTs1AntPosRx2X;
			int[] array13 = new int[4];
			array13[0] = 32;
			nudTs1AntPosRx2X.Maximum = new decimal(array13);
			this.m_nudTs1AntPosRx2X.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosRx2X.Name = "m_nudTs1AntPosRx2X";
			this.m_nudTs1AntPosRx2X.Size = new Size(82, 25);
			this.m_nudTs1AntPosRx2X.TabIndex = 29;
			this.m_nudTs1AntPosRx2X.Value = new decimal(new int[]
			{
				5,
				0,
				0,
				65536
			});
			this.m_nudTs1AntPosRx2X.ValueChanged += this.Rx2AntennaPosxValueChanged;
			this.m_lblTs1AntPosRx1.AutoSize = true;
			this.m_lblTs1AntPosRx1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1AntPosRx1.Location = new Point(44, 49);
			this.m_lblTs1AntPosRx1.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1AntPosRx1.Name = "m_lblTs1AntPosRx1";
			this.m_lblTs1AntPosRx1.Size = new Size(57, 17);
			this.m_lblTs1AntPosRx1.TabIndex = 48;
			this.m_lblTs1AntPosRx1.Text = "RX1 (λ)";
			this.m_nudTs1AntPosRx1Z.DecimalPlaces = 3;
			this.m_nudTs1AntPosRx1Z.Enabled = false;
			this.m_nudTs1AntPosRx1Z.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosRx1Z.Location = new Point(249, 46);
			this.m_nudTs1AntPosRx1Z.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosRx1Z = this.m_nudTs1AntPosRx1Z;
			int[] array14 = new int[4];
			array14[0] = 32;
			nudTs1AntPosRx1Z.Maximum = new decimal(array14);
			this.m_nudTs1AntPosRx1Z.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosRx1Z.Name = "m_nudTs1AntPosRx1Z";
			this.m_nudTs1AntPosRx1Z.Size = new Size(82, 25);
			this.m_nudTs1AntPosRx1Z.TabIndex = 28;
			this.m_nudTs1AntPosRx1Z.ValueChanged += this.Rx1AntennaPosZValueChanged;
			this.m_nudTs1AntPosRx1X.DecimalPlaces = 3;
			this.m_nudTs1AntPosRx1X.Enabled = false;
			this.m_nudTs1AntPosRx1X.Increment = new decimal(new int[]
			{
				125,
				0,
				0,
				196608
			});
			this.m_nudTs1AntPosRx1X.Location = new Point(125, 46);
			this.m_nudTs1AntPosRx1X.Margin = new Padding(2);
			NumericUpDown nudTs1AntPosRx1X = this.m_nudTs1AntPosRx1X;
			int[] array15 = new int[4];
			array15[0] = 32;
			nudTs1AntPosRx1X.Maximum = new decimal(array15);
			this.m_nudTs1AntPosRx1X.Minimum = new decimal(new int[]
			{
				32,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1AntPosRx1X.Name = "m_nudTs1AntPosRx1X";
			this.m_nudTs1AntPosRx1X.Size = new Size(82, 25);
			this.m_nudTs1AntPosRx1X.TabIndex = 27;
			this.m_nudTs1AntPosRx1X.ValueChanged += this.Rx1AntennaPosXValueChanged;
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2Sig);
			this.m_grpTs1Obj2.Controls.Add(this.m_lblTs1Obj2Sig);
			this.m_grpTs1Obj2.Controls.Add(this.m_lblTs1Obj2BoundMax);
			this.m_grpTs1Obj2.Controls.Add(this.m_lblTs1Obj2Pos1);
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2PosZ);
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2BoundMaxY);
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2PosX);
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2BoundMaxX);
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2PosY);
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2BoundMaxZ);
			this.m_grpTs1Obj2.Controls.Add(this.m_lblTs1Obj2Vel1);
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2VelZ);
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2BoundMinY);
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2VelX);
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2BoundMinX);
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2VelY);
			this.m_grpTs1Obj2.Controls.Add(this.m_nudTs1Obj2BoundMinZ);
			this.m_grpTs1Obj2.Controls.Add(this.m_lblTs1Obj2BoundMin);
			this.m_grpTs1Obj2.Location = new Point(549, 172);
			this.m_grpTs1Obj2.Margin = new Padding(2);
			this.m_grpTs1Obj2.Name = "m_grpTs1Obj2";
			this.m_grpTs1Obj2.Padding = new Padding(2);
			this.m_grpTs1Obj2.Size = new Size(514, 236);
			this.m_grpTs1Obj2.TabIndex = 2;
			this.m_grpTs1Obj2.TabStop = false;
			this.m_grpTs1Obj2.Text = "Object2";
			this.m_nudTs1Obj2Sig.DecimalPlaces = 2;
			this.m_nudTs1Obj2Sig.Increment = new decimal(new int[]
			{
				25,
				0,
				0,
				131072
			});
			this.m_nudTs1Obj2Sig.Location = new Point(179, 196);
			this.m_nudTs1Obj2Sig.Margin = new Padding(2);
			this.m_nudTs1Obj2Sig.Maximum = new decimal(new int[4]);
			this.m_nudTs1Obj2Sig.Minimum = new decimal(new int[]
			{
				9550,
				0,
				0,
				-2147352576
			});
			this.m_nudTs1Obj2Sig.Name = "m_nudTs1Obj2Sig";
			this.m_nudTs1Obj2Sig.Size = new Size(82, 25);
			this.m_nudTs1Obj2Sig.TabIndex = 26;
			this.m_nudTs1Obj2Sig.Value = new decimal(new int[]
			{
				95,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj2Sig.ValueChanged += this.m_nudTs1Obj2Sig_ValueChanged;
			this.m_lblTs1Obj2Sig.AutoSize = true;
			this.m_lblTs1Obj2Sig.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1Obj2Sig.Location = new Point(10, 196);
			this.m_lblTs1Obj2Sig.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1Obj2Sig.Name = "m_lblTs1Obj2Sig";
			this.m_lblTs1Obj2Sig.Size = new Size(137, 17);
			this.m_lblTs1Obj2Sig.TabIndex = 69;
			this.m_lblTs1Obj2Sig.Text = "Signal Level (dBFS)";
			this.m_lblTs1Obj2BoundMax.AutoSize = true;
			this.m_lblTs1Obj2BoundMax.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1Obj2BoundMax.Location = new Point(10, 155);
			this.m_lblTs1Obj2BoundMax.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1Obj2BoundMax.Name = "m_lblTs1Obj2BoundMax";
			this.m_lblTs1Obj2BoundMax.Size = new Size(131, 17);
			this.m_lblTs1Obj2BoundMax.TabIndex = 64;
			this.m_lblTs1Obj2BoundMax.Text = "BoundaryMax (cm)";
			this.m_lblTs1Obj2Pos1.AutoSize = true;
			this.m_lblTs1Obj2Pos1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1Obj2Pos1.Location = new Point(10, 31);
			this.m_lblTs1Obj2Pos1.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1Obj2Pos1.Name = "m_lblTs1Obj2Pos1";
			this.m_lblTs1Obj2Pos1.Size = new Size(87, 17);
			this.m_lblTs1Obj2Pos1.TabIndex = 44;
			this.m_lblTs1Obj2Pos1.Text = "Position (m)";
			this.m_nudTs1Obj2PosZ.DecimalPlaces = 2;
			this.m_nudTs1Obj2PosZ.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudTs1Obj2PosZ.Location = new Point(395, 24);
			this.m_nudTs1Obj2PosZ.Margin = new Padding(2);
			NumericUpDown nudTs1Obj2PosZ = this.m_nudTs1Obj2PosZ;
			int[] array16 = new int[4];
			array16[0] = 32767;
			nudTs1Obj2PosZ.Maximum = new decimal(array16);
			this.m_nudTs1Obj2PosZ.Minimum = new decimal(new int[]
			{
				32768,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj2PosZ.Name = "m_nudTs1Obj2PosZ";
			this.m_nudTs1Obj2PosZ.Size = new Size(82, 25);
			this.m_nudTs1Obj2PosZ.TabIndex = 16;
			this.m_nudTs1Obj2BoundMaxY.DecimalPlaces = 1;
			this.m_nudTs1Obj2BoundMaxY.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj2BoundMaxY.Location = new Point(288, 155);
			this.m_nudTs1Obj2BoundMaxY.Margin = new Padding(2);
			NumericUpDown nudTs1Obj2BoundMaxY = this.m_nudTs1Obj2BoundMaxY;
			int[] array17 = new int[4];
			array17[0] = 327;
			nudTs1Obj2BoundMaxY.Maximum = new decimal(array17);
			this.m_nudTs1Obj2BoundMaxY.Minimum = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj2BoundMaxY.Name = "m_nudTs1Obj2BoundMaxY";
			this.m_nudTs1Obj2BoundMaxY.Size = new Size(82, 25);
			this.m_nudTs1Obj2BoundMaxY.TabIndex = 24;
			NumericUpDown nudTs1Obj2BoundMaxY2 = this.m_nudTs1Obj2BoundMaxY;
			int[] array18 = new int[4];
			array18[0] = 327;
			nudTs1Obj2BoundMaxY2.Value = new decimal(array18);
			this.m_nudTs1Obj2PosX.DecimalPlaces = 2;
			this.m_nudTs1Obj2PosX.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudTs1Obj2PosX.Location = new Point(179, 24);
			this.m_nudTs1Obj2PosX.Margin = new Padding(2);
			NumericUpDown nudTs1Obj2PosX = this.m_nudTs1Obj2PosX;
			int[] array19 = new int[4];
			array19[0] = 327;
			nudTs1Obj2PosX.Maximum = new decimal(array19);
			this.m_nudTs1Obj2PosX.Minimum = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj2PosX.Name = "m_nudTs1Obj2PosX";
			this.m_nudTs1Obj2PosX.Size = new Size(82, 25);
			this.m_nudTs1Obj2PosX.TabIndex = 14;
			NumericUpDown nudTs1Obj2PosX2 = this.m_nudTs1Obj2PosX;
			int[] array20 = new int[4];
			array20[0] = 327;
			nudTs1Obj2PosX2.Value = new decimal(array20);
			this.m_nudTs1Obj2BoundMaxX.DecimalPlaces = 1;
			this.m_nudTs1Obj2BoundMaxX.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj2BoundMaxX.Location = new Point(179, 155);
			this.m_nudTs1Obj2BoundMaxX.Margin = new Padding(2);
			NumericUpDown nudTs1Obj2BoundMaxX = this.m_nudTs1Obj2BoundMaxX;
			int[] array21 = new int[4];
			array21[0] = 327;
			nudTs1Obj2BoundMaxX.Maximum = new decimal(array21);
			this.m_nudTs1Obj2BoundMaxX.Minimum = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj2BoundMaxX.Name = "m_nudTs1Obj2BoundMaxX";
			this.m_nudTs1Obj2BoundMaxX.Size = new Size(82, 25);
			this.m_nudTs1Obj2BoundMaxX.TabIndex = 23;
			NumericUpDown nudTs1Obj2BoundMaxX2 = this.m_nudTs1Obj2BoundMaxX;
			int[] array22 = new int[4];
			array22[0] = 327;
			nudTs1Obj2BoundMaxX2.Value = new decimal(array22);
			this.m_nudTs1Obj2PosY.DecimalPlaces = 2;
			this.m_nudTs1Obj2PosY.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudTs1Obj2PosY.Location = new Point(288, 24);
			this.m_nudTs1Obj2PosY.Margin = new Padding(2);
			NumericUpDown nudTs1Obj2PosY = this.m_nudTs1Obj2PosY;
			int[] array23 = new int[4];
			array23[0] = 327;
			nudTs1Obj2PosY.Maximum = new decimal(array23);
			this.m_nudTs1Obj2PosY.Name = "m_nudTs1Obj2PosY";
			this.m_nudTs1Obj2PosY.Size = new Size(82, 25);
			this.m_nudTs1Obj2PosY.TabIndex = 15;
			NumericUpDown nudTs1Obj2PosY2 = this.m_nudTs1Obj2PosY;
			int[] array24 = new int[4];
			array24[0] = 327;
			nudTs1Obj2PosY2.Value = new decimal(array24);
			this.m_nudTs1Obj2BoundMaxZ.DecimalPlaces = 1;
			this.m_nudTs1Obj2BoundMaxZ.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj2BoundMaxZ.Location = new Point(395, 155);
			this.m_nudTs1Obj2BoundMaxZ.Margin = new Padding(2);
			NumericUpDown nudTs1Obj2BoundMaxZ = this.m_nudTs1Obj2BoundMaxZ;
			int[] array25 = new int[4];
			array25[0] = 327;
			nudTs1Obj2BoundMaxZ.Maximum = new decimal(array25);
			this.m_nudTs1Obj2BoundMaxZ.Minimum = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj2BoundMaxZ.Name = "m_nudTs1Obj2BoundMaxZ";
			this.m_nudTs1Obj2BoundMaxZ.Size = new Size(82, 25);
			this.m_nudTs1Obj2BoundMaxZ.TabIndex = 25;
			NumericUpDown nudTs1Obj2BoundMaxZ2 = this.m_nudTs1Obj2BoundMaxZ;
			int[] array26 = new int[4];
			array26[0] = 327;
			nudTs1Obj2BoundMaxZ2.Value = new decimal(array26);
			this.m_lblTs1Obj2Vel1.AutoSize = true;
			this.m_lblTs1Obj2Vel1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1Obj2Vel1.Location = new Point(10, 75);
			this.m_lblTs1Obj2Vel1.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1Obj2Vel1.Name = "m_lblTs1Obj2Vel1";
			this.m_lblTs1Obj2Vel1.Size = new Size(96, 17);
			this.m_lblTs1Obj2Vel1.TabIndex = 56;
			this.m_lblTs1Obj2Vel1.Text = "Velocity (m/s)";
			this.m_nudTs1Obj2VelZ.DecimalPlaces = 1;
			this.m_nudTs1Obj2VelZ.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj2VelZ.Location = new Point(395, 68);
			this.m_nudTs1Obj2VelZ.Margin = new Padding(2);
			this.m_nudTs1Obj2VelZ.Maximum = new decimal(new int[]
			{
				501,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj2VelZ.Minimum = new decimal(new int[]
			{
				501,
				0,
				0,
				-2147418112
			});
			this.m_nudTs1Obj2VelZ.Name = "m_nudTs1Obj2VelZ";
			this.m_nudTs1Obj2VelZ.Size = new Size(82, 25);
			this.m_nudTs1Obj2VelZ.TabIndex = 19;
			this.m_nudTs1Obj2BoundMinY.DecimalPlaces = 1;
			this.m_nudTs1Obj2BoundMinY.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj2BoundMinY.Location = new Point(288, 111);
			this.m_nudTs1Obj2BoundMinY.Margin = new Padding(2);
			NumericUpDown nudTs1Obj2BoundMinY = this.m_nudTs1Obj2BoundMinY;
			int[] array27 = new int[4];
			array27[0] = 327;
			nudTs1Obj2BoundMinY.Maximum = new decimal(array27);
			this.m_nudTs1Obj2BoundMinY.Minimum = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj2BoundMinY.Name = "m_nudTs1Obj2BoundMinY";
			this.m_nudTs1Obj2BoundMinY.Size = new Size(82, 25);
			this.m_nudTs1Obj2BoundMinY.TabIndex = 21;
			this.m_nudTs1Obj2VelX.DecimalPlaces = 1;
			this.m_nudTs1Obj2VelX.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj2VelX.Location = new Point(179, 68);
			this.m_nudTs1Obj2VelX.Margin = new Padding(2);
			this.m_nudTs1Obj2VelX.Maximum = new decimal(new int[]
			{
				501,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj2VelX.Minimum = new decimal(new int[]
			{
				501,
				0,
				0,
				-2147418112
			});
			this.m_nudTs1Obj2VelX.Name = "m_nudTs1Obj2VelX";
			this.m_nudTs1Obj2VelX.Size = new Size(82, 25);
			this.m_nudTs1Obj2VelX.TabIndex = 17;
			this.m_nudTs1Obj2BoundMinX.DecimalPlaces = 1;
			this.m_nudTs1Obj2BoundMinX.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj2BoundMinX.Location = new Point(179, 111);
			this.m_nudTs1Obj2BoundMinX.Margin = new Padding(2);
			NumericUpDown nudTs1Obj2BoundMinX = this.m_nudTs1Obj2BoundMinX;
			int[] array28 = new int[4];
			array28[0] = 327;
			nudTs1Obj2BoundMinX.Maximum = new decimal(array28);
			this.m_nudTs1Obj2BoundMinX.Minimum = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj2BoundMinX.Name = "m_nudTs1Obj2BoundMinX";
			this.m_nudTs1Obj2BoundMinX.Size = new Size(82, 25);
			this.m_nudTs1Obj2BoundMinX.TabIndex = 20;
			this.m_nudTs1Obj2BoundMinX.Value = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj2VelY.DecimalPlaces = 1;
			this.m_nudTs1Obj2VelY.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj2VelY.Location = new Point(288, 68);
			this.m_nudTs1Obj2VelY.Margin = new Padding(2);
			this.m_nudTs1Obj2VelY.Maximum = new decimal(new int[]
			{
				501,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj2VelY.Minimum = new decimal(new int[]
			{
				501,
				0,
				0,
				-2147418112
			});
			this.m_nudTs1Obj2VelY.Name = "m_nudTs1Obj2VelY";
			this.m_nudTs1Obj2VelY.Size = new Size(82, 25);
			this.m_nudTs1Obj2VelY.TabIndex = 18;
			this.m_nudTs1Obj2BoundMinZ.DecimalPlaces = 1;
			this.m_nudTs1Obj2BoundMinZ.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj2BoundMinZ.Location = new Point(395, 111);
			this.m_nudTs1Obj2BoundMinZ.Margin = new Padding(2);
			NumericUpDown nudTs1Obj2BoundMinZ = this.m_nudTs1Obj2BoundMinZ;
			int[] array29 = new int[4];
			array29[0] = 327;
			nudTs1Obj2BoundMinZ.Maximum = new decimal(array29);
			this.m_nudTs1Obj2BoundMinZ.Minimum = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj2BoundMinZ.Name = "m_nudTs1Obj2BoundMinZ";
			this.m_nudTs1Obj2BoundMinZ.Size = new Size(82, 25);
			this.m_nudTs1Obj2BoundMinZ.TabIndex = 22;
			this.m_nudTs1Obj2BoundMinZ.Value = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_lblTs1Obj2BoundMin.AutoSize = true;
			this.m_lblTs1Obj2BoundMin.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1Obj2BoundMin.Location = new Point(10, 114);
			this.m_lblTs1Obj2BoundMin.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1Obj2BoundMin.Name = "m_lblTs1Obj2BoundMin";
			this.m_lblTs1Obj2BoundMin.Size = new Size(123, 17);
			this.m_lblTs1Obj2BoundMin.TabIndex = 60;
			this.m_lblTs1Obj2BoundMin.Text = "BoundaryMin (m) ";
			this.m_lblTsZ.AutoSize = true;
			this.m_lblTsZ.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTsZ.Location = new Point(448, 152);
			this.m_lblTsZ.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTsZ.Name = "m_lblTsZ";
			this.m_lblTsZ.Size = new Size(16, 17);
			this.m_lblTsZ.TabIndex = 51;
			this.m_lblTsZ.Text = "z";
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1Sig);
			this.m_grpTs1Obj1.Controls.Add(this.m_lblTs1Obj1Sig);
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1BoundMaxY);
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1BoundMaxX);
			this.m_grpTs1Obj1.Controls.Add(this.m_lblTs1Obj1Pos1);
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1BoundMaxZ);
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1PosZ);
			this.m_grpTs1Obj1.Controls.Add(this.m_lblTs1Obj1BoundMax);
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1PosX);
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1BoundMinY);
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1PosY);
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1BoundMinX);
			this.m_grpTs1Obj1.Controls.Add(this.m_lblTs1Obj1Vel1);
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1BoundMinZ);
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1VelZ);
			this.m_grpTs1Obj1.Controls.Add(this.m_lblTs1Obj1BoundMin);
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1VelX);
			this.m_grpTs1Obj1.Controls.Add(this.m_nudTs1Obj1VelY);
			this.m_grpTs1Obj1.Location = new Point(30, 172);
			this.m_grpTs1Obj1.Margin = new Padding(2);
			this.m_grpTs1Obj1.Name = "m_grpTs1Obj1";
			this.m_grpTs1Obj1.Padding = new Padding(2);
			this.m_grpTs1Obj1.Size = new Size(514, 236);
			this.m_grpTs1Obj1.TabIndex = 1;
			this.m_grpTs1Obj1.TabStop = false;
			this.m_grpTs1Obj1.Text = "Object1";
			this.m_nudTs1Obj1Sig.DecimalPlaces = 2;
			this.m_nudTs1Obj1Sig.Increment = new decimal(new int[]
			{
				25,
				0,
				0,
				131072
			});
			this.m_nudTs1Obj1Sig.Location = new Point(179, 191);
			this.m_nudTs1Obj1Sig.Margin = new Padding(2);
			this.m_nudTs1Obj1Sig.Maximum = new decimal(new int[4]);
			this.m_nudTs1Obj1Sig.Minimum = new decimal(new int[]
			{
				250,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj1Sig.Name = "m_nudTs1Obj1Sig";
			this.m_nudTs1Obj1Sig.Size = new Size(82, 25);
			this.m_nudTs1Obj1Sig.TabIndex = 13;
			this.m_nudTs1Obj1Sig.Value = new decimal(new int[]
			{
				25,
				0,
				0,
				-2147418112
			});
			this.m_lblTs1Obj1Sig.AutoSize = true;
			this.m_lblTs1Obj1Sig.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1Obj1Sig.Location = new Point(10, 191);
			this.m_lblTs1Obj1Sig.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1Obj1Sig.Name = "m_lblTs1Obj1Sig";
			this.m_lblTs1Obj1Sig.Size = new Size(137, 17);
			this.m_lblTs1Obj1Sig.TabIndex = 68;
			this.m_lblTs1Obj1Sig.Text = "Signal Level (dBFS)";
			this.m_nudTs1Obj1BoundMaxY.DecimalPlaces = 1;
			this.m_nudTs1Obj1BoundMaxY.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1BoundMaxY.Location = new Point(288, 148);
			this.m_nudTs1Obj1BoundMaxY.Margin = new Padding(2);
			NumericUpDown nudTs1Obj1BoundMaxY = this.m_nudTs1Obj1BoundMaxY;
			int[] array30 = new int[4];
			array30[0] = 327;
			nudTs1Obj1BoundMaxY.Maximum = new decimal(array30);
			this.m_nudTs1Obj1BoundMaxY.Minimum = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj1BoundMaxY.Name = "m_nudTs1Obj1BoundMaxY";
			this.m_nudTs1Obj1BoundMaxY.Size = new Size(82, 25);
			this.m_nudTs1Obj1BoundMaxY.TabIndex = 11;
			NumericUpDown nudTs1Obj1BoundMaxY2 = this.m_nudTs1Obj1BoundMaxY;
			int[] array31 = new int[4];
			array31[0] = 327;
			nudTs1Obj1BoundMaxY2.Value = new decimal(array31);
			this.m_nudTs1Obj1BoundMaxX.DecimalPlaces = 1;
			this.m_nudTs1Obj1BoundMaxX.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1BoundMaxX.Location = new Point(179, 148);
			this.m_nudTs1Obj1BoundMaxX.Margin = new Padding(2);
			NumericUpDown nudTs1Obj1BoundMaxX = this.m_nudTs1Obj1BoundMaxX;
			int[] array32 = new int[4];
			array32[0] = 327;
			nudTs1Obj1BoundMaxX.Maximum = new decimal(array32);
			this.m_nudTs1Obj1BoundMaxX.Minimum = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj1BoundMaxX.Name = "m_nudTs1Obj1BoundMaxX";
			this.m_nudTs1Obj1BoundMaxX.Size = new Size(82, 25);
			this.m_nudTs1Obj1BoundMaxX.TabIndex = 10;
			NumericUpDown nudTs1Obj1BoundMaxX2 = this.m_nudTs1Obj1BoundMaxX;
			int[] array33 = new int[4];
			array33[0] = 327;
			nudTs1Obj1BoundMaxX2.Value = new decimal(array33);
			this.m_lblTs1Obj1Pos1.AutoSize = true;
			this.m_lblTs1Obj1Pos1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1Obj1Pos1.Location = new Point(10, 29);
			this.m_lblTs1Obj1Pos1.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1Obj1Pos1.Name = "m_lblTs1Obj1Pos1";
			this.m_lblTs1Obj1Pos1.Size = new Size(87, 17);
			this.m_lblTs1Obj1Pos1.TabIndex = 44;
			this.m_lblTs1Obj1Pos1.Text = "Position (m)";
			this.m_nudTs1Obj1BoundMaxZ.DecimalPlaces = 1;
			this.m_nudTs1Obj1BoundMaxZ.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1BoundMaxZ.Location = new Point(395, 148);
			this.m_nudTs1Obj1BoundMaxZ.Margin = new Padding(2);
			NumericUpDown nudTs1Obj1BoundMaxZ = this.m_nudTs1Obj1BoundMaxZ;
			int[] array34 = new int[4];
			array34[0] = 327;
			nudTs1Obj1BoundMaxZ.Maximum = new decimal(array34);
			this.m_nudTs1Obj1BoundMaxZ.Minimum = new decimal(new int[]
			{
				327,
				0,
				0,
				int.MinValue
			});
			this.m_nudTs1Obj1BoundMaxZ.Name = "m_nudTs1Obj1BoundMaxZ";
			this.m_nudTs1Obj1BoundMaxZ.Size = new Size(82, 25);
			this.m_nudTs1Obj1BoundMaxZ.TabIndex = 12;
			NumericUpDown nudTs1Obj1BoundMaxZ2 = this.m_nudTs1Obj1BoundMaxZ;
			int[] array35 = new int[4];
			array35[0] = 327;
			nudTs1Obj1BoundMaxZ2.Value = new decimal(array35);
			this.m_nudTs1Obj1PosZ.DecimalPlaces = 2;
			this.m_nudTs1Obj1PosZ.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudTs1Obj1PosZ.Location = new Point(395, 29);
			this.m_nudTs1Obj1PosZ.Margin = new Padding(2);
			this.m_nudTs1Obj1PosZ.Maximum = new decimal(new int[]
			{
				3276,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1PosZ.Minimum = new decimal(new int[]
			{
				3276,
				0,
				0,
				-2147418112
			});
			this.m_nudTs1Obj1PosZ.Name = "m_nudTs1Obj1PosZ";
			this.m_nudTs1Obj1PosZ.Size = new Size(82, 25);
			this.m_nudTs1Obj1PosZ.TabIndex = 3;
			this.m_lblTs1Obj1BoundMax.AutoSize = true;
			this.m_lblTs1Obj1BoundMax.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1Obj1BoundMax.Location = new Point(10, 148);
			this.m_lblTs1Obj1BoundMax.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1Obj1BoundMax.Name = "m_lblTs1Obj1BoundMax";
			this.m_lblTs1Obj1BoundMax.Size = new Size(127, 17);
			this.m_lblTs1Obj1BoundMax.TabIndex = 64;
			this.m_lblTs1Obj1BoundMax.Text = "BoundaryMax (m) ";
			this.m_nudTs1Obj1PosX.DecimalPlaces = 2;
			this.m_nudTs1Obj1PosX.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudTs1Obj1PosX.Location = new Point(179, 29);
			this.m_nudTs1Obj1PosX.Margin = new Padding(2);
			this.m_nudTs1Obj1PosX.Maximum = new decimal(new int[]
			{
				3276,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1PosX.Minimum = new decimal(new int[]
			{
				3276,
				0,
				0,
				-2147418112
			});
			this.m_nudTs1Obj1PosX.Name = "m_nudTs1Obj1PosX";
			this.m_nudTs1Obj1PosX.Size = new Size(82, 25);
			this.m_nudTs1Obj1PosX.TabIndex = 1;
			NumericUpDown nudTs1Obj1PosX = this.m_nudTs1Obj1PosX;
			int[] array36 = new int[4];
			array36[0] = 4;
			nudTs1Obj1PosX.Value = new decimal(array36);
			this.m_nudTs1Obj1BoundMinY.DecimalPlaces = 1;
			this.m_nudTs1Obj1BoundMinY.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1BoundMinY.Location = new Point(288, 106);
			this.m_nudTs1Obj1BoundMinY.Margin = new Padding(2);
			this.m_nudTs1Obj1BoundMinY.Maximum = new decimal(new int[]
			{
				3277,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1BoundMinY.Minimum = new decimal(new int[]
			{
				3277,
				0,
				0,
				-2147418112
			});
			this.m_nudTs1Obj1BoundMinY.Name = "m_nudTs1Obj1BoundMinY";
			this.m_nudTs1Obj1BoundMinY.Size = new Size(82, 25);
			this.m_nudTs1Obj1BoundMinY.TabIndex = 8;
			this.m_nudTs1Obj1PosY.DecimalPlaces = 2;
			this.m_nudTs1Obj1PosY.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.m_nudTs1Obj1PosY.Location = new Point(288, 29);
			this.m_nudTs1Obj1PosY.Margin = new Padding(2);
			this.m_nudTs1Obj1PosY.Maximum = new decimal(new int[]
			{
				3276,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1PosY.Name = "m_nudTs1Obj1PosY";
			this.m_nudTs1Obj1PosY.Size = new Size(82, 25);
			this.m_nudTs1Obj1PosY.TabIndex = 2;
			NumericUpDown nudTs1Obj1PosY = this.m_nudTs1Obj1PosY;
			int[] array37 = new int[4];
			array37[0] = 3;
			nudTs1Obj1PosY.Value = new decimal(array37);
			this.m_nudTs1Obj1BoundMinX.DecimalPlaces = 1;
			this.m_nudTs1Obj1BoundMinX.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1BoundMinX.Location = new Point(179, 106);
			this.m_nudTs1Obj1BoundMinX.Margin = new Padding(2);
			this.m_nudTs1Obj1BoundMinX.Maximum = new decimal(new int[]
			{
				3277,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1BoundMinX.Minimum = new decimal(new int[]
			{
				3277,
				0,
				0,
				-2147418112
			});
			this.m_nudTs1Obj1BoundMinX.Name = "m_nudTs1Obj1BoundMinX";
			this.m_nudTs1Obj1BoundMinX.Size = new Size(82, 25);
			this.m_nudTs1Obj1BoundMinX.TabIndex = 7;
			this.m_nudTs1Obj1BoundMinX.Value = new decimal(new int[]
			{
				3276,
				0,
				0,
				-2147418112
			});
			this.m_lblTs1Obj1Vel1.AutoSize = true;
			this.m_lblTs1Obj1Vel1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1Obj1Vel1.Location = new Point(10, 68);
			this.m_lblTs1Obj1Vel1.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1Obj1Vel1.Name = "m_lblTs1Obj1Vel1";
			this.m_lblTs1Obj1Vel1.Size = new Size(96, 17);
			this.m_lblTs1Obj1Vel1.TabIndex = 56;
			this.m_lblTs1Obj1Vel1.Text = "Velocity (m/s)";
			this.m_nudTs1Obj1BoundMinZ.DecimalPlaces = 1;
			this.m_nudTs1Obj1BoundMinZ.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1BoundMinZ.Location = new Point(395, 106);
			this.m_nudTs1Obj1BoundMinZ.Margin = new Padding(2);
			this.m_nudTs1Obj1BoundMinZ.Maximum = new decimal(new int[]
			{
				3277,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1BoundMinZ.Minimum = new decimal(new int[]
			{
				3277,
				0,
				0,
				-2147418112
			});
			this.m_nudTs1Obj1BoundMinZ.Name = "m_nudTs1Obj1BoundMinZ";
			this.m_nudTs1Obj1BoundMinZ.Size = new Size(82, 25);
			this.m_nudTs1Obj1BoundMinZ.TabIndex = 9;
			this.m_nudTs1Obj1BoundMinZ.Value = new decimal(new int[]
			{
				3276,
				0,
				0,
				-2147418112
			});
			this.m_nudTs1Obj1VelZ.DecimalPlaces = 1;
			this.m_nudTs1Obj1VelZ.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1VelZ.Location = new Point(395, 68);
			this.m_nudTs1Obj1VelZ.Margin = new Padding(2);
			this.m_nudTs1Obj1VelZ.Maximum = new decimal(new int[]
			{
				501,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1VelZ.Minimum = new decimal(new int[]
			{
				501,
				0,
				0,
				-2147418112
			});
			this.m_nudTs1Obj1VelZ.Name = "m_nudTs1Obj1VelZ";
			this.m_nudTs1Obj1VelZ.Size = new Size(82, 25);
			this.m_nudTs1Obj1VelZ.TabIndex = 6;
			this.m_lblTs1Obj1BoundMin.AutoSize = true;
			this.m_lblTs1Obj1BoundMin.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTs1Obj1BoundMin.Location = new Point(10, 105);
			this.m_lblTs1Obj1BoundMin.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTs1Obj1BoundMin.Name = "m_lblTs1Obj1BoundMin";
			this.m_lblTs1Obj1BoundMin.Size = new Size(123, 17);
			this.m_lblTs1Obj1BoundMin.TabIndex = 60;
			this.m_lblTs1Obj1BoundMin.Text = "BoundaryMin (m) ";
			this.m_nudTs1Obj1VelX.DecimalPlaces = 1;
			this.m_nudTs1Obj1VelX.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1VelX.Location = new Point(179, 68);
			this.m_nudTs1Obj1VelX.Margin = new Padding(2);
			this.m_nudTs1Obj1VelX.Maximum = new decimal(new int[]
			{
				501,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1VelX.Minimum = new decimal(new int[]
			{
				501,
				0,
				0,
				-2147418112
			});
			this.m_nudTs1Obj1VelX.Name = "m_nudTs1Obj1VelX";
			this.m_nudTs1Obj1VelX.Size = new Size(82, 25);
			this.m_nudTs1Obj1VelX.TabIndex = 4;
			this.m_nudTs1Obj1VelY.DecimalPlaces = 1;
			this.m_nudTs1Obj1VelY.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1VelY.Location = new Point(288, 68);
			this.m_nudTs1Obj1VelY.Margin = new Padding(2);
			this.m_nudTs1Obj1VelY.Maximum = new decimal(new int[]
			{
				501,
				0,
				0,
				65536
			});
			this.m_nudTs1Obj1VelY.Minimum = new decimal(new int[]
			{
				501,
				0,
				0,
				-2147418112
			});
			this.m_nudTs1Obj1VelY.Name = "m_nudTs1Obj1VelY";
			this.m_nudTs1Obj1VelY.Size = new Size(82, 25);
			this.m_nudTs1Obj1VelY.TabIndex = 5;
			this.m_lblTsY.AutoSize = true;
			this.m_lblTsY.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTsY.Location = new Point(340, 152);
			this.m_lblTsY.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTsY.Name = "m_lblTsY";
			this.m_lblTsY.Size = new Size(15, 17);
			this.m_lblTsY.TabIndex = 50;
			this.m_lblTsY.Text = "y";
			this.m_lblTsX.AutoSize = true;
			this.m_lblTsX.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.m_lblTsX.Location = new Point(232, 152);
			this.m_lblTsX.Margin = new Padding(2, 0, 2, 0);
			this.m_lblTsX.Name = "m_lblTsX";
			this.m_lblTsX.Size = new Size(15, 17);
			this.m_lblTsX.TabIndex = 49;
			this.m_lblTsX.Text = "x";
			base.AutoScaleDimensions = new SizeF(120f, 120f);
			base.AutoScaleMode = AutoScaleMode.Dpi;
			base.Controls.Add(this.m_grpTestSource1);
			base.Margin = new Padding(4, 4, 4, 4);
			base.Name = "TestSourceTab";
			base.Size = new Size(1135, 766);
			base.Load += this.TestSourceTab_Load;
			this.m_grpTestSource1.ResumeLayout(false);
			this.m_grpTestSource1.PerformLayout();
			((ISupportInitialize)this.pictureBox1).EndInit();
			this.m_grpTs1TxAntPos.ResumeLayout(false);
			this.m_grpTs1TxAntPos.PerformLayout();
			((ISupportInitialize)this.m_nudTs1AntPosTx3Z).EndInit();
			((ISupportInitialize)this.m_nudTs1AntPosTx3X).EndInit();
			((ISupportInitialize)this.m_nudTs1AntPosTx2Z).EndInit();
			((ISupportInitialize)this.m_nudTs1AntPosTx2X).EndInit();
			((ISupportInitialize)this.m_nudTs1AntPosTx1Z).EndInit();
			((ISupportInitialize)this.m_nudTs1AntPosTx1X).EndInit();
			this.m_grpTs1RxAntPos.ResumeLayout(false);
			this.m_grpTs1RxAntPos.PerformLayout();
			((ISupportInitialize)this.m_nudTs1AntPosRx4Z).EndInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx4X).EndInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx3Z).EndInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx3X).EndInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx2Z).EndInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx2X).EndInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx1Z).EndInit();
			((ISupportInitialize)this.m_nudTs1AntPosRx1X).EndInit();
			this.m_grpTs1Obj2.ResumeLayout(false);
			this.m_grpTs1Obj2.PerformLayout();
			((ISupportInitialize)this.m_nudTs1Obj2Sig).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj2PosZ).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj2BoundMaxY).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj2PosX).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj2BoundMaxX).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj2PosY).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj2BoundMaxZ).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj2VelZ).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj2BoundMinY).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj2VelX).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj2BoundMinX).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj2VelY).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj2BoundMinZ).EndInit();
			this.m_grpTs1Obj1.ResumeLayout(false);
			this.m_grpTs1Obj1.PerformLayout();
			((ISupportInitialize)this.m_nudTs1Obj1Sig).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj1BoundMaxY).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj1BoundMaxX).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj1BoundMaxZ).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj1PosZ).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj1PosX).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj1BoundMinY).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj1PosY).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj1BoundMinX).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj1BoundMinZ).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj1VelZ).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj1VelX).EndInit();
			((ISupportInitialize)this.m_nudTs1Obj1VelY).EndInit();
			base.ResumeLayout(false);
		}

		private void PostInitialization()
		{
		}

		private GuiManager m_GuiManager = GlobalRef.GuiManager;

		private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

		private frmAR1Main m_MainForm;

		private TestSourceParams m_TestSourceParams;

		private IContainer components;

		private GroupBox m_grpTestSource1;

		private Button m_btnTs1Set;

		private GroupBox m_grpTs1TxAntPos;

		private Label m_lblTs1AntPosTx3;

		private NumericUpDown m_nudTs1AntPosTx3Z;

		private Label m_lblTs1AntPosTx2;

		private NumericUpDown m_nudTs1AntPosTx3X;

		private NumericUpDown m_nudTs1AntPosTx2Z;

		private NumericUpDown m_nudTs1AntPosTx2X;

		private Label m_lblTs1AntPosTx1;

		private NumericUpDown m_nudTs1AntPosTx1Z;

		private NumericUpDown m_nudTs1AntPosTx1X;

		private GroupBox m_grpTs1RxAntPos;

		private Label m_lblTs1AntPosRx4;

		private NumericUpDown m_nudTs1AntPosRx4Z;

		private NumericUpDown m_nudTs1AntPosRx4X;

		private Label m_lblTs1AntPosRx3;

		private NumericUpDown m_nudTs1AntPosRx3Z;

		private Label m_lblTs1AntPosRx2;

		private NumericUpDown m_nudTs1AntPosRx3X;

		private NumericUpDown m_nudTs1AntPosRx2Z;

		private NumericUpDown m_nudTs1AntPosRx2X;

		private Label m_lblTs1AntPosRx1;

		private NumericUpDown m_nudTs1AntPosRx1Z;

		private NumericUpDown m_nudTs1AntPosRx1X;

		private GroupBox m_grpTs1Obj2;

		private NumericUpDown m_nudTs1Obj2Sig;

		private Label m_lblTs1Obj2Sig;

		private Label m_lblTs1Obj2BoundMax;

		private Label m_lblTs1Obj2Pos1;

		private NumericUpDown m_nudTs1Obj2PosZ;

		private NumericUpDown m_nudTs1Obj2BoundMaxY;

		private NumericUpDown m_nudTs1Obj2PosX;

		private NumericUpDown m_nudTs1Obj2BoundMaxX;

		private NumericUpDown m_nudTs1Obj2PosY;

		private NumericUpDown m_nudTs1Obj2BoundMaxZ;

		private Label m_lblTs1Obj2Vel1;

		private NumericUpDown m_nudTs1Obj2VelZ;

		private NumericUpDown m_nudTs1Obj2BoundMinY;

		private NumericUpDown m_nudTs1Obj2VelX;

		private NumericUpDown m_nudTs1Obj2BoundMinX;

		private NumericUpDown m_nudTs1Obj2VelY;

		private NumericUpDown m_nudTs1Obj2BoundMinZ;

		private Label m_lblTs1Obj2BoundMin;

		private Label m_lblTsZ;

		private GroupBox m_grpTs1Obj1;

		private NumericUpDown m_nudTs1Obj1Sig;

		private Label m_lblTs1Obj1Sig;

		private NumericUpDown m_nudTs1Obj1BoundMaxY;

		private NumericUpDown m_nudTs1Obj1BoundMaxX;

		private Label m_lblTs1Obj1Pos1;

		private NumericUpDown m_nudTs1Obj1BoundMaxZ;

		private NumericUpDown m_nudTs1Obj1PosZ;

		private Label m_lblTs1Obj1BoundMax;

		private NumericUpDown m_nudTs1Obj1PosX;

		private NumericUpDown m_nudTs1Obj1BoundMinY;

		private NumericUpDown m_nudTs1Obj1PosY;

		private NumericUpDown m_nudTs1Obj1BoundMinX;

		private Label m_lblTs1Obj1Vel1;

		private NumericUpDown m_nudTs1Obj1BoundMinZ;

		private NumericUpDown m_nudTs1Obj1VelZ;

		private Label m_lblTs1Obj1BoundMin;

		private NumericUpDown m_nudTs1Obj1VelX;

		private NumericUpDown m_nudTs1Obj1VelY;

		private Label m_lblTsY;

		private Label m_lblTsX;

		private Label label2;

		private Label label1;

		private Label label3;

		private Label label4;

		private Label label5;

		private PictureBox pictureBox1;

		private TextBox textBox1;
	}
}
