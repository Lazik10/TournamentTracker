using TournamentTrackerLibrary.Logic;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace TournamentTrackerUI
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Load appsettings file
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", true, true);
            builder.AddUserSecrets(Assembly.GetExecutingAssembly());
            IConfiguration config = builder.Build();

            // Initialize the database connection
            TournamentTrackerLibrary.GlobalConfig.InitializeConnections(true, false);
            TournamentTrackerLibrary.GlobalConfig.SqlConnectionString = config.GetConnectionString("SqlConnection");

            // Initialize email data
            Email.Port = int.Parse(config["Smtp:Port"]);
            Email.Connection = config["Smtp:Host"];
            Email.Login = config["Smtp:Login"];
            Email.Password = config["Smtp:Password"];

            Application.Run(new Forms.TournamentDashboardForm());
        }
    }
}