using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using MakuTweakerNew.Properties;
using MicaWPF.Controls;
using ModernWpf.Controls;

namespace MakuTweakerNew
{
	// Token: 0x02000004 RID: 4
	public partial class AppInstall : System.Windows.Controls.Page
	{
		// Token: 0x06000021 RID: 33 RVA: 0x0000325C File Offset: 0x0000145C
		public AppInstall()
		{
			this.InitializeComponent();
			this.LoadLang();
			this.isLoaded = true;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000032B0 File Offset: 0x000014B0
		private void LoadLang()
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "app");
			Dictionary<string, Dictionary<string, string>> dictionary2 = MainWindow.Localization.LoadLocalization(language, "base");
			this.label.Text = dictionary["main"]["label"];
			this.start.Content = dictionary["main"]["start"];
			this.stop.Content = dictionary["main"]["stop"];
			this.skip.Content = dictionary["main"]["skip"];
			this.winget.Content = dictionary["main"]["winget"];
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003390 File Offset: 0x00001590
		[NullableContext(1)]
		[DebuggerStepThrough]
		private void start_Click(object sender, RoutedEventArgs e)
		{
			AppInstall.<start_Click>d__7 <start_Click>d__ = new AppInstall.<start_Click>d__7();
			<start_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<start_Click>d__.<>4__this = this;
			<start_Click>d__.sender = sender;
			<start_Click>d__.e = e;
			<start_Click>d__.<>1__state = -1;
			<start_Click>d__.<>t__builder.Start<AppInstall.<start_Click>d__7>(ref <start_Click>d__);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000033D8 File Offset: 0x000015D8
		[NullableContext(1)]
		[DebuggerStepThrough]
		private Task<bool> InstallApp(string packageName, CancellationToken token)
		{
			AppInstall.<InstallApp>d__8 <InstallApp>d__ = new AppInstall.<InstallApp>d__8();
			<InstallApp>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<InstallApp>d__.<>4__this = this;
			<InstallApp>d__.packageName = packageName;
			<InstallApp>d__.token = token;
			<InstallApp>d__.<>1__state = -1;
			<InstallApp>d__.<>t__builder.Start<AppInstall.<InstallApp>d__8>(ref <InstallApp>d__);
			return <InstallApp>d__.<>t__builder.Task;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000342C File Offset: 0x0000162C
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

		// Token: 0x06000026 RID: 38 RVA: 0x000034A0 File Offset: 0x000016A0
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

		// Token: 0x06000027 RID: 39 RVA: 0x00003514 File Offset: 0x00001714
		private void FadeOutAll()
		{
			foreach (ModernWpf.Controls.ToggleSwitch toggleSwitch in new ModernWpf.Controls.ToggleSwitch[]
			{
				this.a1,
				this.a2,
				this.a3,
				this.a4,
				this.a5,
				this.a6,
				this.a7,
				this.a8,
				this.a9,
				this.a10,
				this.a11,
				this.a12,
				this.a13,
				this.a14,
				this.a15,
				this.a16,
				this.a17,
				this.a18,
				this.a19,
				this.a20,
				this.a21,
				this.a22,
				this.a23,
				this.a24
			})
			{
				this.FadeOut(toggleSwitch, 300.0);
				toggleSwitch.IsEnabled = false;
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003640 File Offset: 0x00001840
		private void FadeInAll()
		{
			foreach (ModernWpf.Controls.ToggleSwitch toggleSwitch in new ModernWpf.Controls.ToggleSwitch[]
			{
				this.a1,
				this.a2,
				this.a3,
				this.a4,
				this.a5,
				this.a6,
				this.a7,
				this.a8,
				this.a9,
				this.a10,
				this.a11,
				this.a12,
				this.a13,
				this.a14,
				this.a15,
				this.a16,
				this.a17,
				this.a18,
				this.a19,
				this.a20,
				this.a21,
				this.a22,
				this.a23,
				this.a24
			})
			{
				this.FadeIn(toggleSwitch, 300.0);
				toggleSwitch.IsEnabled = true;
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000376B File Offset: 0x0000196B
		[NullableContext(1)]
		private void stop_Click(object sender, RoutedEventArgs e)
		{
			CancellationTokenSource cancellationTokenSource = this.cancl;
			if (cancellationTokenSource != null)
			{
				cancellationTokenSource.Cancel();
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00003780 File Offset: 0x00001980
		[NullableContext(1)]
		[DebuggerStepThrough]
		private void skip_Click(object sender, RoutedEventArgs e)
		{
			AppInstall.<skip_Click>d__14 <skip_Click>d__ = new AppInstall.<skip_Click>d__14();
			<skip_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<skip_Click>d__.<>4__this = this;
			<skip_Click>d__.sender = sender;
			<skip_Click>d__.e = e;
			<skip_Click>d__.<>1__state = -1;
			<skip_Click>d__.<>t__builder.Start<AppInstall.<skip_Click>d__14>(ref <skip_Click>d__);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000037C8 File Offset: 0x000019C8
		[NullableContext(1)]
		private void winget_Click(object sender, RoutedEventArgs e)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = "ms-windows-store://pdp/?productId=9NBLGGH4NNS1",
				UseShellExecute = true
			};
			Process process = new Process
			{
				StartInfo = startInfo
			};
			process.Start();
		}

		// Token: 0x04000014 RID: 20
		[Nullable(1)]
		private CancellationTokenSource cancl;

		// Token: 0x04000015 RID: 21
		private bool skipcur = false;

		// Token: 0x04000016 RID: 22
		private bool skipped = false;

		// Token: 0x04000017 RID: 23
		private bool isLoaded = false;

		// Token: 0x04000018 RID: 24
		[Nullable(1)]
		private MainWindow mw = (MainWindow)Application.Current.MainWindow;
	}
}
