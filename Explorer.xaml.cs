using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using MakuTweakerNew.Properties;
using MicaWPF.Controls;
using Microsoft.Win32;
using ModernWpf.Controls;

namespace MakuTweakerNew
{
	// Token: 0x02000006 RID: 6
	public partial class Explorer : System.Windows.Controls.Page
	{
		// Token: 0x06000041 RID: 65 RVA: 0x00005588 File Offset: 0x00003788
		public Explorer()
		{
			this.InitializeComponent();
			this.checkReg();
			bool flag = this.checkWinVer() >= 22621;
			if (flag)
			{
				this.e1.Visibility = Visibility.Collapsed;
			}
			else
			{
				this.e5.Visibility = Visibility.Collapsed;
			}
			bool b = Settings.Default.b11;
			if (b)
			{
				this.showall.IsEnabled = false;
			}
			this.LoadLang(Settings.Default.lang);
			this.isLoaded = true;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005630 File Offset: 0x00003830
		[NullableContext(1)]
		private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.e1 = this.e1.IsOn;
				if (!this.e1.IsOn)
				{
					try
					{
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{d3162b92-9365-467a-956b-92703aca08af}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{d3162b92-9365-467a-956b-92703aca08af}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{374DE290-123F-4565-9164-39C4925E467B}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{088e3905-0323-4b02-9826-5d99428e115f}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{374DE290-123F-4565-9164-39C4925E467B}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{088e3905-0323-4b02-9826-5d99428e115f}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{A0953C92-50DC-43bf-BE83-3742FED03C9C}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{d3162b92-9365-467a-956b-92703aca08af}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{d3162b92-9365-467a-956b-92703aca08af}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{374DE290-123F-4565-9164-39C4925E467B}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{088e3905-0323-4b02-9826-5d99428e115f}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{374DE290-123F-4565-9164-39C4925E467B}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{088e3905-0323-4b02-9826-5d99428e115f}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
						Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}");
						try
						{
							Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}");
							Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}");
						}
						catch
						{
						}
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000059EC File Offset: 0x00003BEC
		[NullableContext(1)]
		private void e2_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.e2 = this.e2.IsOn;
				if (!this.e2.IsOn)
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("Hidden", 0);
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("Hidden", 1);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005AA8 File Offset: 0x00003CA8
		[NullableContext(1)]
		private void e3_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.e3 = this.e3.IsOn;
				if (!this.e3.IsOn)
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("HideFileExt", 1);
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("HideFileExt", 0);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00005B64 File Offset: 0x00003D64
		[NullableContext(1)]
		private void e4_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.e4 = this.e4.IsOn;
				if (!this.e4.IsOn)
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("LaunchTo", 2);
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced").SetValue("LaunchTo", 1);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00005C20 File Offset: 0x00003E20
		[NullableContext(1)]
		private void e5_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.e5 = this.e5.IsOn;
				if (!this.e5.IsOn)
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\CLSID\\{e88865ea-0e1c-4e20-9aa6-edcd0212c87c}").SetValue("System.IsPinnedToNameSpaceTree", 1);
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\CLSID\\{e88865ea-0e1c-4e20-9aa6-edcd0212c87c}").SetValue("System.IsPinnedToNameSpaceTree", 0);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00005CDC File Offset: 0x00003EDC
		[NullableContext(1)]
		private void e6_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.e6 = this.e6.IsOn;
				if (!this.e6.IsOn)
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel").SetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}", 1);
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
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00005D98 File Offset: 0x00003F98
		[NullableContext(1)]
		private void e7_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.e7 = this.e7.IsOn;
				if (!this.e7.IsOn)
				{
					try
					{
						Registry.CurrentUser.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\NamingTemplates");
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\NamingTemplates").SetValue("ShortcutNameTemplate", "%s.lnk");
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00005E40 File Offset: 0x00004040
		[NullableContext(1)]
		private void fix_Click(object sender, RoutedEventArgs e)
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "expl");
			try
			{
				Registry.LocalMachine.DeleteSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Desktop\\NameSpace\\DelegateFolders\\{F5FB2C77-0E2F-4A16-A381-3E560C68BC83}");
				Registry.LocalMachine.DeleteSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Desktop\\NameSpace\\DelegateFolders\\{F5FB2C77-0E2F-4A16-A381-3E560C68BC83}");
				this.mw.ChSt(dictionary["status"]["e8"]);
				Settings.Default.isE8Hidden = true;
				this.FadeOut(this.e8, 300.0);
				this.FadeOut(this.fix, 300.0);
				this.e8.IsEnabled = false;
				this.fix.IsEnabled = false;
			}
			catch
			{
				this.mw.ChSt(dictionary["status"]["e8"]);
				Settings.Default.isE8Hidden = true;
				this.FadeOut(this.e8, 300.0);
				this.FadeOut(this.fix, 300.0);
				this.e8.IsEnabled = false;
				this.fix.IsEnabled = false;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00005F90 File Offset: 0x00004190
		[NullableContext(1)]
		private void FadeOut(UIElement element, double durationSeconds)
		{
			DoubleAnimation animation = new DoubleAnimation
			{
				From = new double?(1.0),
				To = new double?(0.0),
				Duration = TimeSpan.FromMilliseconds(durationSeconds),
				EasingFunction = new QuadraticEase
				{
					EasingMode = EasingMode.EaseOut
				}
			};
			element.BeginAnimation(UIElement.OpacityProperty, animation);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00006004 File Offset: 0x00004204
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

		// Token: 0x0600004C RID: 76 RVA: 0x0000608C File Offset: 0x0000428C
		[NullableContext(1)]
		private void LoadLang(string lang)
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "expl");
			Dictionary<string, Dictionary<string, string>> dictionary2 = MainWindow.Localization.LoadLocalization(language, "base");
			this.lab.Text = dictionary["main"]["label"];
			this.e1.Header = dictionary["main"]["e1"];
			this.e2.Header = dictionary["main"]["e2"];
			this.e3.Header = dictionary["main"]["e3"];
			this.e4.Header = dictionary["main"]["e4"];
			this.e5.Header = dictionary["main"]["e5"];
			this.e6.Header = dictionary["main"]["e6"];
			this.e7.Header = dictionary["main"]["e7"];
			this.e8.Text = dictionary["main"]["e8"];
			this.fix.Content = dictionary["main"]["e8b"];
			this.e9.Text = dictionary["main"]["e9"];
			this.hide.Content = dictionary["main"]["choose"];
			this.showall.Content = dictionary["main"]["showall"];
			this.e1.OnContent = dictionary2["def"]["on"];
			this.e2.OnContent = dictionary2["def"]["on"];
			this.e3.OnContent = dictionary2["def"]["on"];
			this.e4.OnContent = dictionary2["def"]["on"];
			this.e5.OnContent = dictionary2["def"]["on"];
			this.e6.OnContent = dictionary2["def"]["on"];
			this.e7.OnContent = dictionary2["def"]["on"];
			this.e1.OffContent = dictionary2["def"]["off"];
			this.e2.OffContent = dictionary2["def"]["off"];
			this.e3.OffContent = dictionary2["def"]["off"];
			this.e4.OffContent = dictionary2["def"]["off"];
			this.e5.OffContent = dictionary2["def"]["off"];
			this.e6.OffContent = dictionary2["def"]["off"];
			this.e7.OffContent = dictionary2["def"]["off"];
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00006444 File Offset: 0x00004644
		private void checkReg()
		{
			this.e1.IsOn = (Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{A0953C92-50DC-43bf-BE83-3742FED03C9C}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{A0953C92-50DC-43bf-BE83-3742FED03C9C}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{f86fa3ab-70d2-4fc7-9c99-fcbf05467f3a}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{d3162b92-9365-467a-956b-92703aca08af}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{A8CDFF1C-4878-43be-B5FD-F8091C1C60D0}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{d3162b92-9365-467a-956b-92703aca08af}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{374DE290-123F-4565-9164-39C4925E467B}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{088e3905-0323-4b02-9826-5d99428e115f}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{374DE290-123F-4565-9164-39C4925E467B}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{088e3905-0323-4b02-9826-5d99428e115f}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{3ADD1653-EB32-4cb0-BBD7-DFA0ABB5ACCA}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{24ad3ad4-a569-4530-98e1-ab02f9417aa8}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{1CF1260C-4DD0-4ebb-811F-33C572699FDE}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{3dfdf296-dbec-4fb4-81d1-6a3438bcf4de}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{B4BFCC3A-DB2C-424C-B029-7FE99A87C641}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MyComputer\\NameSpace\\{0DB7E03F-FC29-4DC6-9020-FF41B59E513A}") == null);
			ModernWpf.Controls.ToggleSwitch toggleSwitch = this.e2;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
			bool? flag;
			if (registryKey == null)
			{
				flag = null;
			}
			else
			{
				object value = registryKey.GetValue("Hidden");
				flag = ((value != null) ? new bool?(value.Equals(1)) : null);
			}
			bool? flag2 = flag;
			toggleSwitch.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch2 = this.e3;
			RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
			bool? flag3;
			if (registryKey2 == null)
			{
				flag3 = null;
			}
			else
			{
				object value2 = registryKey2.GetValue("HideFileExt");
				flag3 = ((value2 != null) ? new bool?(value2.Equals(0)) : null);
			}
			flag2 = flag3;
			toggleSwitch2.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch3 = this.e4;
			RegistryKey registryKey3 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced", true);
			bool? flag4;
			if (registryKey3 == null)
			{
				flag4 = null;
			}
			else
			{
				object value3 = registryKey3.GetValue("LaunchTo");
				flag4 = ((value3 != null) ? new bool?(value3.Equals(1)) : null);
			}
			flag2 = flag4;
			toggleSwitch3.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch4 = this.e5;
			RegistryKey registryKey4 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\CLSID\\{e88865ea-0e1c-4e20-9aa6-edcd0212c87c}", true);
			bool? flag5;
			if (registryKey4 == null)
			{
				flag5 = null;
			}
			else
			{
				object value4 = registryKey4.GetValue("System.IsPinnedToNameSpaceTree");
				flag5 = ((value4 != null) ? new bool?(value4.Equals(0)) : null);
			}
			flag2 = flag5;
			toggleSwitch4.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch5 = this.e6;
			RegistryKey registryKey5 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\HideDesktopIcons\\NewStartPanel", true);
			bool? flag6;
			if (registryKey5 == null)
			{
				flag6 = null;
			}
			else
			{
				object value5 = registryKey5.GetValue("{20D04FE0-3AEA-1069-A2D8-08002B30309D}");
				flag6 = ((value5 != null) ? new bool?(value5.Equals(0)) : null);
			}
			flag2 = flag6;
			toggleSwitch5.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch6 = this.e7;
			RegistryKey registryKey6 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\NamingTemplates", true);
			bool? flag7;
			if (registryKey6 == null)
			{
				flag7 = null;
			}
			else
			{
				object value6 = registryKey6.GetValue("ShortcutNameTemplate");
				flag7 = ((value6 != null) ? new bool?(value6.Equals("%s.lnk")) : null);
			}
			flag2 = flag7;
			toggleSwitch6.IsOn = flag2.GetValueOrDefault();
			bool flag8 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Desktop\\NameSpace\\DelegateFolders\\{F5FB2C77-0E2F-4A16-A381-3E560C68BC83}") == null || Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Desktop\\NameSpace\\DelegateFolders\\{F5FB2C77-0E2F-4A16-A381-3E560C68BC83}") == null;
			if (flag8)
			{
				this.e8.Visibility = Visibility.Collapsed;
				this.fix.Visibility = Visibility.Collapsed;
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00006898 File Offset: 0x00004A98
		[NullableContext(1)]
		[DebuggerStepThrough]
		private void hide_Click(object sender, RoutedEventArgs e)
		{
			Explorer.<hide_Click>d__15 <hide_Click>d__ = new Explorer.<hide_Click>d__15();
			<hide_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<hide_Click>d__.<>4__this = this;
			<hide_Click>d__.sender = sender;
			<hide_Click>d__.e = e;
			<hide_Click>d__.<>1__state = -1;
			<hide_Click>d__.<>t__builder.Start<Explorer.<hide_Click>d__15>(ref <hide_Click>d__);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000068E0 File Offset: 0x00004AE0
		[NullableContext(1)]
		private void showall_Click(object sender, RoutedEventArgs e)
		{
			Settings.Default.hiddenDrives = string.Empty;
			Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer").SetValue("NoDrives", 0, RegistryValueKind.DWord);
			this.mw.RebootNotify(2);
			this.showall.IsEnabled = false;
			Settings.Default.b11 = true;
		}

		// Token: 0x0400004A RID: 74
		[Nullable(1)]
		private MainWindow mw = (MainWindow)Application.Current.MainWindow;

		// Token: 0x0400004B RID: 75
		private bool isLoaded = false;
	}
}
