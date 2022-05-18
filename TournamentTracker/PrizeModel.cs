using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTrackerLibrary
{
    public class PrizeModel
    {
        /// <summary>
        /// Prize place number
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// Prize place name
        /// </summary>
        public string? PlaceName { get; set; }

        /// <summary>
        /// Prize amount
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// Prize percentahe
        /// </summary>
        public double PrizePercentage { get; set; }
    }
}
