﻿using System;
using System.Threading.Tasks;
using Gtk;
using NewLife.Log;
using NewLife.Threading;

namespace XCoder
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XTrace.UseConsole();

            GLib.ExceptionManager.UnhandledException += ExceptionManager_UnhandledException;

            // 检查环境
            GtkHelper.CheckRuntime();

            Application.Init();
            var window = new SharpApp();
            window.ShowAll();
            // Window.InteractiveDebugging = true;
            //XTrace2.UseWinForm(window);
            Application.Run();
        }

        private static void ExceptionManager_UnhandledException(GLib.UnhandledExceptionArgs args)
        {
            if (args.ExceptionObject is Exception ex) XTrace.WriteException(ex);
        }
    }
}
