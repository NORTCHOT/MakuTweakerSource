using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using MakuTweakerNew.Properties;
using ModernWpf.Controls;

namespace MakuTweakerNew
{
	// Token: 0x02000007 RID: 7
	public partial class HidePart : ContentDialog
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00006B9B File Offset: 0x00004D9B
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00006BA3 File Offset: 0x00004DA3
		[Nullable(1)]
		public TaskCompletionSource<decimal> TaskCompletionSource { [NullableContext(1)] get; [NullableContext(1)] private set; }

		// Token: 0x06000054 RID: 84 RVA: 0x00006BAC File Offset: 0x00004DAC
		public HidePart()
		{
			this.InitializeComponent();
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "expl");
			Run item = new Run
			{
				Text = dictionary["status"]["hdInfo1"],
				FontSize = 18.0,
				FontFamily = new FontFamily("Segoe UI Semilight")
			};
			Run item2 = new Run
			{
				Text = dictionary["status"]["hdInfo2"],
				FontSize = 18.0,
				FontFamily = new FontFamily("Segoe UI Semibold")
			};
			base.CloseButtonText = dictionary["status"]["hide"];
			base.PrimaryButtonText = dictionary["status"]["cc"];
			this.textBlock.Inlines.Add(item);
			this.textBlock.Inlines.Add(new LineBreak());
			this.textBlock.Inlines.Add(item2);
			this.textBlock.TextAlignment = TextAlignment.Left;
			this.textBlock.MaxWidth = 500.0;
			this.TaskCompletionSource = new TaskCompletionSource<decimal>();
			bool flag = string.IsNullOrEmpty(Settings.Default.hiddenDrives);
			if (!flag)
			{
				foreach (object obj in this.checkboxpanel.Children)
				{
					CheckBox checkBox = obj as CheckBox;
					bool flag2 = checkBox != null;
					if (flag2)
					{
						bool flag3 = Settings.Default.hiddenDrives.Contains(checkBox.Content.ToString());
						if (flag3)
						{
							checkBox.IsChecked = new bool?(true);
						}
						else
						{
							checkBox.IsChecked = new bool?(false);
						}
					}
				}
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00006DD4 File Offset: 0x00004FD4
		[NullableContext(1)]
		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00006DD7 File Offset: 0x00004FD7
		private void CloseDialog(decimal result)
		{
			this.TaskCompletionSource.SetResult(result);
			base.Hide();
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00006DEE File Offset: 0x00004FEE
		[NullableContext(1)]
		private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
			this.CloseDialog(-1m);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00006E00 File Offset: 0x00005000
		[NullableContext(1)]
		private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
			decimal num = 0m;
			bool valueOrDefault = this.a.IsChecked.GetValueOrDefault();
			if (valueOrDefault)
			{
				num += 1m;
			}
			bool valueOrDefault2 = this.d.IsChecked.GetValueOrDefault();
			if (valueOrDefault2)
			{
				num += 8m;
			}
			bool valueOrDefault3 = this.e.IsChecked.GetValueOrDefault();
			if (valueOrDefault3)
			{
				num += 16m;
			}
			bool valueOrDefault4 = this.f.IsChecked.GetValueOrDefault();
			if (valueOrDefault4)
			{
				num += 32m;
			}
			bool valueOrDefault5 = this.g.IsChecked.GetValueOrDefault();
			if (valueOrDefault5)
			{
				num += 64m;
			}
			bool valueOrDefault6 = this.h.IsChecked.GetValueOrDefault();
			if (valueOrDefault6)
			{
				num += 128m;
			}
			bool valueOrDefault7 = this.i.IsChecked.GetValueOrDefault();
			if (valueOrDefault7)
			{
				num += 256m;
			}
			bool valueOrDefault8 = this.j.IsChecked.GetValueOrDefault();
			if (valueOrDefault8)
			{
				num += 512m;
			}
			bool valueOrDefault9 = this.k.IsChecked.GetValueOrDefault();
			if (valueOrDefault9)
			{
				num += 1024m;
			}
			bool valueOrDefault10 = this.l.IsChecked.GetValueOrDefault();
			if (valueOrDefault10)
			{
				num += 2048m;
			}
			bool valueOrDefault11 = this.m.IsChecked.GetValueOrDefault();
			if (valueOrDefault11)
			{
				num += 4096m;
			}
			bool valueOrDefault12 = this.n.IsChecked.GetValueOrDefault();
			if (valueOrDefault12)
			{
				num += 8192m;
			}
			bool valueOrDefault13 = this.o.IsChecked.GetValueOrDefault();
			if (valueOrDefault13)
			{
				num += 16384m;
			}
			bool valueOrDefault14 = this.p.IsChecked.GetValueOrDefault();
			if (valueOrDefault14)
			{
				num += 32768m;
			}
			bool valueOrDefault15 = this.q.IsChecked.GetValueOrDefault();
			if (valueOrDefault15)
			{
				num += 65536m;
			}
			bool valueOrDefault16 = this.r.IsChecked.GetValueOrDefault();
			if (valueOrDefault16)
			{
				num += 131072m;
			}
			bool valueOrDefault17 = this.s.IsChecked.GetValueOrDefault();
			if (valueOrDefault17)
			{
				num += 262144m;
			}
			bool valueOrDefault18 = this.t.IsChecked.GetValueOrDefault();
			if (valueOrDefault18)
			{
				num += 524288m;
			}
			bool valueOrDefault19 = this.u.IsChecked.GetValueOrDefault();
			if (valueOrDefault19)
			{
				num += 1048576m;
			}
			bool valueOrDefault20 = this.v.IsChecked.GetValueOrDefault();
			if (valueOrDefault20)
			{
				num += 2097152m;
			}
			bool valueOrDefault21 = this.w.IsChecked.GetValueOrDefault();
			if (valueOrDefault21)
			{
				num += 4194304m;
			}
			bool valueOrDefault22 = this.x.IsChecked.GetValueOrDefault();
			if (valueOrDefault22)
			{
				num += 8388608m;
			}
			bool valueOrDefault23 = this.y.IsChecked.GetValueOrDefault();
			if (valueOrDefault23)
			{
				num += 16777216m;
			}
			bool valueOrDefault24 = this.z.IsChecked.GetValueOrDefault();
			if (valueOrDefault24)
			{
				num += 33554432m;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (object obj in this.checkboxpanel.Children)
			{
				CheckBox checkBox = obj as CheckBox;
				bool flag = checkBox != null && checkBox.IsChecked.GetValueOrDefault();
				if (flag)
				{
					stringBuilder.Append(checkBox.Content.ToString());
				}
			}
			Settings.Default.hiddenDrives = stringBuilder.ToString();
			this.CloseDialog(num);
		}
	}
}
