using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkProviderView
{
    static class Program
    {
        public static ProviderViewModel Provider { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            APIClient.Connect();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new FormAuthorization();
            form.ShowDialog();
            if (Provider != null)
            {
                Application.Run(new FormMain());
            }
        }
    }
}
