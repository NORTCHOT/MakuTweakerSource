using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MakuTweakerNew.Properties;
using Microsoft.Win32;
using ModernWpf.Controls;

namespace MakuTweakerNew
{
	// Token: 0x02000005 RID: 5
	public partial class ContextMenu : System.Windows.Controls.Page
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00003B48 File Offset: 0x00001D48
		public ContextMenu()
		{
			this.InitializeComponent();
			this.checkReg();
			this.LoadLang();
			bool flag = this.checkWinVer() < 22000;
			if (flag)
			{
				this.t15.Visibility = Visibility.Collapsed;
				this.t13.Visibility = Visibility.Collapsed;
				this.t4.Visibility = Visibility.Collapsed;
			}
			this.isLoaded = true;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003BD0 File Offset: 0x00001DD0
		private int checkWinVer()
		{
			string name = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			string name2 = "CurrentBuild";
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name))
			{
				bool flag = registryKey != null;
				if (flag)
				{
					object value = registryKey.GetValue(name2);
					int result;
					bool flag2 = value != null && int.TryParse(value.ToString(), out result);
					if (flag2)
					{
						return result;
					}
				}
			}
			return 19045;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003C58 File Offset: 0x00001E58
		[NullableContext(1)]
		private void t1_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.o8 = this.t1.IsOn;
				if (!this.t1.IsOn)
				{
					Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop").SetValue("MenuShowDelay", "400");
				}
				else
				{
					Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop").SetValue("MenuShowDelay", "50");
				}
				this.mw.RebootNotify(2);
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003CEC File Offset: 0x00001EEC
		[NullableContext(1)]
		private void t2_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.cm2 = this.t2.IsOn;
				if (!this.t2.IsOn)
				{
					Registry.ClassesRoot.CreateSubKey("CLSID\\{09A47860-11B0-4DA5-AFA5-26D86198A780}\\InprocServer32").SetValue("", "C:\\Program Files\\Windows Defender\\shellext.dll");
					Registry.ClassesRoot.CreateSubKey("CLSID\\{09A47860-11B0-4DA5-AFA5-26D86198A780}\\InprocServer32").SetValue("ThreadingModel", "Apartment");
					Registry.ClassesRoot.CreateSubKey("CLSID\\{09A47860-11B0-4DA5-AFA5-26D86198A780}\\Version").SetValue("", "10.0.22621.1");
				}
				else
				{
					try
					{
						Registry.ClassesRoot.DeleteSubKey("CLSID\\{09A47860-11B0-4DA5-AFA5-26D86198A780}\\InprocServer32");
						Registry.ClassesRoot.DeleteSubKey("CLSID\\{09A47860-11B0-4DA5-AFA5-26D86198A780}\\Version");
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003DD0 File Offset: 0x00001FD0
		[NullableContext(1)]
		private void t3_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.cm3 = this.t3.IsOn;
				if (!this.t3.IsOn)
				{
					try
					{
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Blocked");
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Blocked").SetValue("{9F156763-7844-4DC4-B2B1-901F640F5155}", "");
					}
					catch
					{
					}
				}
				this.mw.RebootNotify(2);
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003E88 File Offset: 0x00002088
		[NullableContext(1)]
		private void t4_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.cm4 = this.t4.IsOn;
				if (!this.t4.IsOn)
				{
					try
					{
						Registry.ClassesRoot.CreateSubKey("AllFilesystemObjects\\shell\\pintohome").SetValue("CommandStateHandler", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
						Registry.ClassesRoot.CreateSubKey("AllFilesystemObjects\\shell\\pintohome").SetValue("CommandStateSync", "");
						Registry.ClassesRoot.CreateSubKey("AllFilesystemObjects\\shell\\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
						Registry.ClassesRoot.CreateSubKey("AllFilesystemObjects\\shell\\pintohome\\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
						Registry.ClassesRoot.CreateSubKey("Drive\\shell\\pintohome").SetValue("CommandStateHandler", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
						Registry.ClassesRoot.CreateSubKey("Drive\\shell\\pintohome").SetValue("CommandStateSync", "");
						Registry.ClassesRoot.CreateSubKey("Drive\\shell\\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
						Registry.ClassesRoot.CreateSubKey("Drive\\shell\\pintohome").SetValue("NeverDefault", "");
						Registry.ClassesRoot.CreateSubKey("Drive\\shell\\pintohome\\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
						Registry.ClassesRoot.CreateSubKey("Folder\\shell\\pintohome").SetValue("AppliesTo", "System.ParsingName:<>\"::{679f85cb-0220-4080-b29b-5540cc05aab6}\" AND System.ParsingName:<>\"::{645FF040-5081-101B-9F08-00AA002F954E}\" AND System.IsFolder:=System.StructuredQueryType.Boolean#True");
						Registry.ClassesRoot.CreateSubKey("Folder\\shell\\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
						Registry.ClassesRoot.CreateSubKey("Folder\\shell\\pintohome\\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
						Registry.ClassesRoot.CreateSubKey("Network\\shell\\pintohome").SetValue("CommandStateHandler", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
						Registry.ClassesRoot.CreateSubKey("Network\\shell\\pintohome").SetValue("CommandStateSync", "");
						Registry.ClassesRoot.CreateSubKey("Network\\shell\\pintohome").SetValue("MUIVerb", "@shell32.dll,-51377");
						Registry.ClassesRoot.CreateSubKey("Network\\shell\\pintohome").SetValue("NeverDefault", "");
						Registry.ClassesRoot.CreateSubKey("Network\\shell\\pintohome\\command").SetValue("DelegateExecute", "{b455f46e-e4af-4035-b0a4-cf18d2f6f28e}");
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.ClassesRoot.CreateSubKey("*\\shell\\pintohomefile").SetValue("ProgrammaticAccessOnly", "");
						Registry.ClassesRoot.CreateSubKey("Drive\\shell\\pintohomefile").SetValue("ProgrammaticAccessOnly", "");
						Registry.ClassesRoot.CreateSubKey("Folder\\shell\\pintohomefile").SetValue("ProgrammaticAccessOnly", "");
						Registry.ClassesRoot.CreateSubKey("Network\\shell\\pintohomefile").SetValue("ProgrammaticAccessOnly", "");
						Registry.ClassesRoot.DeleteSubKeyTree("Drive\\shell\\pintohome");
						Registry.ClassesRoot.DeleteSubKeyTree("Folder\\shell\\pintohome");
						Registry.ClassesRoot.DeleteSubKeyTree("Network\\shell\\pintohome");
					}
					catch
					{
					}
				}
				this.mw.RebootNotify(2);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000041E8 File Offset: 0x000023E8
		[NullableContext(1)]
		private void t5_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.cm5 = this.t5.IsOn;
				if (!this.t5.IsOn)
				{
					Registry.ClassesRoot.CreateSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers\\ModernSharing").SetValue("", "{e2bf9676-5f8f-435c-97eb-11607a5bedf7}");
				}
				else
				{
					try
					{
						Registry.ClassesRoot.DeleteSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers\\ModernSharing");
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004278 File Offset: 0x00002478
		[NullableContext(1)]
		private void t6_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.cm6 = this.t6.IsOn;
				if (!this.t6.IsOn)
				{
					try
					{
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Blocked");
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Blocked").SetValue("{596AB062-B4D2-4215-9F74-E9109B0A8153}", "");
					}
					catch
					{
					}
				}
				this.mw.RebootNotify(2);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0000432C File Offset: 0x0000252C
		[NullableContext(1)]
		private void t8_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.cm8 = this.t8.IsOn;
				if (!this.t8.IsOn)
				{
					Registry.ClassesRoot.CreateSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers\\SendTo").SetValue("", "{7BA4C740-9E81-11CF-99D3-00AA004AE837}");
				}
				else
				{
					try
					{
						Registry.ClassesRoot.CreateSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers\\SendTo").SetValue("", "");
					}
					catch
					{
					}
				}
				this.mw.RebootNotify(2);
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000043DC File Offset: 0x000025DC
		[NullableContext(1)]
		private void t10_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.cm10 = this.t10.IsOn;
				if (!this.t10.IsOn)
				{
					Registry.ClassesRoot.CreateSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers\\CopyAsPathMenu").SetValue("", "{f3d06e7c-1e45-4a26-847e-f9fcdee59be0}");
				}
				else
				{
					try
					{
						Registry.ClassesRoot.DeleteSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers\\CopyAsPathMenu");
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00004470 File Offset: 0x00002670
		[NullableContext(1)]
		private void t11_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.cm11 = this.t11.IsOn;
				if (!this.t11.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Classes\\Folder\\shellex\\ContextMenuHandlers\\PintoStartScreen").SetValue("", "{470C0EBD-5D73-4d58-9CED-E91E22E23282}");
					Registry.ClassesRoot.CreateSubKey("exefile\\shellex\\ContextMenuHandlers\\PintoStartScreen").SetValue("", "{470C0EBD-5D73-4d58-9CED-E91E22E23282}");
				}
				else
				{
					try
					{
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Classes\\Folder\\shellex\\ContextMenuHandlers\\PintoStartScreen");
						Registry.ClassesRoot.CreateSubKey("exefile\\shellex\\ContextMenuHandlers\\PintoStartScreen").SetValue("", "");
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00004544 File Offset: 0x00002744
		[NullableContext(1)]
		private void t12_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.cm12 = this.t12.IsOn;
				if (!this.t12.IsOn)
				{
					Registry.ClassesRoot.CreateSubKey("*\\shellex\\ContextMenuHandlers\\{90AA3A4E-1CBA-4233-B8BB-535773D48449}").SetValue("", "Taskband Pin");
				}
				else
				{
					try
					{
						Registry.ClassesRoot.DeleteSubKey("*\\shellex\\ContextMenuHandlers\\{90AA3A4E-1CBA-4233-B8BB-535773D48449}");
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000045D8 File Offset: 0x000027D8
		[NullableContext(1)]
		private void t13_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.cm13 = this.t13.IsOn;
				if (!this.t13.IsOn)
				{
					Registry.ClassesRoot.CreateSubKey("Folder\\shell\\opennewtab").SetValue("CommandStateHandler", "{11dbb47c-a525-400b-9e80-a54615a090c0}");
					Registry.ClassesRoot.CreateSubKey("Folder\\shell\\opennewtab").SetValue("CommandStateSync", "");
					Registry.ClassesRoot.CreateSubKey("Folder\\shell\\opennewtab").SetValue("LaunchExplorerFlags", 32);
					Registry.ClassesRoot.CreateSubKey("Folder\\shell\\opennewtab").SetValue("MUIVerb", "@windows.storage.dll,-8519");
					Registry.ClassesRoot.CreateSubKey("Folder\\shell\\opennewtab").SetValue("MultiSelectModel", "Document");
					Registry.ClassesRoot.CreateSubKey("Folder\\shell\\opennewtab").SetValue("OnlyInBrowserWindow", "");
					Registry.ClassesRoot.CreateSubKey("Folder\\shell\\opennewtab\\command").SetValue("DelegateExecute", "{11dbb47c-a525-400b-9e80-a54615a090c0}");
				}
				else
				{
					try
					{
						Registry.ClassesRoot.DeleteSubKeyTree("Folder\\shell\\opennewtab");
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000472C File Offset: 0x0000292C
		[NullableContext(1)]
		private void t14_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.cm14 = this.t14.IsOn;
				if (!this.t14.IsOn)
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("Software\\NVIDIA Corporation\\Global\\NvCplApi\\Policies").SetValue("ContextUIPolicy", 2);
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("Software\\NVIDIA Corporation\\Global\\NvCplApi\\Policies").SetValue("ContextUIPolicy", 0);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000047E8 File Offset: 0x000029E8
		[NullableContext(1)]
		private void t15_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.cm15 = this.t15.IsOn;
				if (!this.t15.IsOn)
				{
					Process.Start("cmd.exe", "/c \"reg delete \"HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32\" /f\"");
					Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel").SetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}", 0);
				}
				else
				{
					Process.Start("cmd.exe", "/c \"reg.exe add \"HKCU\\Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32\" /f /ve\"");
					Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel").SetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}", 0);
				}
				this.mw.RebootNotify(2);
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000048A0 File Offset: 0x00002AA0
		private void LoadLang()
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "cm");
			Dictionary<string, Dictionary<string, string>> dictionary2 = MainWindow.Localization.LoadLocalization(language, "base");
			this.label.Text = dictionary["main"]["label"];
			this.t15.Header = dictionary["main"]["t1"];
			this.t1.Header = dictionary["main"]["o8"];
			this.t2.Header = dictionary["main"]["t2"];
			this.t3.Header = dictionary["main"]["t3"];
			this.t4.Header = dictionary["main"]["t4"];
			this.t5.Header = dictionary["main"]["t5"];
			this.t6.Header = dictionary["main"]["t6"];
			this.t8.Header = dictionary["main"]["t8"];
			this.t10.Header = dictionary["main"]["t10"];
			this.t11.Header = dictionary["main"]["t11"];
			this.t12.Header = dictionary["main"]["t12"];
			this.t13.Header = dictionary["main"]["t13"];
			this.t14.Header = dictionary["main"]["t14"];
			this.t1.OffContent = dictionary2["def"]["off"];
			this.t2.OffContent = dictionary2["def"]["off"];
			this.t3.OffContent = dictionary2["def"]["off"];
			this.t4.OffContent = dictionary2["def"]["off"];
			this.t5.OffContent = dictionary2["def"]["off"];
			this.t6.OffContent = dictionary2["def"]["off"];
			this.t8.OffContent = dictionary2["def"]["off"];
			this.t10.OffContent = dictionary2["def"]["off"];
			this.t11.OffContent = dictionary2["def"]["off"];
			this.t12.OffContent = dictionary2["def"]["off"];
			this.t13.OffContent = dictionary2["def"]["off"];
			this.t14.OffContent = dictionary2["def"]["off"];
			this.t15.OffContent = dictionary2["def"]["off"];
			this.t1.OnContent = dictionary2["def"]["on"];
			this.t2.OnContent = dictionary2["def"]["on"];
			this.t3.OnContent = dictionary2["def"]["on"];
			this.t4.OnContent = dictionary2["def"]["on"];
			this.t5.OnContent = dictionary2["def"]["on"];
			this.t6.OnContent = dictionary2["def"]["on"];
			this.t8.OnContent = dictionary2["def"]["on"];
			this.t10.OnContent = dictionary2["def"]["on"];
			this.t11.OnContent = dictionary2["def"]["on"];
			this.t12.OnContent = dictionary2["def"]["on"];
			this.t13.OnContent = dictionary2["def"]["on"];
			this.t14.OnContent = dictionary2["def"]["on"];
			this.t15.OnContent = dictionary2["def"]["on"];
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004E04 File Offset: 0x00003004
		private void checkReg()
		{
			ToggleSwitch toggleSwitch = this.t1;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop");
			bool? flag;
			if (registryKey == null)
			{
				flag = null;
			}
			else
			{
				object value = registryKey.GetValue("MenuShowDelay");
				flag = ((value != null) ? new bool?(value.Equals("50")) : null);
			}
			bool? flag2 = flag;
			toggleSwitch.IsOn = flag2.GetValueOrDefault();
			ToggleSwitch toggleSwitch2 = this.t3;
			RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Blocked");
			bool? flag3;
			if (registryKey2 == null)
			{
				flag3 = null;
			}
			else
			{
				object value2 = registryKey2.GetValue("{9F156763-7844-4DC4-B2B1-901F640F5155}");
				flag3 = ((value2 != null) ? new bool?(value2.Equals("")) : null);
			}
			flag2 = flag3;
			toggleSwitch2.IsOn = flag2.GetValueOrDefault();
			this.t5.IsOn = (Registry.ClassesRoot.OpenSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers\\ModernSharing") == null);
			ToggleSwitch toggleSwitch3 = this.t6;
			RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Blocked");
			bool? flag4;
			if (registryKey3 == null)
			{
				flag4 = null;
			}
			else
			{
				object value3 = registryKey3.GetValue("{596AB062-B4D2-4215-9F74-E9109B0A8153}");
				flag4 = ((value3 != null) ? new bool?(value3.Equals("")) : null);
			}
			flag2 = flag4;
			toggleSwitch3.IsOn = flag2.GetValueOrDefault();
			ToggleSwitch toggleSwitch4 = this.t8;
			RegistryKey registryKey4 = Registry.ClassesRoot.OpenSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers\\SendTo");
			bool? flag5;
			if (registryKey4 == null)
			{
				flag5 = null;
			}
			else
			{
				object value4 = registryKey4.GetValue("");
				flag5 = ((value4 != null) ? new bool?(value4.Equals("")) : null);
			}
			flag2 = flag5;
			toggleSwitch4.IsOn = flag2.GetValueOrDefault();
			this.t10.IsOn = (Registry.ClassesRoot.OpenSubKey("AllFilesystemObjects\\shellex\\ContextMenuHandlers\\CopyAsPathMenu") == null);
			ToggleSwitch toggleSwitch5 = this.t11;
			bool isOn;
			if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Classes\\Folder\\shellex\\ContextMenuHandlers\\PintoStartScreen") != null)
			{
				RegistryKey registryKey5 = Registry.ClassesRoot.CreateSubKey("exefile\\shellex\\ContextMenuHandlers\\PintoStartScreen");
				bool? flag6;
				if (registryKey5 == null)
				{
					flag6 = null;
				}
				else
				{
					object value5 = registryKey5.GetValue("");
					flag6 = ((value5 != null) ? new bool?(value5.Equals("")) : null);
				}
				flag2 = flag6;
				isOn = flag2.GetValueOrDefault();
			}
			else
			{
				isOn = true;
			}
			toggleSwitch5.IsOn = isOn;
			this.t12.IsOn = (Registry.ClassesRoot.OpenSubKey("*\\shellex\\ContextMenuHandlers\\{90AA3A4E-1CBA-4233-B8BB-535773D48449}") == null);
			this.t13.IsOn = (Registry.ClassesRoot.OpenSubKey("Folder\\shell\\opennewtab") == null);
			ToggleSwitch toggleSwitch6 = this.t14;
			RegistryKey registryKey6 = Registry.CurrentUser.OpenSubKey("Software\\NVIDIA Corporation\\Global\\NvCplApi\\Policies");
			bool? flag7;
			if (registryKey6 == null)
			{
				flag7 = null;
			}
			else
			{
				object value6 = registryKey6.GetValue("ContextUIPolicy");
				flag7 = ((value6 != null) ? new bool?(value6.Equals(0)) : null);
			}
			flag2 = flag7;
			toggleSwitch6.IsOn = flag2.GetValueOrDefault();
			ToggleSwitch toggleSwitch7 = this.t15;
			RegistryKey registryKey7 = Registry.CurrentUser.OpenSubKey("Software\\Classes\\CLSID\\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\\InprocServer32");
			bool? flag8;
			if (registryKey7 == null)
			{
				flag8 = null;
			}
			else
			{
				object value7 = registryKey7.GetValue("");
				flag8 = ((value7 != null) ? new bool?(value7.Equals("")) : null);
			}
			flag2 = flag8;
			toggleSwitch7.IsOn = flag2.GetValueOrDefault();
			this.t2.IsOn = (Registry.ClassesRoot.OpenSubKey("CLSID\\{09A47860-11B0-4DA5-AFA5-26D86198A780}\\InprocServer32") == null || Registry.ClassesRoot.OpenSubKey("CLSID\\{09A47860-11B0-4DA5-AFA5-26D86198A780}\\Version") == null);
			ToggleSwitch toggleSwitch8 = this.t4;
			bool isOn2;
			if (Registry.ClassesRoot.OpenSubKey("Network\\shell\\pintohome") != null && Registry.ClassesRoot.OpenSubKey("Drive\\shell\\pintohome") != null && Registry.ClassesRoot.OpenSubKey("Folder\\shell\\pintohome") != null)
			{
				RegistryKey registryKey8 = Registry.ClassesRoot.OpenSubKey("Drive\\shell\\pintohomefile");
				bool? flag9;
				if (registryKey8 == null)
				{
					flag9 = null;
				}
				else
				{
					object value8 = registryKey8.GetValue("ProgrammaticAccessOnly");
					flag9 = ((value8 != null) ? new bool?(value8.Equals("")) : null);
				}
				flag2 = flag9;
				if (!flag2.GetValueOrDefault())
				{
					RegistryKey registryKey9 = Registry.ClassesRoot.OpenSubKey("Folder\\shell\\pintohomefile");
					bool? flag10;
					if (registryKey9 == null)
					{
						flag10 = null;
					}
					else
					{
						object value9 = registryKey9.GetValue("ProgrammaticAccessOnly");
						flag10 = ((value9 != null) ? new bool?(value9.Equals("")) : null);
					}
					flag2 = flag10;
					if (!flag2.GetValueOrDefault())
					{
						RegistryKey registryKey10 = Registry.ClassesRoot.OpenSubKey("Network\\shell\\pintohomefile");
						bool? flag11;
						if (registryKey10 == null)
						{
							flag11 = null;
						}
						else
						{
							object value10 = registryKey10.GetValue("ProgrammaticAccessOnly");
							flag11 = ((value10 != null) ? new bool?(value10.Equals("")) : null);
						}
						flag2 = flag11;
						if (!flag2.GetValueOrDefault())
						{
							RegistryKey registryKey11 = Registry.ClassesRoot.OpenSubKey("*\\shell\\pintohomefile");
							bool? flag12;
							if (registryKey11 == null)
							{
								flag12 = null;
							}
							else
							{
								object value11 = registryKey11.GetValue("ProgrammaticAccessOnly");
								flag12 = ((value11 != null) ? new bool?(value11.Equals("")) : null);
							}
							flag2 = flag12;
							isOn2 = flag2.GetValueOrDefault();
							goto IL_4BF;
						}
					}
				}
			}
			isOn2 = true;
			IL_4BF:
			toggleSwitch8.IsOn = isOn2;
		}

		// Token: 0x04000039 RID: 57
		[Nullable(1)]
		private MainWindow mw = (MainWindow)Application.Current.MainWindow;

		// Token: 0x0400003A RID: 58
		private bool isLoaded = false;
	}
}
