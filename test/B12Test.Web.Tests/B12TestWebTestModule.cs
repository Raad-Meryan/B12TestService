using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using B12Test.EntityFrameworkCore;
using B12Test.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace B12Test.Web.Tests
{
    [DependsOn(
        typeof(B12TestWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class B12TestWebTestModule : AbpModule
    {
        public B12TestWebTestModule(B12TestEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(B12TestWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(B12TestWebMvcModule).Assembly);
        }
    }
}