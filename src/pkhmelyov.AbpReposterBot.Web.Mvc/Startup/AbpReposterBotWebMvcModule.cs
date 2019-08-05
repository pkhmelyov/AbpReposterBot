using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using pkhmelyov.AbpReposterBot.Configuration;

namespace pkhmelyov.AbpReposterBot.Web.Startup
{
    [DependsOn(typeof(AbpReposterBotWebCoreModule))]
    public class AbpReposterBotWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpReposterBotWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<AbpReposterBotNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpReposterBotWebMvcModule).GetAssembly());
        }
    }
}
