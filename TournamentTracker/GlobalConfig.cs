using TournamentTrackerLibrary.DataAccess;

namespace TournamentTrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
        public static string? SqlConnectionString { get; set; }

        public static void InitializeConnections(bool database, bool textFiles)
        {
            if (database)
            {
                // TODO - Set up the SQL Connector properly
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }

            if (textFiles)
            {
                // TODO - Create the Text Connection
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }
    }
}
