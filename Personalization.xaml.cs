using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using MakuTweakerNew.Properties;
using MicaWPF.Controls;
using Microsoft.Win32;
using ModernWpf.Controls;

namespace MakuTweakerNew
{
	// Token: 0x0200000F RID: 15
	public partial class Personalization : System.Windows.Controls.Page
	{
		// Token: 0x060000AE RID: 174 RVA: 0x0000B2F4 File Offset: 0x000094F4
		public Personalization()
		{
			this.InitializeComponent();
			this.color.SelectedIndex = Settings.Default.p3;
			this.checkReg();
			this.LoadLang();
			bool flag = this.checkWinVer() < 22000;
			if (flag)
			{
				this.p7.Visibility = Visibility.Collapsed;
			}
			this.sr2.IsOn = Settings.Default.sr2;
			this.sr3.IsOn = Settings.Default.sr3;
			this.isLoaded = true;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000B3A4 File Offset: 0x000095A4
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

		// Token: 0x060000B0 RID: 176 RVA: 0x0000B42C File Offset: 0x0000962C
		[NullableContext(1)]
		private void apN_Click(object sender, RoutedEventArgs e)
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "per");
			Settings.Default.p2 = this.newname.Text;
			string text = this.newname.Text;
			string str = "reg add HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\NamingTemplates /v RenameNameTemplate /t REG_SZ /d \"" + text + "\" /f";
			Process.Start("cmd.exe", "/c " + str);
			this.mw.ChSt(dictionary["status"]["apN"]);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000B4C4 File Offset: 0x000096C4
		[NullableContext(1)]
		private void stN_Click(object sender, RoutedEventArgs e)
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "per");
			Settings.Default.p2 = string.Empty;
			this.newname.Text = string.Empty;
			string str = "reg delete HKCU\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\NamingTemplates /v RenameNameTemplate /f";
			Process.Start("cmd.exe", "/c " + str);
			this.mw.ChSt(dictionary["status"]["stN"]);
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000B550 File Offset: 0x00009750
		[NullableContext(1)]
		private void apC_Click(object sender, RoutedEventArgs e)
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "per");
			Settings.Default.p3 = this.color.SelectedIndex;
			string name = "Control Panel\\Colors";
			string value;
			string value2;
			switch (this.color.SelectedIndex)
			{
			case 0:
				value = "51 153 255";
				value2 = "0 102 204";
				break;
			case 1:
				value = "0 100 100";
				value2 = "0 100 100";
				break;
			case 2:
				value = "180 0 180";
				value2 = "110 0 110";
				break;
			case 3:
				value = "0 90 30";
				value2 = "0 90 30";
				break;
			case 4:
				value = "100 40 0";
				value2 = "100 40 0";
				break;
			case 5:
				value = "135 0 0";
				value2 = "135 0 0";
				break;
			case 6:
				value = "15, 0, 120";
				value2 = "15, 0, 120";
				break;
			case 7:
				value = "40 40 40";
				value2 = "40 40 40";
				break;
			default:
				return;
			}
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(name, true);
			bool flag = registryKey != null;
			if (flag)
			{
				registryKey.SetValue("HightLight", value, RegistryValueKind.String);
				registryKey.SetValue("Hilight", value, RegistryValueKind.String);
				registryKey.SetValue("HotTrackingColor", value2, RegistryValueKind.String);
			}
			this.mw.ChSt(dictionary["status"]["apC"]);
			this.mw.RebootNotify(1);
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000B6E4 File Offset: 0x000098E4
		[NullableContext(1)]
		private void p2_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.p4 = this.p2.IsOn;
				if (!this.p2.IsOn)
				{
					Process.Start("cmd.exe", "/c \"reg add \"HKEY_CURRENT_USER\\Control Panel\\Desktop\\WindowMetrics\" /v CaptionHeight /t REG_SZ /d -330 /f\"");
					Process.Start("cmd.exe", "/c \"reg add \"HKEY_CURRENT_USER\\Control Panel\\Desktop\\WindowMetrics\" /v CaptionWidth /t REG_SZ /d -330 /f\"");
				}
				else
				{
					Process.Start("cmd.exe", "/c \"reg add \"HKEY_CURRENT_USER\\Control Panel\\Desktop\\WindowMetrics\" /v CaptionHeight /t REG_SZ /d -270 /f\"");
					Process.Start("cmd.exe", "/c \"reg add \"HKEY_CURRENT_USER\\Control Panel\\Desktop\\WindowMetrics\" /v CaptionWidth /t REG_SZ /d -270 /f\"");
				}
				this.mw.RebootNotify(1);
			}
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000B778 File Offset: 0x00009978
		[NullableContext(1)]
		private void p3_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.o6 = this.p3.IsOn;
				if (!this.p3.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System").SetValue("DisableAcrylicBackgroundOnLogon", 0);
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System").SetValue("DisableAcrylicBackgroundOnLogon", 1);
				}
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000B800 File Offset: 0x00009A00
		private void LoadLang()
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "per");
			Dictionary<string, Dictionary<string, string>> dictionary2 = MainWindow.Localization.LoadLocalization(language, "base");
			Dictionary<string, Dictionary<string, string>> dictionary3 = MainWindow.Localization.LoadLocalization(language, "sr");
			Dictionary<string, Dictionary<string, string>> dictionary4 = MainWindow.Localization.LoadLocalization(language, "oth");
			this.label.Text = dictionary["main"]["label"];
			this.l1.Text = dictionary["main"]["p1l"];
			this.newname.Watermark = dictionary["main"]["newname"];
			this.apN.Content = dictionary["main"]["b1"];
			this.apC.Content = dictionary["main"]["b1"];
			this.stN.Content = dictionary["main"]["b2"];
			this.l2.Text = dictionary["main"]["p2l"];
			this.c1.Content = dictionary["main"]["c1"];
			this.c2.Content = dictionary["main"]["c2"];
			this.c3.Content = dictionary["main"]["c3"];
			this.c4.Content = dictionary["main"]["c4"];
			this.c5.Content = dictionary["main"]["c5"];
			this.c6.Content = dictionary["main"]["c6"];
			this.c7.Content = dictionary["main"]["c7"];
			this.c8.Content = dictionary["main"]["c8"];
			this.p2.Header = dictionary["main"]["p4"];
			this.p3.Header = dictionary["main"]["p5"];
			this.p4.Header = dictionary["main"]["p7"];
			this.p5.Header = dictionary["main"]["p8"];
			this.p6.Header = dictionary["main"]["p3"];
			this.p7.Header = dictionary3["main"]["etask"];
			this.sr2.Header = dictionary3["main"]["sr2"];
			this.sr3.Header = dictionary3["main"]["sr3"];
			this.p2.OffContent = dictionary2["def"]["off"];
			this.p3.OffContent = dictionary2["def"]["off"];
			this.p4.OffContent = dictionary2["def"]["off"];
			this.p5.OffContent = dictionary2["def"]["off"];
			this.sr2.OffContent = dictionary2["def"]["off"];
			this.sr3.OffContent = dictionary2["def"]["off"];
			this.p6.OffContent = dictionary2["def"]["off"];
			this.p7.OffContent = dictionary2["def"]["off"];
			this.p2.OnContent = dictionary2["def"]["on"];
			this.p3.OnContent = dictionary2["def"]["on"];
			this.p4.OnContent = dictionary2["def"]["on"];
			this.p5.OnContent = dictionary2["def"]["on"];
			this.sr2.OnContent = dictionary2["def"]["on"];
			this.sr3.OnContent = dictionary2["def"]["on"];
			this.p6.OnContent = dictionary2["def"]["on"];
			this.p7.OnContent = dictionary2["def"]["on"];
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000BD5C File Offset: 0x00009F5C
		private void checkReg()
		{
			System.Windows.Controls.TextBox textBox = this.newname;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\NamingTemplates");
			string text;
			if (registryKey == null)
			{
				text = null;
			}
			else
			{
				object value = registryKey.GetValue("RenameNameTemplate");
				text = ((value != null) ? value.ToString() : null);
			}
			textBox.Text = text;
			ModernWpf.Controls.ToggleSwitch toggleSwitch = this.p2;
			RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop\\WindowMetrics");
			bool flag;
			if (registryKey2 == null)
			{
				flag = false;
			}
			else
			{
				object value2 = registryKey2.GetValue("CaptionHeight");
				flag = ((value2 != null) ? new bool?(value2.Equals(-270)) : null).GetValueOrDefault();
			}
			bool isOn;
			if (!flag)
			{
				RegistryKey registryKey3 = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop\\WindowMetrics");
				if (registryKey3 == null)
				{
					isOn = false;
				}
				else
				{
					object value3 = registryKey3.GetValue("CaptionWidth");
					isOn = ((value3 != null) ? new bool?(value3.Equals(-270)) : null).GetValueOrDefault();
				}
			}
			else
			{
				isOn = true;
			}
			toggleSwitch.IsOn = isOn;
			ModernWpf.Controls.ToggleSwitch toggleSwitch2 = this.p3;
			RegistryKey registryKey4 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System");
			bool isOn2;
			if (registryKey4 == null)
			{
				isOn2 = false;
			}
			else
			{
				object value4 = registryKey4.GetValue("DisableAcrylicBackgroundOnLogon");
				isOn2 = ((value4 != null) ? new bool?(value4.Equals(1)) : null).GetValueOrDefault();
			}
			toggleSwitch2.IsOn = isOn2;
			ModernWpf.Controls.ToggleSwitch toggleSwitch3 = this.p4;
			RegistryKey registryKey5 = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize");
			bool isOn3;
			if (registryKey5 == null)
			{
				isOn3 = false;
			}
			else
			{
				object value5 = registryKey5.GetValue("EnableTransparency");
				isOn3 = ((value5 != null) ? new bool?(value5.Equals(0)) : null).GetValueOrDefault();
			}
			toggleSwitch3.IsOn = isOn3;
			ModernWpf.Controls.ToggleSwitch toggleSwitch4 = this.p5;
			RegistryKey registryKey6 = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize");
			object obj = (registryKey6 != null) ? registryKey6.GetValue("AppsUseLightTheme") : null;
			bool isOn4;
			if (obj is int && (int)obj == 0)
			{
				RegistryKey registryKey7 = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize");
				obj = ((registryKey7 != null) ? registryKey7.GetValue("SystemUsesLightTheme") : null);
				if (obj is int)
				{
					int num = (int)obj;
					isOn4 = (num == 0);
				}
				else
				{
					isOn4 = false;
				}
			}
			else
			{
				isOn4 = false;
			}
			toggleSwitch4.IsOn = isOn4;
			ModernWpf.Controls.ToggleSwitch toggleSwitch5 = this.p6;
			RegistryKey registryKey8 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
			bool? flag2;
			if (registryKey8 == null)
			{
				flag2 = null;
			}
			else
			{
				object value6 = registryKey8.GetValue("verbosestatus");
				flag2 = ((value6 != null) ? new bool?(value6.Equals(1)) : null);
			}
			bool? flag3 = flag2;
			toggleSwitch5.IsOn = flag3.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch6 = this.p7;
			RegistryKey registryKey9 = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\TaskbarDeveloperSettings");
			obj = ((registryKey9 != null) ? registryKey9.GetValue("TaskbarEndTask") : null);
			bool isOn5;
			if (obj is int)
			{
				int num2 = (int)obj;
				isOn5 = (num2 == 1);
			}
			else
			{
				isOn5 = false;
			}
			toggleSwitch6.IsOn = isOn5;
			Settings.Default.sr9 = this.p7.IsOn;
			Settings.Default.Save();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000C030 File Offset: 0x0000A230
		[NullableContext(1)]
		private void p4_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				if (!this.p4.IsOn)
				{
					Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize").SetValue("EnableTransparency", 1);
				}
				else
				{
					Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize").SetValue("EnableTransparency", 0);
				}
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000C0A4 File Offset: 0x0000A2A4
		[NullableContext(1)]
		private void p5_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				if (!this.p5.IsOn)
				{
					Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize").SetValue("AppsUseLightTheme", 1);
					Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize").SetValue("SystemUsesLightTheme", 1);
				}
				else
				{
					Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize").SetValue("AppsUseLightTheme", 0);
					Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize").SetValue("SystemUsesLightTheme", 0);
				}
				this.mw.RebootNotify(2);
				System.Windows.Forms.Application.Restart();
				System.Windows.Application.Current.Shutdown();
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000C178 File Offset: 0x0000A378
		[NullableContext(1)]
		private void p6_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				if (!this.p6.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System").SetValue("verbosestatus", 0);
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System").SetValue("verbosestatus", 1);
				}
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000C1EC File Offset: 0x0000A3EC
		[NullableContext(1)]
		private void sr2_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.sr2 = this.sr2.IsOn;
				if (!this.sr2.IsOn)
				{
					Process.Start("cmd.exe", "/c \"bcdedit /set \"{globalsettings}\" custom:16000067 false\"");
				}
				else
				{
					Process.Start("cmd.exe", "/c \"bcdedit /set \"{globalsettings}\" custom:16000067 true\"");
				}
			}
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000C254 File Offset: 0x0000A454
		[NullableContext(1)]
		private void sr3_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.sr3 = this.sr3.IsOn;
				if (!this.sr3.IsOn)
				{
					Process.Start("cmd.exe", "/c \"bcdedit /set \"{globalsettings}\" custom:16000069 false\"");
				}
				else
				{
					Process.Start("cmd.exe", "/c \"bcdedit /set \"{globalsettings}\" custom:16000069 true\"");
				}
			}
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000C2BC File Offset: 0x0000A4BC
		[NullableContext(1)]
		private void p7_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.sr9 = this.p7.IsOn;
				if (!this.p7.IsOn)
				{
					Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\TaskbarDeveloperSettings").SetValue("TaskbarEndTask", 0);
				}
				else
				{
					Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\\TaskbarDeveloperSettings").SetValue("TaskbarEndTask", 1);
				}
			}
		}

		// Token: 0x040000CD RID: 205
		private bool isLoaded = false;

		// Token: 0x040000CE RID: 206
		[Nullable(1)]
		private MainWindow mw = (MainWindow)System.Windows.Application.Current.MainWindow;
	}
}
