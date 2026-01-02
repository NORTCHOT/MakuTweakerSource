using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using MakuTweakerNew.Properties;
using MicaWPF.Controls;
using MicaWPF.Core.Enums;
using MicaWPF.Core.Services;
using Microsoft.Win32;
using ModernWpf;

namespace MakuTweakerNew
{
	// Token: 0x02000012 RID: 18
	public partial class SettingsAbout : Page
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x0000DB3C File Offset: 0x0000BD3C
		public SettingsAbout()
		{
			this.InitializeComponent();
			this.credN.Text = "Mark Adderly\nNikitori\nNikitori, Massgrave";
			this.lang.SelectedIndex = Settings.Default.langSI;
			this.relang();
			bool flag = this.checkWinVer() < 22000;
			if (flag)
			{
				this.style.Visibility = Visibility.Collapsed;
				this.styleL.Visibility = Visibility.Collapsed;
			}
			WindowsTheme currentTheme = MicaWPFServiceUtility.ThemeService.CurrentTheme;
			this.theme.SelectedIndex = ((currentTheme == WindowsTheme.Dark) ? 1 : 0);
			string text = Settings.Default.style;
			string a = text;
			if (!(a == "Mica"))
			{
				if (!(a == "Tabbed"))
				{
					if (!(a == "Acrylic"))
					{
						if (a == "None")
						{
							this.style.SelectedIndex = 3;
						}
					}
					else
					{
						this.style.SelectedIndex = 2;
					}
				}
				else
				{
					this.style.SelectedIndex = 1;
				}
			}
			else
			{
				this.style.SelectedIndex = 0;
			}
			this.isLoaded = true;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x0000DC7C File Offset: 0x0000BE7C
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

		// Token: 0x060000D7 RID: 215 RVA: 0x0000DD04 File Offset: 0x0000BF04
		[NullableContext(1)]
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Process.Start(new ProcessStartInfo("https://adderly.top")
			{
				UseShellExecute = true
			});
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000DD1F File Offset: 0x0000BF1F
		[NullableContext(1)]
		private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Process.Start(new ProcessStartInfo("https://boosty.to/adderly")
			{
				UseShellExecute = true
			});
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000DD3A File Offset: 0x0000BF3A
		[NullableContext(1)]
		private void Image_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
		{
			Process.Start(new ProcessStartInfo("https://t.me/adderly324")
			{
				UseShellExecute = true
			});
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000DD55 File Offset: 0x0000BF55
		[NullableContext(1)]
		private void Image_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
		{
			Process.Start(new ProcessStartInfo("https://youtube.com/@MakuAdarii")
			{
				UseShellExecute = true
			});
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000DD70 File Offset: 0x0000BF70
		[NullableContext(1)]
		private void theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				int selectedIndex = this.theme.SelectedIndex;
				int num = selectedIndex;
				if (num != 0)
				{
					if (num == 1)
					{
						Settings.Default.theme = "Dark";
						MicaWPFServiceUtility.ThemeService.ChangeTheme(WindowsTheme.Dark);
						ThemeManager.Current.ApplicationTheme = new ApplicationTheme?(ApplicationTheme.Dark);
						this.mw.Foreground = Brushes.White;
						this.mw.Separator.Stroke = Brushes.White;
					}
				}
				else
				{
					Settings.Default.theme = "Light";
					MicaWPFServiceUtility.ThemeService.ChangeTheme(WindowsTheme.Light);
					ThemeManager.Current.ApplicationTheme = new ApplicationTheme?(ApplicationTheme.Light);
					this.mw.Foreground = Brushes.Black;
					this.mw.Separator.Stroke = Brushes.Black;
				}
				Settings.Default.Save();
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0000DE60 File Offset: 0x0000C060
		[NullableContext(1)]
		private void lang_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				switch (this.lang.SelectedIndex)
				{
				case 0:
					Settings.Default.lang = "en";
					break;
				case 1:
					Settings.Default.lang = "ru";
					break;
				case 2:
					Settings.Default.lang = "ua";
					break;
				case 3:
					Settings.Default.lang = "es";
					break;
				case 4:
					Settings.Default.lang = "pt";
					break;
				case 5:
					Settings.Default.lang = "de";
					break;
				case 6:
					Settings.Default.lang = "kz";
					break;
				case 7:
					Settings.Default.lang = "jp";
					break;
				case 8:
					Settings.Default.lang = "cn";
					break;
				case 9:
					Settings.Default.lang = "hi";
					break;
				}
				Settings.Default.langSI = this.lang.SelectedIndex;
				this.mw.LoadLang(Settings.Default.lang);
				this.relang();
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000DFAC File Offset: 0x0000C1AC
		private void relang()
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "ab");
			Dictionary<string, Dictionary<string, string>> dictionary2 = MainWindow.Localization.LoadLocalization(language, "base");
			this.credL.Text = dictionary["main"]["credL"];
			this.label.Text = dictionary["main"]["label"];
			this.web.Content = dictionary["main"]["atop"];
			this.langL.Text = dictionary["main"]["lang"];
			this.styleL.Text = dictionary["main"]["st"];
			this.l.Content = " " + dictionary["main"]["l"];
			this.d.Content = " " + dictionary["main"]["d"];
			this.themeL.Text = dictionary["main"]["th"];
			this.off.Content = " " + dictionary2["def"]["off"];
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000E134 File Offset: 0x0000C334
		[NullableContext(1)]
		private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
		{
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000E137 File Offset: 0x0000C337
		[NullableContext(1)]
		private void Image_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000E13C File Offset: 0x0000C33C
		[NullableContext(1)]
		private void style_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			bool flag = this.isLoaded;
			if (flag)
			{
				switch (this.style.SelectedIndex)
				{
				case 0:
					MicaWPFServiceUtility.ThemeService.EnableBackdrop(this.mw, BackdropType.Mica);
					Settings.Default.style = "Mica";
					break;
				case 1:
					MicaWPFServiceUtility.ThemeService.EnableBackdrop(this.mw, BackdropType.Tabbed);
					Settings.Default.style = "Tabbed";
					break;
				case 2:
					MicaWPFServiceUtility.ThemeService.EnableBackdrop(this.mw, BackdropType.Acrylic);
					Settings.Default.style = "Acrylic";
					break;
				case 3:
					MicaWPFServiceUtility.ThemeService.EnableBackdrop(this.mw, BackdropType.None);
					Settings.Default.style = "None";
					break;
				}
			}
		}

		// Token: 0x0400010F RID: 271
		[Nullable(1)]
		private MainWindow mw = (MainWindow)Application.Current.MainWindow;

		// Token: 0x04000110 RID: 272
		private bool isLoaded = false;

		// Token: 0x04000111 RID: 273
		private bool isDevBuild = true;
	}
}
