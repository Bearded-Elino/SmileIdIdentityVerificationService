using Abp.Authorization;
using IdentityVerificationService.Authorization.Roles;
using IdentityVerificationService.Authorization.Users;

namespace IdentityVerificationService.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
