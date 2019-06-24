using System.Security.Claims;
using DNTFrameworkCore.Domain;
namespace DNTFrameworkCoreTemplateAPI.Domain.Identity
{
    public class RoleClaim : TrackableEntity, ICreationTracking
    {
        public const int MaxClaimTypeLength = 256;

        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public Role Role { get; set; }
        public long RoleId { get; set; }

        public Claim ToClaim()
        {
            return new Claim(ClaimType, ClaimValue);
        }

        public void InitializeFromClaim(Claim claim)
        {
            ClaimType = claim.Type;
            ClaimValue = claim.Value;
        }
    }
}