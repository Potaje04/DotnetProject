using Dapper;
using MyprojectInC.Model.Owner;
using MySql.Data.MySqlClient;

namespace MyprojectInC.Model.Claims.Repository
{
    internal class ClaimRepository : IClaimRepository
    {
        private readonly MySQLConfiguration _configuration;

        public ClaimRepository(MySQLConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_configuration.ConnectionString);
        }

        public async Task<bool> DeleteClaim(Claim claim)
        {
            var DB = dbConnection();

            var sql = @"DELETE FROM claim WHERE id = @Id";

            var result = await DB.ExecuteAsync(sql, new { Id = claim.Id });

            return result > 0;
        }

        public async Task<IEnumerable<Claim>> GetAllClaims()
        {
            var DB = dbConnection();

            var sql = @"SELECT id, description, status, date, vehicle_id FROM claim";

            return await DB.QueryAsync<Claim>(sql, new { });
        }

        public async Task<Claim> GetClaimDetails(int id)
        {
            var DB = dbConnection();

            var sql = @"SELECT id, description, status, date, vehicle_id FROM clai WHERE id = @Id";

            return await DB.QueryFirstOrDefaultAsync(sql, new { Id = id });
        }

        public async Task<bool> InsertClaim(Claim claim)
        {
            var DB = dbConnection();

            var sql = @"INSERT INTO claim(description, status, date, vehicle_id) VALUES(@Description, @Status, @Date, @vehicle_id)";

            var result = await DB.ExecuteAsync(sql, new { claim.Description, claim.Status, claim.Date, claim.Vehicle_id });

            return result > 0;
        }

        public async Task<bool> UpdateClaim(Claim claim)
        {
            var DB = dbConnection();

            var sql = @"UPDATE claim SET description=@Description, status=@Status, date=@Date, vehicle_id=@Vehicle_id";

            var result = await DB.ExecuteAsync(sql, new
            { claim.Description, claim.Status, claim.Date, claim.Vehicle_id });

            return result > 0;
        }
    }
}
