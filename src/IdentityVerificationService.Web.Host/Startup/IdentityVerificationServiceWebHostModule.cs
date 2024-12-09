using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityVerificationService.Configuration;
using Abp.Configuration.Startup;
using Microsoft.Extensions.DependencyInjection;
using IdentityVerificationService.Configuration;
using Castle.MicroKernel.Registration;

namespace IdentityVerificationService.Web.Host.Startup
{
    [DependsOn(
       typeof(IdentityVerificationServiceWebCoreModule))]
    public class IdentityVerificationServiceWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public IdentityVerificationServiceWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityVerificationServiceWebHostModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            // Register SmileIdConfig
            Configuration.Modules.AbpConfiguration.ReplaceService<IConfiguration>(
                () => IocManager.IocContainer.Register(
                    Component.For<SmileIdConfig>()
                        .UsingFactoryMethod(() =>
                        {
                            var configuration = IocManager.Resolve<IConfiguration>();
                            return configuration.GetSection("SmileIdConfig").Get<SmileIdConfig>();
                        })
                        .LifestyleSingleton()
                )
            );
        }

    }
}
