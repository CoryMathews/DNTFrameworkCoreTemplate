using System;
using DNTFrameworkCore.Domain.Entities.Tracking;

namespace DNTFrameworkCoreTemplateAPI.Domain.Identity
{
    public class UserToken : CreationTrackingEntity
    {
        public const int MaxAccessTokenHashLength = 256;
        public const int MaxRefreshTokenIdHashLength = 256;
        public const int MaxRefreshTokenIdHashSourceLength = 256;
        
        public string TokenHash { get; set; }
        public DateTimeOffset TokenExpirationDateTime { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
    }
}