using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;

namespace tp2_MaxenceSchroeder.accesDonnees
{
    public partial class App : Application
    {
        private IDbConnection _connexion;

        protected override void OnStartup(StartupEventArgs a)
        {
            base.OnStartup(a);
            string cheminProjet = AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(cheminProjet)
               .AddJsonFile("appsettings.json")
               .Build();

            _connexion = new SqlConnection(configuration.GetConnectionString("SGS"));

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Current.MainWindow = new MainWindow(new UtilisateurDAO(_connexion));

            Current.MainWindow.Show();

        }
        //code de DemoProjetGraphiqueAccesDonnees/App.xaml.cs

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception)e.ExceptionObject;

            File.WriteAllText("errors.txt", exception.ToString());

            FermerApplication();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            FermerApplication();
        }

        private void FermerApplication()
        {
            _connexion?.Dispose();
        }
    }
}