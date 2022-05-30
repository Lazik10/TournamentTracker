using System.Data;
using System.Data.SqlClient;
using TournamentTrackerLibrary.Models;
using Dapper;

namespace TournamentTrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        /// <summary>
        /// Saves a new prize to a database
        /// </summary>
        /// <param name="prize">The prize informations</param>
        /// <returns>The prize informations with unique identifier</returns>
        public void CreatePrize(PrizeModel prize)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.SqlConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PlaceNumber", prize.PlaceNumber);
                parameters.Add("@PlaceName", prize.PlaceName);
                parameters.Add("@PrizeAmount", prize.PrizeAmount);
                parameters.Add("@PrizePercentage", prize.PrizePercentage);
                parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", parameters, commandType: CommandType.StoredProcedure);

                prize.Id = parameters.Get<int>("id");
            }
        }

        /// <summary>
        /// Saves a new person (contestant) into the database
        /// </summary>
        /// <param name="person">Person informations</param>
        /// <returns>Peerson information with specific unique identifier</returns>
        public void CreatePerson(PersonModel person)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.SqlConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PersonFirstName", person.FirstName);
                parameters.Add("@PersonLastName", person.LastName);
                parameters.Add("@PersonEmail", person.Address);
                parameters.Add("@PersonPhone", person.PhoneNumber);
                parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spContestants_Insert", parameters, commandType: CommandType.StoredProcedure);

                person.Id = parameters.Get<int>("id");
            }
        }

        public List<PersonModel> GetAllPersons()
        {
            List<PersonModel> persons = new List<PersonModel>();

            using (IDbConnection connection = new SqlConnection(GlobalConfig.SqlConnectionString))
            {
                persons = connection.Query<PersonModel>("dbo.spContestants_GetAll").ToList();
            }

            return persons;
        }

        public void CreateTeam(TeamModel team)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.SqlConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TeamName", team.TeamName);
                parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeams_Insert", parameters, commandType: CommandType.StoredProcedure);

                team.Id = parameters.Get<int>("id");

                foreach  (PersonModel teamMember in team.TeamMembers)
                {
                    parameters = new DynamicParameters();
                    parameters.Add("@TeamId", team.Id);
                    parameters.Add("@ContestantId", teamMember.Id);

                    connection.Execute("dbo.spTeamMembers_Insert", parameters, commandType: CommandType.StoredProcedure);
                }
            }
        }

        public List<TeamModel> GetAllTeams()
        {
            List<TeamModel> teams = new List<TeamModel>();

            using (IDbConnection connection = new SqlConnection(GlobalConfig.SqlConnectionString))
            {
                teams = connection.Query<TeamModel>("dbo.spTeams_GetAll").ToList();

                foreach (TeamModel team in teams)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@TeamId", team.Id);
                    team.TeamMembers = connection.Query<PersonModel>("dbo.spTeamMembers_GetByTeamId", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }

            return teams;
        }

        public void CreateTournament(TournamentModel tournament)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.SqlConnectionString))
            {
                SaveTournament(connection, tournament);
                SaveTournamentTeams(connection, tournament);
                SaveTournamentPrizes(connection, tournament);
                SaveTournamentRounds(connection, tournament);
            }
        }

        private void SaveTournamentRounds(IDbConnection connection, TournamentModel tournament)
        {
            Queue<int> parentMatchupIds = new Queue<int>();
            int roundId = 0;

            foreach (List<MatchupModel> round in tournament.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    SaveMatchup(connection, matchup, tournament.Id);
                    parentMatchupIds.Enqueue(matchup.Id);

                    foreach (MatchupTeamInfoModel teamInfo in matchup.TeamsInfo)
                    {
                        if (roundId > 0)
                            teamInfo.ParentMatchupId = parentMatchupIds.Dequeue();

                        teamInfo.MatchupId = matchup.Id;
                        SaveTeamInfo(connection, teamInfo, matchup.Id);
                    }
                }
                roundId++;
            }
        }

        private void SaveTeamInfo(IDbConnection connection, MatchupTeamInfoModel teamInfoModel, int matchupId)
        {
            var parameters = new DynamicParameters();
                parameters.Add("@MatchupId", matchupId);
                parameters.Add("@ParentMatchupId",teamInfoModel.ParentMatchupId);
                parameters.Add("@TeamCompetingId", teamInfoModel.TeamCompetingId);
                parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spMatchupTeams_Insert", parameters, commandType: CommandType.StoredProcedure);
        }

        private int SaveMatchup(IDbConnection connection, MatchupModel matchup, int tournamentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TournamentId", tournamentId);
            parameters.Add("@MatchupRound", matchup.MatchupRound);
            parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spMatchups_Insert", parameters, commandType: CommandType.StoredProcedure);

            matchup.Id = parameters.Get<int>("id");

            return matchup.Id;
        }

        private void SaveTournament(IDbConnection connection, TournamentModel tournament)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@TournamentName", tournament.TournamentName);
            parameters.Add("@EntryFee", tournament.EntryFee);
            parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spTournaments_Insert", parameters, commandType: CommandType.StoredProcedure);

            tournament.Id = parameters.Get<int>("id");
        }

        private void SaveTournamentTeams(IDbConnection connection, TournamentModel tournament)
        {
            foreach (TeamModel team in tournament.EntryTeams)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TournamentId", tournament.Id);
                parameters.Add("@TeamId", team.Id);

                connection.Execute("dbo.spTournamentTeams_Insert", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournamentPrizes(IDbConnection connection, TournamentModel tournament)
        {
            foreach (PrizeModel prize in tournament.Prizes)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@TournamentId", tournament.Id);
                parameters.Add("@PrizeId", prize.Id);

                connection.Execute("dbo.spTournamentPrizes_Insert", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public List<TournamentModel> GetAllTournaments()
        {
            List<TournamentModel> tournaments = new List<TournamentModel>();

            using (IDbConnection connection = new SqlConnection(GlobalConfig.SqlConnectionString))
            {
                tournaments = connection.Query<TournamentModel>("dbo.spTournaments_GetAll").ToList();

                foreach (TournamentModel tournament in tournaments)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@TournamentId", tournament.Id);

                    // Populate prizes
                    tournament.Prizes = connection.Query<PrizeModel>("dbo.spPrizes_GetByTournamentId", parameters, commandType: CommandType.StoredProcedure).ToList();
                    // Populate teams
                    tournament.EntryTeams = connection.Query<TeamModel>("dbo.spTeams_GetByTournamentId", parameters, commandType: CommandType.StoredProcedure).ToList();
                    // For each team populate its members
                    foreach (TeamModel team in tournament.EntryTeams)
                    {
                        parameters = new DynamicParameters();
                        parameters.Add("@TeamId", team.Id);

                        team.TeamMembers = connection.Query<PersonModel>("dbo.spContestants_GetByTeamId", parameters, commandType: CommandType.StoredProcedure).ToList();
                    }

                    // Populate rounds
                    parameters = new DynamicParameters();
                    parameters.Add("TournamentId", tournament.Id);
                    List<MatchupModel> matchups = connection.Query<MatchupModel>("dbo.spMatchups_GetByTournamentId", parameters, commandType: CommandType.StoredProcedure).ToList();
                    if (matchups.Count > 0)
                    {
                        int maxRound = matchups.Select(x => x.MatchupRound).Max();

                        for (int i = 1; i <= maxRound; i++)
                        {
                            List<MatchupModel> round = matchups.Where(x => x.MatchupRound == i).ToList();

                            tournament.Rounds.Add(round);
                        }

                        // Populate Matchups
                        foreach (MatchupModel matchup in matchups)
                        {
                            parameters = new DynamicParameters();
                            parameters.Add("@MatchupId", matchup.Id);
                            matchup.TeamsInfo = connection.Query<MatchupTeamInfoModel>("dbo.spMatchupTeams_GetByMatchupId", parameters, commandType: CommandType.StoredProcedure).ToList();
                            
                            if (matchup.WinnerId > 0)
                            {
                                matchup.Winner = tournament.EntryTeams.Where(x => x.Id == matchup.WinnerId).First();
                            }

                            // Populate MatchupTeamInfo
                            foreach (MatchupTeamInfoModel teamInfoModel in matchup.TeamsInfo)
                            {
                                if (teamInfoModel.TeamCompetingId is not null)
                                    teamInfoModel.TeamCompeting = tournament.EntryTeams.Where(x => x.Id == teamInfoModel.TeamCompetingId).First();

                                if (teamInfoModel.ParentMatchupId is not null && teamInfoModel.ParentMatchupId != 0)
                                    teamInfoModel.ParentMatchup = matchups.Where(x => x.Id == teamInfoModel.ParentMatchupId).First();

                                teamInfoModel.MatchupId = matchup.Id;
                            }

                            string? firstTeamName = matchup.TeamsInfo[0].TeamCompeting?.TeamName;
                            string? secondTeamName = matchup.TeamsInfo[1].TeamCompeting?.TeamName;

                            matchup.TeamsCompeting = firstTeamName is null ? "Bye" : firstTeamName;
                            matchup.TeamsCompeting += " vs ";
                            matchup.TeamsCompeting += secondTeamName is null ? "Bye" : secondTeamName;
                        }
                    }
                }
            }

            return tournaments;
        }

        public void UpdateMatchup(MatchupModel matchup)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.SqlConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", matchup.Id);
                parameters.Add("WinnerId", matchup.WinnerId);

                connection.Execute("dbo.spMatchups_Update", parameters, commandType: CommandType.StoredProcedure);

                foreach (MatchupTeamInfoModel teamInfoModel in matchup.TeamsInfo)
                {
                    parameters = new DynamicParameters();
                    parameters.Add("@id", teamInfoModel.Id);
                    parameters.Add("@Score", teamInfoModel.Score);
                    parameters.Add("@MatchupId", matchup.Id);
                    parameters.Add("@TeamCompetingId", teamInfoModel.TeamCompetingId);

                    connection.Execute("dbo.spMatchupTeams_Update", parameters, commandType: CommandType.StoredProcedure);
                }
            }
        }
    }
}
