using System;
using LuaRegister;

namespace AR1xController
{
	public class c000169 : LuaDllRegister
	{
		public c000169(LuaWrapper lua_wrapper, string package_name, string package_desc) : base(lua_wrapper, package_name, package_desc)
		{
			this.iInitMembers(lua_wrapper);
		}

		public c000169(LuaWrapper lua_wrapper) : base(lua_wrapper, c000169.ModuleName, "Provides a Lua Interface for the AR1xxx API")
		{
			this.iInitMembers(lua_wrapper);
		}

		private void iInitMembers(LuaWrapper lua_wrapper)
		{
			GlobalRef.DllController = this;
			GlobalRef.LuaWrapper = lua_wrapper;
			this.m_AR1xxxWrapper = new AR1xxxWrapper(lua_wrapper);
			GlobalRef.TsWrapper = this.m_AR1xxxWrapper;
		}

		public override void RegisterFunctions()
		{
			this.m_LuaWrapper.RegisterLuaFunctions(this.m_PackageName, this.m_AR1xxxWrapper, this.m_PackageDescription);
		}

		public override void SetALOps()
		{
			this.Transmit_func = new TransmitDel(this.m_AR1xxxWrapper.Transmit);
			this.Receive_func = new ReceiveDel(this.m_AR1xxxWrapper.Receive);
		}

		public override void UnLoad()
		{
			this.m_AR1xxxWrapper.UnLoad();
		}

		private AR1xxxWrapper m_AR1xxxWrapper;

		public static string ModuleName = "ar1";
	}
}
