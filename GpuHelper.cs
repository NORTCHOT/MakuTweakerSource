using System;
using System.Collections.Generic;
using System.Management;
using System.Runtime.CompilerServices;
using SharpGen.Runtime;
using Vortice.DXGI;

namespace MakuTweakerNew
{
	// Token: 0x0200000C RID: 12
	[NullableContext(1)]
	[Nullable(0)]
	public static class GpuHelper
	{
		// Token: 0x0600009F RID: 159 RVA: 0x0000AC4C File Offset: 0x00008E4C
		public static List<GpuInfo> GetAllGpus()
		{
			List<GpuInfo> list = new List<GpuInfo>();
			try
			{
				using (IDXGIFactory1 idxgifactory = DXGI.CreateDXGIFactory1<IDXGIFactory1>())
				{
					int num = 0;
					for (;;)
					{
						try
						{
							IDXGIAdapter1 idxgiadapter;
							idxgifactory.EnumAdapters1((uint)num, out idxgiadapter);
							bool flag = idxgiadapter == null;
							if (flag)
							{
								break;
							}
							using (idxgiadapter)
							{
								AdapterDescription1 description = idxgiadapter.Description1;
								string description2 = description.Description;
								string text = ((description2 != null) ? description2.Trim() : null) ?? "";
								bool flag2 = text.Contains("Microsoft Basic Render Driver", StringComparison.OrdinalIgnoreCase);
								if (flag2)
								{
									num++;
									continue;
								}
								bool flag3 = string.IsNullOrWhiteSpace(text) || text.Equals("Null", StringComparison.OrdinalIgnoreCase);
								if (flag3)
								{
									num++;
									continue;
								}
								list.Add(new GpuInfo
								{
									Name = text,
									VRamBytes = description.DedicatedVideoMemory
								});
							}
							num++;
						}
						catch (SharpGenException)
						{
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				return GpuHelper.FallbackToWmi();
			}
			return (list.Count > 0) ? list : GpuHelper.FallbackToWmi();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000ADAC File Offset: 0x00008FAC
		private static List<GpuInfo> FallbackToWmi()
		{
			List<GpuInfo> list = new List<GpuInfo>();
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT Name, AdapterRAM FROM Win32_VideoController"))
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						object obj = managementBaseObject["Name"];
						string name = ((obj != null) ? obj.ToString() : null) ?? "Unknown GPU";
						ulong vramBytes = (managementBaseObject["AdapterRAM"] != null) ? Convert.ToUInt64(managementBaseObject["AdapterRAM"]) : 0UL;
						list.Add(new GpuInfo
						{
							Name = name,
							VRamBytes = vramBytes
						});
					}
				}
			}
			catch
			{
			}
			return list;
		}
	}
}
