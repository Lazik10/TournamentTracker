namespace TournamentTrackerLibrary.Models
{
    public class MatchupModel
    {
        /// <summary>
        /// Unique identification od a matchup
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Contains two teams compeating against each other
        /// </summary>
        public List<MatchupTeamInfoModel> TeamsInfo { get; set; } = new List<MatchupTeamInfoModel>();

        /// <summary>
        /// Represents winner of the matchup
        /// </summary>
        public TeamModel? Winner { get; set; }

        /// <summary>
        /// Represents matchup round number
        /// </summary>
        public int MatchupRound { get; set; }
    }
}
