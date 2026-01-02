using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using MakuTweakerNew.Properties;
using MicaWPF.Controls;
using ModernWpf.Controls;

namespace MakuTweakerNew
{
	// Token: 0x02000015 RID: 21
	public partial class UWP : System.Windows.Controls.Page
	{
		// Token: 0x06000106 RID: 262 RVA: 0x000112F5 File Offset: 0x0000F4F5
		public UWP()
		{
			this.InitializeComponent();
			this.LoadLang();
			this.CheckInstalledUWPAppsAsync(true);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00011334 File Offset: 0x0000F534
		[DebuggerStepThrough]
		private void CheckInstalledUWPAppsAsync(bool anim)
		{
			UWP.<CheckInstalledUWPAppsAsync>d__5 <CheckInstalledUWPAppsAsync>d__ = new UWP.<CheckInstalledUWPAppsAsync>d__5();
			<CheckInstalledUWPAppsAsync>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<CheckInstalledUWPAppsAsync>d__.<>4__this = this;
			<CheckInstalledUWPAppsAsync>d__.anim = anim;
			<CheckInstalledUWPAppsAsync>d__.<>1__state = -1;
			<CheckInstalledUWPAppsAsync>d__.<>t__builder.Start<UWP.<CheckInstalledUWPAppsAsync>d__5>(ref <CheckInstalledUWPAppsAsync>d__);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00011374 File Offset: 0x0000F574
		[NullableContext(1)]
		private bool IsAppInstalled(string appId)
		{
			bool result;
			try
			{
				List<string> installedUWPApps = this.GetInstalledUWPApps();
				result = installedUWPApps.Contains(appId);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error checking app " + appId + ": " + ex.Message, "App Check Error", MessageBoxButton.OK, MessageBoxImage.Hand);
				result = false;
			}
			return result;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000113D0 File Offset: 0x0000F5D0
		[NullableContext(1)]
		private List<string> GetInstalledUWPApps()
		{
			List<string> result = new List<string>();
			try
			{
				string str = "\r\n                    Get-AppxPackage | Select-Object -ExpandProperty Name\r\n                ";
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = "powershell.exe",
					Arguments = "-Command \"" + str + "\"",
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true
				};
				using (Process process = Process.Start(startInfo))
				{
					using (StreamReader standardOutput = process.StandardOutput)
					{
						string text = standardOutput.ReadToEnd();
						bool flag = string.IsNullOrEmpty(text);
						if (flag)
						{
							MessageBox.Show("No output received from PowerShell.");
						}
						else
						{
							result = text.Split(new char[]
							{
								'\r',
								'\n'
							}, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error executing PowerShell: " + ex.Message, "PowerShell Error", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			return result;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000114F8 File Offset: 0x0000F6F8
		[NullableContext(1)]
		private void FadeIn(UIElement element, double durationSeconds)
		{
			DoubleAnimation animation = new DoubleAnimation
			{
				From = new double?(0.0),
				To = new double?(1.0),
				Duration = TimeSpan.FromMilliseconds(durationSeconds),
				EasingFunction = new QuadraticEase
				{
					EasingMode = EasingMode.EaseIn
				}
			};
			element.BeginAnimation(UIElement.OpacityProperty, animation);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0001156C File Offset: 0x0000F76C
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

		// Token: 0x0600010C RID: 268 RVA: 0x000115E0 File Offset: 0x0000F7E0
		private void FadeInAll1()
		{
			this.FadeIn(this.u1, 300.0);
			this.FadeIn(this.u2, 300.0);
			this.FadeIn(this.u3, 300.0);
			this.FadeIn(this.u4, 300.0);
			this.FadeIn(this.u5, 300.0);
			this.FadeIn(this.u6, 300.0);
			this.FadeIn(this.u7, 300.0);
			this.FadeIn(this.u8, 300.0);
			this.FadeIn(this.u9, 300.0);
			this.FadeIn(this.u10, 300.0);
			this.FadeIn(this.u11, 300.0);
			this.FadeIn(this.u12, 300.0);
			this.FadeIn(this.u13, 300.0);
			this.FadeIn(this.u14, 300.0);
			this.FadeIn(this.u15, 300.0);
			this.FadeIn(this.u16, 300.0);
			this.FadeIn(this.u17, 300.0);
			this.FadeIn(this.u18, 300.0);
			this.FadeIn(this.u19, 300.0);
			this.FadeIn(this.u20, 300.0);
			this.FadeIn(this.u21, 300.0);
			this.FadeIn(this.u22, 300.0);
			this.FadeIn(this.u23, 300.0);
			this.FadeIn(this.u24, 300.0);
			this.FadeIn(this.u25, 300.0);
			this.FadeIn(this.u26, 300.0);
			this.FadeIn(this.u27, 300.0);
			this.FadeIn(this.u28, 300.0);
			this.FadeIn(this.b, 300.0);
			this.FadeIn(this.view, 300.0);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00011884 File Offset: 0x0000FA84
		[DebuggerStepThrough]
		private void FadeOutAll1()
		{
			UWP.<FadeOutAll1>d__11 <FadeOutAll1>d__ = new UWP.<FadeOutAll1>d__11();
			<FadeOutAll1>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<FadeOutAll1>d__.<>4__this = this;
			<FadeOutAll1>d__.<>1__state = -1;
			<FadeOutAll1>d__.<>t__builder.Start<UWP.<FadeOutAll1>d__11>(ref <FadeOutAll1>d__);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000118BD File Offset: 0x0000FABD
		private void FadeInAll2()
		{
			this.FadeIn(this.p, 300.0);
			this.FadeIn(this.t, 300.0);
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000118EC File Offset: 0x0000FAEC
		private void FadeOutAll2()
		{
			this.FadeOut(this.u1, 300.0);
			this.FadeOut(this.u2, 300.0);
			this.FadeOut(this.u3, 300.0);
			this.FadeOut(this.u4, 300.0);
			this.FadeOut(this.u5, 300.0);
			this.FadeOut(this.u6, 300.0);
			this.FadeOut(this.u7, 300.0);
			this.FadeOut(this.u8, 300.0);
			this.FadeOut(this.u9, 300.0);
			this.FadeOut(this.u10, 300.0);
			this.FadeOut(this.u11, 300.0);
			this.FadeOut(this.u12, 300.0);
			this.FadeOut(this.u13, 300.0);
			this.FadeOut(this.u14, 300.0);
			this.FadeOut(this.u15, 300.0);
			this.FadeOut(this.u16, 300.0);
			this.FadeOut(this.u17, 300.0);
			this.FadeOut(this.u18, 300.0);
			this.FadeOut(this.u19, 300.0);
			this.FadeOut(this.u20, 300.0);
			this.FadeOut(this.u21, 300.0);
			this.FadeOut(this.u22, 300.0);
			this.FadeOut(this.u23, 300.0);
			this.FadeOut(this.u24, 300.0);
			this.FadeOut(this.u25, 300.0);
			this.FadeOut(this.u26, 300.0);
			this.FadeOut(this.u27, 300.0);
			this.FadeOut(this.u28, 300.0);
			this.FadeOut(this.b, 300.0);
			this.FadeOut(this.view, 300.0);
			this.u1.IsEnabled = false;
			this.u2.IsEnabled = false;
			this.u3.IsEnabled = false;
			this.u4.IsEnabled = false;
			this.u5.IsEnabled = false;
			this.u6.IsEnabled = false;
			this.u7.IsEnabled = false;
			this.u8.IsEnabled = false;
			this.u9.IsEnabled = false;
			this.u10.IsEnabled = false;
			this.u11.IsEnabled = false;
			this.u12.IsEnabled = false;
			this.u13.IsEnabled = false;
			this.u14.IsEnabled = false;
			this.u15.IsEnabled = false;
			this.u16.IsEnabled = false;
			this.u17.IsEnabled = false;
			this.u18.IsEnabled = false;
			this.u19.IsEnabled = false;
			this.u20.IsEnabled = false;
			this.u21.IsEnabled = false;
			this.u22.IsEnabled = false;
			this.u23.IsEnabled = false;
			this.u24.IsEnabled = false;
			this.u25.IsEnabled = false;
			this.u26.IsEnabled = false;
			this.u27.IsEnabled = false;
			this.u28.IsEnabled = false;
			this.b.IsEnabled = false;
			this.view.IsEnabled = false;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00011D14 File Offset: 0x0000FF14
		[NullableContext(1)]
		[DebuggerStepThrough]
		private void b_Click(object sender, RoutedEventArgs e)
		{
			UWP.<b_Click>d__14 <b_Click>d__ = new UWP.<b_Click>d__14();
			<b_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<b_Click>d__.<>4__this = this;
			<b_Click>d__.sender = sender;
			<b_Click>d__.e = e;
			<b_Click>d__.<>1__state = -1;
			<b_Click>d__.<>t__builder.Start<UWP.<b_Click>d__14>(ref <b_Click>d__);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x00011D5C File Offset: 0x0000FF5C
		[NullableContext(1)]
		[DebuggerStepThrough]
		private Task RemovePackageAsync(string packageName)
		{
			UWP.<RemovePackageAsync>d__15 <RemovePackageAsync>d__ = new UWP.<RemovePackageAsync>d__15();
			<RemovePackageAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<RemovePackageAsync>d__.<>4__this = this;
			<RemovePackageAsync>d__.packageName = packageName;
			<RemovePackageAsync>d__.<>1__state = -1;
			<RemovePackageAsync>d__.<>t__builder.Start<UWP.<RemovePackageAsync>d__15>(ref <RemovePackageAsync>d__);
			return <RemovePackageAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000112 RID: 274 RVA: 0x00011DA7 File Offset: 0x0000FFA7
		[NullableContext(1)]
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00011DAA File Offset: 0x0000FFAA
		[NullableContext(1)]
		private void skip_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			this.isSkipped = true;
			CancellationTokenSource cancellationTokenSource = this.cancellationTokenSource;
			if (cancellationTokenSource != null)
			{
				cancellationTokenSource.Cancel();
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00011DC8 File Offset: 0x0000FFC8
		private void FadeInPopular()
		{
			this.u15.Visibility = Visibility.Visible;
			this.u16.Visibility = Visibility.Visible;
			this.u17.Visibility = Visibility.Visible;
			this.u9.Visibility = Visibility.Visible;
			this.FadeIn(this.u16, 300.0);
			this.FadeIn(this.u15, 300.0);
			this.FadeIn(this.u17, 300.0);
			this.FadeIn(this.u9, 300.0);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00011E64 File Offset: 0x00010064
		private void FadeInNecessary()
		{
			this.u23.Visibility = Visibility.Visible;
			this.u24.Visibility = Visibility.Visible;
			this.FadeIn(this.u23, 300.0);
			this.FadeIn(this.u24, 300.0);
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00011EB8 File Offset: 0x000100B8
		[DebuggerStepThrough]
		private void FadeOutPopular()
		{
			UWP.<FadeOutPopular>d__20 <FadeOutPopular>d__ = new UWP.<FadeOutPopular>d__20();
			<FadeOutPopular>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<FadeOutPopular>d__.<>4__this = this;
			<FadeOutPopular>d__.<>1__state = -1;
			<FadeOutPopular>d__.<>t__builder.Start<UWP.<FadeOutPopular>d__20>(ref <FadeOutPopular>d__);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00011EF4 File Offset: 0x000100F4
		[DebuggerStepThrough]
		private void FadeOutNecessary()
		{
			UWP.<FadeOutNecessary>d__21 <FadeOutNecessary>d__ = new UWP.<FadeOutNecessary>d__21();
			<FadeOutNecessary>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<FadeOutNecessary>d__.<>4__this = this;
			<FadeOutNecessary>d__.<>1__state = -1;
			<FadeOutNecessary>d__.<>t__builder.Start<UWP.<FadeOutNecessary>d__21>(ref <FadeOutNecessary>d__);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00011F30 File Offset: 0x00010130
		private void FadeInBloat()
		{
			this.FadeIn(this.u1, 300.0);
			this.FadeIn(this.u2, 300.0);
			this.FadeIn(this.u3, 300.0);
			this.FadeIn(this.u4, 300.0);
			this.FadeIn(this.u5, 300.0);
			this.FadeIn(this.u6, 300.0);
			this.FadeIn(this.u7, 300.0);
			this.FadeIn(this.u8, 300.0);
			this.FadeIn(this.u10, 300.0);
			this.FadeIn(this.u11, 300.0);
			this.FadeIn(this.u12, 300.0);
			this.FadeIn(this.u13, 300.0);
			this.FadeIn(this.u14, 300.0);
			this.FadeIn(this.u18, 300.0);
			this.FadeIn(this.u19, 300.0);
			this.FadeIn(this.u20, 300.0);
			this.FadeIn(this.u21, 300.0);
			this.FadeIn(this.u22, 300.0);
			this.FadeIn(this.u25, 300.0);
			this.FadeIn(this.u26, 300.0);
			this.FadeIn(this.u27, 300.0);
			this.FadeIn(this.u28, 300.0);
			this.FadeIn(this.b, 300.0);
			this.FadeIn(this.view, 300.0);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00012150 File Offset: 0x00010350
		private void FadeOutBloat()
		{
			this.FadeOut(this.u1, 300.0);
			this.FadeOut(this.u2, 300.0);
			this.FadeOut(this.u3, 300.0);
			this.FadeOut(this.u4, 300.0);
			this.FadeOut(this.u5, 300.0);
			this.FadeOut(this.u6, 300.0);
			this.FadeOut(this.u7, 300.0);
			this.FadeOut(this.u8, 300.0);
			this.FadeOut(this.u10, 300.0);
			this.FadeOut(this.u11, 300.0);
			this.FadeOut(this.u12, 300.0);
			this.FadeOut(this.u13, 300.0);
			this.FadeOut(this.u14, 300.0);
			this.FadeOut(this.u18, 300.0);
			this.FadeOut(this.u19, 300.0);
			this.FadeOut(this.u20, 300.0);
			this.FadeOut(this.u21, 300.0);
			this.FadeOut(this.u22, 300.0);
			this.FadeOut(this.u25, 300.0);
			this.FadeOut(this.u26, 300.0);
			this.FadeOut(this.u27, 300.0);
			this.FadeOut(this.u28, 300.0);
			this.FadeOut(this.b, 300.0);
			this.FadeOut(this.view, 300.0);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00012370 File Offset: 0x00010570
		[NullableContext(1)]
		[DebuggerStepThrough]
		private void view_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UWP.<view_SelectionChanged>d__24 <view_SelectionChanged>d__ = new UWP.<view_SelectionChanged>d__24();
			<view_SelectionChanged>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<view_SelectionChanged>d__.<>4__this = this;
			<view_SelectionChanged>d__.sender = sender;
			<view_SelectionChanged>d__.e = e;
			<view_SelectionChanged>d__.<>1__state = -1;
			<view_SelectionChanged>d__.<>t__builder.Start<UWP.<view_SelectionChanged>d__24>(ref <view_SelectionChanged>d__);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000123B8 File Offset: 0x000105B8
		private void LoadLang()
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "uwp");
			this.label.Text = dictionary["main"]["label"];
			this.info1.Text = dictionary["main"]["info1"];
			this.info2.Text = dictionary["main"]["info2"];
			this.u3.OffContent = dictionary["main"]["u3"];
			this.u5.OffContent = dictionary["main"]["u5"];
			this.u6.OffContent = dictionary["main"]["u6"];
			this.u9.OffContent = dictionary["main"]["u9"];
			this.u10.OffContent = dictionary["main"]["u10"];
			this.u13.OffContent = dictionary["main"]["u13"];
			this.u15.OffContent = dictionary["main"]["u15"];
			this.u16.OffContent = dictionary["main"]["u16"];
			this.u17.OffContent = dictionary["main"]["u17"];
			this.u18.OffContent = dictionary["main"]["u18"];
			this.u19.OffContent = dictionary["main"]["u19"];
			this.u20.OffContent = dictionary["main"]["u20"];
			this.u22.OffContent = dictionary["main"]["u22"];
			this.u27.OffContent = dictionary["main"]["u27"];
			this.u3.OnContent = dictionary["main"]["u3"];
			this.u5.OnContent = dictionary["main"]["u5"];
			this.u6.OnContent = dictionary["main"]["u6"];
			this.u9.OnContent = dictionary["main"]["u9"];
			this.u10.OnContent = dictionary["main"]["u10"];
			this.u13.OnContent = dictionary["main"]["u13"];
			this.u15.OnContent = dictionary["main"]["u15"];
			this.u16.OnContent = dictionary["main"]["u16"];
			this.u17.OnContent = dictionary["main"]["u17"];
			this.u18.OnContent = dictionary["main"]["u18"];
			this.u19.OnContent = dictionary["main"]["u19"];
			this.u20.OnContent = dictionary["main"]["u20"];
			this.u22.OnContent = dictionary["main"]["u22"];
			this.u27.OnContent = dictionary["main"]["u27"];
			this.mode1.Content = dictionary["main"]["mode1"];
			this.mode2.Content = dictionary["main"]["mode2"];
			this.mode3.Content = dictionary["main"]["mode3"];
			this.b.Content = dictionary["main"]["b"];
			this.skip.Text = dictionary["main"]["skip"];
			this.t.Text = dictionary["main"]["chk"];
		}

		// Token: 0x04000147 RID: 327
		private bool isSkipped = false;

		// Token: 0x04000148 RID: 328
		[Nullable(1)]
		private CancellationTokenSource cancellationTokenSource;

		// Token: 0x04000149 RID: 329
		[Nullable(1)]
		private MainWindow mw = (MainWindow)Application.Current.MainWindow;

		// Token: 0x0400014A RID: 330
		private int mode;
	}
}
