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
        public void CreatePrize(PrizeModel prize)
        {
            List<PrizeModel> prizes = GlobalConfig.PrizeFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            int currentId = 1;

            if (prizes.Count > 0)
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            
            prize.Id = currentId;

            prizes.Add(prize);
            prizes.SaveToPrizeFile();
        }

        /// <summary>
        /// Creates new contestant (person) and stores it in csv file with unique ID
        /// </summary>
        /// <param name="prize">Person informations</param>
        /// <returns>Person with unique ID</returns>
        public void CreatePerson(PersonModel person)
        {
            List<PersonModel> contestants = GlobalConfig.ContestantFile.FullFilePath().LoadFile().ConvertToPersonModels();

            int currentId = 1;

            if (contestants.Count > 0)
                currentId = contestants.OrderByDescending(x => x.Id).First().Id + 1;

            person.Id = currentId;

            contestants.Add(person);
            contestants.SaveToContestantsFile();
        }

        public List<PersonModel> GetAllPersons()
        {
            return GlobalConfig.ContestantFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public void CreateTeam(TeamModel team)
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
        }

        public List<TeamModel> GetAllTeams()
        {
            return GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
        }

        public void CreateTournament(TournamentModel tournament)
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
        }

        public List<TournamentModel> GetAllTournaments()
        {
            return GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModels();
        }

        public void UpdateMatchup(MatchupModel matchup)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();
            List<MatchupTeamInfoModel> teamInfoModels = GlobalConfig.MatchupTeamFile.FullFilePath().LoadFile().ConvertToTeamInfoModels();

            MatchupModel updatedMatchup = matchups.Where(x => x.Id == matchup.Id).First();
            updatedMatchup.Winner = matchup.Winner;
            updatedMatchup.WinnerId = matchup.WinnerId;

            TextConnectorProcessor.SaveToMatchupFile(matchups);

            for (int i = 0; i < 2; i++)
            {
                if (matchup.TeamsInfo[i].TeamCompetingId != null)
                {
                    MatchupTeamInfoModel teamInfoModel = new MatchupTeamInfoModel();
                    var query = teamInfoModels.Where(x => x.MatchupId == matchup.Id && matchup.TeamsInfo[i].TeamCompetingId == x.TeamCompetingId);
                    if (query.Any())
                    {
                        teamInfoModel = teamInfoModels.First();
                        teamInfoModel.Score = matchup.TeamsInfo[i].Score;
                    }
                }
            }
            TextConnectorProcessor.SaveToTeamInfoFile(teamInfoModels);
        }

        public void CompleteTournament(int tournamentId)
        {
            // TODO - Implement saving active/finnished status stored in text file as well 
        }
    }
}
