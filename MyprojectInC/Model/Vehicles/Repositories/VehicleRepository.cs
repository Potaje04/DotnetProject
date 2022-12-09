using Dapper;
using MyprojectInC.Model.Vehicles;
using MySql.Data.MySqlClient;
using MySqlConnector;
using System.ComponentModel.DataAnnotations;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;

namespace MyprojectInC.Model.Repositories
{
    internal class VehicleRepository : IVehicleRepository
    {

        private readonly MySQLConfiguration _connectionString;
        public VehicleRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteVehicle(Vehicle vehicle)
        {
           var DB = dbConnection();

            var sql = @"DELETE FROM vehicles WHERE id = @Id";

            var result = await DB.ExecuteAsync(sql, new { Id = vehicle.Id});

            return result > 0;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
          var DB = dbConnection();

            var sql = @"SELECT id, brand, vin, color, year, ownerId FROM vehicles";

            return await DB.QueryAsync<Vehicle>(sql, new { });
        }

        public async Task<Vehicle> GetVehicleDetails(int id)
        {
            var DB = dbConnection();

            var sql = @"SELECT id, brand, vin, color, year, ownerId FROM vehicles WHERE id = @Id";

            return await DB.QueryFirstOrDefaultAsync<Vehicle>(sql, new { Id = id});
        }

        public async Task<bool> InsertVehicle(Vehicle vehicle)
        {
            var DB = dbConnection();

            var sql = @"INSERT INTO vehicles(brand, vin, color, year, ownerId) VALUES(@Brand, @Vin, @Color, @Year, @OwnerId)";

            var result = await DB.ExecuteAsync(sql, new
            {vehicle.Brand, vehicle.Vin, vehicle.Color, vehicle.Year, vehicle.OwnerId});

            return result > 0;
        }

        public async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            var DB = dbConnection();

            var sql = @"UPDATE vehicles SETbrand = @Brand, vin = @Vin, color = @Color, year = @Year, ownerId = @OwnerId WHERE id = @Id";

            var result = await DB.ExecuteAsync(sql, new
            { vehicle.Brand, vehicle.Vin, vehicle.Color, vehicle.Year, vehicle.OwnerId });

            return result > 0;
        }
    }
}
