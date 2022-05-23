using TournamentTrackerLibrary.DataAccess.Helpers;
using TournamentTrackerLibrary.Models;

namespace TournamentTrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizeFile = "PrizeModels.csv";

        // TODO - Create prize
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prize"></param>
        /// <returns></returns>
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
    }
}
