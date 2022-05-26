using TournamentTrackerLibrary.DataAccess;

namespace TournamentTrackerLibrary
{
    public static class GlobalConfig
    {
        public const string PrizeFile = "PrizeModels.csv";
        public const string ContestantFile = "ContestantModels.csv";
        public const string TeamFile = "TeamModels.csv";
        public const string TournamentFile = "TournamentModels.csv";
        public const string MatchupFile = "MatchupModels.csv";
        public const string MatchupTeamFile = "MatchupTeamsInfoModels.csv";

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
