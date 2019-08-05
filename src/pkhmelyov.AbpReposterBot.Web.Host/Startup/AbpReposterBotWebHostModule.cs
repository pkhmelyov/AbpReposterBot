using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using pkhmelyov.AbpReposterBot.Configuration;

namespace pkhmelyov.AbpReposterBot.Web.Host.Startup
{
    [DependsOn(
       typeof(AbpReposterBotWebCoreModule))]
    public class AbpReposterBotWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpReposterBotWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpReposterBotWebHostModule).GetAssembly());
        }
    }
}
