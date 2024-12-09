using Abp.Application.Services.Dto;

namespace IdentityVerificationService.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

