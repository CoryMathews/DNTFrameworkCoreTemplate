using System.Security.Claims;
using DNTFrameworkCore.Domain.Entities.Tracking;

namespace DNTFrameworkCoreTemplateAPI.Domain.Identity
{
    public class UserClaim : ModificationTrackingEntity
    {
        public const int MaxClaimTypeLength = 256;

        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public User User { get; set; }
        public long UserId { get; set; }

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