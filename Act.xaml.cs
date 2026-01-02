using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
	// Token: 0x02000002 RID: 2
	public partial class Act : System.Windows.Controls.Page
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002048 File Offset: 0x00000248
		public Act()
		{
			this.InitializeComponent();
			this.LoadLang();
			bool flag = this.checkWinVer() > 26071;
			if (flag)
			{
				this.mact9.Visibility = Visibility.Collapsed;
				this.mact1.Visibility = Visibility.Collapsed;
				this.mact2.Visibility = Visibility.Collapsed;
				this.mact3.Visibility = Visibility.Collapsed;
				this.mact6.Visibility = Visibility.Collapsed;
				this.mact7.Visibility = Visibility.Collapsed;
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020E4 File Offset: 0x000002E4
		[DebuggerStepThrough]
		private void HWIDAct()
		{
			Act.<HWIDAct>d__4 <HWIDAct>d__ = new Act.<HWIDAct>d__4();
			<HWIDAct>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<HWIDAct>d__.<>4__this = this;
			<HWIDAct>d__.<>1__state = -1;
			<HWIDAct>d__.<>t__builder.Start<Act.<HWIDAct>d__4>(ref <HWIDAct>d__);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002120 File Offset: 0x00000320
		[NullableContext(1)]
		[DebuggerStepThrough]
		private Task<string> GetEmbeddedCmdContentAsync(string resourceName)
		{
			Act.<GetEmbeddedCmdContentAsync>d__5 <GetEmbeddedCmdContentAsync>d__ = new Act.<GetEmbeddedCmdContentAsync>d__5();
			<GetEmbeddedCmdContentAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<GetEmbeddedCmdContentAsync>d__.<>4__this = this;
			<GetEmbeddedCmdContentAsync>d__.resourceName = resourceName;
			<GetEmbeddedCmdContentAsync>d__.<>1__state = -1;
			<GetEmbeddedCmdContentAsync>d__.<>t__builder.Start<Act.<GetEmbeddedCmdContentAsync>d__5>(ref <GetEmbeddedCmdContentAsync>d__);
			return <GetEmbeddedCmdContentAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000216C File Offset: 0x0000036C
		[NullableContext(1)]
		[DebuggerStepThrough]
		private Task<string> ExecuteCommandAsync(string cmdContent)
		{
			Act.<ExecuteCommandAsync>d__6 <ExecuteCommandAsync>d__ = new Act.<ExecuteCommandAsync>d__6();
			<ExecuteCommandAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<ExecuteCommandAsync>d__.<>4__this = this;
			<ExecuteCommandAsync>d__.cmdContent = cmdContent;
			<ExecuteCommandAsync>d__.<>1__state = -1;
			<ExecuteCommandAsync>d__.<>t__builder.Start<Act.<ExecuteCommandAsync>d__6>(ref <ExecuteCommandAsync>d__);
			return <ExecuteCommandAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000021B7 File Offset: 0x000003B7
		[NullableContext(1)]
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.HWIDAct();
			this.ActAnim();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021C8 File Offset: 0x000003C8
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

		// Token: 0x06000007 RID: 7 RVA: 0x0000223C File Offset: 0x0000043C
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

		// Token: 0x06000008 RID: 8 RVA: 0x000022B0 File Offset: 0x000004B0
		private void ActAnim()
		{
			this.FadeOut(this.mact1, 300.0);
			this.FadeOut(this.mact2, 300.0);
			this.FadeOut(this.mact3, 300.0);
			this.FadeOut(this.mact6, 300.0);
			this.FadeOut(this.mact7, 300.0);
			this.FadeOut(this.mact9, 300.0);
			this.FadeOut(this.offi, 300.0);
			this.FadeOut(this.autooffact, 300.0);
			this.FadeIn(this.p, 300.0);
			this.FadeIn(this.t, 300.0);
			this.autoact.IsEnabled = false;
			this.autooffact.IsEnabled = false;
			this.mact1.IsEnabled = false;
			this.mact2.IsEnabled = false;
			this.mact3.IsEnabled = false;
			this.mact6.IsEnabled = false;
			this.mact7.IsEnabled = false;
			this.mact9.IsEnabled = false;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002404 File Offset: 0x00000604
		private void OffiActAnim()
		{
			this.FadeOut(this.mact1, 300.0);
			this.FadeOut(this.mact2, 300.0);
			this.FadeOut(this.mact3, 300.0);
			this.FadeOut(this.mact6, 300.0);
			this.FadeOut(this.mact7, 300.0);
			this.FadeOut(this.mact9, 300.0);
			this.FadeIn(this.p, 300.0);
			this.FadeIn(this.t, 300.0);
			this.autoact.IsEnabled = false;
			this.autooffact.IsEnabled = false;
			this.mact1.IsEnabled = false;
			this.mact2.IsEnabled = false;
			this.mact3.IsEnabled = false;
			this.mact6.IsEnabled = false;
			this.mact7.IsEnabled = false;
			this.mact9.IsEnabled = false;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000252C File Offset: 0x0000072C
		private void PostOffiActAnim()
		{
			this.FadeIn(this.mact1, 300.0);
			this.FadeIn(this.mact2, 300.0);
			this.FadeIn(this.mact3, 300.0);
			this.FadeIn(this.mact6, 300.0);
			this.FadeIn(this.mact7, 300.0);
			this.FadeIn(this.mact9, 300.0);
			this.FadeOut(this.p, 300.0);
			this.FadeOut(this.t, 300.0);
			this.autoact.IsEnabled = true;
			this.autooffact.IsEnabled = true;
			this.mact1.IsEnabled = true;
			this.mact2.IsEnabled = true;
			this.mact3.IsEnabled = true;
			this.mact6.IsEnabled = true;
			this.mact7.IsEnabled = true;
			this.mact9.IsEnabled = true;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002654 File Offset: 0x00000854
		private void PostActAnim()
		{
			this.FadeIn(this.mact1, 300.0);
			this.FadeIn(this.mact2, 300.0);
			this.FadeIn(this.mact3, 300.0);
			this.FadeIn(this.mact6, 300.0);
			this.FadeIn(this.mact7, 300.0);
			this.FadeIn(this.mact9, 300.0);
			this.FadeIn(this.offi, 300.0);
			this.FadeIn(this.autooffact, 300.0);
			this.FadeOut(this.p, 300.0);
			this.FadeOut(this.t, 300.0);
			this.autoact.IsEnabled = true;
			this.autooffact.IsEnabled = true;
			this.mact1.IsEnabled = true;
			this.mact2.IsEnabled = true;
			this.mact3.IsEnabled = true;
			this.mact6.IsEnabled = true;
			this.mact7.IsEnabled = true;
			this.mact9.IsEnabled = true;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000027A8 File Offset: 0x000009A8
		private void ManualActAnim()
		{
			this.FadeIn(this.p, 300.0);
			this.FadeIn(this.t, 300.0);
			this.autoact.IsEnabled = false;
			this.autooffact.IsEnabled = false;
			this.mact1.IsEnabled = false;
			this.mact2.IsEnabled = false;
			this.mact3.IsEnabled = false;
			this.mact6.IsEnabled = false;
			this.mact7.IsEnabled = false;
			this.mact9.IsEnabled = false;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000284C File Offset: 0x00000A4C
		private void ManualPostActAnim()
		{
			this.FadeOut(this.p, 300.0);
			this.FadeOut(this.t, 300.0);
			this.autoact.IsEnabled = true;
			this.autooffact.IsEnabled = true;
			this.mact1.IsEnabled = true;
			this.mact2.IsEnabled = true;
			this.mact3.IsEnabled = true;
			this.mact6.IsEnabled = true;
			this.mact7.IsEnabled = true;
			this.mact9.IsEnabled = true;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000028F0 File Offset: 0x00000AF0
		[NullableContext(1)]
		private void mact3_Click(object sender, RoutedEventArgs e)
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "act");
			switch (this.mact2.SelectedIndex)
			{
			case 0:
				this.kms = "kms.digiboy.ir";
				break;
			case 1:
				this.kms = "kms.ddns.net";
				break;
			case 2:
				this.kms = "k.zpale.com";
				break;
			case 3:
				this.kms = "mvg.zpale.com";
				break;
			}
			this.CMDAsync("cscript C:\\Windows\\System32\\slmgr.vbs /skms " + this.kms, 0);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002990 File Offset: 0x00000B90
		[NullableContext(1)]
		[DebuggerStepThrough]
		private Task CMDAsync(string command, int act)
		{
			Act.<CMDAsync>d__17 <CMDAsync>d__ = new Act.<CMDAsync>d__17();
			<CMDAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<CMDAsync>d__.<>4__this = this;
			<CMDAsync>d__.command = command;
			<CMDAsync>d__.act = act;
			<CMDAsync>d__.<>1__state = -1;
			<CMDAsync>d__.<>t__builder.Start<Act.<CMDAsync>d__17>(ref <CMDAsync>d__);
			return <CMDAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000029E4 File Offset: 0x00000BE4
		[NullableContext(1)]
		[DebuggerStepThrough]
		private void mact7_Click(object sender, RoutedEventArgs e)
		{
			Act.<mact7_Click>d__18 <mact7_Click>d__ = new Act.<mact7_Click>d__18();
			<mact7_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<mact7_Click>d__.<>4__this = this;
			<mact7_Click>d__.sender = sender;
			<mact7_Click>d__.e = e;
			<mact7_Click>d__.<>1__state = -1;
			<mact7_Click>d__.<>t__builder.Start<Act.<mact7_Click>d__18>(ref <mact7_Click>d__);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002A2C File Offset: 0x00000C2C
		[NullableContext(1)]
		[DebuggerStepThrough]
		private Task CMDAsyncFinal(string command, bool isfinal)
		{
			Act.<CMDAsyncFinal>d__19 <CMDAsyncFinal>d__ = new Act.<CMDAsyncFinal>d__19();
			<CMDAsyncFinal>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<CMDAsyncFinal>d__.<>4__this = this;
			<CMDAsyncFinal>d__.command = command;
			<CMDAsyncFinal>d__.isfinal = isfinal;
			<CMDAsyncFinal>d__.<>1__state = -1;
			<CMDAsyncFinal>d__.<>t__builder.Start<Act.<CMDAsyncFinal>d__19>(ref <CMDAsyncFinal>d__);
			return <CMDAsyncFinal>d__.<>t__builder.Task;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002A80 File Offset: 0x00000C80
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
			return 22621;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002B08 File Offset: 0x00000D08
		private void LoadLang()
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "act");
			this.label.Text = dictionary["main"]["label"];
			this.hwid.Text = dictionary["main"]["hwid"];
			this.autoact.Content = dictionary["main"]["button20"];
			this.autooffact.Content = dictionary["main"]["button20"];
			this.mact3.Content = dictionary["main"]["button20"];
			this.mact7.Content = dictionary["main"]["button20"];
			this.mact1.Text = dictionary["main"]["step1"];
			this.mact6.Text = dictionary["main"]["step2"];
			this.mact9.Text = dictionary["main"]["kms"];
			this.offi.Text = dictionary["main"]["offi"];
			this.t.Text = dictionary["status"]["inprog"];
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002CA1 File Offset: 0x00000EA1
		[NullableContext(1)]
		private void autooffact_Click(object sender, RoutedEventArgs e)
		{
			this.OffiActAnim();
			this.OffiAct();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002CB4 File Offset: 0x00000EB4
		[DebuggerStepThrough]
		private void OffiAct()
		{
			Act.<OffiAct>d__23 <OffiAct>d__ = new Act.<OffiAct>d__23();
			<OffiAct>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OffiAct>d__.<>4__this = this;
			<OffiAct>d__.<>1__state = -1;
			<OffiAct>d__.<>t__builder.Start<Act.<OffiAct>d__23>(ref <OffiAct>d__);
		}

		// Token: 0x04000001 RID: 1
		[Nullable(1)]
		private MainWindow mw = (MainWindow)Application.Current.MainWindow;

		// Token: 0x04000002 RID: 2
		[Nullable(1)]
		private string kms;

		// Token: 0x04000003 RID: 3
		[Nullable(1)]
		private string kmskey;
	}
}
