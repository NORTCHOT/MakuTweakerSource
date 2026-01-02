using System;
using System.Runtime.CompilerServices;

namespace MakuTweakerNew
{
	// Token: 0x0200000D RID: 13
	[NullableContext(1)]
	[Nullable(0)]
	public class StorageInfo
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x0000AEA0 File Offset: 0x000090A0
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x0000AEA8 File Offset: 0x000090A8
		public string Name { get; set; } = string.Empty;

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x0000AEB1 File Offset: 0x000090B1
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x0000AEB9 File Offset: 0x000090B9
		public ulong CapacityBytes { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x0000AEC2 File Offset: 0x000090C2
		public string CapacityFormatted
		{
			get
			{
				return StorageInfo.FormatBytes(this.CapacityBytes);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x0000AECF File Offset: 0x000090CF
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x0000AED7 File Offset: 0x000090D7
		public string DevicePath { get; set; } = string.Empty;

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x0000AEE0 File Offset: 0x000090E0
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x0000AEE8 File Offset: 0x000090E8
		public ulong TotalBytesWritten { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000AA RID: 170 RVA: 0x0000AEF1 File Offset: 0x000090F1
		public string TotalBytesWrittenFormatted
		{
			get
			{
				return StorageInfo.FormatBytes(this.TotalBytesWritten);
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000AF00 File Offset: 0x00009100
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
			bool flag = bytes == 0UL;
			string result;
			if (flag)
			{
				result = "N/A";
			}
			else
			{
				while (num >= 1024.0 && num2 < array.Length - 1)
				{
					num2++;
					num /= 1024.0;
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<double>(num, "0.##");
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted(array[num2]);
				result = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			return result;
		}
	}
}
