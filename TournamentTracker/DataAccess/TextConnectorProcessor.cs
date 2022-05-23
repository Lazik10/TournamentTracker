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

        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel prizeModel in models)
            {
                lines.Add($"{prizeModel.Id},{prizeModel.PlaceNumber},{prizeModel.PlaceName},{prizeModel.PrizeAmount},{prizeModel.PrizePercentage}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}
