using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace IdentityVerificationService.Controllers
{
    public abstract class IdentityVerificationServiceControllerBase: AbpController
    {
        protected IdentityVerificationServiceControllerBase()
        {
            LocalizationSourceName = IdentityVerificationServiceConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
