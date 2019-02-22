using System.Security.Claims;
using DNTFrameworkCore.Domain.Entities.Tracking;

namespace DNTFrameworkCoreTemplateAPI.Domain.Identity
{
    public class RoleClaim : ModificationTrackingEntity
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