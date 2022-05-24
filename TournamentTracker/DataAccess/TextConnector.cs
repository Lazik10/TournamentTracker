using TournamentTrackerLibrary.DataAccess.Helpers;
using TournamentTrackerLibrary.Models;

namespace TournamentTrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizeFile = "PrizeModels.csv";
        private const string ContestantFile = "ContestantModels.csv";
        private const string TeamFile = "TeamModels.csv";

        /// <summary>
        /// Creates new prize and stores it in csv file with unique ID
        /// </summary>
        /// <param name="prize">Prize informations</param>
        /// <returns>Prize with unique ID</returns>
        public PrizeModel CreatePrize(PrizeModel prize)
        {
            List<PrizeModel> prizes = PrizeFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            int currentId = 1;

            if (prizes.Count > 0)
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            
            prize.Id = currentId;

            prizes.Add(prize);
            prizes.SaveToPrizeFile(PrizeFile);

            return prize;
        }

        /// <summary>
        /// Creates new contestant (person) and stores it in csv file with unique ID
        /// </summary>
        /// <param name="prize">Person informations</param>
        /// <returns>Person with unique ID</returns>
        public PersonModel CreatePerson(PersonModel person)
        {
            List<PersonModel> contestants = ContestantFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int currentId = 1;

            if (contestants.Count > 0)
                currentId = contestants.OrderByDescending(x => x.Id).First().Id + 1;

            person.Id = currentId;

            contestants.Add(person);
            contestants.SaveToContestantsFile(ContestantFile);

            return person;
        }

        public List<PersonModel> GetAllPersons()
        {
            return ContestantFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public TeamModel CreateTeam(TeamModel team)
        {
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(ContestantFile);

            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            team.Id = currentId;
            teams.Add(team);

            teams.SaveToTeamsFile(TeamFile);

            return team;
        }
    }
}
