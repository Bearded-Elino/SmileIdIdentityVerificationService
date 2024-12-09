using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IdentityVerificationService.EntityFrameworkCore;
using IdentityVerificationService.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace IdentityVerificationService.Web.Tests
{
    [DependsOn(
        typeof(IdentityVerificationServiceWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class IdentityVerificationServiceWebTestModule : AbpModule
    {
        public IdentityVerificationServiceWebTestModule(IdentityVerificationServiceEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(IdentityVerificationServiceWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(IdentityVerificationServiceWebMvcModule).Assembly);
        }
    }
}