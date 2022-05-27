using TournamentTrackerLibrary.DataAccess.Helpers;
using TournamentTrackerLibrary.Models;

namespace TournamentTrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        /// <summary>
        /// Creates new prize and stores it in csv file with unique ID
        /// </summary>
        /// <param name="prize">Prize informations</param>
        /// <returns>Prize with unique ID</returns>
        public PrizeModel CreatePrize(PrizeModel prize)
        {
            List<PrizeModel> prizes = GlobalConfig.PrizeFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            int currentId = 1;

            if (prizes.Count > 0)
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            
            prize.Id = currentId;

            prizes.Add(prize);
            prizes.SaveToPrizeFile();

            return prize;
        }

        /// <summary>
        /// Creates new contestant (person) and stores it in csv file with unique ID
        /// </summary>
        /// <param name="prize">Person informations</param>
        /// <returns>Person with unique ID</returns>
        public PersonModel CreatePerson(PersonModel person)
        {
            List<PersonModel> contestants = GlobalConfig.ContestantFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int currentId = 1;

            if (contestants.Count > 0)
                currentId = contestants.OrderByDescending(x => x.Id).First().Id + 1;

            person.Id = currentId;

            contestants.Add(person);
            contestants.SaveToContestantsFile();

            return person;
        }

        public List<PersonModel> GetAllPersons()
        {
            return GlobalConfig.ContestantFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public TeamModel CreateTeam(TeamModel team)
        {
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();

            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            team.Id = currentId;
            teams.Add(team);

            teams.SaveToTeamsFile();

            return team;
        }

        public List<TeamModel> GetAllTeams()
        {
            return GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
        }

        public TournamentModel CreateTournament(TournamentModel tournament)
        {
            List<TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();

            int currentId = 1;

            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }

            tournament.Id = currentId;
            tournament.SaveTournamentMatchups();
            
            tournaments.Add(tournament);
            tournaments.SaveToTournamentFile();

            return tournament;
        }

        public List<TournamentModel> GetAllTournaments()
        {
            return GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();
        }
    }
}
