using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace BSJ_suspender
{
	// Token: 0x02000003 RID: 3
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class initial
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002050 File Offset: 0x00000250
		internal initial()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002090 File Offset: 0x00000290
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(initial.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("BSJ_suspender.initial", typeof(initial).Assembly);
					initial.resourceMan = resourceManager;
				}
				return initial.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020DC File Offset: 0x000002DC
		// (set) Token: 0x06000006 RID: 6 RVA: 0x00002076 File Offset: 0x00000276
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return initial.resourceCulture;
			}
			set
			{
				initial.resourceCulture = value;
			}
		}

		// Token: 0x04000001 RID: 1
		private static ResourceManager resourceMan;

		// Token: 0x04000002 RID: 2
		private static CultureInfo resourceCulture;
	}
}
