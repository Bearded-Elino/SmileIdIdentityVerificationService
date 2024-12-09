using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityVerificationService.Configuration;
using IdentityVerificationService.EntityFrameworkCore;
using IdentityVerificationService.Migrator.DependencyInjection;

namespace IdentityVerificationService.Migrator
{
    [DependsOn(typeof(IdentityVerificationServiceEntityFrameworkModule))]
    public class IdentityVerificationServiceMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public IdentityVerificationServiceMigratorModule(IdentityVerificationServiceEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(IdentityVerificationServiceMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                IdentityVerificationServiceConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityVerificationServiceMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
