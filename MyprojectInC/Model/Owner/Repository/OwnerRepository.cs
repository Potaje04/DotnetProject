using Dapper;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace MyprojectInC.Model.Owner.Repository
{
    internal class OwnerRepository : IOwnerRepository
    {
        private readonly MySQLConfiguration _configuration;

        public OwnerRepository(MySQLConfiguration mySQLConfiguration)
        {
            _configuration = mySQLConfiguration;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_configuration.ConnectionString);
        }

        public async Task<bool> DeleteOwner(Owner owner)
        {
            var DB = dbConnection();

            var sql = @"DELETE FROM owner WHERE id = @Id";

            var result = await DB.ExecuteAsync(sql, new { Id = owner.Id });

            return result > 0;
        }

        public async Task<IEnumerable<Owner>> GetAllOwners()
        {
            var DB = dbConnection();

            var sql = @"SELECT id, firstName, lastName, driverLicense FROM owner";

            return await DB.QueryAsync<Owner>(sql, new { });
        }

        public async Task<Owner> GetOwnerDetails(int id)
        {
            var DB = dbConnection();

            var sql = @"SELECT id, firstName, lastName, driverLicense FROM owner WHERE id = @Id";

            return await DB.QueryFirstOrDefaultAsync(sql, new { Id = id });
        }

        public async Task<bool> InsertOwner(Owner owner)
        {
            var DB = dbConnection();

            var sql = @"INSERT INTO owner(firstName, lastName, driverLicense) VALUES(@FirstName, @LastName, @DriverLicense)";

            var result = await DB.ExecuteAsync(sql, new {owner.FirstName, owner.LastName, owner.DriverLicense });

            return result > 0;
        }

        public async Task<bool> UpdateOwner(Owner owner)
        {
            var DB = dbConnection();

            var sql = @"UPDATE owner SET firstName=@FirstName, lastName=@LastName, driverLicense=@DriverLicense";

            var result = await DB.ExecuteAsync(sql, new
            { owner.FirstName, owner.LastName, owner.DriverLicense });

            return result > 0;
        }
    }
}
