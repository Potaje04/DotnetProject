using MyprojectInC.Model.Vehicles;

namespace MyprojectInC.Model.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehicles();
        Task<Vehicle> GetVehicleDetails(int id);
        Task<bool> InsertVehicle(Vehicle vehicle);
        Task<bool> UpdateVehicle(Vehicle vehicle);
        Task<bool> DeleteVehicle(Vehicle vehicle);
    }
}
