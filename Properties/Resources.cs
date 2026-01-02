using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MakuTweakerNew.Properties
{
	// Token: 0x02000018 RID: 24
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000138 RID: 312 RVA: 0x000147DC File Offset: 0x000129DC
		internal Resources()
		{
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000139 RID: 313 RVA: 0x000147E8 File Offset: 0x000129E8
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("MakuTweakerNew.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00014830 File Offset: 0x00012A30
		// (set) Token: 0x0600013B RID: 315 RVA: 0x00014847 File Offset: 0x00012A47
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x040001A0 RID: 416
		private static ResourceManager resourceMan;

		// Token: 0x040001A1 RID: 417
		private static CultureInfo resourceCulture;
	}
}
