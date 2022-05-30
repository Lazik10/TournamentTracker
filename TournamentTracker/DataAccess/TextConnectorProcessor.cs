using System.Reflection;
using TournamentTrackerLibrary.Models;

namespace TournamentTrackerLibrary.DataAccess.Helpers
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            string? assemblyName = "TournamentTracker";
            // Because we are creating new folder in a subfolder of APPDATA directory named as our assmebly,
            // we need to check if it exists or we need to create all subdirectories in our path
            // File.Create() would crash if it doesn't find the subdirecotry specified in a file path
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" + assemblyName);
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" + assemblyName + "\\" + fileName;
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> prizeModels = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] column = line.Split(',');

                PrizeModel prize = new PrizeModel();
                prize.Id = int.Parse(column[0]);
                prize.PlaceNumber = int.Parse(column[1]);
                prize.PlaceName = column[2];
                prize.PrizeAmount = decimal.Parse(column[3]);
                prize.PrizePercentage = double.Parse(column[4]);

                prizeModels.Add(prize);
            }

            return prizeModels;
        }

        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> personModels = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] column = line.Split(',');

                PersonModel person = new PersonModel(column[1], column[2], column[3], column[4]);
                person.Id = int.Parse(column[0]);
                personModels.Add(person);
            }

            return personModels;
        }

        public static List<TeamModel> ConvertToTeamModels(this List<string> lines)
        {
            List<TeamModel> teams = new List<TeamModel>();
            List<PersonModel> contestants = GlobalConfig.ContestantFile.FullFilePath().LoadFile().ConvertToPersonModels();

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');

                TeamModel team = new TeamModel();
                team.Id = int.Parse(columns[0]);
                team.TeamName = columns[1];

                string[] contestantIds = columns[2].Split('|');

                foreach (string id in contestantIds)
                {
                    team.TeamMembers.Add(contestants.Where(x => x.Id == int.Parse(id)).First());
                }

                teams.Add(team);
            }

            return teams;
        }

        public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
        {
            List<MatchupModel> matchups = new List<MatchupModel>();
            List<MatchupTeamInfoModel> teamInfo = GlobalConfig.MatchupTeamFile.FullFilePath().LoadFile().ConvertToTeamInfoModels();
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
            
            // id, winner, round
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');

                MatchupModel matchup = new MatchupModel();
                matchup.Id = int.Parse(columns[0]);
                matchup.WinnerId = string.IsNullOrEmpty(columns[1]) ? null : int.Parse(columns[1]);
                if (!string.IsNullOrEmpty(columns[1]))
                    matchup.Winner = teams.Where(x => x.Id == int.Parse(columns[1])).First();
                matchup.TeamsInfo = teamInfo.Where(x => x.MatchupId == matchup.Id).ToList();
                matchup.MatchupRound = int.Parse(columns[2]);


                string? firstTeamName = matchup.TeamsInfo[0]?.TeamCompeting?.TeamName;
                string? secondTeamname = matchup.TeamsInfo[1]?.TeamCompeting?.TeamName;

                matchup.TeamsCompeting = (firstTeamName ?? "Bye") + " vs " + (secondTeamname ??= "Bye");

                matchups.Add(matchup);
            }

            return matchups;
        }

        public static List<MatchupTeamInfoModel> ConvertToTeamInfoModels(this List<string> lines)
        {
            List<MatchupTeamInfoModel> teamInfoModels = new List<MatchupTeamInfoModel>();
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();

            // matchupId, parentMatchupId, teamcompeting, score
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');

                MatchupTeamInfoModel teamInfoModel = new MatchupTeamInfoModel();
                teamInfoModel.MatchupId = int.Parse(columns[0]);
                teamInfoModel.ParentMatchupId = string.IsNullOrEmpty(columns[1]) ? null : int.Parse(columns[1]);
                teamInfoModel.TeamCompetingId = string.IsNullOrEmpty(columns[2]) ? null : int.Parse(columns[2]);
                if (!string.IsNullOrEmpty(columns[2]))
                    teamInfoModel.TeamCompeting = teams.Where(x => x.Id == int.Parse(columns[2])).First();
                teamInfoModel.Score = string.IsNullOrEmpty(columns[3]) ? null : int.Parse(columns[3]);

                teamInfoModels.Add(teamInfoModel);
            }

            return teamInfoModels;
        }

        public static List<TournamentModel> ConvertToTournamentModels(this List<string> strings)
        {
            List<TournamentModel> tournaments = new List<TournamentModel>();
            List<PrizeModel> prizes = GlobalConfig.PrizeFile.FullFilePath().LoadFile().ConvertToPrizeModels();
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();
            List<MatchupModel> tournamentRoundMatchups = new List<MatchupModel>();

            // ID, TournamentName, EntryFee, Prizes, Teams, Rounds
            foreach (string line in strings)
            {
                string[] columns = line.Split(',');

                TournamentModel tournament = new TournamentModel();
                tournament.Id = int.Parse(columns[0]);
                tournament.TournamentName = columns[1];
                tournament.EntryFee = decimal.Parse(columns[2]);

                // Load Prizes
                string[] prizeIds = columns[3].Split('|');
                foreach (string id in prizeIds)
                {
                    if (id != "")
                        tournament.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                }

                // Load Teams
                string[] teamIds = columns[4].Split('|');
                foreach (string id in teamIds)
                {
                    if (id != "")
                        tournament.EntryTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                }

                // Load Rounds
                string[] matchupsInAllRounds = columns[5].Split('|');
                foreach (string matchupsInOneRound in matchupsInAllRounds)
                {
                    string[] matchupInRound = matchupsInOneRound.Split('^');
                    foreach (string matchup in matchupInRound)
                    {
                        tournamentRoundMatchups.Add(matchups.Where(x => x.Id == int.Parse(matchup)).First());
                    }
                    tournament.Rounds.Add(tournamentRoundMatchups.ToList());
                    tournamentRoundMatchups.Clear();
                }

                tournaments.Add(tournament);
            }
            return tournaments;
        }

        public static void SaveToPrizeFile(this List<PrizeModel> models)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel prizeModel in models)
            {
                lines.Add($"{prizeModel.Id},{prizeModel.PlaceNumber},{prizeModel.PlaceName},{prizeModel.PrizeAmount},{prizeModel.PrizePercentage}");
            }

            File.WriteAllLines(GlobalConfig.PrizeFile.FullFilePath(), lines);
        }

        public static void SaveToContestantsFile(this List<PersonModel> models)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel personModel in models)
            {
                lines.Add($"{personModel.Id},{personModel.FirstName},{personModel.LastName},{personModel.Address},{personModel.PhoneNumber}");
            }

            File.WriteAllLines(GlobalConfig.ContestantFile.FullFilePath(), lines);
        }

        public static void SaveToTeamsFile(this List<TeamModel> models)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel teamModel in models)
            {
                lines.Add($"{teamModel.Id},{teamModel.TeamName},{ConvertMemberIdsToStringIds(teamModel)}");
            }

            File.WriteAllLines(GlobalConfig.TeamFile.FullFilePath(), lines);
        }

        public static void SaveTournamentMatchups(this TournamentModel tournament)
        {
            List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();
            int newMatchupId = 1;
            if (matchups.Count > 0)
            {
                newMatchupId = matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }

            List<MatchupTeamInfoModel> matchupTeamInfoList = GlobalConfig.MatchupTeamFile.FullFilePath().LoadFile().ConvertToTeamInfoModels();

            // We can't retrieve
            Queue<int> previousRoundIds = new Queue<int>();

            // For every round take all IDs of a matchups and save them to file
            foreach (List<MatchupModel> round in tournament.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    matchup.Id = newMatchupId;

                    previousRoundIds.Enqueue(matchup.Id);

                    // Convert to string and add it to list
                    matchups.Add(matchup);

                    foreach (MatchupTeamInfoModel teamInfo in matchup.TeamsInfo)
                    {
                        teamInfo.MatchupId = matchup.Id;

                        if (matchup.MatchupRound > 1)
                            teamInfo.ParentMatchupId = previousRoundIds.Dequeue();


                        matchupTeamInfoList.Add(teamInfo);
                    }

                    newMatchupId++;
                }
            }

            matchups.SaveToMatchupFile();
            matchupTeamInfoList.SaveToTeamInfoFile();
        }

        private static string ConvertMatchupToString(this MatchupModel matchup)
        {
            return $"{matchup.Id},{matchup.WinnerId},{matchup.MatchupRound}";
        }

        private static string ConvertTeamInfoToString(this MatchupTeamInfoModel teamInfo)
        {
            return $"{teamInfo.MatchupId},{teamInfo.ParentMatchupId},{teamInfo.TeamCompetingId},{teamInfo.Score}";
        }

        public static void SaveToMatchupFile(this List<MatchupModel> matchups)
        {
            List<string> lines = new List<string>();

            foreach (MatchupModel matchup in matchups)
            {
                lines.Add(ConvertMatchupToString(matchup));
            }
            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
        }

        public static void SaveToTeamInfoFile(this List<MatchupTeamInfoModel> teamInfoModels)
        {
            List<string> lines = new List<string>();

            foreach (MatchupTeamInfoModel matchupTeamInfo in teamInfoModels)
            {
                lines.Add(ConvertTeamInfoToString(matchupTeamInfo));
            }
            File.WriteAllLines(GlobalConfig.MatchupTeamFile.FullFilePath(), lines);
        }

        public static void SaveToTournamentFile(this List<TournamentModel> models)
        {
            List<string> lines = new List<string>();

            foreach (TournamentModel tournamentModel in models)
            {
                lines.Add($"{tournamentModel.Id},{tournamentModel.TournamentName},{tournamentModel.EntryFee}," +
                          $"{ConvertPrizeIdsToStringIds(tournamentModel.Prizes)},{ConvertTeamIdsToStringIds(tournamentModel.EntryTeams)}," +
                          $"{ConvertRoundIdsToStringIds(tournamentModel.Rounds)}");
            }

            File.WriteAllLines(GlobalConfig.TournamentFile.FullFilePath(), lines);
        }

        private static string ConvertRoundIdsToStringIds(List<List<MatchupModel>> rounds)
        {
            string roundString = "";

            if (rounds.Count == 0)
            {
                return roundString;
            }

            foreach (List<MatchupModel> matchup in rounds)
            {
                roundString += $"{ConvertMatchupListToStringIds(matchup)}|";
            }

            roundString = roundString.Substring(0, roundString.Length - 1);

            return roundString;
        }

        private static string ConvertMatchupListToStringIds(List<MatchupModel> matchups)
        {
            string matchupId = "";

            if (matchups.Count == 0)
            {
                return matchupId;
            }

            return string.Join('^', matchups.Select(x => x.Id));
        }

        private static string ConvertPrizeIdsToStringIds(List<PrizeModel> prizeModels)
        {
            string prizes = "";

            if (prizeModels.Count == 0)
            {
                return prizes;
            }

            return string.Join('|', prizeModels.Select(x => x.Id));
        }

        private static string ConvertTeamIdsToStringIds(List<TeamModel> teamModels)
        {
            string teams = "";

            if (teamModels.Count == 0)
            {
                return teams;
            }

            return string.Join('|', teamModels.Select(x => x.Id));
        }

        private static string ConvertMemberIdsToStringIds(TeamModel teamModel)
        {
            if (!teamModel.TeamMembers.Any())
                return "";

            return string.Join('|', teamModel.TeamMembers.Select(x => x.Id));
        }
    }
}
