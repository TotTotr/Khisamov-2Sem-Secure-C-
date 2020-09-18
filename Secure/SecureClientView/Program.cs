using SecureLogic.ViewModels;
using System;
using System.Windows.Forms;

namespace SecureClientView
{
    static class Program
    {
        public static ClientViewModel Client { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ClientApi.Connect();

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
