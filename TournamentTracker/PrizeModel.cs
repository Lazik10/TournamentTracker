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
        /// Unique identificator for the prize
        /// </summary>
        public int Id { get; set; }
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

        public PrizeModel() {}

        public PrizeModel(string placeNumber, string placeName, string prizeAmount, string prizePercentage)
        {
            PlaceNumber = int.Parse(placeNumber);
            PlaceName = placeName;
            PrizeAmount = decimal.Parse(prizeAmount);
            PrizePercentage = double.Parse(prizePercentage);
        }
    }
}
