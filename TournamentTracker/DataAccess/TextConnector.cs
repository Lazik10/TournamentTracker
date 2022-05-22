using TournamentTrackerLibrary.Models;

namespace TournamentTrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        // TODO - Create prize
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prize"></param>
        /// <returns></returns>
        public PrizeModel CreatePrize(PrizeModel prize)
        {
            prize.Id = 1;

            return prize;
        }
    }
}
