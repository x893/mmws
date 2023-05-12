using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using InfraLib.GuiControls;

namespace AR1xController
{
    public class RegOpeTab : UserControl
    {
        public frmAR1Main MainTsfrm
        {
            get
            {
                return this.m_MainForm;
            }
            set
            {
                this.m_MainForm = value;
            }
        }

        public GuiManager GuiManager
        {
            get
            {
                return this.m_GuiManager;
            }
            set
            {
                this.m_GuiManager = value;
            }
        }

        public RegOpeTab()
        {
            this.InitializeComponent();
            this.m_MainForm = this.m_GuiManager.MainTsForm;
            this.m_cboDbgSignal.SelectedIndex = 1;
            this.m_MSSGetDataBlockConfigParams = this.m_GuiManager.TsParams.MSSGetDataBlockConfigParams;
            this.f000206 = this.m_GuiManager.TsParams.p000005;
            this.f00020f.SelectedIndex = 0;
        }

        public void Init(GuiManager gui_manager, AR1xxxWrapper ts_wrapper)
        {
            this.m_GuiManager = gui_manager;
            this.m_MainForm = gui_manager.MainTsForm;
            this.m_SPWrapper = new SerialPortWrapper();
        }

        public void m00005d(int val)
        {
            if (base.InvokeRequired)
            {
                del_v_i method = new del_v_i(this.m00005d);
                base.Invoke(method, new object[]
                {
                    val
                });
                return;
            }
            this.f00020e.Text = val.ToString("X");
            string full_command = string.Format("GPIO Value Read: 0x{0} ", new object[]
            {
                val.ToString("X")
            });
            this.m_GuiManager.RecordLog(0, full_command);
        }

        public bool UpdateGPIOReadConfigDataFrmCmd()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateGPIOReadConfigDataFrmCmd);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.f00020b.Text = Convert.ToString((long)((ulong)this.f000206.gpioBase), 10);
                this.f00020a.Text = Convert.ToString((long)((ulong)this.f000206.gpioPin), 10);
                this.f00020e.Text = Convert.ToString((long)((ulong)this.f000206.gpioValue), 10);
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        private void m00005e(object sender, EventArgs p1)
        {
            if (!GlobalRef.g_TDACaptureCardConnectStatus)
            {
                this.m_GuiManager.Error("TDA is not connected!");
                return;
            }
            this.f000206.gpioBase = Convert.ToUInt32(this.f00020b.Text);
            this.f000206.gpioPin = Convert.ToUInt32(this.f00020a.Text);
            string full_command = string.Format("ar1.gpioGetValue({0}, {1}, {2})", new object[]
            {
                GlobalRef.g_RadarDeviceId,
                this.f000206.gpioBase,
                this.f000206.gpioPin
            });
            this.m_GuiManager.RecordLog(0, full_command);
            int num = Imports.gpioGetValue(GlobalRef.g_RadarDeviceId, this.f000206.gpioBase, this.f000206.gpioPin);
            if (num == 0)
            {
                string full_command2 = string.Format("Status : Passed", new object[0]);
                this.m_GuiManager.RecordLog(0, full_command2);
                return;
            }
            this.m_GuiManager.Error("TDA GPIO Read: failed with error " + num);
        }

        public int iGPIOReadConfigFromLua_Impl(out uint gpioVal)
        {
            int num = -1;
            if (GlobalRef.g_TDACaptureCardConnectStatus)
            {
                this.f000206.gpioBase = Convert.ToUInt32(this.f00020b.Text);
                this.f000206.gpioPin = Convert.ToUInt32(this.f00020a.Text);
                GlobalRef.f0002ce = 0U;
                string full_command = string.Format("ar1.gpioGetValue({0}, {1}, {2})", new object[]
                {
                    GlobalRef.g_RadarDeviceId,
                    this.f000206.gpioBase,
                    this.f000206.gpioPin
                });
                this.m_GuiManager.RecordLog(0, full_command);
                num = Imports.gpioGetValue(GlobalRef.g_RadarDeviceId, this.f000206.gpioBase, this.f000206.gpioPin);
                if (num == 0)
                {
                    string full_command2 = string.Format("Status : Passed", new object[0]);
                    this.m_GuiManager.RecordLog(0, full_command2);
                }
                else
                {
                    this.m_GuiManager.Error("TDA GPIO Read: failed with error " + num);
                }
                while (GlobalRef.f0002ce == 0U)
                {
                    Thread.Sleep(200);
                }
                gpioVal = Convert.ToUInt32(this.f00020e.Text);
            }
            else
            {
                this.m_GuiManager.Error("TDA is not connected!");
                gpioVal = 0U;
            }
            return num;
        }

        private void m00005f(object sender, EventArgs p1)
        {
            if (!GlobalRef.g_TDACaptureCardConnectStatus)
            {
                this.m_GuiManager.Error("TDA is not connected!");
                return;
            }
            this.f000206.gpioBase = Convert.ToUInt32(this.f00020b.Text);
            this.f000206.gpioPin = Convert.ToUInt32(this.f00020a.Text);
            this.f000206.gpioValue = Convert.ToUInt32(this.f00020e.Text);
            string full_command = string.Format("ar1.gpioSetValue({0}, {1}, {2}, {3})", new object[]
            {
                GlobalRef.g_RadarDeviceId,
                this.f000206.gpioBase,
                this.f000206.gpioPin,
                this.f000206.gpioValue
            });
            this.m_GuiManager.RecordLog(0, full_command);
            int num = Imports.gpioSetValue(GlobalRef.g_RadarDeviceId, this.f000206.gpioBase, this.f000206.gpioPin, this.f000206.gpioValue);
            if (num == 0)
            {
                string full_command2 = string.Format("Status : Passed", new object[0]);
                this.m_GuiManager.RecordLog(0, full_command2);
                return;
            }
            this.m_GuiManager.Error("TDA GPIO Write: failed with error " + num);
        }

        public int iGPIOWriteConfigFromLua_Impl()
        {
            int num = -1;
            if (GlobalRef.g_TDACaptureCardConnectStatus)
            {
                this.f000206.gpioBase = Convert.ToUInt32(this.f00020b.Text);
                this.f000206.gpioPin = Convert.ToUInt32(this.f00020a.Text);
                this.f000206.gpioValue = Convert.ToUInt32(this.f00020e.Text);
                string full_command = string.Format("ar1.gpioSetValue({0}, {1}, {2}, {3})", new object[]
                {
                    GlobalRef.g_RadarDeviceId,
                    this.f000206.gpioBase,
                    this.f000206.gpioPin,
                    this.f000206.gpioValue
                });
                this.m_GuiManager.RecordLog(0, full_command);
                num = Imports.gpioSetValue(GlobalRef.g_RadarDeviceId, this.f000206.gpioBase, this.f000206.gpioPin, this.f000206.gpioValue);
                if (num == 0)
                {
                    string full_command2 = string.Format("Status : Passed", new object[0]);
                    this.m_GuiManager.RecordLog(0, full_command2);
                }
                else
                {
                    this.m_GuiManager.Error("TDA GPIO Write: failed with error " + num);
                }
            }
            else
            {
                this.m_GuiManager.Error("TDA is not connected!");
            }
            return num;
        }

        private void m_btnRead_Click(object sender, EventArgs p1)
        {
            if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
            {
                this.iReadRegister();
                return;
            }
            if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
            {
                this.iReadRegisterSpi();
            }
        }

        private void iReadRegister()
        {
            try
            {
                int num = (int)this.m_nudStartBit.Value;
                int num2 = (int)this.m_nudEndBit.Value;
                uint address;
                if (!this.iConvertHexTextToUInt(this.m_txtAddr, out address))
                {
                    this.m_GuiManager.ErrorAbort("ReadRegister: Invalid address");
                }
                else
                {
                    int type = 1;
                    uint num4;
                    int num3 = this.m_TsWrapper.ReadRegister(type, address, num, num2, out num4);
                    string text = "0x" + address.ToString("x");
                    string full_command = string.Format("ar1.ReadRegister({0}, {1}, {2})", new object[]
                    {
                        text,
                        (ushort)num,
                        num2
                    });
                    this.m_GuiManager.RecordLog(0, full_command);
                    if (num3 == 0)
                    {
                        this.m_txtValue.Text = num4.ToString("X");
                        string text2 = num4.ToString("X");
                        string full_command2 = string.Format("Value Read: {0} ", new object[]
                        {
                            text2
                        });
                        this.m_GuiManager.RecordLog(0, full_command2);
                    }
                    else
                    {
                        this.m_GuiManager.Error("ReadRegister failed with error " + num3);
                    }
                }
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        private void iReadRegisterSpi()
        {
            byte[] array = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                array[i] = (byte)(i + 1);
            }
            uint num = (uint)this.m_nudStartBit.Value;
            uint num2 = (uint)this.m_nudEndBit.Value;
            try
            {
                uint memAddr;
                if (!this.iConvertHexTextToUInt(this.m_txtAddr, out memAddr))
                {
                    this.m_GuiManager.ErrorAbort("ReadRegister: Invalid address");
                }
                else
                {
                    IntPtr value = GCHandle.Alloc(array, GCHandleType.Pinned).AddrOfPinnedObject();
                    if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                    {
                        string text = "0x" + memAddr.ToString("x");
                        string full_command = string.Format("ar1.GetInternalCfg({0}, {1}, {2})", new object[]
                        {
                            text,
                            (ushort)num,
                            num2
                        });
                        this.m_GuiManager.RecordLog(0, full_command);
                    }
                    else
                    {
                        string text2 = "0x" + memAddr.ToString("x");
                        string full_command2 = string.Format("ar1.GetInternalCfg_mult({0}, {1}, {2},{3})", new object[]
                        {
                            GlobalRef.g_RadarDeviceId,
                            text2,
                            (ushort)num,
                            num2
                        });
                        this.m_GuiManager.RecordLog(0, full_command2);
                    }
                    int num3 = Imports.RadarLinkImpl_GetInternalCfg(GlobalRef.g_RadarDeviceId, memAddr, value);
                    if (num3 == 0)
                    {
                        Array.Reverse(array);
                        string value2 = BitConverter.ToString(array).Replace("-", string.Empty);
                        if (this.iBitValidation(num, num2))
                        {
                            uint num4 = this.iGetBitsRange(Convert.ToUInt32(value2, 16), num, num2);
                            this.m_txtValue.Text = num4.ToString("X");
                            string text3 = num4.ToString("X");
                            string full_command3 = string.Format("Value Read: {0} ", new object[]
                            {
                                text3
                            });
                            this.m_GuiManager.RecordLog(0, full_command3);
                        }
                        else
                        {
                            uint num4 = uint.MaxValue;
                            this.m_txtValue.Text = num4.ToString("X");
                        }
                    }
                    else
                    {
                        this.m_GuiManager.Error("ReadRegister failed with error " + num3);
                    }
                }
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        public int iReadRegisterDataViaSpi(uint RadarDeviceId, uint address, uint StartBit, uint StopBit, out string RegVal)
        {
            byte[] array = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                array[i] = (byte)(i + 1);
            }
            RegVal = string.Empty;
            int num = -1;
            GlobalRef.g_RadarDeviceId = RadarDeviceId;
            int result;
            try
            {
                IntPtr value = GCHandle.Alloc(array, GCHandleType.Pinned).AddrOfPinnedObject();
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    // "0x" + address.ToString("x");
                }
                else
                {
                    // "0x" + address.ToString("x");
                }
                num = Imports.RadarLinkImpl_GetInternalCfg(GlobalRef.g_RadarDeviceId, address, value);
                if (num == 0)
                {
                    Array.Reverse(array);
                    string value2 = BitConverter.ToString(array).Replace("-", string.Empty);
                    if (this.iBitValidation(StartBit, StopBit))
                    {
                        uint num2 = this.iGetBitsRange(Convert.ToUInt32(value2, 16), StartBit, StopBit);
                        this.m_txtValue.Text = num2.ToString("X");
                        string str = num2.ToString("X");
                        RegVal = "0x" + str;
                    }
                    else
                    {
                        uint num2 = uint.MaxValue;
                        this.m_txtValue.Text = num2.ToString("X");
                    }
                }
                else
                {
                    this.m_GuiManager.Error("ReadRegister failed with error " + num);
                }
                result = num;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = num;
            }
            return result;
        }

        public int iReadRegisterDataThroughSpi(ushort RadarDeviceId, uint address, uint StartBit, uint StopBit)
        {
            byte[] array = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                array[i] = (byte)(i + 1);
            }
            int num = -1;
            GlobalRef.g_RadarDeviceId = (uint)RadarDeviceId;
            int result;
            try
            {
                IntPtr value = GCHandle.Alloc(array, GCHandleType.Pinned).AddrOfPinnedObject();
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    // "0x" + address.ToString("x");
                    string full_command = string.Format("ar1.GetInternalCfg({0}, {1}, {2})", new object[]
                    {
                        address,
                        (ushort)StartBit,
                        StopBit
                    });
                    this.m_GuiManager.RecordLog(0, full_command);
                }
                else
                {
                    // "0x" + address.ToString("x");
                    string full_command2 = string.Format("ar1.GetInternalCfg_mult({0}, {1}, {2},{3})", new object[]
                    {
                        GlobalRef.g_RadarDeviceId,
                        address,
                        (ushort)StartBit,
                        StopBit
                    });
                    this.m_GuiManager.RecordLog(0, full_command2);
                }
                num = Imports.RadarLinkImpl_GetInternalCfg(GlobalRef.g_RadarDeviceId, address, value);
                if (num == 0)
                {
                    Array.Reverse(array);
                    string value2 = BitConverter.ToString(array).Replace("-", string.Empty);
                    if (this.iBitValidation(StartBit, StopBit))
                    {
                        uint num2 = this.iGetBitsRange(Convert.ToUInt32(value2, 16), StartBit, StopBit);
                        this.m_txtValue.Text = num2.ToString("X");
                        string text = num2.ToString("X");
                        string full_command3 = string.Format("Value Read: {0} ", new object[]
                        {
                            text
                        });
                        this.m_GuiManager.RecordLog(0, full_command3);
                    }
                    else
                    {
                        uint num2 = uint.MaxValue;
                        this.m_txtValue.Text = num2.ToString("X");
                    }
                }
                else
                {
                    this.m_GuiManager.Error("ReadRegister failed with error " + num);
                }
                result = num;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = num;
            }
            return result;
        }

        private uint iGetBitsRange(uint val, uint start_bit, uint end_bit)
        {
            ulong num = (1UL << (int)(end_bit - start_bit + 1U)) - 1UL;
            return (uint)((ulong)(val >> (int)start_bit) & num);
        }

        private bool iBitValidation(uint start_bit, uint end_bit)
        {
            uint num = 31U;
            if (0U > start_bit || num < end_bit)
            {
                GlobalRef.GuiManager.Error("wrong start bit");
                return false;
            }
            if (start_bit > end_bit || end_bit > num)
            {
                GlobalRef.GuiManager.Error("wrong end bit");
                return false;
            }
            return true;
        }

        private bool iConvertHexTextToUInt(TextBox p0, out uint uint_val)
        {
            uint_val = 0U;
            if (string.IsNullOrEmpty(p0.Text))
            {
                return false;
            }
            string text = p0.Text.ToLower();
            if (text.Length > 1 && text.StartsWith("0x"))
            {
                text = text.Remove(0, 2);
            }
            return uint.TryParse(text, NumberStyles.HexNumber, null, out uint_val);
        }

        private void m_btnWrite_Click(object sender, EventArgs p1)
        {
            if (GlobalRef.g_NtvRS232Connect[(int)GlobalRef.g_RadarDeviceIndex])
            {
                this.iWriteRegister();
                return;
            }
            if ((GlobalRef.g_CasCadeDeviceSpiConnect & 1U) == 1U || (GlobalRef.g_CasCadeDeviceSpiConnect & 2U) == 2U || (GlobalRef.g_CasCadeDeviceSpiConnect & 4U) == 4U || (GlobalRef.g_CasCadeDeviceSpiConnect & 8U) == 8U)
            {
                this.iWriteRegisterSpi();
            }
        }

        private void iWriteRegister()
        {
            try
            {
                int num = (int)this.m_nudStartBit.Value;
                int num2 = (int)this.m_nudEndBit.Value;
                uint address;
                uint num3;
                if (!this.iConvertHexTextToUInt(this.m_txtAddr, out address))
                {
                    this.m_GuiManager.ErrorAbort("WriteRegister: Invalid address");
                }
                else if (!this.iConvertHexTextToUInt(this.m_txtValue, out num3))
                {
                    this.m_GuiManager.ErrorAbort("WriteRegister: Invalid value");
                }
                else
                {
                    int type = 1;
                    int num4 = this.m_TsWrapper.WriteRegister(type, address, num, num2, num3);
                    string text = "0x" + address.ToString("x");
                    string full_command = string.Format("ar1.WriteRegister({0}, {1}, {2}, {3})", new object[]
                    {
                        text,
                        (ushort)num,
                        num2,
                        num3
                    });
                    this.m_GuiManager.RecordLog(0, full_command);
                    if (num4 == 0)
                    {
                        string full_command2 = string.Format("Status: Success, Value Set: {0}", new object[]
                        {
                            num3.ToString("x")
                        });
                        this.m_GuiManager.RecordLog(99, full_command2);
                    }
                    if (num4 != 0)
                    {
                        this.m_GuiManager.Error("WriteRegister failed with error " + num4);
                    }
                }
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        private void iWriteRegisterSpi()
        {
            try
            {
                uint memAddr;
                uint num;
                if (!this.iConvertHexTextToUInt(this.m_txtAddr, out memAddr))
                {
                    this.m_GuiManager.ErrorAbort("WriteRegister: Invalid address");
                }
                else if (!this.iConvertHexTextToUInt(this.m_txtValue, out num))
                {
                    this.m_GuiManager.ErrorAbort("WriteRegister: Invalid value");
                }
                else
                {
                    if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                    {
                        string text = "0x" + memAddr.ToString("x");
                        string full_command = string.Format("ar1.SetInternalCfg({0}, {1})", new object[]
                        {
                            text,
                            num
                        });
                        this.m_GuiManager.RecordLog(0, full_command);
                    }
                    else
                    {
                        string text2 = "0x" + memAddr.ToString("x");
                        string full_command2 = string.Format("ar1.SetInternalCfg_mult({0}, {1},{2})", new object[]
                        {
                            GlobalRef.g_RadarDeviceId,
                            text2,
                            num
                        });
                        this.m_GuiManager.RecordLog(0, full_command2);
                    }
                    int num2 = Imports.RadarLinkImpl_SetInternalCfg(GlobalRef.g_RadarDeviceId, memAddr, num);
                    if (num2 == 0)
                    {
                        string full_command3 = string.Format("Status: Success, Value Set: {0}", new object[]
                        {
                            num
                        });
                        this.m_GuiManager.RecordLog(99, full_command3);
                    }
                    if (num2 != 0)
                    {
                        this.m_GuiManager.Error("WriteRegister failed with error " + num2);
                    }
                }
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        public int iWriteRegisterViaSpiChannel(ushort RadarDeviceId, uint address, uint value)
        {
            int num = -1;
            GlobalRef.g_RadarDeviceId = (uint)RadarDeviceId;
            int result;
            try
            {
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    string text = "0x" + address.ToString("x");
                    string full_command = string.Format("ar1.SetInternalCfg({0}, {1})", new object[]
                    {
                        text,
                        value
                    });
                    this.m_GuiManager.RecordLog(0, full_command);
                }
                else
                {
                    string text2 = "0x" + address.ToString("x");
                    string full_command2 = string.Format("ar1.SetInternalCfg_mult({0}, {1},{2})", new object[]
                    {
                        GlobalRef.g_RadarDeviceId,
                        text2,
                        value
                    });
                    this.m_GuiManager.RecordLog(0, full_command2);
                }
                num = Imports.RadarLinkImpl_SetInternalCfg(GlobalRef.g_RadarDeviceId, address, value);
                if (num == 0)
                {
                    string full_command3 = string.Format("Status: Success, Value Set: {0}", new object[]
                    {
                        value
                    });
                    this.m_GuiManager.RecordLog(99, full_command3);
                }
                if (num != 0)
                {
                    this.m_GuiManager.Error("WriteRegister failed with error " + num);
                }
                result = num;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = num;
            }
            return result;
        }

        private void m_btnBssRead_Click(object sender, EventArgs p1)
        {
            this.iReadBssRegister();
        }

        private void iReadBssRegister()
        {
            byte[] array = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                array[i] = (byte)(i + 1);
            }
            uint num = (uint)this.m_nudStartBitBss.Value;
            uint num2 = (uint)this.m_nudEndBitBss.Value;
            try
            {
                uint memAddr;
                if (!this.iConvertHexTextToUInt(this.m_txtBssRegAddr, out memAddr))
                {
                    this.m_GuiManager.ErrorAbort("ReadRegister: Invalid address");
                }
                else
                {
                    IntPtr value = GCHandle.Alloc(array, GCHandleType.Pinned).AddrOfPinnedObject();
                    if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                    {
                        string text = "0x" + memAddr.ToString("x");
                        string full_command = string.Format("ar1.GetInternalRfCfg({0}, {1}, {2}, {3})", new object[]
                        {
                            (ushort)this.m_nudProfileId.Value,
                            text,
                            (ushort)num,
                            num2
                        });
                        this.m_GuiManager.RecordLog(0, full_command);
                    }
                    else
                    {
                        string text2 = "0x" + memAddr.ToString("x");
                        string full_command2 = string.Format("ar1.GetInternalRfCfg_mult({0}, {1}, {2}, {3},{4})", new object[]
                        {
                            GlobalRef.g_RadarDeviceId,
                            (ushort)this.m_nudProfileId.Value,
                            text2,
                            (ushort)num,
                            num2
                        });
                        this.m_GuiManager.RecordLog(0, full_command2);
                    }
                    int num3 = Imports.RadarLinkImpl_GetInternalRfCfg(GlobalRef.g_RadarDeviceId, (ushort)this.m_nudProfileId.Value, memAddr, value);
                    if (num3 == 0)
                    {
                        Array.Reverse(array);
                        string value2 = BitConverter.ToString(array).Replace("-", string.Empty);
                        if (this.iBitValidation(num, num2))
                        {
                            uint num4 = this.iGetBitsRange(Convert.ToUInt32(value2, 16), num, num2);
                            this.m_txtBssRegValue.Text = num4.ToString("X");
                            string text3 = num4.ToString("X");
                            string full_command3 = string.Format("Value Read: {0} ", new object[]
                            {
                                text3
                            });
                            this.m_GuiManager.RecordLog(0, full_command3);
                        }
                        else
                        {
                            uint num4 = uint.MaxValue;
                            this.m_txtBssRegValue.Text = num4.ToString("X");
                        }
                    }
                    else
                    {
                        this.m_GuiManager.Error("ReadRegister failed with error " + num3);
                    }
                }
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        public int iReadBssRegister_ViaCmdLine(ushort RadarDeviceId, ushort ProfileIDValue, uint address, ushort start_bit, ushort end_bit, out string RegVal)
        {
            GlobalRef.g_RadarDeviceId = (uint)RadarDeviceId;
            byte[] array = new byte[4];
            RegVal = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                array[i] = (byte)(i + 1);
            }
            int result;
            try
            {
                IntPtr value = GCHandle.Alloc(array, GCHandleType.Pinned).AddrOfPinnedObject();
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    string text = "0x" + address.ToString("x");
                    string full_command = string.Format("ar1.GetInternalRfCfg({0}, {1}, {2}, {3})", new object[]
                    {
                        ProfileIDValue,
                        text,
                        start_bit,
                        end_bit
                    });
                    this.m_GuiManager.RecordLog(0, full_command);
                }
                else
                {
                    string text2 = "0x" + address.ToString("x");
                    string full_command2 = string.Format("ar1.GetInternalRfCfg_mult({0}, {1}, {2}, {3},{4})", new object[]
                    {
                        GlobalRef.g_RadarDeviceId,
                        ProfileIDValue,
                        text2,
                        start_bit,
                        end_bit
                    });
                    this.m_GuiManager.RecordLog(0, full_command2);
                }
                int num = Imports.RadarLinkImpl_GetInternalRfCfg(GlobalRef.g_RadarDeviceId, ProfileIDValue, address, value);
                if (num == 0)
                {
                    Array.Reverse(array);
                    string value2 = BitConverter.ToString(array).Replace("-", string.Empty);
                    if (this.iBitValidation((uint)start_bit, (uint)end_bit))
                    {
                        string text3 = this.iGetBitsRange(Convert.ToUInt32(value2, 16), (uint)start_bit, (uint)end_bit).ToString("X");
                        RegVal = "0x" + text3;
                        string full_command3 = string.Format("Value Read: {0} ", new object[]
                        {
                            text3
                        });
                        this.m_GuiManager.RecordLog(0, full_command3);
                    }
                    else
                    {
                        num = -1;
                    }
                }
                else
                {
                    this.m_GuiManager.Error("ReadRegister failed with error " + num);
                }
                result = num;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = 0;
            }
            return result;
        }

        public uint iReadBssRegister_CmdLine(ushort RadarDeviceId, ushort ProfileIDValue, uint address, ushort start_bit, ushort end_bit)
        {
            GlobalRef.g_RadarDeviceId = (uint)RadarDeviceId;
            byte[] array = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                array[i] = (byte)(i + 1);
            }
            uint num = 0U;
            uint result;
            try
            {
                IntPtr value = GCHandle.Alloc(array, GCHandleType.Pinned).AddrOfPinnedObject();
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    string text = "0x" + address.ToString("x");
                    string full_command = string.Format("ar1.GetInternalRfCfg({0}, {1}, {2}, {3})", new object[]
                    {
                        ProfileIDValue,
                        text,
                        start_bit,
                        end_bit
                    });
                    this.m_GuiManager.RecordLog(0, full_command);
                }
                else
                {
                    string text2 = "0x" + address.ToString("x");
                    string full_command2 = string.Format("ar1.GetInternalRfCfg_mult({0}, {1}, {2}, {3},{4})", new object[]
                    {
                        GlobalRef.g_RadarDeviceId,
                        ProfileIDValue,
                        text2,
                        start_bit,
                        end_bit
                    });
                    this.m_GuiManager.RecordLog(0, full_command2);
                }
                int num2 = Imports.RadarLinkImpl_GetInternalRfCfg(GlobalRef.g_RadarDeviceId, ProfileIDValue, address, value);
                if (num2 == 0)
                {
                    Array.Reverse(array);
                    string value2 = BitConverter.ToString(array).Replace("-", string.Empty);
                    if (this.iBitValidation((uint)start_bit, (uint)end_bit))
                    {
                        num = Convert.ToUInt32(value2, 16);
                        string text3 = num.ToString("X");
                        string full_command3 = string.Format("Value Read: {0} ", new object[]
                        {
                            text3
                        });
                        this.m_GuiManager.RecordLog(0, full_command3);
                    }
                    else
                    {
                        num = uint.MaxValue;
                    }
                }
                else
                {
                    this.m_GuiManager.Error("ReadRegister failed with error " + num2);
                }
                result = num;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = 0U;
            }
            return result;
        }

        private void m_btnBssWrite_Click(object sender, EventArgs p1)
        {
            this.iWriteBssRegister();
        }

        private void iWriteBssRegister()
        {
            try
            {
                uint num;
                uint num2;
                if (!this.iConvertHexTextToUInt(this.m_txtBssRegAddr, out num))
                {
                    this.m_GuiManager.ErrorAbort("WriteRegister: Invalid address");
                }
                else if (!this.iConvertHexTextToUInt(this.m_txtBssRegValue, out num2))
                {
                    this.m_GuiManager.ErrorAbort("WriteRegister: Invalid value");
                }
                else
                {
                    ushort num3 = (ushort)this.m_nudProfileId.Value;
                    ushort num4 = (ushort)this.m_nudStartBitBss.Value;
                    ushort num5 = (ushort)this.m_nudEndBitBss.Value;
                    uint num6 = (uint)(num5 - num4 + 1);
                    uint num7 = this.iReadBssRegister_CmdLine((ushort)GlobalRef.g_RadarDeviceId, 0, num, num4, num5);
                    int num8;
                    if (num6 == 32U)
                    {
                        num8 = Imports.RadarLinkImpl_SetInternalRfCfg(GlobalRef.g_RadarDeviceId, num3, num, num2);
                    }
                    else if (num7 != 4294967295U)
                    {
                        uint num9 = (1U << (int)num6) - 1U << (int)num4;
                        uint value = (num7 & ~num9) | num2 << (int)num4;
                        this.m_txtBssRegValue.Text = value.ToString("X");
                        num8 = Imports.RadarLinkImpl_SetInternalRfCfg(GlobalRef.g_RadarDeviceId, num3, num, value);
                    }
                    else
                    {
                        num8 = -1;
                    }
                    if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                    {
                        string text = "0x" + num.ToString("x");
                        string text2 = "0x" + num2.ToString("x");
                        string full_command = string.Format("ar1.SetInternalRfCfg({0}, {1}, {2}, {3}, {4})", new object[]
                        {
                            num3,
                            text,
                            text2,
                            num4,
                            num5
                        });
                        this.m_GuiManager.RecordLog(0, full_command);
                    }
                    else
                    {
                        string text3 = "0x" + num.ToString("x");
                        string text4 = "0x" + num2.ToString("x");
                        string full_command2 = string.Format("ar1.SetInternalRfCfg_mult({0}, {1}, {2}, {3}, {4},{5})", new object[]
                        {
                            GlobalRef.g_RadarDeviceId,
                            num3,
                            text3,
                            text4,
                            num4,
                            num5
                        });
                        this.m_GuiManager.RecordLog(0, full_command2);
                    }
                    if (num8 == 0)
                    {
                        string full_command3 = string.Format("Status: Success, Value Set: {0}", new object[]
                        {
                            num2.ToString("x")
                        });
                        this.m_GuiManager.RecordLog(99, full_command3);
                    }
                    if (num8 != 0)
                    {
                        this.m_GuiManager.Error("WriteRegister failed with error " + num8);
                    }
                }
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        public int iWriteBssRegister_CmdLine(ushort RadarDeviceId, ushort profId, uint address, uint value, ushort start_bit, ushort end_bit)
        {
            GlobalRef.g_RadarDeviceId = (uint)RadarDeviceId;
            int result;
            try
            {
                uint num = (uint)(end_bit - start_bit + 1);
                uint num2 = this.iReadBssRegister_CmdLine((ushort)GlobalRef.g_RadarDeviceId, 0, address, start_bit, end_bit);
                int num3;
                if (num == 32U)
                {
                    num3 = Imports.RadarLinkImpl_SetInternalRfCfg(GlobalRef.g_RadarDeviceId, profId, address, value);
                }
                else
                {
                    uint num4 = (1U << (int)num) - 1U << (int)start_bit;
                    uint value2 = (num2 & ~num4) | value << (int)start_bit;
                    num3 = Imports.RadarLinkImpl_SetInternalRfCfg(GlobalRef.g_RadarDeviceId, profId, address, value2);
                }
                if (GlobalRef.g_NumOfRadarDevicesDetected == 1U)
                {
                    string text = "0x" + address.ToString("x");
                    string text2 = "0x" + value.ToString("x");
                    string full_command = string.Format("ar1.SetInternalRFCfg({0}, {1}, {2}, {3}, {4})", new object[]
                    {
                        profId,
                        text,
                        text2,
                        start_bit,
                        end_bit
                    });
                    this.m_GuiManager.RecordLog(0, full_command);
                }
                else
                {
                    string text3 = "0x" + address.ToString("x");
                    string text4 = "0x" + value.ToString("x");
                    string full_command2 = string.Format("ar1.SetInternalRFCfg_mult({0}, {1}, {2}, {3}, {4},{5})", new object[]
                    {
                        GlobalRef.g_RadarDeviceId,
                        profId,
                        text3,
                        text4,
                        start_bit,
                        end_bit
                    });
                    this.m_GuiManager.RecordLog(0, full_command2);
                }
                if (num3 == 0)
                {
                    string full_command3 = string.Format("Status: Success, Value Set: {0}", new object[]
                    {
                        value.ToString("x")
                    });
                    this.m_GuiManager.RecordLog(99, full_command3);
                }
                if (num3 != 0)
                {
                    this.m_GuiManager.Error("WriteRegister failed with error " + num3);
                }
                result = num3;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = -1;
            }
            return result;
        }

        public void m000060()
        {
            this.EnableControl_Rec(true, this.m_grpReadWrite);
            this.EnableControl_Rec(true, this.m_grpBssReadWrite);
        }

        public void m000061()
        {
            this.EnableControl_Rec(false, this.m_grpReadWrite);
            this.EnableControl_Rec(false, this.m_grpBssReadWrite);
        }

        public void EnableControl_Rec(bool bEnable, Control ctrl)
        {
            if (base.InvokeRequired)
            {
                del_b_ctrl method = new del_b_ctrl(this.EnableControl_Rec);
                base.Invoke(method, new object[]
                {
                    bEnable,
                    ctrl
                });
                return;
            }
            if (ctrl is GroupBox || ctrl is Panel || ctrl is NumericUpDown || ctrl is TextBox || ctrl is TabPage || ctrl.Parent is TabPage)
            {
                if (ctrl is GroupBox)
                {
                    ctrl.Enabled = true;
                }
                else
                {
                    ctrl.Enabled = bEnable;
                }

                foreach (Control ctrl2 in ctrl.Controls)
                {
                    this.EnableControl_Rec(bEnable, ctrl2);
                }
                return;
            }
            ctrl.Enabled = bEnable;
        }

        public void ReadWriteExt(int reg_type, uint address, int start_bit, int end_bit, uint value)
        {
            if (base.InvokeRequired)
            {
                delegate011c method = new delegate011c(this.ReadWriteExt);
                base.Invoke(method, new object[]
                {
                    reg_type,
                    address,
                    start_bit,
                    end_bit,
                    value
                });
                return;
            }
            try
            {
                this.m_txtAddr.Text = address.ToString("X");
                this.m_nudStartBit.Value = start_bit;
                this.m_nudEndBit.Value = end_bit;
                this.m_txtValue.Text = value.ToString("X");
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
            }
        }

        public bool iDisableRegOpeTabBtns()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.iDisableRegOpeTabBtns);
                return (bool)base.Invoke(method);
            }
            this.m_btnRead.Enabled = false;
            this.m_btnWrite.Enabled = false;
            return true;
        }

        public bool iDisableRegOpeFnFrCust()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.iDisableRegOpeFnFrCust);
                return (bool)base.Invoke(method);
            }
            this.m_grpBssReadWrite.Visible = false;
            return true;
        }

        public bool iEnableRegOpeTabBtns()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.iEnableRegOpeTabBtns);
                return (bool)base.Invoke(method);
            }
            this.m_btnRead.Enabled = true;
            this.m_btnWrite.Enabled = true;
            return true;
        }

        private void m_btnAllBits_Click(object sender, EventArgs p1)
        {
            this.m_nudStartBit.Value = 0m;
            this.m_nudEndBit.Value = 31m;
        }

        private void m_btnAllBitsBss_Click(object sender, EventArgs p1)
        {
            this.m_nudStartBitBss.Value = 0m;
            this.m_nudEndBitBss.Value = 31m;
        }

        public bool UpdateRegData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateRegData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_GbgSigIndex = this.m_cboDbgSignal.SelectedIndex;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateGPIOData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateGPIOData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.f000207 = this.f000208.SelectedIndex;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateRegDataDbgGui()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateRegDataDbgGui);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_cboDbgSignal.SelectedIndex = this.m_GbgSigIndex;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public int GetDbgSigDataFrmCmd(ushort dbgSigVal)
        {
            this.m_GbgSigIndex = (int)dbgSigVal;
            this.UpdateRegDataDbgGui();
            this.UpdateRegData();
            int result = this.m_GuiManager.ScriptOps.iDbgSignal_Impl(this.m_GbgSigIndex);
            this.m_MainForm.GuiOpEnd(true);
            return result;
        }

        private void iDbgSigOp()
        {
            this.UpdateRegData();
            this.m_GuiManager.ScriptOps.iDbgSignal_Impl(this.m_GbgSigIndex);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void DbgSigAsync()
        {
            new del_v_v(this.iDbgSigOp).BeginInvoke(null, null);
        }

        private void m_btnDbgSig_Click(object sender, EventArgs p1)
        {
            this.DbgSigAsync();
        }

        private void iSetRegisterAddressCheck()
        {
            uint abs_addr = 1126318080U;
            string seqAddress = string.Empty;
            seqAddress = this.m_txtRegisterAddr.Text;
            uint num_of_dwords = 256U;
            if (Convert.ToBoolean(this.m_TsWrapper.ReadBlockSeq(abs_addr, num_of_dwords, seqAddress)))
            {
                this.m_lblSeqRAMAvailable.ForeColor = Color.Green;
                this.m_lblSeqRAMAvailable.Text = "Available";
            }
            else
            {
                this.m_lblSeqRAMAvailable.ForeColor = Color.Red;
                this.m_lblSeqRAMAvailable.Text = "Not Available";
            }
            this.m_btnRegisterCheck.Text = "Check";
        }

        private void iSetRegisterAddressCheckAsync()
        {
            new del_v_v(this.iSetRegisterAddressCheck).BeginInvoke(null, null);
        }

        private void m_btnRegisterCheck_Click(object sender, EventArgs p1)
        {
            this.m_lblSeqRAMAvailable.ForeColor = Color.Black;
            this.m_lblSeqRAMAvailable.Text = "Checking Status..";
            this.m_lblSeqRAMAvailable.Refresh();
            this.iSetRegisterAddressCheck();
        }

        private void iADCStartOp()
        {
            this.UpdateGPIOData();
            this.m_GuiManager.ScriptOps.m00008a(this.f000207);
            this.m_MainForm.GuiOpEnd(true);
        }

        public void ADCStartAsync()
        {
            new del_v_v(this.iADCStartOp).BeginInvoke(null, null);
        }

        private void m_btnADCSet_Click(object sender, EventArgs p1)
        {
            this.ADCStartAsync();
        }

        private int iSetMSSGetContiguousBlockConfig_internal(bool is_starting_op, bool is_ending_op)
        {
            return this.m_GuiManager.ScriptOps.iSetMSSGetDataBlockConfig_Gui(is_starting_op, is_ending_op);
        }

        private void iSetMSSGetContiguousBlockConfig()
        {
            this.iSetMSSGetContiguousBlockConfig_internal(true, false);
            this.m_MainForm.GuiOpEnd(true);
        }

        private void iSetMSSGetContiguousBlockConfigAsync()
        {
            new del_v_v(this.iSetMSSGetContiguousBlockConfig).BeginInvoke(null, null);
        }

        private void m_btnMSSGetContiguousBlockConfigSet_Click(object sender, EventArgs p1)
        {
            this.iSetMSSGetContiguousBlockConfigAsync();
        }

        public bool UpdateMSSGetContiguousBlockConfigData()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateMSSGetContiguousBlockConfigData);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                uint blockStartAddress;
                if (!this.iConvertHexTextToUInt(this.m_txtMSSBlockStartAddr, out blockStartAddress))
                {
                    this.m_GuiManager.ErrorAbort("ReadRegister: Invalid address");
                    result = false;
                }
                else
                {
                    this.m_MSSGetDataBlockConfigParams.BlockStartAddress = blockStartAddress;
                    this.m_MSSGetDataBlockConfigParams.DataLength = (uint)this.m_nudDataBlockLength.Value;
                    this.m_MSSGetDataBlockConfigParams.Reserved = 0U;
                    result = true;
                }
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool UpdateMSSGetContiguousBlockDataFrmCmdSrc()
        {
            if (base.InvokeRequired)
            {
                del_b_v method = new del_b_v(this.UpdateMSSGetContiguousBlockDataFrmCmdSrc);
                return (bool)base.Invoke(method);
            }
            bool result;
            try
            {
                this.m_txtMSSBlockStartAddr.Text = Convert.ToString(this.m_MSSGetDataBlockConfigParams.BlockStartAddress);
                this.m_nudDataBlockLength.Value = this.m_MSSGetDataBlockConfigParams.DataLength;
                this.m_MSSGetDataBlockConfigParams.Reserved = 0U;
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
        }

        public bool MSSGetDataBlockAsyncReportData(uint RadarDeviceId, ushort RemainingChunks, uint BlockData0, uint BlockData1, uint BlockData2, uint BlockData3, uint BlockData4, uint BlockData5, uint BlockData6, uint BlockData7, uint BlockData8, uint BlockData9, uint BlockData10, uint BlockData11, uint BlockData12, uint BlockData13, uint BlockData14, uint BlockData15, uint BlockData16, uint BlockData17, uint BlockData18, uint BlockData19, uint BlockData20, uint BlockData21, uint BlockData22, uint BlockData23, uint BlockData24, uint BlockData25, uint BlockData26, uint BlockData27, uint BlockData28, uint BlockData29, uint BlockData30, uint BlockData31, uint BlockData32, uint BlockData33, uint BlockData34, uint BlockData35, uint BlockData36, uint BlockData37, uint BlockData38, uint BlockData39, uint BlockData40, uint BlockData41, uint BlockData42, uint BlockData43, uint BlockData44, uint BlockData45, uint BlockData46, uint BlockData47, uint BlockData48, uint BlockData49, uint BlockData50, uint BlockData51, uint BlockData52, uint BlockData53, uint BlockData54)
        {
            string empty = string.Empty;
            string directoryName = Path.GetDirectoryName(Application.StartupPath);
            StreamWriter streamWriter = new StreamWriter(string.Concat(new string[]
            {
                directoryName + "\\PostProc\\MSSGetDataBlock.txt"
            }), false);
            uint dataLength = this.m_MSSGetDataBlockConfigParams.DataLength;
            if (dataLength <= 108U)
            {
                if (dataLength <= 52U)
                {
                    if (dataLength <= 24U)
                    {
                        if (dataLength <= 12U)
                        {
                            if (dataLength == 4U)
                            {
                                streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                                goto IL_A69F;
                            }
                            if (dataLength == 8U)
                            {
                                streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                                goto IL_A69F;
                            }
                            if (dataLength == 12U)
                            {
                                streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                                goto IL_A69F;
                            }
                        }
                        else
                        {
                            if (dataLength == 16U)
                            {
                                streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                                goto IL_A69F;
                            }
                            if (dataLength == 20U)
                            {
                                streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                                goto IL_A69F;
                            }
                            if (dataLength == 24U)
                            {
                                streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                                streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                                goto IL_A69F;
                            }
                        }
                    }
                    else if (dataLength <= 36U)
                    {
                        if (dataLength == 28U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            goto IL_A69F;
                        }
                        if (dataLength == 32U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            goto IL_A69F;
                        }
                        if (dataLength == 36U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            goto IL_A69F;
                        }
                    }
                    else if (dataLength <= 44U)
                    {
                        if (dataLength == 40U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            goto IL_A69F;
                        }
                        if (dataLength == 44U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            goto IL_A69F;
                        }
                    }
                    else
                    {
                        if (dataLength == 48U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            goto IL_A69F;
                        }
                        if (dataLength == 52U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            goto IL_A69F;
                        }
                    }
                }
                else if (dataLength <= 80U)
                {
                    if (dataLength <= 64U)
                    {
                        if (dataLength == 56U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            goto IL_A69F;
                        }
                        if (dataLength == 60U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            goto IL_A69F;
                        }
                        if (dataLength == 64U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                            goto IL_A69F;
                        }
                    }
                    else if (dataLength <= 72U)
                    {
                        if (dataLength == 68U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                            goto IL_A69F;
                        }
                        if (dataLength == 72U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                            goto IL_A69F;
                        }
                    }
                    else
                    {
                        if (dataLength == 76U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                            goto IL_A69F;
                        }
                        if (dataLength == 80U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                            goto IL_A69F;
                        }
                    }
                }
                else if (dataLength <= 92U)
                {
                    if (dataLength == 84U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        goto IL_A69F;
                    }
                    if (dataLength == 88U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        goto IL_A69F;
                    }
                    if (dataLength == 92U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        goto IL_A69F;
                    }
                }
                else if (dataLength <= 100U)
                {
                    if (dataLength == 96U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        goto IL_A69F;
                    }
                    if (dataLength == 100U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        goto IL_A69F;
                    }
                }
                else
                {
                    if (dataLength == 104U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        goto IL_A69F;
                    }
                    if (dataLength == 108U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        goto IL_A69F;
                    }
                }
            }
            else if (dataLength <= 164U)
            {
                if (dataLength <= 136U)
                {
                    if (dataLength <= 120U)
                    {
                        if (dataLength == 112U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                            goto IL_A69F;
                        }
                        if (dataLength == 116U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                            goto IL_A69F;
                        }
                        if (dataLength == 120U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                            goto IL_A69F;
                        }
                    }
                    else if (dataLength <= 128U)
                    {
                        if (dataLength == 124U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                            goto IL_A69F;
                        }
                        if (dataLength == 128U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                            goto IL_A69F;
                        }
                    }
                    else
                    {
                        if (dataLength == 132U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                            goto IL_A69F;
                        }
                        if (dataLength == 136U)
                        {
                            streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                            streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                            goto IL_A69F;
                        }
                    }
                }
                else if (dataLength <= 148U)
                {
                    if (dataLength == 140U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        goto IL_A69F;
                    }
                    if (dataLength == 144U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        goto IL_A69F;
                    }
                    if (dataLength == 148U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                        goto IL_A69F;
                    }
                }
                else if (dataLength <= 156U)
                {
                    if (dataLength == 152U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                        goto IL_A69F;
                    }
                    if (dataLength == 156U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                        goto IL_A69F;
                    }
                }
                else
                {
                    if (dataLength == 160U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                        goto IL_A69F;
                    }
                    if (dataLength == 164U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                        goto IL_A69F;
                    }
                }
            }
            else if (dataLength <= 192U)
            {
                if (dataLength <= 176U)
                {
                    if (dataLength == 168U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                        goto IL_A69F;
                    }
                    if (dataLength == 172U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                        goto IL_A69F;
                    }
                    if (dataLength == 176U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData43), 16));
                        goto IL_A69F;
                    }
                }
                else if (dataLength <= 184U)
                {
                    if (dataLength == 180U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData43), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData44), 16));
                        goto IL_A69F;
                    }
                    if (dataLength == 184U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData43), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData44), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData45), 16));
                        goto IL_A69F;
                    }
                }
                else
                {
                    if (dataLength == 188U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData43), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData44), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData45), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData46), 16));
                        goto IL_A69F;
                    }
                    if (dataLength == 192U)
                    {
                        streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData43), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData44), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData45), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData46), 16));
                        streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData47), 16));
                        goto IL_A69F;
                    }
                }
            }
            else if (dataLength <= 204U)
            {
                if (dataLength == 196U)
                {
                    streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData43), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData44), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData45), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData46), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData47), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData48), 16));
                    goto IL_A69F;
                }
                if (dataLength == 200U)
                {
                    streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData43), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData44), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData45), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData46), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData47), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData48), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData49), 16));
                    goto IL_A69F;
                }
                if (dataLength == 204U)
                {
                    streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData43), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData44), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData45), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData46), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData47), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData48), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData49), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData50), 16));
                    goto IL_A69F;
                }
            }
            else if (dataLength <= 212U)
            {
                if (dataLength == 208U)
                {
                    streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData43), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData44), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData45), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData46), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData47), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData48), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData49), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData50), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData51), 16));
                    goto IL_A69F;
                }
                if (dataLength == 212U)
                {
                    streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData43), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData44), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData45), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData46), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData47), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData48), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData49), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData50), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData51), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData52), 16));
                    goto IL_A69F;
                }
            }
            else
            {
                if (dataLength == 216U)
                {
                    streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData43), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData44), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData45), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData46), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData47), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData48), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData49), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData50), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData51), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData52), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData53), 16));
                    goto IL_A69F;
                }
                if (dataLength == 220U)
                {
                    streamWriter.WriteLine("0x" + Convert.ToString((int)RemainingChunks, 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData0), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData1), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData2), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData3), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData4), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData5), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData6), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData7), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData8), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData9), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData10), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData11), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData12), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData13), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData14), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData15), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData16), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData17), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData18), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData19), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData20), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData21), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData22), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData23), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData24), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData25), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData26), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData27), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData28), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData29), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData30), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData31), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData32), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData33), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData34), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData35), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData36), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData37), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData38), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData39), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData40), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData41), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData42), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData43), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData44), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData45), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData46), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData47), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData48), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData49), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData50), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData51), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData52), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData53), 16));
                    streamWriter.WriteLine("0x" + Convert.ToString((long)((ulong)BlockData54), 16));
                    goto IL_A69F;
                }
            }
            string full_command = string.Format("MSS DATA RECIEVED MORE THAN 220 BYTES ", new object[0]);
            GlobalRef.GuiManager.RecordLog(0, full_command);
        IL_A69F:
            streamWriter.Close();
            streamWriter.Dispose();
            return true;
        }

        private void m_boxGPIOPinSelect_SelectedIndexChanged(object sender, EventArgs p1)
        {
            if (this.f00020f.SelectedIndex == 0)
            {
                this.f00020b.Text = "2";
                this.f00020a.Text = "2";
                return;
            }
            if (this.f00020f.SelectedIndex == 1)
            {
                this.f00020b.Text = "2";
                this.f00020a.Text = "9";
                return;
            }
            if (this.f00020f.SelectedIndex == 2)
            {
                this.f00020b.Text = "2";
                this.f00020a.Text = "10";
                return;
            }
            if (this.f00020f.SelectedIndex == 3)
            {
                this.f00020b.Text = "2";
                this.f00020a.Text = "11";
                return;
            }
            if (this.f00020f.SelectedIndex == 4)
            {
                this.f00020b.Text = "2";
                this.f00020a.Text = "12";
                return;
            }
            if (this.f00020f.SelectedIndex == 5)
            {
                this.f00020b.Text = "2";
                this.f00020a.Text = "13";
                return;
            }
            if (this.f00020f.SelectedIndex == 6)
            {
                this.f00020b.Text = "2";
                this.f00020a.Text = "22";
                return;
            }
            if (this.f00020f.SelectedIndex == 7)
            {
                this.f00020b.Text = "2";
                this.f00020a.Text = "25";
                return;
            }
            if (this.f00020f.SelectedIndex == 8)
            {
                this.f00020b.Text = "";
                this.f00020a.Text = "";
            }
        }

        public bool DisableAndEnableGPIOStatus(bool status)
        {
            if (base.InvokeRequired)
            {
                del_b_b method = new del_b_b(this.DisableAndEnableGPIOStatus);
                return (bool)base.Invoke(method, new object[]
                {
                    status
                });
            }
            bool result;
            try
            {
                if (status)
                {
                    this.f000209.Visible = false;
                }
                else
                {
                    this.f000209.Visible = true;
                }
                result = true;
            }
            catch (Exception ex)
            {
                this.m_GuiManager.Error(ex.Message, ex.StackTrace);
                result = false;
            }
            return result;
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
            this.m_grpReadWrite = new GroupBox();
            this.m_nudEndBit = new NumericUpDownEx();
            this.m_nudStartBit = new NumericUpDownEx();
            this.m_btnAllBits = new Button();
            this.m_lblEndBit = new Label();
            this.m_lblStartBit = new Label();
            this.m_lblValue = new Label();
            this.m_txtValue = new TextBox();
            this.m_txtAddr = new TextBox();
            this.m_lblAddr = new Label();
            this.m_btnWrite = new Button();
            this.m_btnRead = new Button();
            this.m_grpBssReadWrite = new GroupBox();
            this.m_btnAllBitsBss = new Button();
            this.m_nudEndBitBss = new NumericUpDownEx();
            this.m_nudStartBitBss = new NumericUpDownEx();
            this.label1 = new Label();
            this.label2 = new Label();
            this.m_btnBssRead = new Button();
            this.m_nudProfileId = new NumericUpDown();
            this.m_lblProfileProfileId = new Label();
            this.m_lblRegValue = new Label();
            this.m_txtBssRegValue = new TextBox();
            this.m_txtBssRegAddr = new TextBox();
            this.m_lblRegAddr = new Label();
            this.m_btnBssWrite = new Button();
            this.groupBox1 = new GroupBox();
            this.m_cboDbgSignal = new ComboBox();
            this.m_btnSetDbgSig = new Button();
            this.m_grpSequenceExtensionCheck = new GroupBox();
            this.m_lblSeqRAMAvailable = new Label();
            this.m_btnRegisterCheck = new Button();
            this.m_txtRegisterAddr = new TextBox();
            this.label4 = new Label();
            this.label3 = new Label();
            this.m_grpADCStart = new GroupBox();
            this.f000208 = new ComboBox();
            this.m_btnADCSet = new Button();
            this.groupBox2 = new GroupBox();
            this.m_nudDataBlockLength = new NumericUpDown();
            this.m_txtMSSBlockStartAddr = new TextBox();
            this.label6 = new Label();
            this.label5 = new Label();
            this.m_btnMSSGetContiguousBlockConfigSet = new Button();
            this.f000209 = new GroupBox();
            this.label7 = new Label();
            this.f00020e = new TextBox();
            this.label9 = new Label();
            this.f00020a = new TextBox();
            this.f00020b = new TextBox();
            this.label10 = new Label();
            this.f00020c = new Button();
            this.f00020d = new Button();
            this.label8 = new Label();
            this.f00020f = new ComboBox();
            this.m_grpReadWrite.SuspendLayout();
            ((ISupportInitialize)this.m_nudEndBit).BeginInit();
            ((ISupportInitialize)this.m_nudStartBit).BeginInit();
            this.m_grpBssReadWrite.SuspendLayout();
            ((ISupportInitialize)this.m_nudEndBitBss).BeginInit();
            ((ISupportInitialize)this.m_nudStartBitBss).BeginInit();
            ((ISupportInitialize)this.m_nudProfileId).BeginInit();
            this.groupBox1.SuspendLayout();
            this.m_grpSequenceExtensionCheck.SuspendLayout();
            this.m_grpADCStart.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((ISupportInitialize)this.m_nudDataBlockLength).BeginInit();
            this.f000209.SuspendLayout();
            base.SuspendLayout();
            this.m_grpReadWrite.Controls.Add(this.m_nudEndBit);
            this.m_grpReadWrite.Controls.Add(this.m_nudStartBit);
            this.m_grpReadWrite.Controls.Add(this.m_btnAllBits);
            this.m_grpReadWrite.Controls.Add(this.m_lblEndBit);
            this.m_grpReadWrite.Controls.Add(this.m_lblStartBit);
            this.m_grpReadWrite.Controls.Add(this.m_lblValue);
            this.m_grpReadWrite.Controls.Add(this.m_txtValue);
            this.m_grpReadWrite.Controls.Add(this.m_txtAddr);
            this.m_grpReadWrite.Controls.Add(this.m_lblAddr);
            this.m_grpReadWrite.Controls.Add(this.m_btnWrite);
            this.m_grpReadWrite.Controls.Add(this.m_btnRead);
            this.m_grpReadWrite.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_grpReadWrite.Location = new Point(56, 36);
            this.m_grpReadWrite.Margin = new Padding(4);
            this.m_grpReadWrite.Name = "m_grpReadWrite";
            this.m_grpReadWrite.Padding = new Padding(4);
            this.m_grpReadWrite.Size = new Size(304, 226);
            this.m_grpReadWrite.TabIndex = 35;
            this.m_grpReadWrite.TabStop = false;
            this.m_grpReadWrite.Text = "Read/Write (Hex)";
            this.m_nudEndBit.ChangedByCode = false;
            this.m_nudEndBit.Enabled = false;
            this.m_nudEndBit.Location = new Point(9, 133);
            this.m_nudEndBit.Margin = new Padding(4);
            NumericUpDownEx nudEndBit = this.m_nudEndBit;
            int[] array = new int[4];
            array[0] = 31;
            nudEndBit.Maximum = new decimal(array);
            this.m_nudEndBit.Minimum = new decimal(new int[4]);
            this.m_nudEndBit.Name = "m_nudEndBit";
            this.m_nudEndBit.Size = new Size(56, 25);
            this.m_nudEndBit.TabIndex = 3;
            NumericUpDownEx nudEndBit2 = this.m_nudEndBit;
            int[] array2 = new int[4];
            array2[0] = 31;
            nudEndBit2.Value = new decimal(array2);
            this.m_nudStartBit.ChangedByCode = false;
            this.m_nudStartBit.Enabled = false;
            this.m_nudStartBit.Location = new Point(76, 133);
            this.m_nudStartBit.Margin = new Padding(4);
            NumericUpDownEx nudStartBit = this.m_nudStartBit;
            int[] array3 = new int[4];
            array3[0] = 31;
            nudStartBit.Maximum = new decimal(array3);
            this.m_nudStartBit.Minimum = new decimal(new int[4]);
            this.m_nudStartBit.Name = "m_nudStartBit";
            this.m_nudStartBit.Size = new Size(56, 25);
            this.m_nudStartBit.TabIndex = 4;
            this.m_nudStartBit.Value = new decimal(new int[4]);
            this.m_btnAllBits.Enabled = false;
            this.m_btnAllBits.Location = new Point(155, 133);
            this.m_btnAllBits.Margin = new Padding(4);
            this.m_btnAllBits.Name = "m_btnAllBits";
            this.m_btnAllBits.Size = new Size(76, 28);
            this.m_btnAllBits.TabIndex = 5;
            this.m_btnAllBits.Text = "All Bits";
            this.m_btnAllBits.UseVisualStyleBackColor = true;
            this.m_btnAllBits.Click += this.m_btnAllBits_Click;
            this.m_lblEndBit.AutoSize = true;
            this.m_lblEndBit.Location = new Point(7, 116);
            this.m_lblEndBit.Margin = new Padding(4, 0, 4, 0);
            this.m_lblEndBit.Name = "m_lblEndBit";
            this.m_lblEndBit.Size = new Size(55, 17);
            this.m_lblEndBit.TabIndex = 8;
            this.m_lblEndBit.Text = "End Bit";
            this.m_lblStartBit.AutoSize = true;
            this.m_lblStartBit.Location = new Point(73, 116);
            this.m_lblStartBit.Margin = new Padding(4, 0, 4, 0);
            this.m_lblStartBit.Name = "m_lblStartBit";
            this.m_lblStartBit.Size = new Size(60, 17);
            this.m_lblStartBit.TabIndex = 7;
            this.m_lblStartBit.Text = "Start Bit";
            this.m_lblValue.AutoSize = true;
            this.m_lblValue.Location = new Point(49, 79);
            this.m_lblValue.Margin = new Padding(4, 0, 4, 0);
            this.m_lblValue.Name = "m_lblValue";
            this.m_lblValue.Size = new Size(82, 17);
            this.m_lblValue.TabIndex = 6;
            this.m_lblValue.Text = "Value (Hex)";
            this.m_txtValue.Enabled = false;
            this.m_txtValue.Location = new Point(155, 75);
            this.m_txtValue.Margin = new Padding(4);
            this.m_txtValue.Name = "m_txtValue";
            this.m_txtValue.Size = new Size(115, 25);
            this.m_txtValue.TabIndex = 2;
            this.m_txtValue.Text = "0";
            this.m_txtValue.TextAlign = HorizontalAlignment.Right;
            this.m_txtAddr.Enabled = false;
            this.m_txtAddr.Location = new Point(155, 31);
            this.m_txtAddr.Margin = new Padding(4);
            this.m_txtAddr.Name = "m_txtAddr";
            this.m_txtAddr.Size = new Size(115, 25);
            this.m_txtAddr.TabIndex = 1;
            this.m_txtAddr.TextAlign = HorizontalAlignment.Right;
            this.m_lblAddr.AutoSize = true;
            this.m_lblAddr.Location = new Point(156, 11);
            this.m_lblAddr.Margin = new Padding(4, 0, 4, 0);
            this.m_lblAddr.Name = "m_lblAddr";
            this.m_lblAddr.Size = new Size(101, 17);
            this.m_lblAddr.TabIndex = 3;
            this.m_lblAddr.Text = "Address (Hex)";
            this.m_btnWrite.Enabled = false;
            this.m_btnWrite.Location = new Point(76, 28);
            this.m_btnWrite.Margin = new Padding(4);
            this.m_btnWrite.Name = "m_btnWrite";
            this.m_btnWrite.Size = new Size(63, 28);
            this.m_btnWrite.TabIndex = 2;
            this.m_btnWrite.Text = "Write";
            this.m_btnWrite.UseVisualStyleBackColor = true;
            this.m_btnWrite.Click += this.m_btnWrite_Click;
            this.m_btnRead.Enabled = false;
            this.m_btnRead.Location = new Point(8, 28);
            this.m_btnRead.Margin = new Padding(4);
            this.m_btnRead.Name = "m_btnRead";
            this.m_btnRead.Size = new Size(60, 28);
            this.m_btnRead.TabIndex = 0;
            this.m_btnRead.Text = "Read";
            this.m_btnRead.UseVisualStyleBackColor = true;
            this.m_btnRead.Click += this.m_btnRead_Click;
            this.m_grpBssReadWrite.Controls.Add(this.m_btnAllBitsBss);
            this.m_grpBssReadWrite.Controls.Add(this.m_nudEndBitBss);
            this.m_grpBssReadWrite.Controls.Add(this.m_nudStartBitBss);
            this.m_grpBssReadWrite.Controls.Add(this.label1);
            this.m_grpBssReadWrite.Controls.Add(this.label2);
            this.m_grpBssReadWrite.Controls.Add(this.m_btnBssRead);
            this.m_grpBssReadWrite.Controls.Add(this.m_nudProfileId);
            this.m_grpBssReadWrite.Controls.Add(this.m_lblProfileProfileId);
            this.m_grpBssReadWrite.Controls.Add(this.m_lblRegValue);
            this.m_grpBssReadWrite.Controls.Add(this.m_txtBssRegValue);
            this.m_grpBssReadWrite.Controls.Add(this.m_txtBssRegAddr);
            this.m_grpBssReadWrite.Controls.Add(this.m_lblRegAddr);
            this.m_grpBssReadWrite.Controls.Add(this.m_btnBssWrite);
            this.m_grpBssReadWrite.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_grpBssReadWrite.Location = new Point(56, 288);
            this.m_grpBssReadWrite.Margin = new Padding(4);
            this.m_grpBssReadWrite.Name = "m_grpBssReadWrite";
            this.m_grpBssReadWrite.Padding = new Padding(4);
            this.m_grpBssReadWrite.Size = new Size(304, 236);
            this.m_grpBssReadWrite.TabIndex = 37;
            this.m_grpBssReadWrite.TabStop = false;
            this.m_grpBssReadWrite.Text = "Sequencer Extension";
            this.m_btnAllBitsBss.Enabled = false;
            this.m_btnAllBitsBss.Location = new Point(160, 191);
            this.m_btnAllBitsBss.Margin = new Padding(4);
            this.m_btnAllBitsBss.Name = "m_btnAllBitsBss";
            this.m_btnAllBitsBss.Size = new Size(76, 28);
            this.m_btnAllBitsBss.TabIndex = 11;
            this.m_btnAllBitsBss.Text = "All Bits";
            this.m_btnAllBitsBss.UseVisualStyleBackColor = true;
            this.m_btnAllBitsBss.Click += this.m_btnAllBitsBss_Click;
            this.m_nudEndBitBss.ChangedByCode = false;
            this.m_nudEndBitBss.Enabled = false;
            this.m_nudEndBitBss.Location = new Point(11, 193);
            this.m_nudEndBitBss.Margin = new Padding(4);
            NumericUpDownEx nudEndBitBss = this.m_nudEndBitBss;
            int[] array4 = new int[4];
            array4[0] = 31;
            nudEndBitBss.Maximum = new decimal(array4);
            this.m_nudEndBitBss.Minimum = new decimal(new int[4]);
            this.m_nudEndBitBss.Name = "m_nudEndBitBss";
            this.m_nudEndBitBss.Size = new Size(56, 25);
            this.m_nudEndBitBss.TabIndex = 9;
            NumericUpDownEx nudEndBitBss2 = this.m_nudEndBitBss;
            int[] array5 = new int[4];
            array5[0] = 31;
            nudEndBitBss2.Value = new decimal(array5);
            this.m_nudStartBitBss.ChangedByCode = false;
            this.m_nudStartBitBss.Enabled = false;
            this.m_nudStartBitBss.Location = new Point(77, 193);
            this.m_nudStartBitBss.Margin = new Padding(4);
            NumericUpDownEx nudStartBitBss = this.m_nudStartBitBss;
            int[] array6 = new int[4];
            array6[0] = 31;
            nudStartBitBss.Maximum = new decimal(array6);
            this.m_nudStartBitBss.Minimum = new decimal(new int[4]);
            this.m_nudStartBitBss.Name = "m_nudStartBitBss";
            this.m_nudStartBitBss.Size = new Size(56, 25);
            this.m_nudStartBitBss.TabIndex = 10;
            this.m_nudStartBitBss.Value = new decimal(new int[4]);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(8, 176);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(55, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "End Bit";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(75, 176);
            this.label2.Margin = new Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(60, 17);
            this.label2.TabIndex = 35;
            this.label2.Text = "Start Bit";
            this.m_btnBssRead.Enabled = false;
            this.m_btnBssRead.Location = new Point(11, 90);
            this.m_btnBssRead.Margin = new Padding(4);
            this.m_btnBssRead.Name = "m_btnBssRead";
            this.m_btnBssRead.Size = new Size(60, 28);
            this.m_btnBssRead.TabIndex = 10;
            this.m_btnBssRead.Text = "Read";
            this.m_btnBssRead.UseVisualStyleBackColor = true;
            this.m_btnBssRead.Click += this.m_btnBssRead_Click;
            this.m_nudProfileId.Enabled = false;
            this.m_nudProfileId.Location = new Point(156, 41);
            this.m_nudProfileId.Margin = new Padding(4);
            NumericUpDown nudProfileId = this.m_nudProfileId;
            int[] array7 = new int[4];
            array7[0] = 16;
            nudProfileId.Maximum = new decimal(array7);
            this.m_nudProfileId.Name = "m_nudProfileId";
            this.m_nudProfileId.Size = new Size(115, 25);
            this.m_nudProfileId.TabIndex = 6;
            this.m_lblProfileProfileId.AutoSize = true;
            this.m_lblProfileProfileId.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_lblProfileProfileId.Location = new Point(59, 43);
            this.m_lblProfileProfileId.Margin = new Padding(4, 0, 4, 0);
            this.m_lblProfileProfileId.Name = "m_lblProfileProfileId";
            this.m_lblProfileProfileId.Size = new Size(64, 17);
            this.m_lblProfileProfileId.TabIndex = 8;
            this.m_lblProfileProfileId.Text = "Profile Id";
            this.m_lblRegValue.AutoSize = true;
            this.m_lblRegValue.Location = new Point(35, 143);
            this.m_lblRegValue.Margin = new Padding(4, 0, 4, 0);
            this.m_lblRegValue.Name = "m_lblRegValue";
            this.m_lblRegValue.Size = new Size(82, 17);
            this.m_lblRegValue.TabIndex = 6;
            this.m_lblRegValue.Text = "Value (Hex)";
            this.m_txtBssRegValue.Enabled = false;
            this.m_txtBssRegValue.Location = new Point(156, 139);
            this.m_txtBssRegValue.Margin = new Padding(4);
            this.m_txtBssRegValue.Name = "m_txtBssRegValue";
            this.m_txtBssRegValue.Size = new Size(115, 25);
            this.m_txtBssRegValue.TabIndex = 8;
            this.m_txtBssRegValue.Text = "0";
            this.m_txtBssRegValue.TextAlign = HorizontalAlignment.Right;
            this.m_txtBssRegAddr.Enabled = false;
            this.m_txtBssRegAddr.Location = new Point(155, 92);
            this.m_txtBssRegAddr.Margin = new Padding(4);
            this.m_txtBssRegAddr.Name = "m_txtBssRegAddr";
            this.m_txtBssRegAddr.Size = new Size(115, 25);
            this.m_txtBssRegAddr.TabIndex = 7;
            this.m_txtBssRegAddr.TextAlign = HorizontalAlignment.Right;
            this.m_lblRegAddr.AutoSize = true;
            this.m_lblRegAddr.Location = new Point(156, 73);
            this.m_lblRegAddr.Margin = new Padding(4, 0, 4, 0);
            this.m_lblRegAddr.Name = "m_lblRegAddr";
            this.m_lblRegAddr.Size = new Size(101, 17);
            this.m_lblRegAddr.TabIndex = 3;
            this.m_lblRegAddr.Text = "Address (Hex)";
            this.m_btnBssWrite.Enabled = false;
            this.m_btnBssWrite.Location = new Point(75, 90);
            this.m_btnBssWrite.Margin = new Padding(4);
            this.m_btnBssWrite.Name = "m_btnBssWrite";
            this.m_btnBssWrite.Size = new Size(60, 28);
            this.m_btnBssWrite.TabIndex = 2;
            this.m_btnBssWrite.Text = "Write";
            this.m_btnBssWrite.UseVisualStyleBackColor = true;
            this.m_btnBssWrite.Click += this.m_btnBssWrite_Click;
            this.groupBox1.Controls.Add(this.m_cboDbgSignal);
            this.groupBox1.Controls.Add(this.m_btnSetDbgSig);
            this.groupBox1.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.groupBox1.Location = new Point(447, 36);
            this.groupBox1.Margin = new Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new Padding(4);
            this.groupBox1.Size = new Size(276, 143);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Debug Signal";
            this.m_cboDbgSignal.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_cboDbgSignal.FormattingEnabled = true;
            this.m_cboDbgSignal.Items.AddRange(new object[]
            {
                "NO MUX",
                "APLL OUT",
                "SYNTH OUT(2.5G)",
                "SYNTH OUT(5G)"
            });
            this.m_cboDbgSignal.Location = new Point(65, 42);
            this.m_cboDbgSignal.Margin = new Padding(4);
            this.m_cboDbgSignal.Name = "m_cboDbgSignal";
            this.m_cboDbgSignal.Size = new Size(185, 25);
            this.m_cboDbgSignal.TabIndex = 12;
            this.m_btnSetDbgSig.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_btnSetDbgSig.Location = new Point(141, 79);
            this.m_btnSetDbgSig.Margin = new Padding(4);
            this.m_btnSetDbgSig.Name = "m_btnSetDbgSig";
            this.m_btnSetDbgSig.Size = new Size(111, 33);
            this.m_btnSetDbgSig.TabIndex = 13;
            this.m_btnSetDbgSig.Text = "Set";
            this.m_btnSetDbgSig.UseVisualStyleBackColor = true;
            this.m_btnSetDbgSig.Click += this.m_btnDbgSig_Click;
            this.m_grpSequenceExtensionCheck.Controls.Add(this.m_lblSeqRAMAvailable);
            this.m_grpSequenceExtensionCheck.Controls.Add(this.m_btnRegisterCheck);
            this.m_grpSequenceExtensionCheck.Controls.Add(this.m_txtRegisterAddr);
            this.m_grpSequenceExtensionCheck.Controls.Add(this.label4);
            this.m_grpSequenceExtensionCheck.Controls.Add(this.label3);
            this.m_grpSequenceExtensionCheck.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_grpSequenceExtensionCheck.Location = new Point(447, 350);
            this.m_grpSequenceExtensionCheck.Margin = new Padding(4);
            this.m_grpSequenceExtensionCheck.Name = "m_grpSequenceExtensionCheck";
            this.m_grpSequenceExtensionCheck.Padding = new Padding(4);
            this.m_grpSequenceExtensionCheck.Size = new Size(276, 188);
            this.m_grpSequenceExtensionCheck.TabIndex = 39;
            this.m_grpSequenceExtensionCheck.TabStop = false;
            this.m_grpSequenceExtensionCheck.Text = "Sequence Extension Check";
            this.m_lblSeqRAMAvailable.AutoSize = true;
            this.m_lblSeqRAMAvailable.Font = new Font("Arial", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.m_lblSeqRAMAvailable.Location = new Point(153, 144);
            this.m_lblSeqRAMAvailable.Margin = new Padding(4, 0, 4, 0);
            this.m_lblSeqRAMAvailable.Name = "m_lblSeqRAMAvailable";
            this.m_lblSeqRAMAvailable.Size = new Size(53, 18);
            this.m_lblSeqRAMAvailable.TabIndex = 54;
            this.m_lblSeqRAMAvailable.Text = "Status";
            this.m_btnRegisterCheck.Location = new Point(143, 85);
            this.m_btnRegisterCheck.Margin = new Padding(4);
            this.m_btnRegisterCheck.Name = "m_btnRegisterCheck";
            this.m_btnRegisterCheck.Size = new Size(111, 33);
            this.m_btnRegisterCheck.TabIndex = 4;
            this.m_btnRegisterCheck.Text = "Check";
            this.m_btnRegisterCheck.UseVisualStyleBackColor = true;
            this.m_btnRegisterCheck.Click += this.m_btnRegisterCheck_Click;
            this.m_txtRegisterAddr.CharacterCasing = CharacterCasing.Lower;
            this.m_txtRegisterAddr.Location = new Point(119, 50);
            this.m_txtRegisterAddr.Margin = new Padding(4);
            this.m_txtRegisterAddr.Name = "m_txtRegisterAddr";
            this.m_txtRegisterAddr.Size = new Size(132, 25);
            this.m_txtRegisterAddr.TabIndex = 2;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(12, 144);
            this.label4.Margin = new Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(74, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Availability";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(8, 54);
            this.label3.Margin = new Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(78, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Value(Hex)";
            this.m_grpADCStart.Controls.Add(this.f000208);
            this.m_grpADCStart.Controls.Add(this.m_btnADCSet);
            this.m_grpADCStart.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_grpADCStart.Location = new Point(447, 193);
            this.m_grpADCStart.Margin = new Padding(4);
            this.m_grpADCStart.Name = "m_grpADCStart";
            this.m_grpADCStart.Padding = new Padding(4);
            this.m_grpADCStart.Size = new Size(276, 142);
            this.m_grpADCStart.TabIndex = 40;
            this.m_grpADCStart.TabStop = false;
            this.m_grpADCStart.Text = "GPIO_0";
            this.f000208.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.f000208.FormattingEnabled = true;
            this.f000208.Items.AddRange(new object[]
            {
                "FUNC_GPIO",
                "FUNC_ADC_VALID"
            });
            this.f000208.Location = new Point(65, 42);
            this.f000208.Margin = new Padding(4);
            this.f000208.Name = "m_cboGPIOSignal";
            this.f000208.Size = new Size(185, 25);
            this.f000208.TabIndex = 13;
            this.m_btnADCSet.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.m_btnADCSet.Location = new Point(141, 86);
            this.m_btnADCSet.Margin = new Padding(4);
            this.m_btnADCSet.Name = "m_btnADCSet";
            this.m_btnADCSet.Size = new Size(111, 33);
            this.m_btnADCSet.TabIndex = 0;
            this.m_btnADCSet.Text = "Set";
            this.m_btnADCSet.UseVisualStyleBackColor = true;
            this.m_btnADCSet.Click += this.m_btnADCSet_Click;
            this.groupBox2.Controls.Add(this.m_nudDataBlockLength);
            this.groupBox2.Controls.Add(this.m_txtMSSBlockStartAddr);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.m_btnMSSGetContiguousBlockConfigSet);
            this.groupBox2.Location = new Point(784, 37);
            this.groupBox2.Margin = new Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new Padding(4);
            this.groupBox2.Size = new Size(375, 174);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MSS Get Data Block Config";
            NumericUpDown nudDataBlockLength = this.m_nudDataBlockLength;
            int[] array8 = new int[4];
            array8[0] = 4;
            nudDataBlockLength.Increment = new decimal(array8);
            this.m_nudDataBlockLength.Location = new Point(197, 62);
            this.m_nudDataBlockLength.Margin = new Padding(4);
            NumericUpDown nudDataBlockLength2 = this.m_nudDataBlockLength;
            int[] array9 = new int[4];
            array9[0] = 220;
            nudDataBlockLength2.Maximum = new decimal(array9);
            this.m_nudDataBlockLength.Name = "m_nudDataBlockLength";
            this.m_nudDataBlockLength.Size = new Size(133, 22);
            this.m_nudDataBlockLength.TabIndex = 10;
            this.m_txtMSSBlockStartAddr.Location = new Point(196, 21);
            this.m_txtMSSBlockStartAddr.Margin = new Padding(4);
            this.m_txtMSSBlockStartAddr.Name = "m_txtMSSBlockStartAddr";
            this.m_txtMSSBlockStartAddr.Size = new Size(137, 22);
            this.m_txtMSSBlockStartAddr.TabIndex = 9;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(15, 62);
            this.label6.Margin = new Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(86, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Data Length";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(11, 26);
            this.label5.Margin = new Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(174, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Block Start  Address (Hex)";
            this.m_btnMSSGetContiguousBlockConfigSet.Location = new Point(233, 117);
            this.m_btnMSSGetContiguousBlockConfigSet.Margin = new Padding(4);
            this.m_btnMSSGetContiguousBlockConfigSet.Name = "m_btnMSSGetContiguousBlockConfigSet";
            this.m_btnMSSGetContiguousBlockConfigSet.Size = new Size(100, 39);
            this.m_btnMSSGetContiguousBlockConfigSet.TabIndex = 0;
            this.m_btnMSSGetContiguousBlockConfigSet.Text = "Set";
            this.m_btnMSSGetContiguousBlockConfigSet.UseVisualStyleBackColor = true;
            this.m_btnMSSGetContiguousBlockConfigSet.Click += this.m_btnMSSGetContiguousBlockConfigSet_Click;
            this.f000209.Controls.Add(this.f00020f);
            this.f000209.Controls.Add(this.label8);
            this.f000209.Controls.Add(this.label7);
            this.f000209.Controls.Add(this.f00020e);
            this.f000209.Controls.Add(this.label9);
            this.f000209.Controls.Add(this.f00020a);
            this.f000209.Controls.Add(this.f00020b);
            this.f000209.Controls.Add(this.label10);
            this.f000209.Controls.Add(this.f00020c);
            this.f000209.Controls.Add(this.f00020d);
            this.f000209.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.f000209.Location = new Point(784, 242);
            this.f000209.Margin = new Padding(4);
            this.f000209.Name = "m_grpTDAxxGPIO";
            this.f000209.Padding = new Padding(4);
            this.f000209.Size = new Size(375, 251);
            this.f000209.TabIndex = 42;
            this.f000209.TabStop = false;
            this.f000209.Text = "TDA GPIO";
            this.f000209.Visible = false;
            this.label7.AutoSize = true;
            this.label7.Location = new Point(17, 163);
            this.label7.Margin = new Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new Size(122, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "GPIO Value (Hex)";
            this.f00020e.Location = new Point(155, 160);
            this.f00020e.Margin = new Padding(4);
            this.f00020e.Name = "m_valTDAGPIOValue";
            this.f00020e.Size = new Size(115, 25);
            this.f00020e.TabIndex = 7;
            this.f00020e.TextAlign = HorizontalAlignment.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new Point(63, 122);
            this.label9.Margin = new Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(69, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "GPIO Pin";
            this.f00020a.Location = new Point(155, 119);
            this.f00020a.Margin = new Padding(4);
            this.f00020a.Name = "m_valTDAGPIOPin";
            this.f00020a.Size = new Size(115, 25);
            this.f00020a.TabIndex = 2;
            this.f00020a.TextAlign = HorizontalAlignment.Right;
            this.f00020b.Location = new Point(155, 79);
            this.f00020b.Margin = new Padding(4);
            this.f00020b.Name = "m_valTDAGPIOBase";
            this.f00020b.Size = new Size(115, 25);
            this.f00020b.TabIndex = 1;
            this.f00020b.TextAlign = HorizontalAlignment.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new Point(51, 83);
            this.label10.Margin = new Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new Size(82, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "GPIO Base";
            this.f00020c.Location = new Point(155, 206);
            this.f00020c.Margin = new Padding(4);
            this.f00020c.Name = "m_btnTDAGPIOWrite";
            this.f00020c.Size = new Size(63, 28);
            this.f00020c.TabIndex = 2;
            this.f00020c.Text = "Write";
            this.f00020c.UseVisualStyleBackColor = true;
            this.f00020c.Click += this.m00005f;
            this.f00020d.Location = new Point(87, 206);
            this.f00020d.Margin = new Padding(4);
            this.f00020d.Name = "m_btnTDAGPIORead";
            this.f00020d.Size = new Size(60, 28);
            this.f00020d.TabIndex = 0;
            this.f00020d.Text = "Read";
            this.f00020d.UseVisualStyleBackColor = true;
            this.f00020d.Click += this.m00005e;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(25, 43);
            this.label8.Margin = new Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new Size(107, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Pin Description";
            this.f00020f.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.f00020f.FormattingEnabled = true;
            this.f00020f.Items.AddRange(new object[]
            {
                "AWR1_RESETN",
                "AWR2_RESETN",
                "AWR3_RESETN",
                "AWR4_RESETN",
                "AWR_WARM_RST",
                "AWR_SOP2",
                "AWR_SOP0",
                "AWR_SOP1",
                "CUSTOM_GPIO"
            });
            this.f00020f.Location = new Point(155, 37);
            this.f00020f.Margin = new Padding(4);
            this.f00020f.Name = "m_boxGPIOPinSelect";
            this.f00020f.Size = new Size(185, 25);
            this.f00020f.TabIndex = 14;
            this.f00020f.SelectedIndexChanged += this.m_boxGPIOPinSelect_SelectedIndexChanged;
            base.AutoScaleDimensions = new SizeF(8f, 16f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.f000209);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.m_grpADCStart);
            base.Controls.Add(this.m_grpSequenceExtensionCheck);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.m_grpBssReadWrite);
            base.Controls.Add(this.m_grpReadWrite);
            base.Margin = new Padding(4);
            base.Name = "RegOpeTab";
            base.Size = new Size(1183, 756);
            this.m_grpReadWrite.ResumeLayout(false);
            this.m_grpReadWrite.PerformLayout();
            ((ISupportInitialize)this.m_nudEndBit).EndInit();
            ((ISupportInitialize)this.m_nudStartBit).EndInit();
            this.m_grpBssReadWrite.ResumeLayout(false);
            this.m_grpBssReadWrite.PerformLayout();
            ((ISupportInitialize)this.m_nudEndBitBss).EndInit();
            ((ISupportInitialize)this.m_nudStartBitBss).EndInit();
            ((ISupportInitialize)this.m_nudProfileId).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.m_grpSequenceExtensionCheck.ResumeLayout(false);
            this.m_grpSequenceExtensionCheck.PerformLayout();
            this.m_grpADCStart.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((ISupportInitialize)this.m_nudDataBlockLength).EndInit();
            this.f000209.ResumeLayout(false);
            this.f000209.PerformLayout();
            base.ResumeLayout(false);
        }

        private SerialPortWrapper m_SPWrapper;

        private GuiManager m_GuiManager = GlobalRef.GuiManager;

        private AR1xxxWrapper m_TsWrapper = GlobalRef.TsWrapper;

        private MSSGetDataBlockConfigParams m_MSSGetDataBlockConfigParams;

        public c000263 f000206;

        public frmAR1Main m_MainForm;

        public int m_GbgSigIndex;

        public int f000207;

        private IContainer components;

        private GroupBox m_grpReadWrite;

        private NumericUpDownEx m_nudEndBit;

        private NumericUpDownEx m_nudStartBit;

        private Button m_btnAllBits;

        private Label m_lblEndBit;

        private Label m_lblStartBit;

        private Label m_lblValue;

        private TextBox m_txtValue;

        private TextBox m_txtAddr;

        private Label m_lblAddr;

        private Button m_btnWrite;

        private Button m_btnRead;

        private GroupBox m_grpBssReadWrite;

        private Label m_lblRegValue;

        private TextBox m_txtBssRegValue;

        private TextBox m_txtBssRegAddr;

        private Label m_lblRegAddr;

        private Button m_btnBssWrite;

        private NumericUpDown m_nudProfileId;

        private Label m_lblProfileProfileId;

        private Button m_btnBssRead;

        private Button m_btnAllBitsBss;

        private NumericUpDownEx m_nudEndBitBss;

        private NumericUpDownEx m_nudStartBitBss;

        private Label label1;

        private Label label2;

        private GroupBox groupBox1;

        private Button m_btnSetDbgSig;

        private ComboBox m_cboDbgSignal;

        private GroupBox m_grpSequenceExtensionCheck;

        private Button m_btnRegisterCheck;

        private TextBox m_txtRegisterAddr;

        private Label label4;

        private Label label3;

        private Label m_lblSeqRAMAvailable;

        private GroupBox m_grpADCStart;

        private Button m_btnADCSet;

        private ComboBox f000208;

        private GroupBox groupBox2;

        private NumericUpDown m_nudDataBlockLength;

        private TextBox m_txtMSSBlockStartAddr;

        private Label label6;

        private Label label5;

        private Button m_btnMSSGetContiguousBlockConfigSet;

        private GroupBox f000209;

        private Label label9;

        private TextBox f00020a;

        private TextBox f00020b;

        private Label label10;

        private Button f00020c;

        private Button f00020d;

        private Label label7;

        private TextBox f00020e;

        private ComboBox f00020f;

        private Label label8;
    }
}
