namespace TournamentTrackerLibrary.Models
{
    public class TournamentModel
    {
        /// <summary>
        /// Unique identificator of a tournament
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Tournament name
        /// </summary>
        public string TournamentName { get; set; }

        /// <summary>
        /// Tournament's entry fee
        /// </summary>
        public decimal EntryFee { get; set; }

        /// <summary>
        /// List of teams in the current tournament
        /// </summary>
        public List<TeamModel> EntryTeams { get; set; } = new List<TeamModel>();

        /// <summary>
        /// List of prizes in the current tournament
        /// </summary>
        public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();

        /// <summary>
        /// List of rounds in the current tournament
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();

        public bool Active { get; set; } = true;
    }
}
