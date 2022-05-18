using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTrackerLibrary
{
    public class PersonModel
    {
        /// <summary>
        /// Person's first name
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Person's last name
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Person's email address
        /// </summary>
        public string? EmailAddress { get; set; }

        /// <summary>
        /// Person's cellphone number
        /// </summary>
        public string? CellphoneNumber { get; set; }
    }
}
