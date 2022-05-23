namespace TournamentTrackerLibrary.Models
{
    public class PersonModel
    {
        /// <summary>
        /// Person's ID in database
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Person's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Person's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Person's email address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Person's cellphone number
        /// </summary>
        public string CellphoneNumber { get; set; }

        public PersonModel(string firstName, string lastName, string emailAddress, string cellphoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            CellphoneNumber = cellphoneNumber;
        }
    }
}
