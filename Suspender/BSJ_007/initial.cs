using System;
using System.Windows.Forms;

namespace bsj_007
{
	// Token: 0x02000002 RID: 2
	internal sealed class initial
	{
		// Token: 0x06000002 RID: 2 RVA: 0x0000205B File Offset: 0x0000025B
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frm1());
		}
	}
}
