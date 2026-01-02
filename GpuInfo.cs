using System;
using System.Runtime.CompilerServices;

namespace MakuTweakerNew
{
	// Token: 0x0200000B RID: 11
	[NullableContext(1)]
	[Nullable(0)]
	public class GpuInfo
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000096 RID: 150 RVA: 0x0000AB39 File Offset: 0x00008D39
		// (set) Token: 0x06000097 RID: 151 RVA: 0x0000AB41 File Offset: 0x00008D41
		public string Name { get; set; } = string.Empty;

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000098 RID: 152 RVA: 0x0000AB4A File Offset: 0x00008D4A
		// (set) Token: 0x06000099 RID: 153 RVA: 0x0000AB52 File Offset: 0x00008D52
		public ulong VRamBytes { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600009A RID: 154 RVA: 0x0000AB5B File Offset: 0x00008D5B
		public string VRamFormatted
		{
			get
			{
				return GpuInfo.FormatBytes(this.VRamBytes);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600009B RID: 155 RVA: 0x0000AB68 File Offset: 0x00008D68
		// (set) Token: 0x0600009C RID: 156 RVA: 0x0000AB70 File Offset: 0x00008D70
		public string LHMName { get; set; } = string.Empty;

		// Token: 0x0600009D RID: 157 RVA: 0x0000AB7C File Offset: 0x00008D7C
		private static string FormatBytes(ulong bytes)
		{
			string[] array = new string[]
			{
				"B",
				"KB",
				"MB",
				"GB",
				"TB"
			};
			double num = bytes;
			int num2 = 0;
			while (num >= 1024.0 && num2 < array.Length - 1)
			{
				num2++;
				num /= 1024.0;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<double>(num, "0.##");
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted(array[num2]);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
	}
}
