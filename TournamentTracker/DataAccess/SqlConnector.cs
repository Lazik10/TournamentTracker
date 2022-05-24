using System.Data;
using System.Data.SqlClient;
using TournamentTrackerLibrary.Models;
using Dapper;

namespace TournamentTrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        /// <summary>
        /// Saves a new prize to a database
        /// </summary>
        /// <param name="prize">The prize informations</param>
        /// <returns>The prize informations with unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel prize)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.SqlConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PlaceNumber", prize.PlaceNumber);
                parameters.Add("@PlaceName", prize.PlaceName);
                parameters.Add("@PrizeAmount", prize.PrizeAmount);
                parameters.Add("@PrizePercentage", prize.PrizePercentage);
                parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", parameters, commandType: CommandType.StoredProcedure);

                prize.Id = parameters.Get<int>("id");

                return prize;
            }
        }

        /// <summary>
        /// Saves a new person (contestant) into the database
        /// </summary>
        /// <param name="person">Person informations</param>
        /// <returns>Peerson information with specific unique identifier</returns>
        public PersonModel CreatePerson(PersonModel person)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.SqlConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@PersonFirstName", person.FirstName);
                parameters.Add("@PersonLastName", person.LastName);
                parameters.Add("@PersonEmail", person.Address);
                parameters.Add("@PersonPhone", person.PhoneNumber);
                parameters.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spContestants_Insert", parameters, commandType: CommandType.StoredProcedure);

                person.Id = parameters.Get<int>("id");

                return person;
            }
        }

        public List<PersonModel> GetAllPersons()
        {
            List<PersonModel> persons = new List<PersonModel>();

            using (IDbConnection connection = new SqlConnection(GlobalConfig.SqlConnectionString))
            {
                persons = connection.Query<PersonModel>("dbo.spContestants_GetAll").ToList();
            }

            return persons;
        }
    }
}
