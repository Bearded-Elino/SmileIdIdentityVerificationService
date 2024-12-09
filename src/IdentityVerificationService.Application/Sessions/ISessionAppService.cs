using System.Threading.Tasks;
using Abp.Application.Services;
using IdentityVerificationService.Sessions.Dto;

namespace IdentityVerificationService.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
