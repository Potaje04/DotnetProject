namespace MyprojectInC.Model.Claims.Repository
{
    public interface IClaimRepository
    {
        Task<IEnumerable<Claim>> GetAllClaims();
        Task<Claim> GetClaimDetails(int id);
        Task<bool> InsertClaim(Claim claim);
        Task<bool> UpdateClaim(Claim claim);
        Task<bool> DeleteClaim(Claim claim);
    }
}
