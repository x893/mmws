using System;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using LuaRegister;

namespace AR1xController
{
	public class SerialPortWrapper
	{
		public SerialPortWrapper()
		{
			this.m_bReconnected = false;
		}

		public uint Init(string com_port, int baudrate)
		{
			try
			{
				this.m_SP = new SerialPort(com_port, baudrate);
				Thread.Sleep(400);
				this.m_SP.ReadBufferSize = 131072;
				this.iOpenPort();
				this.m_SP.WriteLine("x0 \r");
			}
			catch (Exception ex)
			{
				GlobalRef.GuiManager.Error("Serial Port Init(): " + ex.Message);
				return 1U;
			}
			Thread.Sleep(400);
			if (this.IsConnected())
			{
				this.m_SP.WriteLine("x0 \r");
				return 0U;
			}
			if (this.m_bReconnected)
			{
				this.Close();
				this.m_bReconnected = false;
				return 2U;
			}
			return this.iReconnectChangeBaudRate(com_port, baudrate);
		}

		public uint Close()
		{
			if (this.m_SP != null)
			{
				this.m_SP.Close();
				this.m_SP.Dispose();
			}
			return 0U;
		}

		public bool IsConnected()
		{
			if (this.m_SP.IsOpen)
			{
				this.m_SP.WriteLine("x0 \r");
				Thread.Sleep(100);
				uint num;
				return this.Read(4294959868U, out num) == 0U;
			}
			this.Close();
			return false;
		}

		public uint Read(uint addr, uint start_bit, uint end_bit)
		{
			uint num2;
			uint num = this.Read(addr, out num2);
			if (num != 0U)
			{
				GlobalRef.GuiManager.Error("Read returned error code:" + num);
				return num;
			}
			if (this.iBitValidation(start_bit, end_bit))
			{
				num2 = this.iGetBitsRange(num2, start_bit, end_bit);
				return num2;
			}
			return uint.MaxValue;
		}

		public uint Read(uint addr, out uint val)
		{
			string command = string.Format("rd {0}\r", addr.ToString("x").PadLeft(8, '0'));
			string s;
			this.SendAndRead(command, out s, 100);
			if (uint.TryParse(s, NumberStyles.HexNumber, null, out val))
			{
				return 0U;
			}
			return 1U;
		}

		public uint Write(uint addr, uint val)
		{
			if (this.m_SP == null)
			{
				GlobalRef.GuiManager.Error("Write Error: Invalid handle value");
				return 1U;
			}
			string text = string.Format("wr {0} {1}\r", addr.ToString("x").PadLeft(8, '0'), val.ToString("x").PadLeft(8, '0'));
			this.m_SP.Write(text);
			return 0U;
		}

		public int ReadBlock(uint addr, uint num_of_dwords, out string out_buffer)
		{
			string empty = string.Empty;
			out_buffer = "";
			string str = "";
			uint num = num_of_dwords;
			uint num2 = addr;
			while (num > 0U)
			{
				uint num3;
				if (num >= 1024U)
				{
					num3 = 1024U;
				}
				else
				{
					num3 = num;
				}
				uint num4 = num2 + (num3 - 1U) * 4U;
				string command = string.Format("rd {0} {1}\r", num2.ToString("x").PadLeft(8, '0'), num4.ToString("x").PadLeft(8, '0'));
				this.SendAndBlockRead(command, out str, 4000);
				out_buffer += str;
				num -= num3;
				num2 += num3 * 4U;
			}
			return 0;
		}

		private uint SendAndBlockRead(string command, out string response, int timeout)
		{
			string empty = string.Empty;
			string empty2 = string.Empty;
			string empty3 = string.Empty;
			string empty4 = string.Empty;
			string empty5 = string.Empty;
			string empty6 = string.Empty;
			string empty7 = string.Empty;
			string empty8 = string.Empty;
			response = "";
			if (this.m_SP.BaudRate == 921600 && timeout > 100)
			{
				int num = timeout / 7;
			}
			if (this.m_SP.IsOpen)
			{
				this.m_SP.ReadExisting();
				this.m_SP.Write(command);
				Thread.Sleep(timeout);
				while (this.m_SP.BytesToRead != 0)
				{
					response += this.m_SP.ReadExisting();
					if (this.m_SP.BytesToRead != 0)
					{
						GlobalRef.GuiManager.Warning("#####Timeout : " + timeout);
						Thread.Sleep(timeout);
					}
				}
				return 0U;
			}
			return 4U;
		}

		public int WriteBlockReg(uint addr, uint[] values, uint num_of_dwords)
		{
			string text = "";
			string text2 = string.Format("wr {0}", addr.ToString("x").PadLeft(8, '0'));
			int num = 0;
			while ((long)num < (long)((ulong)num_of_dwords))
			{
				text += string.Format("{0} ", values[num].ToString("x").PadLeft(8, '0'));
				num++;
			}
			text2 = text2 + " " + text + "\r";
			this.m_SP.Write(text2);
			return 0;
		}

		public int WriteBlockRegDSS(uint addr, uint[] values, uint num_of_dwords)
		{
			string text = "";
			string text2 = string.Format("wr {0}", addr.ToString("x").PadLeft(8, '0'));
			int num = 0;
			while ((long)num < (long)((ulong)num_of_dwords))
			{
				text += string.Format("{0} ", values[num].ToString("x").PadLeft(8, '0'));
				num++;
			}
			text2 = text2 + " " + text + "\r";
			this.m_SP.Write(text2);
			return 0;
		}

		public int RegWrite(uint addr, byte[] values, uint num_of_dwords)
		{
			string text = "";
			string text2 = string.Format("wr {0}", addr.ToString("x").PadLeft(8, '0'));
			int num = 0;
			while ((long)num < (long)((ulong)num_of_dwords))
			{
				text += string.Format("{0} ", values[num].ToString("x").PadLeft(8, '0'));
				num++;
			}
			text2 = text2 + " " + text + "\r";
			this.m_SP.Write(text2);
			return 0;
		}

		[AttrLuaFunc("WriteBlockMB", "Write a block of registers", new string[]
		{
			"absolute address",
			"number of registers to write",
			"file name path"
		})]
		public int WriteBlockMB(uint addr, uint[] values, uint num_of_dwords)
		{
			string text = "";
			string text2 = string.Format("wr {0}", addr.ToString("x").PadLeft(8, '0'));
			int num = 0;
			while ((long)num < (long)((ulong)num_of_dwords))
			{
				text += string.Format("{0} ", values[num].ToString("x").PadLeft(8, '0'));
				num++;
			}
			text2 = text2 + " " + text + "\r";
			this.m_SP.Write(text2);
			return 0;
		}

		private uint SendAndRead(string command, out string response, int timeout)
		{
			response = "";
			if (this.m_SP.BaudRate == 921600 && timeout > 100)
			{
				int num = timeout / 7;
			}
			if (this.m_SP.IsOpen)
			{
				this.m_SP.ReadExisting();
				this.m_SP.Write(command);
				Thread.Sleep(timeout);
				while (this.m_SP.BytesToRead != 0)
				{
					response += this.m_SP.ReadExisting();
					if (this.m_SP.BytesToRead != 0)
					{
						GlobalRef.GuiManager.Warning("#####Timeout : " + timeout);
						Thread.Sleep(timeout);
					}
				}
				return 0U;
			}
			return 4U;
		}

		public uint iGetBitsRange(uint val, uint start_bit, uint end_bit)
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

		private void iOpenPort()
		{
			int num = 0;
			while (!this.m_SP.IsOpen)
			{
				try
				{
					this.m_SP.Close();
					this.m_SP.Dispose();
					this.m_SP.Open();
				}
				catch (UnauthorizedAccessException ex)
				{
					GlobalRef.GuiManager.Warning("Serial Port Init(): " + ex.Message);
					this.m_SP.Close();
					this.m_SP.Dispose();
					Thread.Sleep(100);
					if (num == 3)
					{
						GlobalRef.GuiManager.Warning("Please check selected port is being accssed by either some other process or some application !!!!:");
						break;
					}
					num++;
				}
			}
		}

		private uint iReconnectChangeBaudRate(string com_port, int baudrate)
		{
			int millisecondsTimeout = 300;
			uint val = 1820417371U;
			this.m_bReconnected = true;
			if (baudrate != 115200)
			{
				if (baudrate == 921600)
				{
					this.m_SP.BaudRate = 115200;
					val = 227552299U;
				}
			}
			else
			{
				this.m_SP.BaudRate = 921600;
				val = 1820417371U;
			}
			Thread.Sleep(500);
			this.iOpenPort();
			Thread.Sleep(500);
			if (this.IsConnected())
			{
				Thread.Sleep(millisecondsTimeout);
				GlobalRef.GuiManager.Warning("Connected with baudrate " + this.m_SP.BaudRate);
				uint num;
				this.Read(4294959428U, out num);
				num |= 30720U;
				this.Write(4294959428U, num);
				Thread.Sleep(millisecondsTimeout);
				this.Write(4294959716U, val);
				Thread.Sleep(millisecondsTimeout);
				if (this.m_SP.BaudRate == 115200)
				{
					this.m_SP.BaudRate = 921600;
				}
				else
				{
					this.m_SP.BaudRate = 115200;
				}
				this.Close();
				Thread.Sleep(millisecondsTimeout);
				this.IsConnected();
				GlobalRef.GuiManager.Warning("Disconnected existing BaudRate");
				Thread.Sleep(millisecondsTimeout);
				GlobalRef.GuiManager.Warning("Trying to connect with baudrate " + this.m_SP.BaudRate);
				Thread.Sleep(millisecondsTimeout);
				this.m_bReconnected = false;
				return this.Init(com_port, this.m_SP.BaudRate);
			}
			this.m_bReconnected = false;
			this.Close();
			return 3U;
		}

		public void WriteBlock(uint Address, byte[] Data, int val)
		{
			string text = "";
			string text2 = string.Format("wr {0}", Address.ToString("x").PadLeft(8, '0'));
			for (int i = 0; i < val; i += 4)
			{
				text += string.Format("{0} ", BitConverter.ToUInt32(Data, i).ToString("x").PadLeft(8, '0'));
			}
			text2 = text2 + " " + text + "\r";
			this.m_SP.Write(text2);
		}

		public void DSSWriteBlock(uint Address, byte[] Data, int val)
		{
			string text = "";
			string text2 = string.Format("wr {0}", Address.ToString("x").PadLeft(8, '0'));
			for (int i = 0; i < val; i += 4)
			{
				text += string.Format("{0} ", BitConverter.ToUInt32(Data, i).ToString("x").PadLeft(8, '0'));
			}
			text2 = text2 + " " + text + "\r";
			this.m_SP.Write(text2);
		}

		public void DSSWriteBlockForHexFormat(uint Address, uint[] values, uint num_of_dwords)
		{
			string text = "";
			string text2 = string.Format("wr {0}", Address.ToString("x").PadLeft(8, '0'));
			int num = 0;
			while ((long)num < (long)((ulong)num_of_dwords))
			{
				text += string.Format("{0} ", values[num].ToString("x").PadLeft(8, '0'));
				num++;
			}
			text2 = text2 + " " + text + "\r";
			this.m_SP.Write(text2);
		}

		public void DSSWriteBlockForHexFormatIntData(uint Address, uint values, uint num_of_dwords)
		{
			string text = "";
			string text2 = string.Format("wr {0}", Address.ToString("x").PadLeft(8, '0'));
			text += string.Format("{0} ", values.ToString("x").PadLeft(8, '0'));
			text2 = text2 + " " + text + "\r";
			this.m_SP.Write(text2);
		}

		public int OldVersionDownloadToDevice(string file_path)
		{
			byte[] array = new byte[0];
			byte[] source = new byte[0];
			IntPtr zero = IntPtr.Zero;
			byte[] array2 = new byte[0];
			ushort num = 4096;
			uint num2 = 0U;
			uint num3 = 0U;
			GlobalRef.m_FwDownloadProgress = 0;
			array = File.ReadAllBytes(file_path);
			uint num4 = BitConverter.ToUInt32(array, 4);
			uint num5 = BitConverter.ToUInt32(array, 8);
			array = array.Skip(16).Take(array.Length).ToArray<byte>();
			uint num6 = num4 - 16U - num5 * 8U;
			while (num5 > 0U)
			{
				uint num7 = BitConverter.ToUInt32(array, 0);
				uint num8 = BitConverter.ToUInt32(array, 4);
				source = array.Skip(8).Take((int)num8).ToArray<byte>();
				for (uint num9 = 0U; num9 <= num8 / (uint)num; num9 += 1U)
				{
					array2 = source.Skip((int)((uint)num * num9)).Take((int)num).ToArray<byte>();
					if (array2.Length < (int)num)
					{
						int num10 = array2.Length;
					}
					this.WriteBlock(num7, array2, array2.Length);
					num7 += (uint)array2.Length;
					if (num8 < 8U)
					{
						num2 += (uint)(array2.Length * 2);
						num3 += (uint)(array2.Length * 2);
					}
					else
					{
						num2 += (uint)array2.Length;
						num3 += (uint)array2.Length;
					}
					GlobalRef.m_FwDownloadProgress = (int)(num2 * 100U / num6);
				}
				array = array.Skip((int)(8U + num3)).Take((int)(num4 - (8U + num3))).ToArray<byte>();
				num3 = 0U;
				num5 -= 1U;
			}
			GlobalRef.m_FwDownloadProgress = 100;
			return 0;
		}

		public int DownloadToDevice(string file_path)
		{
			byte[] array = new byte[0];
			byte[] source = new byte[0];
			IntPtr zero = IntPtr.Zero;
			byte[] array2 = new byte[0];
			ushort num = 4096;
			uint num2 = 0U;
			uint num3 = 0U;
			array = File.ReadAllBytes(file_path);
			uint num4 = (uint)array.Length;
			uint num5 = BitConverter.ToUInt32(array, 12);
			array = array.Skip(24).Take(array.Length).ToArray<byte>();
			uint num6 = num4 - 24U - num5 * 24U;
			GlobalRef.m_FwDownloadProgress = 0;
			while (num5 > 0U)
			{
				uint num7 = BitConverter.ToUInt32(array, 0);
				if (ConnectTab.m_BSSDwnld || GlobalRef.g_BSSFwDl)
				{
					if (num7 >= 134217728U)
					{
						num7 += 956301312U;
					}
					else
					{
						num7 += 1073741824U;
					}
				}
				else if (!ConnectTab.m_MSSDwnld)
				{
					bool g_MSSFwDl = GlobalRef.g_MSSFwDl;
				}
				uint num8 = BitConverter.ToUInt32(array, 8);
				num8 += num8 % 8U;
				source = array.Skip(24).Take((int)num8).ToArray<byte>();
				for (uint num9 = 0U; num9 <= num8 / (uint)num; num9 += 1U)
				{
					array2 = source.Skip((int)((uint)num * num9)).Take((int)num).ToArray<byte>();
					if (array2.Length < (int)num)
					{
						int num10 = array2.Length;
					}
					this.WriteBlock(num7, array2, array2.Length);
					num7 += (uint)array2.Length;
					if (num8 < 8U)
					{
						num2 += (uint)(array2.Length * 2);
						num3 += (uint)(array2.Length * 2);
					}
					else
					{
						num2 += (uint)array2.Length;
						num3 += (uint)array2.Length;
					}
					GlobalRef.m_FwDownloadProgress = (int)(num2 * 100U / num6);
				}
				array = array.Skip((int)(24U + num3)).Take((int)(num4 - (24U + num3))).ToArray<byte>();
				num3 = 0U;
				num5 -= 1U;
			}
			GlobalRef.m_FwDownloadProgress = 100;
			return 0;
		}

		public int DownloadDSPFwToDevice(string file_path)
		{
			byte[] array = new byte[0];
			byte[] source = new byte[0];
			IntPtr zero = IntPtr.Zero;
			byte[] array2 = new byte[0];
			ushort num = 4096;
			uint num2 = 0U;
			uint num3 = 0U;
			array = File.ReadAllBytes(file_path);
			uint num4 = (uint)array.Length;
			uint num5 = BitConverter.ToUInt32(array, 12);
			array = array.Skip(24).Take(array.Length).ToArray<byte>();
			uint num6 = num4 - 24U - num5 * 24U;
			GlobalRef.m_FwDownloadProgress = 0;
			while (num5 > 0U)
			{
				uint num7 = BitConverter.ToUInt32(array, 0);
				num7 += 1459617792U;
				uint num8 = BitConverter.ToUInt32(array, 8);
				num8 += num8 % 8U;
				source = array.Skip(24).Take((int)num8).ToArray<byte>();
				for (uint num9 = 0U; num9 <= num8 / (uint)num; num9 += 1U)
				{
					array2 = source.Skip((int)((uint)num * num9)).Take((int)num).ToArray<byte>();
					if (array2.Length < (int)num)
					{
						int num10 = array2.Length;
					}
					this.WriteBlock(num7, array2, array2.Length);
					num7 += (uint)array2.Length;
					if (num8 < 8U)
					{
						num2 += (uint)(array2.Length * 2);
						num3 += (uint)(array2.Length * 2);
					}
					else
					{
						num2 += (uint)array2.Length;
						num3 += (uint)array2.Length;
					}
					GlobalRef.m_FwDownloadProgress = (int)(num2 * 100U / num6);
				}
				array = array.Skip((int)(24U + num3)).Take((int)(num4 - (24U + num3))).ToArray<byte>();
				num3 = 0U;
				num5 -= 1U;
			}
			GlobalRef.m_FwDownloadProgress = 100;
			return 0;
		}

		public unsafe int DownloadToDeviceOvSPI(int fileType, string file_path)
		{
			uint num = 0U;
			FileStream fileStream = File.OpenRead(file_path);
			int num2;
			if (GlobalRef.g_2243MetaImageDwld)
			{
				num2 = (int)fileStream.Length;
			}
			else
			{
				num2 = (int)fileStream.Length - 4;
			}
			byte[] array = new byte[234];
			for (int i = 0; i < 234; i++)
			{
				array[i] = (byte)i;
			}
			IntPtr chunk = GCHandle.Alloc(array, GCHandleType.Pinned).AddrOfPinnedObject();
			fileStream.Read(array, 0, 224);
			num += 224U;
			ushort num3 = 232;
			ushort num4 = (ushort)((num2 + 8) / (int)num3);
			ushort num5 = num4;
			ushort num6 = 0;
			GlobalRef.m_FwDownloadProgress = 0;
			ushort num7;
			if (num5 > 0)
			{
				num6 = (ushort)((num2 + 8) % (int)num3);
				num7 = 232;
			}
			else
			{
				num7 = (ushort)(num2 + 8);
			}
			byte[] array2 = new byte[232];
			IntPtr chunk2 = GCHandle.Alloc(array2, GCHandleType.Pinned).AddrOfPinnedObject();
			int num8;
			fixed (byte* ptr = &array2[0])
			{
				void* dest = (void*)ptr;
				fixed (byte* ptr2 = &array2[4])
				{
					void* dest2 = (void*)ptr2;
					fixed (byte* ptr3 = &array2[8])
					{
						void* dest3 = (void*)ptr3;
						fixed (byte* ptr4 = &array[0])
						{
							void* src = (void*)ptr4;
							int* src2 = &fileType;
							int* src3 = &num2;
							Imports.memcpy(dest, (void*)src2, 4UL);
							Imports.memcpy(dest2, (void*)src3, 4UL);
							Imports.memcpy(dest3, src, (ulong)((long)(num7 - 8)));
							num8 = Imports.RadarLinkImpl_FileDownload(GlobalRef.g_RadarDeviceId, num5, num7, chunk2);
						}
					}
				}
			}
			if (num8 != 0)
			{
				fileStream.Close();
				return num8;
			}
			for (num5 -= 1; num5 > 0; num5 -= 1)
			{
				fileStream.Read(array, 0, 232);
				num8 = Imports.RadarLinkImpl_FileDownload(GlobalRef.g_RadarDeviceId, num5, 232, chunk);
				if (num8 != 0)
				{
					fileStream.Close();
					return num8;
				}
				GlobalRef.m_FwDownloadProgress = (int)((num4 - num5) * 100 / num4);
				num += 232U;
			}
			if (num6 > 0)
			{
				fileStream.Read(array, 0, (int)num6);
				num8 = Imports.RadarLinkImpl_FileDownload(GlobalRef.g_RadarDeviceId, 0, num6, chunk);
				if (num8 != 0)
				{
					fileStream.Close();
					return num8;
				}
			}
			GlobalRef.m_FwDownloadProgress = 100;
			fileStream.Close();
			return num8;
		}

		private SerialPort m_SP;

		private bool m_bReconnected;
	}
}
