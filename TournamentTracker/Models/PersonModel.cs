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
        public string Address { get; set; }

        /// <summary>
        /// Person's cellphone number
        /// </summary>
        public string PhoneNumber { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public PersonModel() { }

        public PersonModel(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = emailAddress;
            PhoneNumber = phoneNumber;
        }
    }
}
