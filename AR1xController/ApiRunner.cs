using System;
using System.Threading;

namespace AR1xController
{
	public class ApiRunner
	{
		public int Res
		{
			get
			{
				return this.m_Res;
			}
			set
			{
				this.m_Res = value;
			}
		}

		public bool Aborted
		{
			get
			{
				return this.m_Aborted;
			}
			set
			{
				this.m_Aborted = value;
			}
		}

		public ApiRunner(TsApiOp op_id, object[] args, bool is_ending_op)
		{
			this.m_TsApiOp = op_id;
			this.m_Args = args;
			this.m_IsEndingOp = is_ending_op;
			this.m_Res = -1;
			this.m_Aborted = false;
		}

		public void Execute()
		{
			try
			{
				Delegate apiFunc = GlobalRef.GuiManager.GetApiFunc(this.m_TsApiOp);
				if (apiFunc != null)
				{
					object obj;
					if (this.m_Args != null)
					{
						obj = apiFunc.DynamicInvoke(new object[]
						{
							this.m_Args
						});
					}
					else
					{
						obj = apiFunc.DynamicInvoke(new object[0]);
					}
					if (obj is int)
					{
						this.m_Res = (int)obj;
					}
				}
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					this.m_Aborted = true;
				}
				else
				{
					this.m_Res = -1;
					GlobalRef.GuiManager.Error(ex.Message, ex.StackTrace);
				}
			}
			finally
			{
				if (GlobalRef.TsWrapper.IsGuiShown())
				{
					GlobalRef.GuiManager.MainTsForm.ConnectTab.GuiOpEnd(this.m_IsEndingOp);
				}
			}
		}

		private TsApiOp m_TsApiOp;

		private object[] m_Args;

		private bool m_IsEndingOp;

		private int m_Res;

		private bool m_Aborted;
	}
}
