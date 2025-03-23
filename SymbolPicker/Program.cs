using System;
using System.Runtime.InteropServices;

namespace SymbolPicker
{
    internal static class Program
    {
        public static Settings SettingPage;

        private static Mutex mutex = new Mutex(false, "Global\\_SymbolPicker_");
        public const int MUTEXMESSAGE = 0x8000 + 100; //WM_APP 0x8000 ~ 0xBFFF


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            if (!mutex.WaitOne(100, false))
            {
                SendMutexMsgToWindow();
                Environment.Exit(0);
            }


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        #region mutex send message
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private static void SendMutexMsgToWindow()
        {
            IntPtr targetWindowHandle = FindWindow(null, "Symbol Picker");
            if (targetWindowHandle != IntPtr.Zero)
            {
                SendMessage(targetWindowHandle, MUTEXMESSAGE, IntPtr.Zero, IntPtr.Zero);
            }
            else
            {
                MessageBox.Show("The app is already running, click the icon in the tray to see.");
            }
        }
        #endregion
    }
}
