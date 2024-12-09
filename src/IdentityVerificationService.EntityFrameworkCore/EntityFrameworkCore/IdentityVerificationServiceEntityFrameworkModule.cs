using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using IdentityVerificationService.EntityFrameworkCore.Seed;

namespace IdentityVerificationService.EntityFrameworkCore
{
    [DependsOn(
        typeof(IdentityVerificationServiceCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class IdentityVerificationServiceEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<IdentityVerificationServiceDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        IdentityVerificationServiceDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        IdentityVerificationServiceDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityVerificationServiceEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
