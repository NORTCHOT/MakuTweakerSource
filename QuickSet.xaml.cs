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
	// Token: 0x02000010 RID: 16
	public partial class QuickSet : System.Windows.Controls.Page
	{
		// Token: 0x060000BF RID: 191 RVA: 0x0000C696 File Offset: 0x0000A896
		public QuickSet()
		{
			this.InitializeComponent();
			this.LoadLang();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000C6C4 File Offset: 0x0000A8C4
		[NullableContext(1)]
		private void start_Click(object sender, RoutedEventArgs e)
		{
			bool isOn = this.t1.IsOn;
			if (isOn)
			{
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("Hidden", 1);
			}
			bool isOn2 = this.t2.IsOn;
			if (isOn2)
			{
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("HideFileExt", 0);
			}
			bool isOn3 = this.t3.IsOn;
			if (isOn3)
			{
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("LaunchTo", 1);
			}
			bool isOn4 = this.t4.IsOn;
			if (isOn4)
			{
				try
				{
					Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Desktop\\NameSpace\\DelegateFolders\\{F5FB2C77-0E2F-4A16-A381-3E560C68BC83}");
					Registry.LocalMachine.DeleteSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Desktop\\NameSpace\\DelegateFolders\\{F5FB2C77-0E2F-4A16-A381-3E560C68BC83}");
				}
				catch
				{
				}
			}
			bool isOn5 = this.t5.IsOn;
			if (isOn5)
			{
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel").SetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}", 0);
			}
			bool isOn6 = this.t6.IsOn;
			if (isOn6)
			{
				try
				{
					Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel").SetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}", 0);
					Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\NamingTemplates").SetValue("ShortcutNameTemplate", "%s.lnk");
				}
				catch
				{
				}
			}
			bool isOn7 = this.t7.IsOn;
			if (isOn7)
			{
				try
				{
					Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("ShowTaskViewButton", 0);
					Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("TaskbarDa", 0);
					Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("TaskbarMn", 0);
				}
				catch
				{
				}
			}
			bool isOn8 = this.t8.IsOn;
			if (isOn8)
			{
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\SearchSettings").SetValue("IsDynamicSearchBoxEnabled", 0);
			}
			bool isOn9 = this.t9.IsOn;
			if (isOn9)
			{
				Registry.CurrentUser.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer").SetValue("DisableSearchBoxSuggestions", 1);
			}
			bool isOn10 = this.t10.IsOn;
			if (isOn10)
			{
				Process.Start("cmd.exe", "/c \"reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v ActiveHoursStart /t REG_DWORD /d 9 /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v ActiveHoursEnd /t REG_DWORD /d 2 /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseFeatureUpdatesStartTime /t REG_SZ /d \"2015-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseQualityUpdatesStartTime /t REG_SZ /d \"2015-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseUpdatesExpiryTime /t REG_SZ /d \"2077-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseFeatureUpdatesEndTime /t REG_SZ /d \"2077-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseQualityUpdatesEndTime /t REG_SZ /d \"2077-01-01T00:00:00Z\" /f && reg add HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\WindowsUpdate\\UX\\Settings /v PauseUpdatesStartTime /t REG_SZ /d \"2015-01-01T00:00:00Z\" /f\"");
			}
			bool isOn11 = this.t12.IsOn;
			if (isOn11)
			{
				Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\StickyKeys").SetValue("Flags", "506");
				Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\Keyboard Response").SetValue("Flags", "122");
				Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\ToggleKeys").SetValue("Flags", "58");
			}
			bool isOn12 = this.t13.IsOn;
			if (isOn12)
			{
				Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Clipboard").SetValue("EnableClipboardHistory", 1);
			}
			bool isOn13 = this.t14.IsOn;
			if (isOn13)
			{
				Registry.CurrentUser.CreateSubKey("Control Panel\\Desktop").SetValue("MenuShowDelay", "50");
			}
			bool isOn14 = this.t15.IsOn;
			if (isOn14)
			{
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager").SetValue("AutoChkTimeout", 60);
			}
			bool isOn15 = this.t16.IsOn;
			if (isOn15)
			{
				Process.Start("powershell.exe", "-Command \"& dism /online /Enable-Feature /FeatureName:DirectPlay /All\"");
			}
			bool isOn16 = this.t17.IsOn;
			if (isOn16)
			{
				Process.Start("powershell.exe", "-Command \"& Add-WindowsCapability -Online -Name NetFx3~~~~\"");
			}
			bool isOn17 = this.t19.IsOn;
			if (isOn17)
			{
				Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\BitLocker").SetValue("PreventDeviceEncryption", 1, RegistryValueKind.DWord);
			}
			this.mw.RebootNotify(3);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000CAEC File Offset: 0x0000ACEC
		private void LoadLang()
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "base");
			Dictionary<string, Dictionary<string, string>> dictionary2 = MainWindow.Localization.LoadLocalization(language, "quick");
			this.label.Text = dictionary2["main"]["label"];
			this.info.Text = dictionary2["main"]["info"];
			this.start.Content = dictionary2["main"]["b"];
			this.t1.Header = dictionary2["main"]["t1"];
			this.t2.Header = dictionary2["main"]["t2"];
			this.t3.Header = dictionary2["main"]["t3"];
			this.t4.Header = dictionary2["main"]["t4"];
			this.t5.Header = dictionary2["main"]["t5"];
			this.t6.Header = dictionary2["main"]["t6"];
			this.t7.Header = dictionary2["main"]["t8"];
			this.t8.Header = dictionary2["main"]["t9"];
			this.t9.Header = dictionary2["main"]["t10"];
			this.t10.Header = dictionary2["main"]["t11"];
			this.t12.Header = dictionary2["main"]["t13"];
			this.t13.Header = dictionary2["main"]["t14"];
			this.t14.Header = dictionary2["main"]["t15"];
			this.t15.Header = dictionary2["main"]["t16"];
			this.t16.Header = dictionary2["main"]["t17"];
			this.t17.Header = dictionary2["main"]["t18"];
			this.t19.Header = dictionary2["main"]["t20"];
			this.t1.OnContent = dictionary["def"]["on"];
			this.t2.OnContent = dictionary["def"]["on"];
			this.t3.OnContent = dictionary["def"]["on"];
			this.t4.OnContent = dictionary["def"]["on"];
			this.t5.OnContent = dictionary["def"]["on"];
			this.t6.OnContent = dictionary["def"]["on"];
			this.t7.OnContent = dictionary["def"]["on"];
			this.t8.OnContent = dictionary["def"]["on"];
			this.t9.OnContent = dictionary["def"]["on"];
			this.t10.OnContent = dictionary["def"]["on"];
			this.t12.OnContent = dictionary["def"]["on"];
			this.t13.OnContent = dictionary["def"]["on"];
			this.t14.OnContent = dictionary["def"]["on"];
			this.t15.OnContent = dictionary["def"]["on"];
			this.t16.OnContent = dictionary["def"]["on"];
			this.t17.OnContent = dictionary["def"]["on"];
			this.t19.OnContent = dictionary["def"]["on"];
			this.t1.OffContent = dictionary["def"]["off"];
			this.t2.OffContent = dictionary["def"]["off"];
			this.t3.OffContent = dictionary["def"]["off"];
			this.t4.OffContent = dictionary["def"]["off"];
			this.t5.OffContent = dictionary["def"]["off"];
			this.t6.OffContent = dictionary["def"]["off"];
			this.t7.OffContent = dictionary["def"]["off"];
			this.t8.OffContent = dictionary["def"]["off"];
			this.t9.OffContent = dictionary["def"]["off"];
			this.t10.OffContent = dictionary["def"]["off"];
			this.t12.OffContent = dictionary["def"]["off"];
			this.t13.OffContent = dictionary["def"]["off"];
			this.t14.OffContent = dictionary["def"]["off"];
			this.t15.OffContent = dictionary["def"]["off"];
			this.t16.OffContent = dictionary["def"]["off"];
			this.t17.OffContent = dictionary["def"]["off"];
			this.t19.OffContent = dictionary["def"]["off"];
		}

		// Token: 0x040000E8 RID: 232
		[Nullable(1)]
		private MainWindow mw = (MainWindow)Application.Current.MainWindow;
	}
}
