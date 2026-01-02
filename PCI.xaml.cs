using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using MakuTweakerNew.Properties;
using Microsoft.Win32;

namespace MakuTweakerNew
{
	// Token: 0x0200000A RID: 10
	public partial class PCI : Page
	{
		// Token: 0x0600007A RID: 122 RVA: 0x0000894C File Offset: 0x00006B4C
		public PCI()
		{
			Environment.SetEnvironmentVariable("LHM_NO_RING0", "1");
			this.InitializeComponent();
			base.PreviewKeyDown += this.PCI_PreviewKeyDown;
			this.LoadLang();
			this.ShowRamInfo();
			this.ShowCpuInfo();
			this.ShowCpuExtraInfo();
			this.ShowMotherboardInfo();
			this.LoadGpuList();
			this.LoadStorageList();
			this.isLoaded = true;
		}

		// Token: 0x0600007B RID: 123
		[DllImport("user32.dll")]
		private static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

		// Token: 0x0600007C RID: 124
		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowDC(IntPtr hWnd);

		// Token: 0x0600007D RID: 125
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x0600007E RID: 126
		[DllImport("user32.dll")]
		private static extern bool GetWindowRect(IntPtr hWnd, out PCI.RECT lpRect);

		// Token: 0x0600007F RID: 127 RVA: 0x00008A04 File Offset: 0x00006C04
		[NullableContext(1)]
		private void PCI_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.Key == Key.F5;
			if (flag)
			{
				this.SaveDataToTxt();
			}
			bool flag2 = (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && e.Key == Key.S;
			if (flag2)
			{
				this.SaveDataToTxt();
				e.Handled = true;
			}
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00008A60 File Offset: 0x00006C60
		[NullableContext(1)]
		[DebuggerStepThrough]
		private Task RunBenchmarkAsync(bool runMultithreadedByDefault)
		{
			PCI.<RunBenchmarkAsync>d__13 <RunBenchmarkAsync>d__ = new PCI.<RunBenchmarkAsync>d__13();
			<RunBenchmarkAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<RunBenchmarkAsync>d__.<>4__this = this;
			<RunBenchmarkAsync>d__.runMultithreadedByDefault = runMultithreadedByDefault;
			<RunBenchmarkAsync>d__.<>1__state = -1;
			<RunBenchmarkAsync>d__.<>t__builder.Start<PCI.<RunBenchmarkAsync>d__13>(ref <RunBenchmarkAsync>d__);
			return <RunBenchmarkAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00008AAC File Offset: 0x00006CAC
		[NullableContext(1)]
		[DebuggerStepThrough]
		private void singleBench_Click(object sender, RoutedEventArgs e)
		{
			PCI.<singleBench_Click>d__14 <singleBench_Click>d__ = new PCI.<singleBench_Click>d__14();
			<singleBench_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<singleBench_Click>d__.<>4__this = this;
			<singleBench_Click>d__.sender = sender;
			<singleBench_Click>d__.e = e;
			<singleBench_Click>d__.<>1__state = -1;
			<singleBench_Click>d__.<>t__builder.Start<PCI.<singleBench_Click>d__14>(ref <singleBench_Click>d__);
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00008AF4 File Offset: 0x00006CF4
		[NullableContext(1)]
		[DebuggerStepThrough]
		private void multiBench_Click(object sender, RoutedEventArgs e)
		{
			PCI.<multiBench_Click>d__15 <multiBench_Click>d__ = new PCI.<multiBench_Click>d__15();
			<multiBench_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<multiBench_Click>d__.<>4__this = this;
			<multiBench_Click>d__.sender = sender;
			<multiBench_Click>d__.e = e;
			<multiBench_Click>d__.<>1__state = -1;
			<multiBench_Click>d__.<>t__builder.Start<PCI.<multiBench_Click>d__15>(ref <multiBench_Click>d__);
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00008B3C File Offset: 0x00006D3C
		[NullableContext(1)]
		public double GetGpuPowerUsageFallback(string gpuName)
		{
			double result;
			try
			{
				bool flag = gpuName.Contains("NVIDIA", StringComparison.OrdinalIgnoreCase);
				if (flag)
				{
					double num = PCI.NvmlWrapper.TryGetGpuPowerWatts(0);
					bool flag2 = num > 0.0;
					if (flag2)
					{
						return num;
					}
				}
				result = this.GetGpuEstimatedTdp(gpuName);
			}
			catch (Exception ex)
			{
				result = 0.0;
			}
			return result;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00008BA4 File Offset: 0x00006DA4
		[NullableContext(1)]
		private double GetGpuEstimatedTdp(string name)
		{
			bool flag = name.Contains("3050");
			double result;
			if (flag)
			{
				result = 115.0;
			}
			else
			{
				bool flag2 = name.Contains("3060");
				if (flag2)
				{
					result = 170.0;
				}
				else
				{
					bool flag3 = name.Contains("3070");
					if (flag3)
					{
						result = 220.0;
					}
					else
					{
						bool flag4 = name.Contains("3080");
						if (flag4)
						{
							result = 320.0;
						}
						else
						{
							bool flag5 = name.Contains("1030");
							if (flag5)
							{
								result = 30.0;
							}
							else
							{
								bool flag6 = name.Contains("A770");
								if (flag6)
								{
									result = 225.0;
								}
								else
								{
									result = 100.0;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00008C6A File Offset: 0x00006E6A
		[NullableContext(1)]
		private void PCI_Unloaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00008C70 File Offset: 0x00006E70
		[NullableContext(1)]
		private void DeleteDriverFile(string fileName)
		{
			try
			{
				string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
				bool flag = File.Exists(path);
				if (flag)
				{
					File.Delete(path);
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00008CBC File Offset: 0x00006EBC
		private void LoadLang()
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "pci");
			this.label.Text = dictionary["main"]["label"];
			this.labelcpu.Text = dictionary["main"]["processorlabel"];
			this.cpul.Text = dictionary["main"]["processorname"];
			this.cpucorel.Text = dictionary["main"]["processorcores"];
			this.threadsl.Text = dictionary["main"]["processorthr"];
			this.corespeedl.Text = dictionary["main"]["processorfreq"];
			this.l3cashl.Text = dictionary["main"]["processorcache"];
			this.labelRAM.Text = dictionary["main"]["ramlabel"];
			this.raml.Text = dictionary["main"]["ramtotal"];
			this.ddrl.Text = dictionary["main"]["ramddr"];
			this.freql.Text = dictionary["main"]["ramfreq"];
			this.MOTHERBOARD.Text = dictionary["main"]["mblabel"];
			this.mbnamel.Text = dictionary["main"]["mbname"];
			this.biosverl.Text = dictionary["main"]["mbver"];
			this.biosdatel.Text = dictionary["main"]["mbdate"];
			this.video.Text = dictionary["main"]["vlabel"];
			this.videol.Text = dictionary["main"]["vname"];
			this.vraml.Text = dictionary["main"]["vmem"];
			this.ssdLabel.Text = dictionary["main"]["ssdl"];
			this.ssdnLabel.Text = dictionary["main"]["sname"];
			this.ssdcLabel.Text = dictionary["main"]["smem"];
			this.benchmarkLabel.Text = dictionary["main"]["benchtitle"];
			this.singleBench.Content = dictionary["main"]["benchbutton"];
			this.multiBench.Content = dictionary["main"]["benchbutton2"];
			this.benchmarkResultText.Text = dictionary["main"]["benchtip"] + "\n";
			this.lookresults.Content = dictionary["main"]["lookresulbutton"];
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00009050 File Offset: 0x00007250
		private void ShowCpuInfo()
		{
			try
			{
				string text = "Unknown";
				int num = 0;
				int num2 = 0;
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select Name, NumberOfCores, NumberOfLogicalProcessors from Win32_Processor"))
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						object obj = managementBaseObject["Name"];
						string text2;
						if (obj == null)
						{
							text2 = null;
						}
						else
						{
							string text3 = obj.ToString();
							text2 = ((text3 != null) ? text3.Trim() : null);
						}
						text = (text2 ?? text);
						num += Convert.ToInt32(managementBaseObject["NumberOfCores"]);
						num2 += Convert.ToInt32(managementBaseObject["NumberOfLogicalProcessors"]);
					}
				}
				this.cpue.Text = (text ?? "");
				TextBlock textBlock = this.cpucore;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				textBlock.Text = defaultInterpolatedStringHandler.ToStringAndClear();
				TextBlock textBlock2 = this.threads;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				textBlock2.Text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			catch (Exception ex)
			{
				this.cpue.Text = (ex.Message ?? "");
				this.cpucore.Text = "N/A";
				this.threads.Text = "N/A";
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000091FC File Offset: 0x000073FC
		private void ShowCpuExtraInfo()
		{
			try
			{
				int num = 0;
				int num2 = 0;
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select MaxClockSpeed, L3CacheSize from Win32_Processor"))
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						num = Convert.ToInt32(managementBaseObject["MaxClockSpeed"]);
						num2 += Convert.ToInt32(managementBaseObject["L3CacheSize"]);
					}
				}
				double value = Math.Round((double)num2 / 1024.0, 1);
				double value2 = Math.Round((double)num / 1000.0, 2);
				TextBlock textBlock = this.corespeed;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendFormatted<double>(value2);
				defaultInterpolatedStringHandler.AppendLiteral(" GHz");
				textBlock.Text = defaultInterpolatedStringHandler.ToStringAndClear();
				TextBlock textBlock2 = this.l3cash;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
				defaultInterpolatedStringHandler.AppendFormatted<double>(value);
				defaultInterpolatedStringHandler.AppendLiteral(" MB");
				textBlock2.Text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			catch (Exception ex)
			{
				this.corespeed.Text = (ex.Message ?? "");
				this.l3cash.Text = "N/A";
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00009394 File Offset: 0x00007594
		private void ShowRamInfo()
		{
			try
			{
				double num = 0.0;
				int num2 = 0;
				int num3 = 0;
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT Capacity, MemoryType, SMBIOSMemoryType, Speed FROM Win32_PhysicalMemory"))
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						bool flag = managementBaseObject["Capacity"] != null;
						if (flag)
						{
							num += Convert.ToDouble(managementBaseObject["Capacity"]) / 1073741824.0;
						}
						bool flag2 = managementBaseObject["SMBIOSMemoryType"] != null;
						if (flag2)
						{
							num2 = Convert.ToInt32(managementBaseObject["SMBIOSMemoryType"]);
						}
						bool flag3 = managementBaseObject["Speed"] != null;
						if (flag3)
						{
							num3 = Convert.ToInt32(managementBaseObject["Speed"]);
						}
					}
				}
				if (!true)
				{
				}
				string text;
				switch (num2)
				{
				case 20:
					text = "DDR";
					goto IL_1BE;
				case 21:
					text = "DDR2";
					goto IL_1BE;
				case 22:
					text = "DDR2 FB-DIMM";
					goto IL_1BE;
				case 24:
					text = "DDR3";
					goto IL_1BE;
				case 26:
					text = "DDR4";
					goto IL_1BE;
				case 27:
					text = "LPDDR";
					goto IL_1BE;
				case 28:
					text = "LPDDR2";
					goto IL_1BE;
				case 29:
					text = "LPDDR3";
					goto IL_1BE;
				case 30:
					text = "LPDDR4";
					goto IL_1BE;
				case 31:
					text = "DDR5";
					goto IL_1BE;
				case 32:
					text = "LPDDR5";
					goto IL_1BE;
				case 33:
					text = "LPDDR5X";
					goto IL_1BE;
				case 34:
					text = "LPDDR5";
					goto IL_1BE;
				case 35:
					text = "LPDDR5X";
					goto IL_1BE;
				}
				text = "Unknown";
				IL_1BE:
				if (!true)
				{
				}
				string text2 = text;
				int num4 = num3;
				bool flag4 = text2.StartsWith("LPDDR5") && num3 > 7000;
				if (flag4)
				{
					num4 = 6400;
				}
				else
				{
					bool flag5 = text2.Contains("DDR4") && num3 > 4000;
					if (flag5)
					{
						num4 /= 2;
					}
					else
					{
						bool flag6 = text2.Contains("DDR3") && num3 > 3000;
						if (flag6)
						{
							num4 /= 2;
						}
					}
				}
				bool flag7 = text2 == "Unknown" && num3 > 7000;
				if (flag7)
				{
					num4 = (int)Math.Round((double)num3 * 0.75);
				}
				TextBlock textBlock = this.rama;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
				defaultInterpolatedStringHandler.AppendFormatted<double>(Math.Round(num, 1));
				defaultInterpolatedStringHandler.AppendLiteral(" GB");
				textBlock.Text = defaultInterpolatedStringHandler.ToStringAndClear();
				this.ddre.Text = text2;
				TextBlock textBlock2 = this.freq;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num4);
				defaultInterpolatedStringHandler.AppendLiteral(" MHz");
				textBlock2.Text = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			catch (Exception ex)
			{
				this.rama.Text = "Unknown: " + ex.Message;
				this.ddre.Text = "N/A";
				this.freq.Text = "N/A";
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00009718 File Offset: 0x00007918
		private void ShowMotherboardInfo()
		{
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT Product, Manufacturer FROM Win32_BaseBoard"))
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						object obj = managementBaseObject["Product"];
						string str = ((obj != null) ? obj.ToString() : null) ?? "Unknown";
						object obj2 = managementBaseObject["Manufacturer"];
						string str2 = ((obj2 != null) ? obj2.ToString() : null) ?? "Unknown";
						this.mbname.Text = str2 + " " + str;
					}
				}
				using (ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("SELECT SMBIOSBIOSVersion, ReleaseDate FROM Win32_BIOS"))
				{
					foreach (ManagementBaseObject managementBaseObject2 in managementObjectSearcher2.Get())
					{
						object obj3 = managementBaseObject2["SMBIOSBIOSVersion"];
						string text = ((obj3 != null) ? obj3.ToString() : null) ?? "Unknown";
						object obj4 = managementBaseObject2["ReleaseDate"];
						string text2 = ((obj4 != null) ? obj4.ToString() : null) ?? "";
						string text3 = "Unknown";
						bool flag = !string.IsNullOrEmpty(text2) && text2.Length >= 8;
						if (flag)
						{
							string value = text2.Substring(0, 4);
							string value2 = text2.Substring(4, 2);
							string value3 = text2.Substring(6, 2);
							DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
							defaultInterpolatedStringHandler.AppendFormatted(value3);
							defaultInterpolatedStringHandler.AppendLiteral(".");
							defaultInterpolatedStringHandler.AppendFormatted(value2);
							defaultInterpolatedStringHandler.AppendLiteral(".");
							defaultInterpolatedStringHandler.AppendFormatted(value);
							text3 = defaultInterpolatedStringHandler.ToStringAndClear();
						}
						this.biosver.Text = text;
						this.biosdate.Text = text3;
					}
				}
			}
			catch (Exception ex)
			{
				this.mbname.Text = (ex.Message ?? "");
				this.biosver.Text = "N/A";
				this.biosdate.Text = "N/A";
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000099DC File Offset: 0x00007BDC
		private void LoadStorageList()
		{
			try
			{
				this._storageDevices = StorageHelper.GetAllStorageDevices();
				this.ssdComboBox.Items.Clear();
				bool flag = this._storageDevices.Count == 0;
				if (flag)
				{
					this.ssdnValue.Text = "N/A";
					this.ssdcValue.Text = "N/A";
				}
				else
				{
					for (int i = 0; i < this._storageDevices.Count; i++)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
						string text;
						if (string.IsNullOrWhiteSpace(this._storageDevices[i].Name))
						{
							defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
							defaultInterpolatedStringHandler.AppendLiteral("Drive #");
							defaultInterpolatedStringHandler.AppendFormatted<int>(i + 1);
							text = defaultInterpolatedStringHandler.ToStringAndClear();
						}
						else
						{
							text = this._storageDevices[i].Name;
						}
						string value = text;
						ItemCollection items = this.ssdComboBox.Items;
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
						defaultInterpolatedStringHandler.AppendFormatted<int>(i + 1);
						defaultInterpolatedStringHandler.AppendLiteral(". ");
						defaultInterpolatedStringHandler.AppendFormatted(value);
						items.Add(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					this.ssdComboBox.SelectedIndex = 0;
					this.UpdateStorageInfo(0);
				}
			}
			catch (Exception ex)
			{
				this.ssdnValue.Text = "N/A";
				this.ssdcValue.Text = "N/A";
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00009B58 File Offset: 0x00007D58
		[NullableContext(1)]
		private void SSDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			bool flag = this.ssdComboBox.SelectedIndex >= 0;
			if (flag)
			{
				this.UpdateStorageInfo(this.ssdComboBox.SelectedIndex);
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00009B90 File Offset: 0x00007D90
		private void UpdateStorageInfo(int index)
		{
			bool flag = index < 0 || index >= this._storageDevices.Count;
			if (!flag)
			{
				StorageInfo storageInfo = this._storageDevices[index];
				this.ssdnValue.Text = storageInfo.Name;
				this.ssdcValue.Text = storageInfo.CapacityFormatted;
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00009BF0 File Offset: 0x00007DF0
		private void LoadGpuList()
		{
			try
			{
				this._gpus = GpuHelper.GetAllGpus();
				this.videoComboBox.Items.Clear();
				bool flag = this._gpus.Count == 0;
				if (flag)
				{
					this.videon.Text = "N/A";
					this.vram.Text = "N/A";
				}
				else
				{
					for (int i = 0; i < this._gpus.Count; i++)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
						string text;
						if (string.IsNullOrWhiteSpace(this._gpus[i].Name))
						{
							defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 1);
							defaultInterpolatedStringHandler.AppendLiteral("GPU #");
							defaultInterpolatedStringHandler.AppendFormatted<int>(i + 1);
							text = defaultInterpolatedStringHandler.ToStringAndClear();
						}
						else
						{
							text = this._gpus[i].Name;
						}
						string value = text;
						ItemCollection items = this.videoComboBox.Items;
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
						defaultInterpolatedStringHandler.AppendFormatted<int>(i + 1);
						defaultInterpolatedStringHandler.AppendLiteral(". ");
						defaultInterpolatedStringHandler.AppendFormatted(value);
						items.Add(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					this.videoComboBox.SelectedIndex = 0;
					this.UpdateGpuInfo(0);
				}
			}
			catch (Exception ex)
			{
				this.videon.Text = "N/A";
				this.vram.Text = "N/A";
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00009D6C File Offset: 0x00007F6C
		[NullableContext(1)]
		private void VideoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			bool flag = this.videoComboBox.SelectedIndex >= 0;
			if (flag)
			{
				this.UpdateGpuInfo(this.videoComboBox.SelectedIndex);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00009DA4 File Offset: 0x00007FA4
		private void UpdateGpuInfo(int index)
		{
			bool flag = index < 0 || index >= this._gpus.Count;
			if (!flag)
			{
				GpuInfo gpuInfo = this._gpus[index];
				this.videon.Text = gpuInfo.Name;
				this.vram.Text = gpuInfo.VRamFormatted;
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00009E04 File Offset: 0x00008004
		[NullableContext(1)]
		private void LookResults_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "https://adderly.top/makubench",
					UseShellExecute = true
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show("Default Browser Error. MT 0x001", "MakuTweaker", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00009E60 File Offset: 0x00008060
		private void SaveDataToTxt()
		{
			try
			{
				Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(Settings.Default.lang ?? "en", "pci");
				SaveFileDialog saveFileDialog = new SaveFileDialog
				{
					Filter = "TXT File| *.txt",
					Title = "MakuTweaker",
					FileName = "MakuTweaker System Info.txt"
				};
				bool valueOrDefault = saveFileDialog.ShowDialog().GetValueOrDefault();
				if (valueOrDefault)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendLine("MakuTweaker // MarkAdderly");
					stringBuilder.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
					stringBuilder.AppendLine();
					stringBuilder.AppendLine();
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder3 = stringBuilder2;
					StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("=== ");
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["processorlabel"]);
					appendInterpolatedStringHandler.AppendLiteral(" ===");
					stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder4 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["processorname"]);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(this.cpue.Text);
					stringBuilder4.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder5 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["processorcores"]);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(this.cpucore.Text);
					stringBuilder5.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder6 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["processorthr"]);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(this.threads.Text);
					stringBuilder6.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder7 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["processorfreq"]);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(this.corespeed.Text);
					stringBuilder7.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder8 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["processorcache"]);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(this.l3cash.Text);
					stringBuilder8.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder.AppendLine();
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder9 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("=== ");
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["ramlabel"]);
					appendInterpolatedStringHandler.AppendLiteral(" ===");
					stringBuilder9.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder10 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["ramtotal"]);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(this.rama.Text);
					stringBuilder10.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder11 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["ramddr"]);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(this.ddre.Text);
					stringBuilder11.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder12 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["ramfreq"]);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(this.freq.Text);
					stringBuilder12.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder.AppendLine();
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder13 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("=== ");
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["mblabel"]);
					appendInterpolatedStringHandler.AppendLiteral(" ===");
					stringBuilder13.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder14 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["mbname"]);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(this.mbname.Text);
					stringBuilder14.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder15 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["mbver"]);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(this.biosver.Text);
					stringBuilder15.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder16 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["mbdate"]);
					appendInterpolatedStringHandler.AppendLiteral(" ");
					appendInterpolatedStringHandler.AppendFormatted(this.biosdate.Text);
					stringBuilder16.AppendLine(ref appendInterpolatedStringHandler);
					stringBuilder.AppendLine();
					stringBuilder.AppendLine();
					stringBuilder.AppendLine();
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder17 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("=== ");
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["vlabel"]);
					appendInterpolatedStringHandler.AppendLiteral(" ===");
					stringBuilder17.AppendLine(ref appendInterpolatedStringHandler);
					bool flag = this._gpus.Count == 0;
					if (flag)
					{
						stringBuilder.AppendLine("No GPU found");
					}
					else
					{
						for (int i = 0; i < this._gpus.Count; i++)
						{
							GpuInfo gpuInfo = this._gpus[i];
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder18 = stringBuilder2;
							appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(3, 2, stringBuilder2);
							appendInterpolatedStringHandler.AppendLiteral("[");
							appendInterpolatedStringHandler.AppendFormatted<int>(i + 1);
							appendInterpolatedStringHandler.AppendLiteral("] ");
							appendInterpolatedStringHandler.AppendFormatted(gpuInfo.Name);
							stringBuilder18.AppendLine(ref appendInterpolatedStringHandler);
							stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder19 = stringBuilder2;
							appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
							appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["vmem"]);
							appendInterpolatedStringHandler.AppendLiteral(" ");
							appendInterpolatedStringHandler.AppendFormatted(gpuInfo.VRamFormatted);
							stringBuilder19.AppendLine(ref appendInterpolatedStringHandler);
							stringBuilder.AppendLine();
						}
					}
					stringBuilder.AppendLine();
					stringBuilder.AppendLine();
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder20 = stringBuilder2;
					appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, stringBuilder2);
					appendInterpolatedStringHandler.AppendLiteral("=== ");
					appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["ssdl"]);
					appendInterpolatedStringHandler.AppendLiteral(" ===");
					stringBuilder20.AppendLine(ref appendInterpolatedStringHandler);
					for (int j = 0; j < this._storageDevices.Count; j++)
					{
						StorageInfo storageInfo = this._storageDevices[j];
						stringBuilder2 = stringBuilder;
						StringBuilder stringBuilder21 = stringBuilder2;
						appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(3, 2, stringBuilder2);
						appendInterpolatedStringHandler.AppendLiteral("[");
						appendInterpolatedStringHandler.AppendFormatted<int>(j + 1);
						appendInterpolatedStringHandler.AppendLiteral("] ");
						appendInterpolatedStringHandler.AppendFormatted(storageInfo.Name);
						stringBuilder21.AppendLine(ref appendInterpolatedStringHandler);
						stringBuilder2 = stringBuilder;
						StringBuilder stringBuilder22 = stringBuilder2;
						appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(1, 2, stringBuilder2);
						appendInterpolatedStringHandler.AppendFormatted(dictionary["main"]["smem"]);
						appendInterpolatedStringHandler.AppendLiteral(" ");
						appendInterpolatedStringHandler.AppendFormatted(storageInfo.CapacityFormatted);
						stringBuilder22.AppendLine(ref appendInterpolatedStringHandler);
						stringBuilder.AppendLine();
					}
					stringBuilder.AppendLine();
					File.WriteAllText(saveFileDialog.FileName, stringBuilder.ToString(), Encoding.UTF8);
					MessageBox.Show("System information saved successfully!\nСистемная информация была успешно сохранена!", "MakuTweaker", MessageBoxButton.OK, MessageBoxImage.Asterisk);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message ?? "", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
		}

		// Token: 0x04000094 RID: 148
		private bool isLoaded = false;

		// Token: 0x04000095 RID: 149
		private bool isNotify = true;

		// Token: 0x04000096 RID: 150
		private bool isbycheck = false;

		// Token: 0x04000097 RID: 151
		[Nullable(1)]
		private MainWindow mw = (MainWindow)Application.Current.MainWindow;

		// Token: 0x04000098 RID: 152
		[Nullable(1)]
		private List<GpuInfo> _gpus = new List<GpuInfo>();

		// Token: 0x04000099 RID: 153
		[Nullable(1)]
		private List<StorageInfo> _storageDevices = new List<StorageInfo>();

		// Token: 0x0200002F RID: 47
		public struct RECT
		{
			// Token: 0x04000252 RID: 594
			public int Left;

			// Token: 0x04000253 RID: 595
			public int Top;

			// Token: 0x04000254 RID: 596
			public int Right;

			// Token: 0x04000255 RID: 597
			public int Bottom;
		}

		// Token: 0x02000030 RID: 48
		public static class NvmlWrapper
		{
			// Token: 0x06000228 RID: 552
			[DllImport("nvml.dll", CallingConvention = 2)]
			public static extern int nvmlInit_v2();

			// Token: 0x06000229 RID: 553
			[DllImport("nvml.dll", CallingConvention = 2)]
			public static extern int nvmlShutdown();

			// Token: 0x0600022A RID: 554
			[DllImport("nvml.dll", CallingConvention = 2)]
			public static extern int nvmlDeviceGetHandleByIndex_v2(int index, out IntPtr device);

			// Token: 0x0600022B RID: 555
			[DllImport("nvml.dll", CallingConvention = 2)]
			public static extern int nvmlDeviceGetPowerUsage(IntPtr device, out uint powerMilliwatts);

			// Token: 0x0600022C RID: 556
			[DllImport("nvml.dll", CallingConvention = 2)]
			public static extern int nvmlDeviceGetTemperature(IntPtr device, int sensorType, out uint temp);

			// Token: 0x0600022D RID: 557 RVA: 0x00019324 File Offset: 0x00017524
			public static double TryGetGpuPowerWatts(int index = 0)
			{
				double result;
				try
				{
					bool flag = PCI.NvmlWrapper.nvmlInit_v2() != 0;
					if (flag)
					{
						result = -1.0;
					}
					else
					{
						IntPtr device;
						bool flag2 = PCI.NvmlWrapper.nvmlDeviceGetHandleByIndex_v2(index, out device) != 0;
						if (flag2)
						{
							result = -1.0;
						}
						else
						{
							uint num;
							bool flag3 = PCI.NvmlWrapper.nvmlDeviceGetPowerUsage(device, out num) != 0;
							if (flag3)
							{
								result = -1.0;
							}
							else
							{
								PCI.NvmlWrapper.nvmlShutdown();
								result = num / 1000.0;
							}
						}
					}
				}
				catch
				{
					result = -1.0;
				}
				return result;
			}

			// Token: 0x0600022E RID: 558 RVA: 0x000193BC File Offset: 0x000175BC
			public static double TryGetGpuTemperature(int index = 0)
			{
				double result;
				try
				{
					bool flag = PCI.NvmlWrapper.nvmlInit_v2() != 0;
					if (flag)
					{
						result = -1.0;
					}
					else
					{
						IntPtr device;
						bool flag2 = PCI.NvmlWrapper.nvmlDeviceGetHandleByIndex_v2(index, out device) != 0;
						if (flag2)
						{
							result = -1.0;
						}
						else
						{
							uint num;
							bool flag3 = PCI.NvmlWrapper.nvmlDeviceGetTemperature(device, 0, out num) != 0;
							if (flag3)
							{
								result = -1.0;
							}
							else
							{
								PCI.NvmlWrapper.nvmlShutdown();
								result = num;
							}
						}
					}
				}
				catch
				{
					result = -1.0;
				}
				return result;
			}
		}
	}
}
