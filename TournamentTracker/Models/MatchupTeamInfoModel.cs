namespace TournamentTrackerLibrary.Models
{
    public class MatchupTeamInfoModel
    {
        /// <summary>
        /// Unique identification od a matchup
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id of a matchup this team info belongs to
        /// </summary>
        public int MatchupId { get; set; }

        /// <summary>
        /// Represents the matchup that this team came from as the winner
        /// </summary>
        public int? ParentMatchupId { get; set; }

        /// <summary>
        /// Actual parent matchup model
        /// </summary>
        public MatchupModel? ParentMatchup { get; set; }

        /// <summary>
        /// ID of a team this team info belongs to
        /// </summary>
        public int? TeamCompetingId { get; set; }

        /// <summary>
        /// Actual team this matchup team info belongs to
        /// </summary>
        public TeamModel? TeamCompeting { get; set; }

        /// <summary>
        /// Represents the score for this particular team
        /// </summary>
        public double? Score { get; set; }
    }
}
