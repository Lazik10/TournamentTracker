namespace TournamentTrackerLibrary.Models
{
    public class TeamModel
    {
        /// <summary>
        /// List of team members in a team
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

        /// <summary>
        /// Team name
        /// </summary>
        public string? TeamName { get; set; }
    }
}
