using System.Data;
using System.Data.SqlClient;
using TournamentTrackerLibrary.Models;
using Dapper;

namespace TournamentTrackerLibrary.DataAccess
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
                GlobalConfig.LastSavedID = prize.Id;

                return prize;
            }
        }
    }
}
