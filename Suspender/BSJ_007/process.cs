using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace bsj_007
{
	// Token: 0x02000005 RID: 5
	public class process
	{
		// Token: 0x0600000F RID: 15
		[DllImport("kernel32.dll")]
		private static extern IntPtr OpenThread(process.ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

		// Token: 0x06000010 RID: 16 RVA: 0x00002A3C File Offset: 0x00000C3C
		public static void ResumeProcess(int PID)
		{
			Process processById = Process.GetProcessById(PID);
			if (!(processById.ProcessName == string.Empty))
			{
				foreach (object obj in processById.Threads)
				{
					ProcessThread processThread = (ProcessThread)obj;
					IntPtr intPtr = process.OpenThread(process.ThreadAccess.SUSPEND_RESUME, false, (uint)processThread.Id);
					if (intPtr == IntPtr.Zero)
					{
						break;
					}
					process.ResumeThread(intPtr);
				}
			}
		}

		// Token: 0x06000011 RID: 17
		[DllImport("kernel32.dll")]
		private static extern int ResumeThread(IntPtr hThread);

		// Token: 0x06000012 RID: 18 RVA: 0x00002AF0 File Offset: 0x00000CF0
		public static void SuspendProcess(int PID)
		{
			Process processById = Process.GetProcessById(PID);
			if (!(processById.ProcessName == string.Empty))
			{
				foreach (object obj in processById.Threads)
				{
					ProcessThread processThread = (ProcessThread)obj;
					IntPtr intPtr = process.OpenThread(process.ThreadAccess.SUSPEND_RESUME, false, (uint)processThread.Id);
					if (intPtr == IntPtr.Zero)
					{
						break;
					}
					process.SuspendThread(intPtr);
				}
			}
		}

		// Token: 0x06000013 RID: 19
		[DllImport("kernel32.dll")]
		private static extern uint SuspendThread(IntPtr hThread);

		// Token: 0x02000006 RID: 6
		[Flags]
		public enum ThreadAccess
		{
			// Token: 0x0400000E RID: 14
			TERMINATE = 1,
			// Token: 0x0400000F RID: 15
			SUSPEND_RESUME = 2,
			// Token: 0x04000010 RID: 16
			GET_CONTEXT = 8,
			// Token: 0x04000011 RID: 17
			SET_CONTEXT = 16,
			// Token: 0x04000012 RID: 18
			SET_INFORMATION = 32,
			// Token: 0x04000013 RID: 19
			QUERY_INFORMATION = 64,
			// Token: 0x04000014 RID: 20
			SET_THREAD_TOKEN = 128,
			// Token: 0x04000015 RID: 21
			IMPERSONATE = 256,
			// Token: 0x04000016 RID: 22
			DIRECT_IMPERSONATION = 512
		}
	}
}
