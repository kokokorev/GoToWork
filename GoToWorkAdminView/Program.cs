using System;
using System.Configuration;
using System.Windows.Forms;
using GoToWorkBusinessLogic.BusinessLogics;
using GoToWorkBusinessLogic.HelperModels;
using GoToWorkBusinessLogic.Interfaces;
using GoToWorkDatabaseImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace GoToWorkAdminView
{
    static class Program
    {
        public static string Email { get; set; }
        public static string Password { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = ConfigurationManager.AppSettings["SmtpClientHost"],
                SmtpClientPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpClientPort"]),
                MailLogin = ConfigurationManager.AppSettings["MailLogin"],
                MailPassword = ConfigurationManager.AppSettings["MailPassword"],
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new FormAuthorization();
            form.ShowDialog();

            if (Email == "123" && Password == "123")
            {
                Application.Run(container.Resolve<FormAdmin>());
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IToyLogic, ToyLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPartLogic, PartLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRequestLogic, RequestLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PartStatusLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}