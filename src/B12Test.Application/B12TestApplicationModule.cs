using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using B12Test.Authorization;
using B12Test.Services;

namespace B12Test
{
    [DependsOn(
        typeof(B12TestCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class B12TestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<IEventAppService, EventAppService>();
            IocManager.Register<EventManager>();
            Configuration.Authorization.Providers.Add<B12TestAuthorizationProvider>();
            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(typeof(B12TestApplicationModule).Assembly)
            );
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(B12TestApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
