using System.Security.Policy;

namespace MyprojectInC.Model.Claims
{
    public class Claim
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public int Vehicle_id { get; set; }
    }
}
