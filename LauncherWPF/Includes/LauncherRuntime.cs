﻿using System.Threading.Tasks;
using H2Shield.Includes;
using Cartographer_Launcher.Includes.Dependencies;
using Cartographer_Launcher.Includes.Settings;
using LauncherWPF;
using System.Diagnostics;

namespace Cartographer_Launcher.Includes
{
	public static class LauncherRuntime
	{
		private static WebHandler _WebControl;
		private static GameLaunch _GameRuntime;
		private static Launcher _LauncherSettings;
		private static ProjectCartographer _ProjectSettings;
		private static H2Startup _GSSettings;
		private static MainWindow _MainWindow;
		private static Methods _Methods;

		public static WebHandler WebControl
		{
			get
			{
				if (_WebControl == null) _WebControl = new WebHandler();
				return _WebControl;
			}
		}

		public static GameLaunch GameRuntime
		{
			get
			{
				if (_GameRuntime == null) _GameRuntime = new GameLaunch();
				return _GameRuntime;
			}
		}

		public static Launcher LauncherSettings
		{
			get
			{
				if (_LauncherSettings == null) _LauncherSettings = new Launcher();
				return _LauncherSettings;
			}
		}

		public static ProjectCartographer ProjectSettings
		{
			get
			{
				if (_ProjectSettings == null) _ProjectSettings = new ProjectCartographer();
				return _ProjectSettings;
			}
		}

		public static H2Startup GSSettings
		{
			get
			{
				if (_GSSettings == null) _GSSettings = new H2Startup();
				return _GSSettings;
			}
		}

		public static MainWindow MainWindow
		{
			get
			{
				if (_MainWindow == null) _MainWindow = new MainWindow();
				return _MainWindow;
			}
		}

		public static Methods Methods
		{
			get
			{
				if (_Methods == null) _Methods = new Methods();
				return _Methods;
			}
		}

		public static async void StartHalo(string Gamertag, string LoginToken, MainWindow MainForm)
		{
			MainForm.Hide();
			int RunningTicks = 0;

			await Task.Delay(500).ContinueWith(_ => { MainForm.Dispatcher.Invoke(() => { GameRuntime.RunGame(); }); });
			while (Process.GetProcessesByName("halo2").Length == 1)
			{
				if (RunningTicks == 16) RunningTicks = 0;
				else RunningTicks++;
				await Task.Delay(1000);
			}
			MainForm.PlayCheck = false;
			MainForm.Show();
		}
	}
}