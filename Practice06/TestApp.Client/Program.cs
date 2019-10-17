using System;
using System.Windows.Forms;
using TestApp.DataContext;
using TestApp.Views;

namespace TestApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string url = System.Configuration.ConfigurationManager.AppSettings["webServiceUrl"];
            Application.Run(new MainForm(new WebApiDataContext(url)));
        }
    }
}
