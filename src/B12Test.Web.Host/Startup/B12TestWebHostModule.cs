using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using B12Test.Configuration;

namespace B12Test.Web.Host.Startup
{
    [DependsOn(
       typeof(B12TestWebCoreModule))]
    public class B12TestWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public B12TestWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(B12TestWebHostModule).GetAssembly());
        }
    }
}
