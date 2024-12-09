using System.Threading.Tasks;
using IdentityVerificationService.Configuration.Dto;

namespace IdentityVerificationService.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
