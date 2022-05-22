namespace TournamentTrackerLibrary.Models
{
    public class MatchupModel
    {
        /// <summary>
        /// Contains two teams compeating against each other
        /// </summary>
        public List<MatchupModel> Entries { get; set; } = new List<MatchupModel>();

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
