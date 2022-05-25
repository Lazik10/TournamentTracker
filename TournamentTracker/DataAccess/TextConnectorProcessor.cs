using System.Reflection;
using TournamentTrackerLibrary.Models;

namespace TournamentTrackerLibrary.DataAccess.Helpers
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            string? assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
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

        public static List<TeamModel> ConvertToTeamModels(this List<string> strings, string contestantFileName)
        {
            List<TeamModel> teams = new List<TeamModel>();
            List<PersonModel> contestants = contestantFileName.FullFilePath().LoadFile().ConvertToPersonModels();

            foreach (string line in strings)
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

        public static List<TournamentModel> ConvertToTournamentModels(this List<string> strings, string prizeFileName, string teamFileName, string contestantFileName)
        {
            List<TournamentModel> tournaments = new List<TournamentModel>();
            List<PrizeModel> prizes = prizeFileName.FullFilePath().LoadFile().ConvertToPrizeModels();
            List<TeamModel> teams = teamFileName.FullFilePath().LoadFile().ConvertToTeamModels(contestantFileName);

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
                    tournament.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                }

                // Load Teams
                string[] teamIds = columns[4].Split('|');
                foreach (string id in teamIds)
                {
                    tournament.EntryTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                }

                // // TODO - Load Rounds
                string[] roundMatchups = columns[5].Split('^');
                for (int i = 0; i < roundMatchups.Length; i++)
                {

                }

                tournaments.Add(tournament);
            }
            return tournaments;
        }

        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel prizeModel in models)
            {
                lines.Add($"{prizeModel.Id},{prizeModel.PlaceNumber},{prizeModel.PlaceName},{prizeModel.PrizeAmount},{prizeModel.PrizePercentage}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToContestantsFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel personModel in models)
            {
                lines.Add($"{personModel.Id},{personModel.FirstName},{personModel.LastName},{personModel.Address},{personModel.PhoneNumber}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToTeamsFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel teamModel in models)
            {
                lines.Add($"{teamModel.Id},{teamModel.TeamName},{ConvertMemberIdsToStringIds(teamModel)}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToTournamentFile(this List<TournamentModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TournamentModel tournamentModel in models)
            {
                lines.Add($"{tournamentModel.Id},{tournamentModel.TournamentName},{tournamentModel.EntryFee}," +
                          $"{ConvertPrizeIdsToStringIds(tournamentModel.Prizes)},{ConvertTeamIdsToStringIds(tournamentModel.EntryTeams)}" +
                          $"{ConvertRoundIdsToStringIds(tournamentModel.Rounds)}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
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
                roundString += $"{ConvertMatchupListToString(matchup)}|";
            }

            roundString = roundString.Substring(0, roundString.Length - 1);

            return roundString;
        }

        private static string ConvertMatchupListToString(List<MatchupModel> matchups)
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
