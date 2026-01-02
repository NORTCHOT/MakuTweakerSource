using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using MakuTweakerNew.Properties;

namespace MakuTweakerNew
{
	// Token: 0x02000003 RID: 3
	[NullableContext(1)]
	[Nullable(0)]
	public partial class App : Application
	{
		// Token: 0x06000018 RID: 24 RVA: 0x00002EAD File Offset: 0x000010AD
		protected override void OnStartup(StartupEventArgs e)
		{
			Environment.SetEnvironmentVariable("LHM_NO_RING0", "1");
			base.OnStartup(e);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002EC8 File Offset: 0x000010C8
		public App()
		{
			base.DispatcherUnhandledException += this.OnDispatcherUnhandledException;
			AppDomain.CurrentDomain.UnhandledException += this.OnUnhandledException;
			TaskScheduler.UnobservedTaskException += this.OnUnobservedTaskException;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002F25 File Offset: 0x00001125
		private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			this.HandleCrash("Unhandled UI Exception", e.Exception, 2);
			e.Handled = true;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002F43 File Offset: 0x00001143
		private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			this.HandleCrash("Unhandled Critical Exception", e.ExceptionObject as Exception, 1);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002F5E File Offset: 0x0000115E
		private void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
		{
			this.HandleCrash("Unhandled Task Exception", e.Exception, 3);
			e.SetObserved();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002F7C File Offset: 0x0000117C
		private void HandleCrash(string errorType, [Nullable(2)] Exception ex, int exitCode)
		{
			bool flag = ex == null;
			if (!flag)
			{
				Exception ex2 = ex.InnerException ?? ex;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 3);
				defaultInterpolatedStringHandler.AppendLiteral("MakuTweaker ");
				defaultInterpolatedStringHandler.AppendFormatted(Settings.Default.ver);
				defaultInterpolatedStringHandler.AppendLiteral(" Crash [");
				defaultInterpolatedStringHandler.AppendFormatted<DateTime>(DateTime.Now, "yyyy-MM-dd HH:mm:ss");
				defaultInterpolatedStringHandler.AppendLiteral("]\n");
				defaultInterpolatedStringHandler.AppendFormatted(errorType);
				defaultInterpolatedStringHandler.AppendLiteral("\n\n");
				string text = defaultInterpolatedStringHandler.ToStringAndClear() + this.GetExceptionDetails(ex2);
				try
				{
					Directory.CreateDirectory(this.logFolder);
					string path = this.logFolder;
					defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
					defaultInterpolatedStringHandler.AppendLiteral("makutw-crash_");
					defaultInterpolatedStringHandler.AppendFormatted<DateTime>(DateTime.Now, "yyyy-MM-dd_HH-mm-ss");
					defaultInterpolatedStringHandler.AppendLiteral(".txt");
					string path2 = Path.Combine(path, defaultInterpolatedStringHandler.ToStringAndClear());
					string str = "If MakuTweaker crashed through no fault of your own, please report this crash in the chat:\r\nhttps://t.me/adderlychat\n\nЕсли MakuTweaker крашнулся не по вашей вине, то, пожалуйста, сообщите об этом краше в чат:\r\nhttps://t.me/adderlychat";
					text = text + "\n\n" + str;
					File.WriteAllText(path2, text);
					MessageBox.Show("Unfortunately, MakuTweaker Has Crashed! :(\n\nError: " + ex2.Message + "\n\nCrash Log Saved To Desktop.", "MakuTweaker Crash", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				catch
				{
					MessageBox.Show("Unfortunately, MakuTweaker Has Crashed! :(\n\nError: " + ex2.Message + "\n\nCrash Log Failed to Save.", "MakuTweaker Crash", MessageBoxButton.OK, MessageBoxImage.Hand);
				}
				Application.Current.Shutdown(exitCode);
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003100 File Offset: 0x00001300
		private string GetExceptionDetails(Exception ex)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(51, 4);
			defaultInterpolatedStringHandler.AppendLiteral("[Message]\n");
			defaultInterpolatedStringHandler.AppendFormatted(ex.Message);
			defaultInterpolatedStringHandler.AppendLiteral("\n\n");
			defaultInterpolatedStringHandler.AppendLiteral("[StackTrace]\n");
			defaultInterpolatedStringHandler.AppendFormatted(ex.StackTrace);
			defaultInterpolatedStringHandler.AppendLiteral("\n\n");
			defaultInterpolatedStringHandler.AppendLiteral("[TargetSite]\n");
			defaultInterpolatedStringHandler.AppendFormatted<MethodBase>(ex.TargetSite);
			defaultInterpolatedStringHandler.AppendLiteral("\n\n");
			defaultInterpolatedStringHandler.AppendLiteral("[Data]\n");
			defaultInterpolatedStringHandler.AppendFormatted((ex.Data.Count > 0) ? string.Join(", ", new object[]
			{
				ex.Data.Keys
			}) : "No Data");
			defaultInterpolatedStringHandler.AppendLiteral("\n\n");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x04000012 RID: 18
		private readonly string logFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
	}
}
