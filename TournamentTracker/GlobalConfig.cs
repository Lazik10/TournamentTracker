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
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }

            if (textFiles)
            {
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }
    }
}
