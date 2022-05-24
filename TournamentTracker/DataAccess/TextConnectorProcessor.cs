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
            }

            return teams;
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

        public static string ConvertMemberIdsToStringIds(TeamModel teamModel)
        {
            if (!teamModel.TeamMembers.Any())
                return "";

            return string.Join('|', teamModel.TeamMembers.Select(x => x.Id));
        }
    }
}
