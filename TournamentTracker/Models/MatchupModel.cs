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
        /// Id of a team which won the match
        /// </summary>
        public int? WinnerId { get; set; }

        /// <summary>
        /// Team info of a winner
        /// </summary>
        public TeamModel? Winner { get; set; }

        /// <summary>
        /// Represents matchup round number
        /// </summary>
        public int MatchupRound { get; set; }

        /// <summary>
        /// String representation of teams competing against each other in a matchup
        /// </summary>
        public string? TeamsCompeting { get; set; }
    }
}
