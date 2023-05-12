using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace RSTD
{

	internal class NamedPipe
	{

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern SafeFileHandle CreateNamedPipe(string pipeName, uint dwOpenMode, uint dwPipeMode, uint nMaxInstances, uint nOutBufferSize, uint nInBufferSize, uint nDefaultTimeOut, IntPtr lpSecurityAttributes);


		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern int ConnectNamedPipe(IntPtr hNamedPipe, IntPtr lpOverlapped);


		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern SafeFileHandle CreateFile(string pipeName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplate);


		[DllImport("kernel32.dll")]
		public static extern bool WriteFile(IntPtr hHandle, byte[] lpBuffer, uint nNumberOfBytesToWrite, byte[] lpNumberOfBytesWritten, uint lpOverlapped);


		[DllImport("kernel32.dll")]
		public static extern bool ReadFile(IntPtr hHandle, byte[] lpBuffer, uint nNumberOfBytesToRead, byte[] lpNumberOfBytesRead, uint lpOverlapped);


		[DllImport("kernel32.dll")]
		public static extern bool FlushFileBuffers(IntPtr hHandle);


		[DllImport("Kernel32.dll", SetLastError = true)]
		public static extern int SetStdHandle(int device, IntPtr handle);


		[DllImport("Kernel32.dll", SetLastError = true)]
		public static extern int GetStdHandle(int device);


		public NamedPipe(ref SafeFileHandle hServer, ref SafeFileHandle hClient)
		{
			hServer = this.CreateNamedPipe();
			hClient = this.Connect();
		}


		public SafeFileHandle CreateNamedPipe()
		{
			this.m_hServer = NamedPipe.CreateNamedPipe("\\\\.\\pipe\\myNamedPipe", 3U, 6U, 255U, 4096U, 4096U, 0U, IntPtr.Zero);
			if (this.m_hServer.IsInvalid)
			{
				return null;
			}
			return this.m_hServer;
		}


		public void Listen()
		{
			while (NamedPipe.ConnectNamedPipe(this.m_hServer.DangerousGetHandle(), IntPtr.Zero) == 1)
			{
			}
		}


		public SafeFileHandle Connect()
		{
			this.m_hClient = NamedPipe.CreateFile("\\\\.\\pipe\\myNamedPipe", 3221225472U, 0U, IntPtr.Zero, 3U, 128U, IntPtr.Zero);
			if (this.m_hClient.IsInvalid)
			{
				return null;
			}
			return this.m_hClient;
		}


		public int SetClientHandleToStdIo(int device)
		{
			return NamedPipe.SetStdHandle(device, this.m_hClient.DangerousGetHandle());
		}


		public string Read()
		{
			return this.Read(this.m_hServer).Trim(new char[1]);
		}


		public string Read(SafeFileHandle handle)
		{
			string result = "";
			byte[] array = this.ReadBytes(handle);
			if (array != null)
			{
				result = Encoding.UTF8.GetString(array);
			}
			return result;
		}


		public byte[] ReadBytes(SafeFileHandle handle)
		{
			byte[] lpNumberOfBytesRead = new byte[4];
			byte[] array = new byte[4096];
			NamedPipe.ReadFile(handle.DangerousGetHandle(), array, 4096U, lpNumberOfBytesRead, 0U);
			return array;
		}


		public void Write(string text)
		{
			this.Write(this.m_hClient, text);
		}


		public void Write(SafeFileHandle handle, string text)
		{
			this.WriteBytes(handle, Encoding.UTF8.GetBytes(text));
		}


		public void WriteBytes(SafeFileHandle handle, byte[] bytes)
		{
			byte[] lpNumberOfBytesWritten = new byte[4];
			if (bytes == null)
			{
				bytes = new byte[0];
			}
			if (bytes.Length == 0)
			{
				bytes = new byte[1];
				bytes = Encoding.UTF8.GetBytes(" ");
			}
			uint nNumberOfBytesToWrite = (uint)bytes.Length;
			NamedPipe.WriteFile(handle.DangerousGetHandle(), bytes, nNumberOfBytesToWrite, lpNumberOfBytesWritten, 0U);
		}


		public static void Flush(SafeFileHandle handle)
		{
			NamedPipe.FlushFileBuffers(handle.DangerousGetHandle());
		}


		public const string PIPE_NAME = "\\\\.\\pipe\\myNamedPipe";


		public const uint BUFFER_SIZE = 4096U;


		public SafeFileHandle m_hServer;


		public SafeFileHandle m_hClient;
	}
}
