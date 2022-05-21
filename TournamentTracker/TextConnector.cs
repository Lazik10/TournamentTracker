using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTrackerLibrary
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
