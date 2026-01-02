using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Hardcodet.Wpf.TaskbarNotification;
using MakuTweakerNew.Properties;
using MicaWPF.Controls;
using MicaWPF.Core.Enums;
using MicaWPF.Core.Services;
using Microsoft.Win32;
using ModernWpf;
using ModernWpf.Controls;
using ModernWpf.Media.Animation;
using Newtonsoft.Json;

namespace MakuTweakerNew
{
	// Token: 0x02000009 RID: 9
	public partial class MainWindow : MicaWindow
	{
		// Token: 0x06000064 RID: 100 RVA: 0x000078CC File Offset: 0x00005ACC
		public MainWindow()
		{
			this.InitializeComponent();
			bool flag = this.checkWinVer() < 14393;
			if (flag)
			{
				DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Your version of Windows is not supported. To use MakuTweaker, update your system to Windows 10 1607 or higher. Do you want to download MakuTweaker Legacy Windows Edition?\n\nВаша версия Windows неподдерживается. Для использования MakuTweaker, обновитесь до Windows 10 1607 или выше. Вы хотите скачать MakuTweaker для старых Windows?", "MakuTweaker", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
				bool flag2 = dialogResult == System.Windows.Forms.DialogResult.Yes;
				if (flag2)
				{
					Process.Start(new ProcessStartInfo("https://adderly.top/mt")
					{
						UseShellExecute = true
					});
				}
				System.Windows.Application.Current.Shutdown();
			}
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream("MakuTweakerNew.BuildLab.txt"))
			{
				using (StreamReader streamReader = new StreamReader(manifestResourceStream))
				{
					string text = streamReader.ReadToEnd();
				}
			}
			this.ExpTimer();
			bool firRun = Settings.Default.firRun;
			if (firRun)
			{
				string name = CultureInfo.CurrentCulture.Name;
				string text2 = name;
				string text3 = text2;
				if (text3 != null)
				{
					if (text3.StartsWith("uk-"))
					{
						Settings.Default.lang = "ua";
						Settings.Default.langSI = 2;
						goto IL_1A1;
					}
					string text4 = text3;
					if (text4.StartsWith("ru-"))
					{
						Settings.Default.lang = "ru";
						Settings.Default.langSI = 1;
						goto IL_1A1;
					}
					string text5 = text3;
					if (text5.StartsWith("en-"))
					{
						Settings.Default.lang = "en";
						Settings.Default.langSI = 0;
						goto IL_1A1;
					}
				}
				Settings.Default.lang = "en";
				Settings.Default.langSI = 0;
				IL_1A1:
				Settings.Default.firRun = false;
				WindowsTheme currentTheme = MicaWPFServiceUtility.ThemeService.CurrentTheme;
				string theme = (currentTheme == WindowsTheme.Dark) ? "Dark" : "Light";
				Settings.Default.theme = theme;
				Settings.Default.firRun = false;
				Settings.Default.Save();
				this.ApplyTheme(currentTheme);
				Settings.Default.Save();
			}
			else
			{
				string theme2 = Settings.Default.theme;
				bool flag3 = string.IsNullOrEmpty(theme2) || theme2 == "Auto";
				if (flag3)
				{
					WindowsTheme currentTheme2 = MicaWPFServiceUtility.ThemeService.CurrentTheme;
					this.ApplyTheme(currentTheme2);
					Settings.Default.theme = ((currentTheme2 == WindowsTheme.Dark) ? "Dark" : "Light");
					Settings.Default.Save();
				}
				else
				{
					WindowsTheme theme3;
					bool flag4 = Enum.TryParse<WindowsTheme>(theme2, out theme3);
					if (flag4)
					{
						this.ApplyTheme(theme3);
					}
					else
					{
						this.ApplyTheme(MicaWPFServiceUtility.ThemeService.CurrentTheme);
					}
				}
			}
			this.LoadLang(Settings.Default.lang);
			this.CheckForUpd();
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00007BB4 File Offset: 0x00005DB4
		private void ApplyTheme(WindowsTheme theme)
		{
			MicaWPFServiceUtility.ThemeService.ChangeTheme(theme);
			bool flag = theme == WindowsTheme.Dark;
			if (flag)
			{
				ThemeManager.Current.ApplicationTheme = new ApplicationTheme?(ApplicationTheme.Dark);
				base.Foreground = System.Windows.Media.Brushes.White;
				this.Separator.Stroke = System.Windows.Media.Brushes.White;
			}
			else
			{
				ThemeManager.Current.ApplicationTheme = new ApplicationTheme?(ApplicationTheme.Light);
				base.Foreground = System.Windows.Media.Brushes.Black;
				this.Separator.Stroke = System.Windows.Media.Brushes.Black;
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00007C38 File Offset: 0x00005E38
		private void ExpTimer()
		{
			this.ExpRestart = new DispatcherTimer();
			this.ExpRestart.Interval = TimeSpan.FromMilliseconds(1000.0);
			this.ExpRestart.Tick += this.ExpRestart_Tick;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00007C78 File Offset: 0x00005E78
		[NullableContext(1)]
		private void MicaWindow_Closing(object sender, CancelEventArgs e)
		{
			Settings.Default.b1 = false;
			Settings.Default.b2 = false;
			Settings.Default.b3 = false;
			Settings.Default.b4 = false;
			Settings.Default.b5 = false;
			Settings.Default.b6 = false;
			Settings.Default.b7 = false;
			Settings.Default.b8 = false;
			Settings.Default.b9 = false;
			Settings.Default.b10 = false;
			Settings.Default.b11 = false;
			Settings.Default.pwsh = false;
			Settings.Default.Save();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00007D24 File Offset: 0x00005F24
		[NullableContext(1)]
		private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this._transitionInfo = new EntranceNavigationTransitionInfo();
			switch (this.Category.SelectedIndex)
			{
			case 0:
				this.MainFrame.Navigate(typeof(Explorer), null, this._transitionInfo);
				break;
			case 1:
				this.MainFrame.Navigate(typeof(WindowsUpdate), null, this._transitionInfo);
				break;
			case 2:
				this.MainFrame.Navigate(typeof(SysAndRec), null, this._transitionInfo);
				break;
			case 3:
				this.MainFrame.Navigate(typeof(UWP), null, this._transitionInfo);
				break;
			case 4:
				this.MainFrame.Navigate(typeof(Personalization), null, this._transitionInfo);
				break;
			case 5:
				this.MainFrame.Navigate(typeof(ContextMenu), null, this._transitionInfo);
				break;
			case 6:
				this.MainFrame.Navigate(typeof(Telemetry), null, this._transitionInfo);
				break;
			case 7:
				this.MainFrame.Navigate(typeof(WindowsComponents), null, this._transitionInfo);
				break;
			case 8:
				this.MainFrame.Navigate(typeof(Act), null, this._transitionInfo);
				break;
			case 9:
				this.MainFrame.Navigate(typeof(AppInstall), null, this._transitionInfo);
				break;
			case 10:
				this.MainFrame.Navigate(typeof(QuickSet), null, this._transitionInfo);
				break;
			case 11:
				this.MainFrame.Navigate(typeof(SAT), null, this._transitionInfo);
				break;
			case 12:
				this.MainFrame.Navigate(typeof(PCI), null, this._transitionInfo);
				break;
			}
			Settings.Default.lastPage = this.Category.SelectedIndex;
			Settings.Default.Save();
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00007F56 File Offset: 0x00006156
		[NullableContext(1)]
		private void MicaWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
		{
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00007F59 File Offset: 0x00006159
		[NullableContext(1)]
		private void MicaWindow_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
		{
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00007F5C File Offset: 0x0000615C
		[NullableContext(1)]
		private void MicaWindow_Loaded(object sender, RoutedEventArgs e)
		{
			bool satstart = Settings.Default.satstart;
			if (satstart)
			{
				this.Category.SelectedIndex = 4;
			}
			else
			{
				bool flag = Settings.Default.lastPage == -1;
				if (flag)
				{
					this.Category.SelectedIndex = 0;
				}
				else
				{
					this.Category.SelectedIndex = Settings.Default.lastPage;
				}
			}
			BackdropType micaType;
			Enum.TryParse<BackdropType>(Settings.Default.style, out micaType);
			MicaWPFServiceUtility.ThemeService.EnableBackdrop(this, micaType);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00007FE4 File Offset: 0x000061E4
		[NullableContext(1)]
		[DebuggerStepThrough]
		public void ChSt(string st)
		{
			MainWindow.<ChSt>d__12 <ChSt>d__ = new MainWindow.<ChSt>d__12();
			<ChSt>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<ChSt>d__.<>4__this = this;
			<ChSt>d__.st = st;
			<ChSt>d__.<>1__state = -1;
			<ChSt>d__.<>t__builder.Start<MainWindow.<ChSt>d__12>(ref <ChSt>d__);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00008024 File Offset: 0x00006224
		[NullableContext(1)]
		public void LoadLang(string lang)
		{
			try
			{
				string language = Settings.Default.lang ?? "en";
				Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "base");
				this.c1.Content = dictionary["catname"]["expl"];
				this.c2.Content = dictionary["catname"]["wu"];
				this.c3.Content = dictionary["catname"]["sr"];
				this.c4.Content = dictionary["catname"]["uwp"];
				this.c5.Content = dictionary["catname"]["per"];
				this.c6.Content = dictionary["catname"]["cm"];
				this.c7.Content = dictionary["catname"]["tel"];
				this.c8.Content = dictionary["catname"]["compon"];
				this.c9.Content = dictionary["catname"]["act"];
				this.c10.Content = dictionary["catname"]["oth"];
				this.c11.Content = dictionary["catname"]["quick"];
				this.c12.Content = dictionary["catname"]["sat"];
				this.c13.Content = dictionary["catname"]["pci"];
				this.rexplorer.Label = dictionary["lowtabs"]["rexp"];
				this.settingsButton.Label = dictionary["lowtabs"]["set"];
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.Message, "MakuTweaker Error", MessageBoxButton.OK, MessageBoxImage.Hand);
				System.Windows.Forms.Application.Restart();
				System.Windows.Application.Current.Shutdown();
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000828C File Offset: 0x0000648C
		[NullableContext(1)]
		private void AnimY(UIElement element, double durationMilliseconds, double from, double to)
		{
			TranslateTransform translateTransform;
			bool flag;
			if (element.RenderTransform != null)
			{
				translateTransform = (element.RenderTransform as TranslateTransform);
				flag = (translateTransform != null);
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			if (flag2)
			{
				double num = translateTransform.Y;
			}
			else
			{
				MatrixTransform matrixTransform;
				bool flag3;
				if (element.RenderTransform != null)
				{
					matrixTransform = (element.RenderTransform as MatrixTransform);
					flag3 = (matrixTransform != null);
				}
				else
				{
					flag3 = false;
				}
				bool flag4 = flag3;
				if (flag4)
				{
					double num = matrixTransform.Matrix.OffsetY;
				}
			}
			DoubleAnimation animation = new DoubleAnimation
			{
				From = new double?(from),
				To = new double?(to),
				Duration = TimeSpan.FromMilliseconds(durationMilliseconds),
				EasingFunction = new QuinticEase
				{
					EasingMode = EasingMode.EaseOut
				}
			};
			bool flag5 = element.RenderTransform == null || !(element.RenderTransform is TranslateTransform);
			if (flag5)
			{
				element.RenderTransform = new TranslateTransform();
			}
			TranslateTransform translateTransform2 = (TranslateTransform)element.RenderTransform;
			translateTransform2.BeginAnimation(TranslateTransform.YProperty, animation);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00008398 File Offset: 0x00006598
		public void RebootNotify(int mode)
		{
			string message = string.Empty;
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "base");
			Icon icon = new Icon(this.GetResourceStream("MakuTweakerNew.MakuT.ico"));
			TaskbarIcon _trayIcon = new TaskbarIcon
			{
				ToolTipText = "MakuTweaker",
				Icon = icon
			};
			bool flag = mode == 1;
			if (flag)
			{
				message = dictionary["def"]["rebnotify"];
			}
			else
			{
				bool flag2 = mode == 2;
				if (flag2)
				{
					message = dictionary["def"]["rebnotifyexplorer"];
				}
				else
				{
					bool flag3 = mode == 3;
					if (flag3)
					{
						message = dictionary["def"]["rebnotifysfc"];
					}
				}
			}
			_trayIcon.ShowBalloonTip("MakuTweaker", message, BalloonIcon.Warning);
			Action <>9__1;
			Task.Delay(8000).ContinueWith(delegate(Task t)
			{
				Dispatcher dispatcher = _trayIcon.Dispatcher;
				Action callback;
				if ((callback = <>9__1) == null)
				{
					callback = (<>9__1 = delegate()
					{
						_trayIcon.Dispose();
					});
				}
				dispatcher.Invoke(callback);
			});
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000084A0 File Offset: 0x000066A0
		[NullableContext(1)]
		private Stream GetResourceStream(string resourceName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(resourceName);
			bool flag = manifestResourceStream == null;
			if (flag)
			{
				throw new FileNotFoundException("Ресурс " + resourceName + " не найден.");
			}
			return manifestResourceStream;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000084E0 File Offset: 0x000066E0
		[NullableContext(1)]
		private void settingsButton_Click(object sender, RoutedEventArgs e)
		{
			this.Category.SelectedIndex = -1;
			this.MainFrame.Navigate(typeof(SettingsAbout), null, this._transitionInfo);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00008510 File Offset: 0x00006710
		[NullableContext(1)]
		private void MainFrame_Navigated(object sender, NavigationEventArgs e)
		{
			bool flag = this.Category.SelectedIndex == -1;
			if (flag)
			{
				this.settingsButton.IsEnabled = false;
			}
			else
			{
				this.settingsButton.IsEnabled = true;
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00008550 File Offset: 0x00006750
		public void expk()
		{
			new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "taskkill",
					Arguments = "/F /IM explorer.exe"
				}
			}.Start();
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00008591 File Offset: 0x00006791
		[NullableContext(1)]
		private void ExpRestart_Tick(object sender, EventArgs e)
		{
			Process.Start("explorer.exe");
			this.ExpRestart.Stop();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000085AB File Offset: 0x000067AB
		[NullableContext(1)]
		private void rexplorer_Click(object sender, RoutedEventArgs e)
		{
			this.expk();
			this.ExpRestart.Start();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000085C4 File Offset: 0x000067C4
		[NullableContext(1)]
		[DebuggerStepThrough]
		private Task CheckForUpd()
		{
			MainWindow.<CheckForUpd>d__22 <CheckForUpd>d__ = new MainWindow.<CheckForUpd>d__22();
			<CheckForUpd>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<CheckForUpd>d__.<>4__this = this;
			<CheckForUpd>d__.<>1__state = -1;
			<CheckForUpd>d__.<>t__builder.Start<MainWindow.<CheckForUpd>d__22>(ref <CheckForUpd>d__);
			return <CheckForUpd>d__.<>t__builder.Task;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00008608 File Offset: 0x00006808
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

		// Token: 0x0400007C RID: 124
		[Nullable(1)]
		private NavigationTransitionInfo _transitionInfo = null;

		// Token: 0x0400007D RID: 125
		[Nullable(1)]
		private DispatcherTimer ExpRestart;

		// Token: 0x0400007E RID: 126
		private bool isAnimating = false;

		// Token: 0x02000029 RID: 41
		public static class Localization
		{
			// Token: 0x06000218 RID: 536 RVA: 0x00018B44 File Offset: 0x00016D44
			[NullableContext(1)]
			public static Dictionary<string, Dictionary<string, string>> LoadLocalization(string language, string category)
			{
				string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "loc");
				string text = Path.Combine(path, language + ".json");
				bool flag = !File.Exists(text);
				if (flag)
				{
					Settings.Default.lang = "en";
					throw new FileNotFoundException("Cannot find a " + text + " localization file.\nPlease reinstall MakuTweaker.\nLanguage has been changed to English.");
				}
				string value = File.ReadAllText(text);
				Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>> dictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Dictionary<string, Dictionary<string, string>>>>>(value);
				bool flag2 = dictionary.ContainsKey("categories");
				if (flag2)
				{
					Dictionary<string, Dictionary<string, Dictionary<string, string>>> dictionary2 = dictionary["categories"];
					bool flag3 = dictionary2.ContainsKey(category);
					if (flag3)
					{
						return dictionary2[category];
					}
				}
				Settings.Default.lang = "en";
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(120, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot find a \"");
				defaultInterpolatedStringHandler.AppendFormatted(category);
				defaultInterpolatedStringHandler.AppendLiteral("\" category in the ");
				defaultInterpolatedStringHandler.AppendFormatted(text);
				defaultInterpolatedStringHandler.AppendLiteral(" localization file.\nPlease reinstall MakuTweaker.\nLanguage has been changed to English.");
				throw new KeyNotFoundException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
		}
	}
}
