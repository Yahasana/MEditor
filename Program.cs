using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MEditor.Properties;

namespace MEditor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (s, args) => {
                int idx = args.Name.IndexOf(',');
                string dllName = idx != -1
                    ? args.Name.Substring(0, idx)
                    : args.Name.Replace(".dll", "");

                return dllName == "ICSharpCode.AvalonEdit" 
                    ? Assembly.Load(Resources.ICSharpCode_AvalonEdit) 
                    : null;
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         //   Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new frmMain());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Sorry，出现了一个错误！如果严重的影响了您的工作，请将它发给我allen.fantasy@gmail.com\n\n" + e.Exception.StackTrace);
        }
    }
}