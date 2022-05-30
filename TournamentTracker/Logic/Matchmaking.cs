using TournamentTrackerLibrary.DataAccess;
using TournamentTrackerLibrary.Models;

namespace TournamentTrackerLibrary.Logic
{
    public static class Matchmaking
    {
        private static readonly Random random = new Random();

        public static void CreateRounds(TournamentModel tournament)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamsOrder(tournament.EntryTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count, out int numberOfByes);
            tournament.Rounds.Add(CreateFirstRound(tournament.EntryTeams, numberOfByes));
            CreateNextRounds(tournament, rounds);
        }

        private static void CreateNextRounds(TournamentModel tournament, int rounds)
        {
            // TODO - Fix issue when creating new tournament and immediately opening viewer form matchup TeamsCompeting are not updated

            // We created first round so start generating from second round
            int currentRound = 2;
            const int TeamsInMatchup = 2;

            List<MatchupModel> previousRoundMatchups = tournament.Rounds[0].ToList();
            List<MatchupModel> currentRoundMatchups = new List<MatchupModel>();

            for (int i = currentRound; i <= rounds; i++)
            {
                // while we have matchups from previous round match two of them agains each other in next round
                while (previousRoundMatchups.Count > 0)
                {
                    MatchupModel newMatchup = new MatchupModel();
                    newMatchup.MatchupRound = currentRound;

                    // select two matchups from previous round and match them together in this round
                    for (int j = 0; j < TeamsInMatchup; j++)
                    {
                        MatchupModel previousMatchup = previousRoundMatchups[random.Next(previousRoundMatchups.Count - 1)];
                        newMatchup.TeamsInfo.Add(new MatchupTeamInfoModel { ParentMatchupId = previousMatchup.Id });
                        previousRoundMatchups.Remove(previousMatchup);
                    }

                    currentRoundMatchups.Add(newMatchup);
                }

                tournament.Rounds.Add(currentRoundMatchups);
                previousRoundMatchups = currentRoundMatchups.ToList();
                currentRoundMatchups = new List<MatchupModel>();
                currentRound++;
            }
        }

        private static List<MatchupModel> CreateFirstRound(List<TeamModel> teams, int numberOfByes)
        {

            List<MatchupModel> matchups = new List<MatchupModel>();
            List<TeamModel> availableTeams = teams.ToList();

            while (availableTeams.Count > 0)
            {
                MatchupModel matchup = new MatchupModel();
                matchup.MatchupRound = 1;

                // IF we have byes available, we will match team with a bye otherwise match two teams agains each other
                int matchTeams = numberOfByes == 0 ? 2 : 1;

                for (int i = 0; i < matchTeams; i++)
                {
                    MatchupTeamInfoModel teamInfo = new MatchupTeamInfoModel();
                    TeamModel team = availableTeams[random.Next(availableTeams.Count - 1)];
                    teamInfo.TeamCompetingId = team.Id;
                    teamInfo.TeamCompeting = team;
                    availableTeams.Remove(team);

                    matchup.TeamsInfo.Add(teamInfo);
                }

                if (matchTeams == 1)
                {
                    matchup.TeamsInfo.Add(new MatchupTeamInfoModel());
                    numberOfByes--;
                }

                matchups.Add(matchup);
            }

            return matchups;
        }

        private static int FindNumberOfRounds(int numberOfTeams, out int numberOfbyes)
        {
            int rounds = 1;
            int teamsInMatchup = 2;

            // In final we have 2 teams, each round before we have twice as many teams,
            // when we find a round in which we have more total teams in round competing agains each other
            // than we have number of teams signed for the tournament we have found how many rounds we can play
            // to get to the finals
            while (teamsInMatchup < numberOfTeams)
            {
                rounds++;
                teamsInMatchup *= 2;
            }

            numberOfbyes = teamsInMatchup - numberOfTeams;

            return rounds;
        }

        private static List<TeamModel> RandomizeTeamsOrder(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public static void UpdateTournamentResults(TournamentModel tournament, MatchupModel matchup, double firstTeamScore, double secondTeamScore)
        {
            UpdateScore(tournament, matchup, firstTeamScore, secondTeamScore);
            AdvanceWinners(matchup, tournament);
        }

        private static void UpdateScore(TournamentModel tournament, MatchupModel matchup, double firstTeamScore, double secondTeamScore)
        {
            int? winnerId = 0;

            if (firstTeamScore > secondTeamScore)
                winnerId = matchup.TeamsInfo[0].TeamCompetingId;
            else if (secondTeamScore > firstTeamScore)
                winnerId = matchup.TeamsInfo[1].TeamCompetingId;

            matchup.TeamsInfo[0].Score = firstTeamScore;
            matchup.TeamsInfo[1].Score = secondTeamScore;
            matchup.Winner = tournament.EntryTeams.Where(x => x.Id == winnerId).First();
            matchup.WinnerId = winnerId;
        }

        private static void AdvanceWinners(MatchupModel matchup, TournamentModel tournament)
        {
            List<MatchupModel> nextRoundMatchups;
            // There is no matchap in next round if we are evaluating last round (finale)
            if (matchup.MatchupRound < tournament.Rounds.Count)
            {
                // Current matchup round is based from 1 to X, this means it also has an index of next round because of zero based index of List
                nextRoundMatchups = tournament.Rounds[matchup.MatchupRound];
                foreach (MatchupModel roundMatchup in nextRoundMatchups)
                {
                    foreach (MatchupTeamInfoModel infoModel in roundMatchup.TeamsInfo)
                    {
                        if (infoModel.ParentMatchupId == matchup.Id)
                        {
                            infoModel.TeamCompeting = matchup.Winner;
                            infoModel.TeamCompetingId = matchup.WinnerId;
                        }
                    }

                    roundMatchup.TeamsCompeting = roundMatchup.TeamsInfo[0]?.TeamCompeting?.TeamName + " vs " +
                                                  roundMatchup.TeamsInfo[1]?.TeamCompeting?.TeamName;

                    foreach (IDataConnection connection in GlobalConfig.Connections)
                    {
                        connection.UpdateMatchup(roundMatchup);
                    }
                }
            }

            foreach (IDataConnection connection in GlobalConfig.Connections)
            {
                connection.UpdateMatchup(matchup);
            }
        }
    }
}
