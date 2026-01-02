using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MakuTweakerNew.Properties;
using MicaWPF.Controls;
using Microsoft.Win32;

namespace MakuTweakerNew
{
	// Token: 0x02000016 RID: 22
	public partial class WindowsComponents : Page
	{
		// Token: 0x0600011E RID: 286 RVA: 0x00012C70 File Offset: 0x00010E70
		public WindowsComponents()
		{
			this.InitializeComponent();
			bool flag = this.checkWinEd() == "Core" || this.checkWinEd() == "CoreSingleLanguage" || this.checkWinEd() == "CoreCountrySpecific" || this.checkWinEd() == "CoreN";
			if (flag)
			{
				this.sr8L.Visibility = Visibility.Visible;
				this.lgp.Visibility = Visibility.Visible;
			}
			this.dp.IsEnabled = !Settings.Default.b1;
			this.dnet.IsEnabled = !Settings.Default.b2;
			this.sxs.IsEnabled = !Settings.Default.b5;
			this.pv.IsEnabled = !Settings.Default.b10;
			this.lgp.IsEnabled = !Settings.Default.b8;
			this.pwsh.IsEnabled = !Settings.Default.pwsh;
			this.LoadLang(Settings.Default.lang);
			this.isLoaded = true;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00012DC0 File Offset: 0x00010FC0
		[NullableContext(1)]
		private string checkWinEd()
		{
			string name = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			string name2 = "EditionID";
			string result;
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name))
			{
				object value = registryKey.GetValue(name2);
				result = value.ToString();
			}
			return result;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00012E18 File Offset: 0x00011018
		[NullableContext(1)]
		private void LoadLang(string lang)
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "base");
			Dictionary<string, Dictionary<string, string>> dictionary2 = MainWindow.Localization.LoadLocalization(language, "compon");
			Dictionary<string, Dictionary<string, string>> dictionary3 = MainWindow.Localization.LoadLocalization(language, "sr");
			Dictionary<string, Dictionary<string, string>> dictionary4 = MainWindow.Localization.LoadLocalization(language, "oth");
			this.label.Text = dictionary2["main"]["label"];
			this.l1.Text = dictionary2["main"]["cm1"];
			this.l2.Text = dictionary2["main"]["cm2"];
			this.l3.Text = dictionary2["main"]["cm3"];
			this.l4.Text = dictionary2["main"]["cm4"];
			this.l5.Text = dictionary2["main"]["cm5"];
			this.l6.Text = dictionary2["main"]["cm6"];
			this.l7.Text = dictionary2["main"]["cm7"];
			this.sr8L.Text = dictionary3["main"]["sr8l"];
			this.dp.Content = dictionary3["main"]["b1"];
			this.dnet.Content = dictionary3["main"]["b1"];
			this.sxs.Content = dictionary3["main"]["b3"];
			this.lgp.Content = dictionary3["main"]["b5"];
			this.dvr.Content = dictionary3["main"]["b6"];
			this.pv.Content = dictionary4["main"]["o11b"];
			this.pwsh.Content = dictionary4["main"]["o11b"];
			this.hypervdis.Content = dictionary3["main"]["b6"];
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000130A0 File Offset: 0x000112A0
		[NullableContext(1)]
		private void pwsh_Click(object sender, RoutedEventArgs e)
		{
			Process.Start(new ProcessStartInfo("powershell", "-Command Set-ExecutionPolicy RemoteSigned -Force")
			{
				CreateNoWindow = true,
				UseShellExecute = false
			});
			this.pwsh.IsEnabled = false;
			Settings.Default.pwsh = !this.pwsh.IsEnabled;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000130F9 File Offset: 0x000112F9
		[NullableContext(1)]
		private void dp_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("cmd.exe", "/C dism /online /Enable-Feature /FeatureName:DirectPlay /All");
			this.dp.IsEnabled = false;
			Settings.Default.b1 = !this.dp.IsEnabled;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00013132 File Offset: 0x00011332
		[NullableContext(1)]
		private void dnet_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("powershell.exe", "/C Add-WindowsCapability -Online -Name NetFx3~~~~\"");
			this.dnet.IsEnabled = false;
			Settings.Default.b2 = !this.dnet.IsEnabled;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0001316C File Offset: 0x0001136C
		[NullableContext(1)]
		private void sxs_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("cmd.exe", "/C dism /Online /Cleanup-Image /StartComponentCleanup /ResetBase");
			this.mw.RebootNotify(3);
			this.sxs.IsEnabled = false;
			Settings.Default.b5 = !this.sxs.IsEnabled;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000131C0 File Offset: 0x000113C0
		[NullableContext(1)]
		private void lgp_Click(object sender, RoutedEventArgs e)
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "sr");
			string contents = "\r\n            pushd \"%~dp0\"\r\n\r\n            dir /b %SystemRoot%\\servicing\\Packages\\Microsoft-Windows-GroupPolicy-ClientExtensions-Package~3*.mum >List.txt \r\n            dir /b %SystemRoot%\\servicing\\Packages\\Microsoft-Windows-GroupPolicy-ClientTools-Package~3*.mum >>List.txt \r\n\r\n            for /f %%i in ('findstr /i . List.txt 2^>nul') do dism /online /norestart /add-package:\"%SystemRoot%\\servicing\\Packages\\%%i\"";
			string text = Path.Combine(Path.GetTempPath(), "script.bat");
			File.WriteAllText(text, contents);
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c \"" + text + "\"";
			process.StartInfo.UseShellExecute = true;
			process.StartInfo.CreateNoWindow = false;
			this.mw.ChSt(dictionary["status"]["sr8"]);
			try
			{
				process.Start();
			}
			catch
			{
			}
			this.lgp.IsEnabled = false;
			Settings.Default.b8 = !this.lgp.IsEnabled;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000132C8 File Offset: 0x000114C8
		[NullableContext(1)]
		private void pv_Click(object sender, RoutedEventArgs e)
		{
			string text = Settings.Default.lang ?? "en";
			try
			{
				using (RegistryKey registryKey = Registry.ClassesRoot.CreateSubKey("Applications\\photoviewer.dll\\shell\\open"))
				{
					registryKey.SetValue("MuiVerb", "@photoviewer.dll,-3043");
				}
				using (RegistryKey registryKey2 = Registry.ClassesRoot.CreateSubKey("Applications\\photoviewer.dll\\shell\\open\\command"))
				{
					registryKey2.SetValue("", "%SystemRoot%\\System32\\rundll32.exe \"%ProgramFiles%\\Windows Photo Viewer\\PhotoViewer.dll\", ImageViewer_Fullscreen %1", RegistryValueKind.String);
				}
				using (RegistryKey registryKey3 = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows Photo Viewer\\Capabilities\\FileAssociations"))
				{
					registryKey3.SetValue(".bmp", "PhotoViewer.FileAssoc.Tiff");
					registryKey3.SetValue(".gif", "PhotoViewer.FileAssoc.Tiff");
					registryKey3.SetValue(".jpeg", "PhotoViewer.FileAssoc.Tiff");
					registryKey3.SetValue(".jpg", "PhotoViewer.FileAssoc.Tiff");
					registryKey3.SetValue(".png", "PhotoViewer.FileAssoc.Tiff");
				}
				this.pv.IsEnabled = false;
				Settings.Default.b10 = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка: " + ex.Message);
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00013430 File Offset: 0x00011630
		[NullableContext(1)]
		private void dvr_Click(object sender, RoutedEventArgs e)
		{
			Registry.CurrentUser.CreateSubKey("System\\GameConfigStore").SetValue("GameDVR_Enabled", 0, RegistryValueKind.DWord);
			Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\GameDVR").SetValue("AllowGameDVR", 0, RegistryValueKind.DWord);
			this.dvr.IsEnabled = false;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0001348D File Offset: 0x0001168D
		[NullableContext(1)]
		private void hypervdis_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("cmd.exe", "/c \"bcdedit /set hypervisorlaunchtype off\"");
			this.hypervdis.IsEnabled = false;
		}

		// Token: 0x04000173 RID: 371
		private bool isLoaded = false;

		// Token: 0x04000174 RID: 372
		[Nullable(1)]
		private MainWindow mw = (MainWindow)Application.Current.MainWindow;
	}
}
