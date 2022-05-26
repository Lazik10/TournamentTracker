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
            builder.AddJsonFile("appsettings.json");
            builder.AddUserSecrets(Assembly.GetExecutingAssembly());
            IConfiguration config = builder.Build();

            // Initialize the database connection
            TournamentTrackerLibrary.GlobalConfig.InitializeConnections(false, true);
            TournamentTrackerLibrary.GlobalConfig.SqlConnectionString = config.GetConnectionString("SqlConnection");

            Application.Run(new Forms.CreateTournamentForm());
        }
    }
}