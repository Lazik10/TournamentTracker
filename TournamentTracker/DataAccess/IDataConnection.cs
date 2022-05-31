using TournamentTrackerLibrary.Models;

namespace TournamentTrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        void CreatePrize(PrizeModel prize);
        void CreatePerson(PersonModel person);
        void CreateTeam(TeamModel team);
        void CreateTournament(TournamentModel tournament);
        List<PersonModel> GetAllPersons();
        List<TeamModel> GetAllTeams();
        List<TournamentModel> GetAllTournaments();
        void UpdateMatchup(MatchupModel matchup);
        void CompleteTournament(int tournamentId);
    }
}
