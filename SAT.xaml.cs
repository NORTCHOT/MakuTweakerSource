using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using MakuTweakerNew.Properties;
using MicaWPF.Controls;

namespace MakuTweakerNew
{
	// Token: 0x02000011 RID: 17
	public partial class SAT : Page
	{
		// Token: 0x060000C4 RID: 196 RVA: 0x0000D424 File Offset: 0x0000B624
		public SAT()
		{
			this.InitializeComponent();
			this.LoadLang();
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "sat");
			int num;
			int.TryParse(this.mins.Text, out num);
			this.hours.Text = dictionary["main"]["minho"] + Math.Round((double)num / 60.0, 2).ToString();
			this.isLoaded = true;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000D4C8 File Offset: 0x0000B6C8
		[NullableContext(1)]
		private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			IEnumerable<char> text = e.Text;
			Func<char, bool> predicate;
			if ((predicate = SAT.<>O.<0>__IsDigit) == null)
			{
				predicate = (SAT.<>O.<0>__IsDigit = new Func<char, bool>(char.IsDigit));
			}
			e.Handled = !text.All(predicate);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000D4FC File Offset: 0x0000B6FC
		[NullableContext(1)]
		private void time_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			this.mins.Text = Math.Round(this.time.Value * 5.0).ToString();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000D538 File Offset: 0x0000B738
		[NullableContext(1)]
		private void mins_TextChanged(object sender, TextChangedEventArgs e)
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "sat");
			int num;
			int.TryParse(this.mins.Text, out num);
			this.hours.Text = dictionary["main"]["minho"] + Math.Round((double)num / 60.0, 2).ToString();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000D5B9 File Offset: 0x0000B7B9
		[NullableContext(1)]
		private void mins_GotFocus(object sender, RoutedEventArgs e)
		{
			this.mins.Dispatcher.InvokeAsync(delegate()
			{
				this.mins.SelectAll();
			}, DispatcherPriority.Input);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000D5DA File Offset: 0x0000B7DA
		[NullableContext(1)]
		private void tenM_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("C:\\Windows\\System32\\shutdown.exe", " -s -t 600");
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000D5ED File Offset: 0x0000B7ED
		[NullableContext(1)]
		private void threeM_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("C:\\Windows\\System32\\shutdown.exe", " -s -t 1800");
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000D600 File Offset: 0x0000B800
		[NullableContext(1)]
		private void oneH_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("C:\\Windows\\System32\\shutdown.exe", " -s -t 3600");
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000D613 File Offset: 0x0000B813
		[NullableContext(1)]
		private void twoH_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("C:\\Windows\\System32\\shutdown.exe", " -s -t 7200");
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000D626 File Offset: 0x0000B826
		[NullableContext(1)]
		private void fourH_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("C:\\Windows\\System32\\shutdown.exe", " -s -t 14400");
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000D639 File Offset: 0x0000B839
		[NullableContext(1)]
		private void sixH_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("C:\\Windows\\System32\\shutdown.exe", " -s -t 21600");
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000D64C File Offset: 0x0000B84C
		[NullableContext(1)]
		private void shut_Click(object sender, RoutedEventArgs e)
		{
			double num = Convert.ToDouble(this.mins.Text);
			double num2 = Convert.ToDouble(60);
			Process.Start("C:\\Windows\\System32\\shutdown.exe", " -s -t " + Convert.ToString(num * num2));
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0000D690 File Offset: 0x0000B890
		[NullableContext(1)]
		private void cancel_Click(object sender, RoutedEventArgs e)
		{
			Process.Start("C:\\Windows\\System32\\shutdown.exe", " -a");
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000D6A4 File Offset: 0x0000B8A4
		private void LoadLang()
		{
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "sat");
			this.label.Text = dictionary["main"]["label"];
			this.sat.Text = dictionary["main"]["info"];
			this.hours.Text = dictionary["main"]["minho"];
			this.os.Text = dictionary["main"]["os"];
			this.oned.Text = dictionary["main"]["oned"];
			this.tenM.Content = dictionary["main"]["tenM"];
			this.threeM.Content = dictionary["main"]["threeM"];
			this.oneH.Content = dictionary["main"]["oneH"];
			this.twoH.Content = dictionary["main"]["twoH"];
			this.fourH.Content = dictionary["main"]["fourH"];
			this.sixH.Content = dictionary["main"]["sixH"];
			this.shut.Content = dictionary["main"]["b1"];
			this.cancel.Content = dictionary["main"]["b2"];
		}

		// Token: 0x040000FE RID: 254
		private bool isLoaded = false;

		// Token: 0x02000037 RID: 55
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x04000270 RID: 624
			public static Func<char, bool> <0>__IsDigit;
		}
	}
}
