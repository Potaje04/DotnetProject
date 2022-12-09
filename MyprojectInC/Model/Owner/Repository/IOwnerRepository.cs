namespace MyprojectInC.Model.Owner.Repository
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllOwners();
        Task<Owner> GetOwnerDetails(int id);
        Task<bool> InsertOwner(Owner owner);
        Task<bool> UpdateOwner(Owner owner);
        Task<bool> DeleteOwner(Owner owner);
    }
}
