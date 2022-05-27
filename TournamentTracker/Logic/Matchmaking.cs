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
    }
}
