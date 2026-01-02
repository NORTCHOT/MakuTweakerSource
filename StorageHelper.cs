using System;
using System.Collections.Generic;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MakuTweakerNew
{
	// Token: 0x0200000E RID: 14
	public static class StorageHelper
	{
		// Token: 0x060000AD RID: 173 RVA: 0x0000AFE4 File Offset: 0x000091E4
		[NullableContext(1)]
		public static List<StorageInfo> GetAllStorageDevices()
		{
			List<StorageInfo> list = new List<StorageInfo>();
			Dictionary<string, ulong> dictionary = new Dictionary<string, ulong>();
			try
			{
				ManagementScope managementScope = new ManagementScope("\\\\.\\root\\microsoft\\windows\\storage");
				managementScope.Connect();
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(managementScope, new ObjectQuery("SELECT DeviceId, TotalBytesWritten FROM MSFT_PhysicalDisk")))
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						object obj = managementBaseObject["DeviceId"];
						string text = ((obj != null) ? obj.ToString() : null) ?? string.Empty;
						ulong value = 0UL;
						bool flag = managementBaseObject["TotalBytesWritten"] != null;
						if (flag)
						{
							value = Convert.ToUInt64(managementBaseObject["TotalBytesWritten"]);
						}
						bool flag2 = !string.IsNullOrEmpty(text);
						if (flag2)
						{
							dictionary[text] = value;
						}
					}
				}
			}
			catch (Exception ex)
			{
			}
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("SELECT Caption, Size, DeviceID FROM Win32_DiskDrive"))
				{
					foreach (ManagementBaseObject managementBaseObject2 in managementObjectSearcher2.Get())
					{
						object obj2 = managementBaseObject2["Caption"];
						string text2 = ((obj2 != null) ? obj2.ToString() : null) ?? "Unknown Device";
						ulong num = (managementBaseObject2["Size"] != null) ? Convert.ToUInt64(managementBaseObject2["Size"]) : 0UL;
						object obj3 = managementBaseObject2["DeviceID"];
						string text3 = ((obj3 != null) ? obj3.ToString() : null) ?? "";
						bool flag3 = num == 0UL || text2.Contains("Virtual", StringComparison.OrdinalIgnoreCase) || text2.Contains("iSCSI", StringComparison.OrdinalIgnoreCase);
						if (!flag3)
						{
							string value2 = Regex.Match(text3, "\\d+$").Value;
							ulong totalBytesWritten = 0UL;
							bool flag4 = !string.IsNullOrEmpty(value2) && dictionary.ContainsKey(value2);
							if (flag4)
							{
								totalBytesWritten = dictionary[value2];
							}
							string devicePath = text3.Replace("PHYSICALDRIVE", "PhysicalDrive", StringComparison.OrdinalIgnoreCase);
							list.Add(new StorageInfo
							{
								Name = text2,
								CapacityBytes = num,
								DevicePath = devicePath,
								TotalBytesWritten = totalBytesWritten
							});
						}
					}
				}
			}
			catch (Exception ex2)
			{
			}
			return list;
		}
	}
}
