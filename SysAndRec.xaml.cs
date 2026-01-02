using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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
	// Token: 0x02000013 RID: 19
	public partial class SysAndRec : System.Windows.Controls.Page
	{
		// Token: 0x060000E3 RID: 227 RVA: 0x0000E44C File Offset: 0x0000C64C
		public SysAndRec()
		{
			this.InitializeComponent();
			this.sr1.IsOn = Settings.Default.sr1;
			this.sr4.IsOn = Settings.Default.sr4;
			this.sr5.IsOn = Settings.Default.sr5;
			this.t13.IsOn = Settings.Default.powercfgsl;
			this.sfc.IsEnabled = !Settings.Default.b3;
			this.dism.IsEnabled = !Settings.Default.b4;
			this.temp.IsEnabled = !Settings.Default.b6;
			this.checkReg();
			this.LoadLang();
			this.isLoaded = true;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000E53C File Offset: 0x0000C73C
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

		// Token: 0x060000E5 RID: 229 RVA: 0x0000E5C4 File Offset: 0x0000C7C4
		[NullableContext(1)]
		private void sr1_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.sr1 = this.sr1.IsOn;
				if (!this.sr1.IsOn)
				{
					Process.Start("cmd.exe", "/c \"bcdedit /set \"{current}\" bootmenupolicy standard\"");
				}
				else
				{
					Process.Start("cmd.exe", "/c \"bcdedit /set \"{current}\" bootmenupolicy legacy\"");
				}
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000E62C File Offset: 0x0000C82C
		[NullableContext(1)]
		private void sr4_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.sr4 = this.sr4.IsOn;
				if (!this.sr4.IsOn)
				{
					Process.Start("cmd.exe", "/c \"bcdedit /set \"{globalsettings}\" advancedoptions false\"");
				}
				else
				{
					Process.Start("cmd.exe", "/c \"bcdedit /set \"{globalsettings}\" advancedoptions true\"");
				}
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000E694 File Offset: 0x0000C894
		[NullableContext(1)]
		private void sr5_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.sr5 = this.sr5.IsOn;
				if (!this.sr5.IsOn)
				{
					Process.Start("cmd.exe", "/k compact /compactos:never");
				}
				else
				{
					Process.Start("cmd.exe", "/k compact /compactos:always");
				}
				this.sr5.IsEnabled = false;
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000E708 File Offset: 0x0000C908
		[NullableContext(1)]
		private void sr6_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.sr6 = this.sr6.IsOn;
				if (!this.sr6.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\BitLocker").SetValue("PreventDeviceEncryption", 0, RegistryValueKind.DWord);
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\BitLocker").SetValue("PreventDeviceEncryption", 1, RegistryValueKind.DWord);
				}
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000E794 File Offset: 0x0000C994
		[NullableContext(1)]
		private void sfc_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("cmd.exe", "/k sfc /scannow");
			this.mw.RebootNotify(3);
			this.sfc.IsEnabled = false;
			Settings.Default.b3 = !this.sfc.IsEnabled;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000E7E8 File Offset: 0x0000C9E8
		[NullableContext(1)]
		private void dism_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("cmd.exe", "/C DISM /Online /Cleanup-Image /RestoreHealth");
			this.mw.RebootNotify(3);
			this.dism.IsEnabled = false;
			Settings.Default.b4 = !this.dism.IsEnabled;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000E839 File Offset: 0x0000CA39
		[NullableContext(1)]
		private void temp_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("cmd.exe", "/k del /q /f %temp%");
			this.temp.IsEnabled = false;
			Settings.Default.b6 = !this.temp.IsEnabled;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000E874 File Offset: 0x0000CA74
		[NullableContext(1)]
		private void t9_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.o9 = this.t9.IsOn;
				if (!this.t9.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager").SetValue("AutoChkTimeout", 8);
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager").SetValue("AutoChkTimeout", 60);
				}
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000E8FC File Offset: 0x0000CAFC
		private void LoadLang()
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "sr");
			Dictionary<string, Dictionary<string, string>> dictionary2 = MainWindow.Localization.LoadLocalization(language, "base");
			Dictionary<string, Dictionary<string, string>> dictionary3 = MainWindow.Localization.LoadLocalization(language, "compon");
			this.label.Text = dictionary["main"]["label"];
			this.l3.Text = dictionary["main"]["sr3l"];
			this.l4.Text = dictionary["main"]["sr4l"];
			this.l6.Text = dictionary["main"]["sr6l"];
			this.l9.Text = dictionary["main"]["sr13"];
			this.sfc.Content = dictionary["main"]["b2"];
			this.dism.Content = dictionary["main"]["b2"];
			this.temp.Content = dictionary["main"]["b4"];
			this.report.Content = dictionary["main"]["sr18"];
			this.sr1.Header = dictionary["main"]["sr1"];
			this.sr4.Header = dictionary["main"]["sr4"];
			this.sr5.Header = dictionary["main"]["sr5"];
			this.sr6.Header = dictionary["main"]["sr6"];
			this.t9.Header = dictionary["main"]["sr17"];
			this.t10.Header = dictionary["main"]["sr7"];
			this.t11.Header = dictionary["main"]["sr8"];
			this.t12.Header = dictionary["main"]["sr11"];
			this.t13.Header = dictionary["main"]["sr10"];
			this.t14.Header = dictionary["main"]["sr16"];
			this.t15.Header = dictionary["main"]["sr15"];
			this.t16.Header = dictionary["main"]["sr14"];
			this.t18.Header = dictionary["main"]["sr9"];
			this.st5.Header = dictionary["main"]["sr12"];
			this.sr1.OffContent = dictionary2["def"]["off"];
			this.sr4.OffContent = dictionary2["def"]["off"];
			this.sr5.OffContent = dictionary2["def"]["off"];
			this.sr6.OffContent = dictionary2["def"]["off"];
			this.t9.OffContent = dictionary2["def"]["off"];
			this.t10.OffContent = dictionary2["def"]["off"];
			this.t11.OffContent = dictionary2["def"]["off"];
			this.t12.OffContent = dictionary2["def"]["off"];
			this.t13.OffContent = dictionary2["def"]["off"];
			this.t14.OffContent = dictionary2["def"]["off"];
			this.t15.OffContent = dictionary2["def"]["off"];
			this.t16.OffContent = dictionary2["def"]["off"];
			this.t18.OffContent = dictionary2["def"]["off"];
			this.st5.OffContent = dictionary2["def"]["off"];
			this.sr1.OnContent = dictionary2["def"]["on"];
			this.sr4.OnContent = dictionary2["def"]["on"];
			this.sr5.OnContent = dictionary2["def"]["on"];
			this.sr6.OnContent = dictionary2["def"]["on"];
			this.t9.OnContent = dictionary2["def"]["on"];
			this.t10.OnContent = dictionary2["def"]["on"];
			this.t11.OnContent = dictionary2["def"]["on"];
			this.t12.OnContent = dictionary2["def"]["on"];
			this.t13.OnContent = dictionary2["def"]["on"];
			this.t14.OnContent = dictionary2["def"]["on"];
			this.t15.OnContent = dictionary2["def"]["on"];
			this.t16.OnContent = dictionary2["def"]["on"];
			this.t18.OnContent = dictionary2["def"]["on"];
			this.st5.OnContent = dictionary2["def"]["on"];
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000EFD8 File Offset: 0x0000D1D8
		private void checkReg()
		{
			ModernWpf.Controls.ToggleSwitch toggleSwitch = this.sr6;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\BitLocker");
			bool? flag;
			if (registryKey == null)
			{
				flag = null;
			}
			else
			{
				object value = registryKey.GetValue("PreventDeviceEncryption");
				flag = ((value != null) ? new bool?(value.Equals(1)) : null);
			}
			bool? flag2 = flag;
			toggleSwitch.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch2 = this.t9;
			RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager");
			bool? flag3;
			if (registryKey2 == null)
			{
				flag3 = null;
			}
			else
			{
				object value2 = registryKey2.GetValue("AutoChkTimeout");
				flag3 = ((value2 != null) ? new bool?(value2.Equals(60)) : null);
			}
			flag2 = flag3;
			toggleSwitch2.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch3 = this.t10;
			RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios");
			bool? flag4;
			if (registryKey3 == null)
			{
				flag4 = null;
			}
			else
			{
				object value3 = registryKey3.GetValue("HypervisorEnforcedCodeIntegrity");
				flag4 = ((value3 != null) ? new bool?(value3.Equals(0)) : null);
			}
			flag2 = flag4;
			toggleSwitch3.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch4 = this.t11;
			RegistryKey registryKey4 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Power");
			bool? flag5;
			if (registryKey4 == null)
			{
				flag5 = null;
			}
			else
			{
				object value4 = registryKey4.GetValue("HibernateEnabled");
				flag5 = ((value4 != null) ? new bool?(value4.Equals(0)) : null);
			}
			flag2 = flag5;
			toggleSwitch4.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch5 = this.t12;
			RegistryKey registryKey5 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management");
			string[] array = ((registryKey5 != null) ? registryKey5.GetValue("PagingFiles") : null) as string[];
			bool isOn;
			if (array == null)
			{
				isOn = true;
			}
			else
			{
				isOn = array.All((string s) => string.IsNullOrWhiteSpace(s));
			}
			toggleSwitch5.IsOn = isOn;
			ModernWpf.Controls.ToggleSwitch toggleSwitch6 = this.t14;
			RegistryKey registryKey6 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
			bool? flag6;
			if (registryKey6 == null)
			{
				flag6 = null;
			}
			else
			{
				object value5 = registryKey6.GetValue("EnableSmartScreen");
				flag6 = ((value5 != null) ? new bool?(value5.Equals(0)) : null);
			}
			flag2 = flag6;
			bool isOn2;
			if (!flag2.GetValueOrDefault())
			{
				RegistryKey registryKey7 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", true);
				bool? flag7;
				if (registryKey7 == null)
				{
					flag7 = null;
				}
				else
				{
					object value6 = registryKey7.GetValue("SmartScreenEnabled");
					flag7 = ((value6 != null) ? new bool?(value6.Equals("Off")) : null);
				}
				flag2 = flag7;
				isOn2 = flag2.GetValueOrDefault();
			}
			else
			{
				isOn2 = true;
			}
			toggleSwitch6.IsOn = isOn2;
			ModernWpf.Controls.ToggleSwitch toggleSwitch7 = this.t15;
			RegistryKey registryKey8 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
			bool? flag8;
			if (registryKey8 == null)
			{
				flag8 = null;
			}
			else
			{
				object value7 = registryKey8.GetValue("EnableLUA");
				flag8 = ((value7 != null) ? new bool?(value7.Equals(0)) : null);
			}
			flag2 = flag8;
			toggleSwitch7.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch8 = this.t16;
			RegistryKey registryKey9 = Registry.CurrentUser.OpenSubKey("Control Panel\\Accessibility\\StickyKeys", true);
			bool? flag9;
			if (registryKey9 == null)
			{
				flag9 = null;
			}
			else
			{
				object value8 = registryKey9.GetValue("Flags");
				flag9 = ((value8 != null) ? new bool?(value8.Equals("506")) : null);
			}
			flag2 = flag9;
			bool isOn3;
			if (!flag2.GetValueOrDefault())
			{
				RegistryKey registryKey10 = Registry.CurrentUser.OpenSubKey("Control Panel\\Accessibility\\ToggleKeys", true);
				bool? flag10;
				if (registryKey10 == null)
				{
					flag10 = null;
				}
				else
				{
					object value9 = registryKey10.GetValue("Flags");
					flag10 = ((value9 != null) ? new bool?(value9.Equals("58")) : null);
				}
				flag2 = flag10;
				if (!flag2.GetValueOrDefault())
				{
					RegistryKey registryKey11 = Registry.CurrentUser.OpenSubKey("Control Panel\\Accessibility\\Keyboard Response", true);
					bool? flag11;
					if (registryKey11 == null)
					{
						flag11 = null;
					}
					else
					{
						object value10 = registryKey11.GetValue("Flags");
						flag11 = ((value10 != null) ? new bool?(value10.Equals("122")) : null);
					}
					flag2 = flag11;
					isOn3 = flag2.GetValueOrDefault();
					goto IL_3D4;
				}
			}
			isOn3 = true;
			IL_3D4:
			toggleSwitch8.IsOn = isOn3;
			ModernWpf.Controls.ToggleSwitch toggleSwitch9 = this.t18;
			RegistryKey registryKey12 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard");
			bool? flag12;
			if (registryKey12 == null)
			{
				flag12 = null;
			}
			else
			{
				object value11 = registryKey12.GetValue("EnableVirtualizationBasedSecurity");
				flag12 = ((value11 != null) ? new bool?(value11.Equals(0)) : null);
			}
			flag2 = flag12;
			toggleSwitch9.IsOn = flag2.GetValueOrDefault();
			ModernWpf.Controls.ToggleSwitch toggleSwitch10 = this.st5;
			RegistryKey registryKey13 = Registry.CurrentUser.OpenSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer", true);
			bool? flag13;
			if (registryKey13 == null)
			{
				flag13 = null;
			}
			else
			{
				object value12 = registryKey13.GetValue("DisableSearchBoxSuggestions");
				flag13 = ((value12 != null) ? new bool?(value12.Equals(1)) : null);
			}
			flag2 = flag13;
			toggleSwitch10.IsOn = flag2.GetValueOrDefault();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000F478 File Offset: 0x0000D678
		[NullableContext(1)]
		private void t10_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				if (!this.t10.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios").SetValue("HypervisorEnforcedCodeIntegrity", 1);
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard\\Scenarios").SetValue("HypervisorEnforcedCodeIntegrity", 0);
				}
				this.mw.RebootNotify(1);
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000F4F8 File Offset: 0x0000D6F8
		[NullableContext(1)]
		private void t11_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				if (!this.t11.IsOn)
				{
					Process.Start("cmd.exe", "/C powercfg /h on");
				}
				else
				{
					Process.Start("cmd.exe", "/C powercfg /h off");
				}
				this.mw.RebootNotify(1);
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000F558 File Offset: 0x0000D758
		[NullableContext(1)]
		private void t12_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				if (!this.t12.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management").SetValue("PagingFiles", new string[]
					{
						"?:\\pagefile.sys"
					}, RegistryValueKind.MultiString);
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management").SetValue("PagingFiles", new string[0], RegistryValueKind.MultiString);
				}
				this.mw.RebootNotify(1);
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000F5E0 File Offset: 0x0000D7E0
		[NullableContext(1)]
		private void t13_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				if (!this.t13.IsOn)
				{
					Process.Start("cmd.exe", "/C powercfg -change -monitor-timeout-ac 10");
					Process.Start("cmd.exe", "/C powercfg -change -monitor-timeout-dc 5");
					Process.Start("cmd.exe", "/C powercfg -change -standby-timeout-ac 30");
					Process.Start("cmd.exe", "/C powercfg -change -standby-timeout-dc 15");
					Settings.Default.powercfgsl = false;
				}
				else
				{
					Process.Start("cmd.exe", "/C powercfg -change -monitor-timeout-ac 0");
					Process.Start("cmd.exe", "/C powercfg -change -monitor-timeout-dc 0");
					Process.Start("cmd.exe", "/C powercfg -change -standby-timeout-ac 0");
					Process.Start("cmd.exe", "/C powercfg -change -standby-timeout-dc 0");
					Settings.Default.powercfgsl = true;
				}
				Settings.Default.Save();
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000F6B8 File Offset: 0x0000D8B8
		[NullableContext(1)]
		private void t14_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				if (!this.t14.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System").SetValue("EnableSmartScreen", 1);
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer").SetValue("SmartScreenEnabled", "Warn", RegistryValueKind.String);
					Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments").SetValue("SaveZoneInformation", 0, RegistryValueKind.DWord);
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System").SetValue("EnableSmartScreen", 0);
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer").SetValue("SmartScreenEnabled", "Off", RegistryValueKind.String);
					Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments").SetValue("SaveZoneInformation", 1, RegistryValueKind.DWord);
				}
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000F7B0 File Offset: 0x0000D9B0
		[NullableContext(1)]
		private void t15_Toggled(object sender, RoutedEventArgs e)
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "sr");
			bool flag = this.isLoaded;
			if (flag)
			{
				bool flag2 = this.checkWinVer() >= 22621 && this.t15.IsOn;
				if (flag2)
				{
					DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(dictionary["status"]["uacwarn"], "MakuTweaker", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
					bool flag3 = dialogResult == DialogResult.No;
					if (flag3)
					{
						this.t15.IsOn = false;
						return;
					}
				}
				if (!this.t15.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System").SetValue("EnableLUA", 1);
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System").SetValue("EnableLUA", 0);
					RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Attachments");
					if (registryKey != null)
					{
						registryKey.SetValue("SaveZoneInformation", 1, RegistryValueKind.DWord);
					}
					RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Associations");
					if (registryKey2 != null)
					{
						registryKey2.SetValue("LowRiskFileTypes", ".exe;.msi;.bat;", RegistryValueKind.String);
					}
				}
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000F8F8 File Offset: 0x0000DAF8
		[NullableContext(1)]
		private void t16_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				if (!this.t16.IsOn)
				{
					Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\StickyKeys").SetValue("Flags", "510");
					Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\Keyboard Response").SetValue("Flags", "126");
					Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\ToggleKeys").SetValue("Flags", "62");
				}
				else
				{
					Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\StickyKeys").SetValue("Flags", "506");
					Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\Keyboard Response").SetValue("Flags", "122");
					Registry.CurrentUser.CreateSubKey("Control Panel\\Accessibility\\ToggleKeys").SetValue("Flags", "58");
				}
				this.mw.RebootNotify(1);
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000F9F4 File Offset: 0x0000DBF4
		[NullableContext(1)]
		private void report_Click(object sender, RoutedEventArgs e)
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "sr");
			Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
			saveFileDialog.Filter = "HTML (*.html)|*.html";
			saveFileDialog.Title = "Microsoft Battery Report";
			saveFileDialog.FileName = "battery-report.html";
			bool valueOrDefault = saveFileDialog.ShowDialog().GetValueOrDefault();
			if (valueOrDefault)
			{
				string fileName = saveFileDialog.FileName;
				try
				{
					Process.Start("cmd.exe", "/c powercfg /batteryreport /output \"" + fileName + "\"");
					this.mw.ChSt(dictionary["status"]["o1b"]);
				}
				catch
				{
				}
			}
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000FAC0 File Offset: 0x0000DCC0
		[NullableContext(1)]
		private void t18_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				if (!this.t18.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard").SetValue("EnableVirtualizationBasedSecurity", 1);
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\DeviceGuard").SetValue("EnableVirtualizationBasedSecurity", 0);
				}
				this.mw.RebootNotify(1);
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000FB40 File Offset: 0x0000DD40
		[NullableContext(1)]
		private void st5_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.st5 = this.st5.IsOn;
				if (!this.st5.IsOn)
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer").SetValue("DisableSearchBoxSuggestions", 0);
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						Registry.CurrentUser.CreateSubKey("Software\\Policies\\Microsoft\\Windows\\Explorer").SetValue("DisableSearchBoxSuggestions", 1);
					}
					catch
					{
					}
				}
			}
		}

		// Token: 0x04000121 RID: 289
		private bool isLoaded = false;

		// Token: 0x04000122 RID: 290
		[Nullable(1)]
		private MainWindow mw = (MainWindow)System.Windows.Application.Current.MainWindow;
	}
}
