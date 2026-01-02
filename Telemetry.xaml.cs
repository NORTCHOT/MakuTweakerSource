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
	// Token: 0x02000014 RID: 20
	public partial class Telemetry : System.Windows.Controls.Page
	{
		// Token: 0x060000FB RID: 251 RVA: 0x0000FFE4 File Offset: 0x0000E1E4
		public Telemetry()
		{
			this.InitializeComponent();
			this.checkReg();
			this.LoadLang();
			this.isLoaded = true;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00010040 File Offset: 0x0000E240
		[NullableContext(1)]
		private void t1_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.t1 = this.t1.IsOn;
				if (!this.t1.IsOn)
				{
					try
					{
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection").SetValue("AllowTelemetry", 1);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection").SetValue("AllowTelemetry", 1);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection").SetValue("MaxTelemetryAllowed", 1);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\CurrentVersion\\Software Protection Platform").SetValue("NoGenTicket", 0);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection").SetValue("DoNotShowFeedbackNotifications", 0);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat").SetValue("AITEnable", 1);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat").SetValue("AllowTelemetry", 1);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat").SetValue("DisableEngine", 0);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat").SetValue("DisableInventory", 0);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat").SetValue("DisablePCA", 0);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat").SetValue("DisableUAR", 0);
					}
					catch
					{
					}
					this.isNotify = false;
					bool flag2 = !this.isbycheck;
					if (flag2)
					{
						this.t2.IsOn = false;
						this.t3.IsOn = false;
						this.t4.IsOn = false;
						this.t5.IsOn = false;
						this.t6.IsOn = false;
						this.mw.RebootNotify(1);
					}
					this.isNotify = true;
				}
				else
				{
					try
					{
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection").SetValue("AllowTelemetry", 0);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection").SetValue("AllowTelemetry", 0);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection").SetValue("MaxTelemetryAllowed", 0);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\CurrentVersion\\Software Protection Platform").SetValue("NoGenTicket", 1);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection").SetValue("DoNotShowFeedbackNotifications", 1);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat").SetValue("AITEnable", 0);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat").SetValue("AllowTelemetry", 0);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat").SetValue("DisableEngine", 1);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat").SetValue("DisableInventory", 1);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat").SetValue("DisablePCA", 1);
						Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat").SetValue("DisableUAR", 1);
					}
					catch
					{
					}
					this.isNotify = false;
					bool flag3 = !this.isbycheck;
					if (flag3)
					{
						this.t2.IsOn = true;
						this.t3.IsOn = true;
						this.t4.IsOn = true;
						this.t5.IsOn = true;
						this.t6.IsOn = true;
						this.mw.RebootNotify(1);
					}
					this.isNotify = true;
				}
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00010470 File Offset: 0x0000E670
		[NullableContext(1)]
		private void t2_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.t2 = this.t2.IsOn;
				if (!this.t2.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appDiagnostics").SetValue("Value", "Allow", RegistryValueKind.String);
					this.isbycheck = true;
					this.t1.IsOn = false;
					this.isbycheck = false;
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appDiagnostics").SetValue("Value", "Deny", RegistryValueKind.String);
				}
				bool flag2 = this.isNotify;
				if (flag2)
				{
					this.mw.RebootNotify(1);
				}
				bool flag3 = this.t2.IsOn && this.t3.IsOn && this.t4.IsOn && this.t5.IsOn && this.t6.IsOn;
				if (flag3)
				{
					this.isbycheck = true;
					this.t1.IsOn = true;
					this.isbycheck = false;
				}
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00010594 File Offset: 0x0000E794
		[NullableContext(1)]
		private void t3_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.t3 = this.t3.IsOn;
				if (!this.t3.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System").SetValue("UploadUserActivities", 1);
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System").SetValue("PublishUserActivities", 1);
					this.isbycheck = true;
					this.t1.IsOn = false;
					this.isbycheck = false;
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System").SetValue("UploadUserActivities", 0);
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System").SetValue("PublishUserActivities", 0);
				}
				bool flag2 = this.isNotify;
				if (flag2)
				{
					this.mw.RebootNotify(1);
				}
				bool flag3 = this.t2.IsOn && this.t3.IsOn && this.t4.IsOn && this.t5.IsOn && this.t6.IsOn;
				if (flag3)
				{
					this.isbycheck = true;
					this.t1.IsOn = true;
					this.isbycheck = false;
				}
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x000106F8 File Offset: 0x0000E8F8
		[NullableContext(1)]
		private void t4_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.t4 = this.t4.IsOn;
				if (!this.t4.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WDI\\{9c5a40da-b965-4fc3-8781-88dd50a6299d}").SetValue("ScenarioExecutionEnabled", 1);
					this.isbycheck = true;
					this.t1.IsOn = false;
					this.isbycheck = false;
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WDI\\{9c5a40da-b965-4fc3-8781-88dd50a6299d}").SetValue("ScenarioExecutionEnabled", 0);
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\DeviceHealthAttestationService").SetValue("EnableDeviceHealthAttestationService", 0);
				}
				bool flag2 = this.isNotify;
				if (flag2)
				{
					this.mw.RebootNotify(1);
				}
				bool flag3 = this.t2.IsOn && this.t3.IsOn && this.t4.IsOn && this.t5.IsOn && this.t6.IsOn;
				if (flag3)
				{
					this.isbycheck = true;
					this.t1.IsOn = true;
					this.isbycheck = false;
				}
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0001083C File Offset: 0x0000EA3C
		[NullableContext(1)]
		private void t5_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.t5 = this.t5.IsOn;
				if (!this.t5.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\InputPersonalization").SetValue("RestrictImplicitTextCollection", 1);
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\InputPersonalization").SetValue("RestrictImplicitInkCollection", 1);
					this.isbycheck = true;
					this.t1.IsOn = false;
					this.isbycheck = false;
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\InputPersonalization").SetValue("RestrictImplicitTextCollection", 0);
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\InputPersonalization").SetValue("RestrictImplicitInkCollection", 0);
				}
				bool flag2 = this.isNotify;
				if (flag2)
				{
					this.mw.RebootNotify(1);
				}
				bool flag3 = this.t2.IsOn && this.t3.IsOn && this.t4.IsOn && this.t5.IsOn && this.t6.IsOn;
				if (flag3)
				{
					this.isbycheck = true;
					this.t1.IsOn = true;
					this.isbycheck = false;
				}
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x000109A0 File Offset: 0x0000EBA0
		[NullableContext(1)]
		private void t6_Toggled(object sender, RoutedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				Settings.Default.t6 = this.t6.IsOn;
				if (!this.t6.IsOn)
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Speech").SetValue("AllowSpeechModelUpdate", 1);
					this.isbycheck = true;
					this.t1.IsOn = false;
					this.isbycheck = false;
				}
				else
				{
					Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Speech").SetValue("AllowSpeechModelUpdate", 0);
				}
				bool flag2 = this.isNotify;
				if (flag2)
				{
					this.mw.RebootNotify(1);
				}
				bool flag3 = this.t2.IsOn && this.t3.IsOn && this.t4.IsOn && this.t5.IsOn && this.t6.IsOn;
				if (flag3)
				{
					this.isbycheck = true;
					this.t1.IsOn = true;
					this.isbycheck = false;
				}
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00010AC4 File Offset: 0x0000ECC4
		private void LoadLang()
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "tel");
			Dictionary<string, Dictionary<string, string>> dictionary2 = MainWindow.Localization.LoadLocalization(language, "base");
			this.label.Text = dictionary["main"]["label"];
			this.t1.Header = dictionary["main"]["t1"];
			this.t2.Header = dictionary["main"]["t2"];
			this.t3.Header = dictionary["main"]["t3"];
			this.t4.Header = dictionary["main"]["t4"];
			this.t5.Header = dictionary["main"]["t5"];
			this.t6.Header = dictionary["main"]["t6"];
			this.t1.OffContent = dictionary2["def"]["off"];
			this.t2.OffContent = dictionary2["def"]["off"];
			this.t3.OffContent = dictionary2["def"]["off"];
			this.t4.OffContent = dictionary2["def"]["off"];
			this.t5.OffContent = dictionary2["def"]["off"];
			this.t6.OffContent = dictionary2["def"]["off"];
			this.t1.OnContent = dictionary2["def"]["on"];
			this.t2.OnContent = dictionary2["def"]["on"];
			this.t3.OnContent = dictionary2["def"]["on"];
			this.t4.OnContent = dictionary2["def"]["on"];
			this.t5.OnContent = dictionary2["def"]["on"];
			this.t6.OnContent = dictionary2["def"]["on"];
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00010D74 File Offset: 0x0000EF74
		private void checkReg()
		{
			ToggleSwitch toggleSwitch = this.t1;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection");
			bool flag;
			if (registryKey == null)
			{
				flag = false;
			}
			else
			{
				object value = registryKey.GetValue("AllowTelemetry");
				flag = ((value != null) ? new bool?(value.Equals(0)) : null).GetValueOrDefault();
			}
			bool isOn;
			if (flag)
			{
				RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection");
				bool flag2;
				if (registryKey2 == null)
				{
					flag2 = false;
				}
				else
				{
					object value2 = registryKey2.GetValue("AllowTelemetry");
					flag2 = ((value2 != null) ? new bool?(value2.Equals(0)) : null).GetValueOrDefault();
				}
				if (flag2)
				{
					RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\DataCollection");
					bool flag3;
					if (registryKey3 == null)
					{
						flag3 = false;
					}
					else
					{
						object value3 = registryKey3.GetValue("MaxTelemetryAllowed");
						flag3 = ((value3 != null) ? new bool?(value3.Equals(0)) : null).GetValueOrDefault();
					}
					if (flag3)
					{
						RegistryKey registryKey4 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows NT\\CurrentVersion\\Software Protection Platform");
						if (registryKey4 == null)
						{
							isOn = false;
						}
						else
						{
							object value4 = registryKey4.GetValue("NoGenTicket");
							isOn = ((value4 != null) ? new bool?(value4.Equals(1)) : null).GetValueOrDefault();
						}
						goto IL_132;
					}
				}
			}
			isOn = false;
			IL_132:
			toggleSwitch.IsOn = isOn;
			ToggleSwitch toggleSwitch2 = this.t2;
			RegistryKey registryKey5 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\CapabilityAccessManager\\ConsentStore\\appDiagnostics");
			string a;
			if (registryKey5 == null)
			{
				a = null;
			}
			else
			{
				object value5 = registryKey5.GetValue("Value");
				a = ((value5 != null) ? value5.ToString() : null);
			}
			toggleSwitch2.IsOn = (a == "Deny");
			ToggleSwitch toggleSwitch3 = this.t3;
			RegistryKey registryKey6 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System");
			bool flag4;
			if (registryKey6 == null)
			{
				flag4 = false;
			}
			else
			{
				object value6 = registryKey6.GetValue("UploadUserActivities");
				flag4 = ((value6 != null) ? new bool?(value6.Equals(0)) : null).GetValueOrDefault();
			}
			bool isOn2;
			if (!flag4)
			{
				RegistryKey registryKey7 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\System");
				if (registryKey7 == null)
				{
					isOn2 = false;
				}
				else
				{
					object value7 = registryKey7.GetValue("PublishUserActivities");
					isOn2 = ((value7 != null) ? new bool?(value7.Equals(0)) : null).GetValueOrDefault();
				}
			}
			else
			{
				isOn2 = true;
			}
			toggleSwitch3.IsOn = isOn2;
			ToggleSwitch toggleSwitch4 = this.t4;
			RegistryKey registryKey8 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\WDI\\{9c5a40da-b965-4fc3-8781-88dd50a6299d}");
			bool flag5;
			if (registryKey8 == null)
			{
				flag5 = false;
			}
			else
			{
				object value8 = registryKey8.GetValue("ScenarioExecutionEnabled");
				flag5 = ((value8 != null) ? new bool?(value8.Equals(0)) : null).GetValueOrDefault();
			}
			bool isOn3;
			if (flag5)
			{
				RegistryKey registryKey9 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\DeviceHealthAttestationService");
				if (registryKey9 == null)
				{
					isOn3 = false;
				}
				else
				{
					object value9 = registryKey9.GetValue("EnableDeviceHealthAttestationService");
					isOn3 = ((value9 != null) ? new bool?(value9.Equals(0)) : null).GetValueOrDefault();
				}
			}
			else
			{
				isOn3 = false;
			}
			toggleSwitch4.IsOn = isOn3;
			ToggleSwitch toggleSwitch5 = this.t5;
			RegistryKey registryKey10 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\InputPersonalization");
			bool flag6;
			if (registryKey10 == null)
			{
				flag6 = false;
			}
			else
			{
				object value10 = registryKey10.GetValue("RestrictImplicitTextCollection");
				flag6 = ((value10 != null) ? new bool?(value10.Equals(0)) : null).GetValueOrDefault();
			}
			bool isOn4;
			if (!flag6)
			{
				RegistryKey registryKey11 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\InputPersonalization");
				if (registryKey11 == null)
				{
					isOn4 = false;
				}
				else
				{
					object value11 = registryKey11.GetValue("RestrictImplicitInkCollection");
					isOn4 = ((value11 != null) ? new bool?(value11.Equals(0)) : null).GetValueOrDefault();
				}
			}
			else
			{
				isOn4 = true;
			}
			toggleSwitch5.IsOn = isOn4;
			ToggleSwitch toggleSwitch6 = this.t6;
			RegistryKey registryKey12 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Speech");
			bool isOn5;
			if (registryKey12 == null)
			{
				isOn5 = false;
			}
			else
			{
				object value12 = registryKey12.GetValue("AllowSpeechModelUpdate");
				isOn5 = ((value12 != null) ? new bool?(value12.Equals(0)) : null).GetValueOrDefault();
			}
			toggleSwitch6.IsOn = isOn5;
			bool isOn6 = this.t1.IsOn;
			if (isOn6)
			{
				this.t2.IsOn = true;
				this.t3.IsOn = true;
				this.t4.IsOn = true;
				this.t5.IsOn = true;
				this.t6.IsOn = true;
			}
		}

		// Token: 0x0400013B RID: 315
		private bool isLoaded = false;

		// Token: 0x0400013C RID: 316
		private bool isNotify = true;

		// Token: 0x0400013D RID: 317
		private bool isbycheck = false;

		// Token: 0x0400013E RID: 318
		[Nullable(1)]
		private MainWindow mw = (MainWindow)Application.Current.MainWindow;
	}
}
