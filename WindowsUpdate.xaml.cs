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
using MicaWPF.Controls;
using Microsoft.Win32;
using ModernWpf.Controls;

namespace MakuTweakerNew
{
	// Token: 0x02000017 RID: 23
	public partial class WindowsUpdate : System.Windows.Controls.Page
	{
		// Token: 0x0600012B RID: 299 RVA: 0x00013724 File Offset: 0x00011924
		public WindowsUpdate()
		{
			this.InitializeComponent();
			this.checkReg();
			bool flag = Settings.Default.wu4 == 2312;
			if (flag)
			{
				int num = this.checkWinVer();
				int num2 = num;
				if (num2 <= 19045)
				{
					if (num2 <= 16299)
					{
						if (num2 != 14393)
						{
							if (num2 == 16299)
							{
								Settings.Default.wu4 = 1;
							}
						}
						else
						{
							Settings.Default.wu4 = 0;
						}
					}
					else if (num2 != 17763)
					{
						if (num2 != 18363)
						{
							switch (num2)
							{
							case 19041:
								Settings.Default.wu4 = 4;
								break;
							case 19042:
								Settings.Default.wu4 = 5;
								break;
							case 19044:
								Settings.Default.wu4 = 6;
								break;
							case 19045:
								Settings.Default.wu4 = 7;
								break;
							}
						}
						else
						{
							Settings.Default.wu4 = 3;
						}
					}
					else
					{
						Settings.Default.wu4 = 2;
					}
				}
				else if (num2 <= 22621)
				{
					if (num2 != 22000)
					{
						if (num2 == 22621)
						{
							Settings.Default.wu4 = 7;
						}
					}
					else
					{
						Settings.Default.wu4 = 6;
					}
				}
				else if (num2 != 22631)
				{
					if (num2 != 26100)
					{
						if (num2 == 26200)
						{
							Settings.Default.wu4 = 10;
						}
					}
					else
					{
						Settings.Default.wu4 = 9;
					}
				}
				else
				{
					Settings.Default.wu4 = 8;
				}
			}
			int arg = this.checkWinVer();
			ValueTuple<Func<int, bool>, UIElement>[] array = new ValueTuple<Func<int, bool>, UIElement>[10];
			array[0] = new ValueTuple<Func<int, bool>, UIElement>((int b) => b > 14393, this.u1607);
			array[1] = new ValueTuple<Func<int, bool>, UIElement>((int b) => b > 16299, this.u1709);
			array[2] = new ValueTuple<Func<int, bool>, UIElement>((int b) => b > 17763, this.u1809);
			array[3] = new ValueTuple<Func<int, bool>, UIElement>((int b) => b > 18363, this.u1909);
			array[4] = new ValueTuple<Func<int, bool>, UIElement>((int b) => b > 19041, this.u2004);
			array[5] = new ValueTuple<Func<int, bool>, UIElement>((int b) => b > 19042, this.u20H2);
			array[6] = new ValueTuple<Func<int, bool>, UIElement>((int b) => (b > 19044 && b < 22000) || b > 22000, this.u21H2);
			array[7] = new ValueTuple<Func<int, bool>, UIElement>((int b) => (b > 19045 && b < 22621) || b > 22621, this.u22H2);
			array[8] = new ValueTuple<Func<int, bool>, UIElement>((int b) => b > 22631, this.u23H2);
			array[9] = new ValueTuple<Func<int, bool>, UIElement>((int b) => b > 26100, this.u24H2);
			ValueTuple<Func<int, bool>, UIElement>[] array2 = array;
			foreach (ValueTuple<Func<int, bool>, UIElement> valueTuple in array2)
			{
				Func<int, bool> item = valueTuple.Item1;
				UIElement item2 = valueTuple.Item2;
				bool flag2 = item(arg);
				if (flag2)
				{
					item2.Visibility = Visibility.Collapsed;
					item2.IsEnabled = false;
				}
			}
			this.pause.IsEnabled = !Settings.Default.b9;
			this.wu4.SelectedIndex = Settings.Default.wu4;
			this.wu6.IsOn = Settings.Default.wu6;
			this.LoadLang("ilovemakutweaker");
			this.wupd.IsEnabled = !Settings.Default.b7;
			this.isLoaded = true;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00013BC8 File Offset: 0x00011DC8
		[NullableContext(1)]
		private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.wu1 = this.wu1.IsOn;
				if (!this.wu1.IsOn)
				{
					try
					{
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU").SetValue("NoAutoUpdate", 0);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("DoNotConnectToWindowsUpdateInternetLocations", 0);
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU").SetValue("NoAutoUpdate", 1);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("DoNotConnectToWindowsUpdateInternetLocations", 1);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00013CC4 File Offset: 0x00011EC4
		[NullableContext(1)]
		private void ToggleSwitch_Toggled_1(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.wu2 = this.wu2.IsOn;
				if (!this.wu2.IsOn)
				{
					try
					{
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("ExcludeWUDriversInQualityUpdate", 0);
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel").SetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}", 0);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("ExcludeWUDriversInQualityUpdate", 1);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00013DA0 File Offset: 0x00011FA0
		[NullableContext(1)]
		private void wu4_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00013DA4 File Offset: 0x00011FA4
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

		// Token: 0x06000130 RID: 304 RVA: 0x00013E2C File Offset: 0x0001202C
		[NullableContext(1)]
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Settings.Default.wu4 = this.wu4.SelectedIndex;
			switch (this.wu4.SelectedIndex)
			{
			case 0:
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("TargetReleaseVersionInfo", "1607");
				break;
			case 1:
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("TargetReleaseVersionInfo", "1709");
				break;
			case 2:
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("TargetReleaseVersionInfo", "1809");
				break;
			case 3:
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("TargetReleaseVersionInfo", "1909");
				break;
			case 4:
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("TargetReleaseVersionInfo", "2004");
				break;
			case 5:
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("TargetReleaseVersionInfo", "20H2");
				break;
			case 6:
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("TargetReleaseVersionInfo", "21H2");
				break;
			case 7:
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("TargetReleaseVersionInfo", "22H2");
				break;
			case 8:
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("TargetReleaseVersionInfo", "23H2");
				break;
			case 9:
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("TargetReleaseVersionInfo", "24H2");
				break;
			case 10:
				Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate").SetValue("TargetReleaseVersionInfo", "25H2");
				break;
			}
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "wu");
			this.mw.ChSt(dictionary["status"]["wu4"]);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00014058 File Offset: 0x00012258
		[NullableContext(1)]
		private void pause_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Process.Start("cmd.exe", "/c \"reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v ActiveHoursStart /t REG_DWORD /d 9 /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v ActiveHoursEnd /t REG_DWORD /d 2 /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseFeatureUpdatesStartTime /t REG_SZ /d \"2015-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseQualityUpdatesStartTime /t REG_SZ /d \"2015-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseUpdatesExpiryTime /t REG_SZ /d \"2077-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseFeatureUpdatesEndTime /t REG_SZ /d \"2077-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseQualityUpdatesEndTime /t REG_SZ /d \"2077-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseUpdatesStartTime /t REG_SZ /d \"2015-01-01T00:00:00Z\" /f\"");
				string language = Settings.Default.lang ?? "en";
				Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "wu");
				this.pause.IsEnabled = false;
				Settings.Default.b9 = !this.pause.IsEnabled;
				this.mw.ChSt(dictionary["status"]["wu5"]);
			}
			catch
			{
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x000140F8 File Offset: 0x000122F8
		[NullableContext(1)]
		private void wu6_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.wu6 = this.wu6.IsOn;
				if (!this.wu6.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ReserveManager").SetValue("ShippedWithReserves", 1);
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ReserveManager").SetValue("ShippedWithReserves", 0);
				}
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00014180 File Offset: 0x00012380
		[NullableContext(1)]
		private void LoadLang(string lang)
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "base");
			Dictionary<string, Dictionary<string, string>> dictionary2 = MainWindow.Localization.LoadLocalization(language, "wu");
			Dictionary<string, Dictionary<string, string>> dictionary3 = MainWindow.Localization.LoadLocalization(language, "sr");
			this.wu1.Header = dictionary2["main"]["wu1"];
			this.wu2.Header = dictionary2["main"]["wu3"];
			this.wu6.Header = dictionary2["main"]["wu6"];
			this.pausel.Text = dictionary2["main"]["wu5"];
			this.blockL.Text = dictionary2["main"]["wu2"];
			this.l7.Text = dictionary3["main"]["sr7l"];
			this.pause.Content = dictionary2["main"]["wu5b"];
			this.block.Content = dictionary2["main"]["wu6b"];
			this.wupd.Content = dictionary3["main"]["b4"];
			this.wu1.OffContent = dictionary["def"]["off"];
			this.wu2.OffContent = dictionary["def"]["off"];
			this.wu6.OffContent = dictionary["def"]["off"];
			this.wu1.OnContent = dictionary["def"]["on"];
			this.wu2.OnContent = dictionary["def"]["on"];
			this.wu6.OnContent = dictionary["def"]["on"];
		}

		// Token: 0x06000134 RID: 308 RVA: 0x000143B8 File Offset: 0x000125B8
		private void checkReg()
		{
			ModernWpf.Controls.ToggleSwitch toggleSwitch = this.wu1;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU", true);
			bool? flag;
			if (registryKey == null)
			{
				flag = null;
			}
			else
			{
				object value = registryKey.GetValue("NoAutoUpdate");
				flag = ((value != null) ? new bool?(value.Equals(1)) : null);
			}
			bool? flag2 = flag;
			toggleSwitch.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch2 = this.wu2;
			RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WindowsUpdate", true);
			bool? flag3;
			if (registryKey2 == null)
			{
				flag3 = null;
			}
			else
			{
				object value2 = registryKey2.GetValue("ExcludeWUDriversInQualityUpdate");
				flag3 = ((value2 != null) ? new bool?(value2.Equals(1)) : null);
			}
			flag2 = flag3;
			toggleSwitch2.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch3 = this.wu6;
			RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\ReserveManage", true);
			bool? flag4;
			if (registryKey3 == null)
			{
				flag4 = null;
			}
			else
			{
				object value3 = registryKey3.GetValue("ShippedWithReserves");
				flag4 = ((value3 != null) ? new bool?(value3.Equals(0)) : null);
			}
			flag2 = flag4;
			toggleSwitch3.IsOn = flag2.GetValueOrDefault();
		}

		// Token: 0x06000135 RID: 309 RVA: 0x000144DA File Offset: 0x000126DA
		[NullableContext(1)]
		private void wupd_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("cmd.exe", "/k del /f /s /q %windir%\\SoftwareDistribution\\Download\\*");
			this.wupd.IsEnabled = false;
			Settings.Default.b7 = !this.wupd.IsEnabled;
		}

		// Token: 0x04000187 RID: 391
		private bool isLoaded = false;

		// Token: 0x04000188 RID: 392
		[Nullable(1)]
		private MainWindow mw = (MainWindow)Application.Current.MainWindow;
	}
}
