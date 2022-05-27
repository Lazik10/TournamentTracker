using TournamentTrackerLibrary.Models;

namespace TournamentTrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        PrizeModel CreatePrize(PrizeModel prize);
        PersonModel CreatePerson(PersonModel person);
        TeamModel CreateTeam(TeamModel team);
        TournamentModel CreateTournament(TournamentModel tournament);
        List<PersonModel> GetAllPersons();
        List<TeamModel> GetAllTeams();
        List<TournamentModel> GetAllTournaments();
    }
}
