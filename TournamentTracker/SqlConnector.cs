using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTrackerLibrary
{
    public class SqlConnector : IDataConnection
    {
        // TODO - Make the CreatePrize method actually save to the database
        /// <summary>
        /// Saves a new prize to a database
        /// </summary>
        /// <param name="prize">The prize informations</param>
        /// <returns>The prize informations with unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel prize)
        {
            prize.Id = 1;

            return prize;
        }
    }
}
