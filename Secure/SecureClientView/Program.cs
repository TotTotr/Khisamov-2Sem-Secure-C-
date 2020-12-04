using SecureLogic.ViewModels;
using System;
using System.Windows.Forms;
using SecureLogic.BusinessLogic;
using SecureLogic.HelperModels;
using SecureLogic.Attributes;
using SecureShopDatabaseImplement.Implements;
using System.Configuration;
using SecureLogic.Interfaces;
using Unity;
using System.Threading;
using Unity.Lifetime;
using System.Collections.Generic;

namespace SecureClientView
{
    static class Program
    {
        public static ClientViewModel Client { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ClientApi.Connect();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new FormEnter();
            form.ShowDialog();
            if (Client != null)
            {
                Application.Run(new FormMain());
            }
        }
    }
}