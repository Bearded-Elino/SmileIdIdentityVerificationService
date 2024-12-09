using System.Threading.Tasks;
using Abp.Application.Services;
using IdentityVerificationService.Authorization.Accounts.Dto;

namespace IdentityVerificationService.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
