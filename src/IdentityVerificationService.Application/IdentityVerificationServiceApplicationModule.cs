using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityVerificationService.Authorization;
using IdentityVerificationService.IdentityVerification.AutoMapper;

namespace IdentityVerificationService
{
    [DependsOn(
        typeof(IdentityVerificationServiceCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class IdentityVerificationServiceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            // Register AutoMapper and its profiles
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                cfg.AddProfile<MappingProfile>(); // Add your custom mapping profile
            });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(IdentityVerificationServiceApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
