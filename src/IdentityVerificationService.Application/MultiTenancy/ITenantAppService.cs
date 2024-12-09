using Abp.Application.Services;
using IdentityVerificationService.MultiTenancy.Dto;

namespace IdentityVerificationService.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

