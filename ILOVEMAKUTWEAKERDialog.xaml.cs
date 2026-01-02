using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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
	// Token: 0x02000008 RID: 8
	[NullableContext(1)]
	[Nullable(0)]
	public partial class ILOVEMAKUTWEAKERDialog : ContentDialog
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600005B RID: 91 RVA: 0x0000754F File Offset: 0x0000574F
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00007557 File Offset: 0x00005757
		public TaskCompletionSource<int> TaskCompletionSource { get; private set; }

		// Token: 0x0600005D RID: 93 RVA: 0x00007560 File Offset: 0x00005760
		public ILOVEMAKUTWEAKERDialog(string app)
		{
			this.InitializeComponent();
			string language = Settings.Default.lang ?? "en";
			Dictionary<string, Dictionary<string, string>> dictionary = MainWindow.Localization.LoadLocalization(language, "uwp");
			Run run = new Run();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 3);
			defaultInterpolatedStringHandler.AppendFormatted(dictionary["main"]["suredialogT1"]);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted(app);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted(dictionary["main"]["suredialogT2"]);
			defaultInterpolatedStringHandler.AppendLiteral("\n");
			run.Text = defaultInterpolatedStringHandler.ToStringAndClear();
			run.FontSize = 14.0;
			run.FontFamily = new FontFamily("Segoe UI");
			Run item = run;
			Run item2 = new Run
			{
				Text = dictionary["main"]["suredialogT3"] + "\n",
				FontSize = 14.0,
				FontFamily = new FontFamily("Segoe UI")
			};
			Run item3 = new Run
			{
				Text = (dictionary["main"]["suredialogT4"] ?? ""),
				FontSize = 18.0,
				FontFamily = new FontFamily("Segoe UI Semibold")
			};
			base.CloseButtonText = dictionary["main"]["suredialogNS"];
			this.textBlock.Inlines.Add(item);
			this.textBlock.Inlines.Add(new LineBreak());
			this.textBlock.Inlines.Add(item2);
			this.textBlock.Inlines.Add(new LineBreak());
			this.textBlock.Inlines.Add(item3);
			this.textBlock.TextAlignment = TextAlignment.Left;
			this.TaskCompletionSource = new TaskCompletionSource<int>();
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00007778 File Offset: 0x00005978
		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			bool flag = this.ILOVEMAKUTWEAKER.Text == "ILOVEMAKUTWEAKER";
			if (flag)
			{
				base.PrimaryButtonText = "OK";
			}
			else
			{
				base.PrimaryButtonText = string.Empty;
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000077BD File Offset: 0x000059BD
		private void CloseDialog(int result)
		{
			this.TaskCompletionSource.SetResult(result);
			base.Hide();
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000077D4 File Offset: 0x000059D4
		private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
			this.CloseDialog(1);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000077DF File Offset: 0x000059DF
		private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
			this.CloseDialog(0);
		}
	}
}
