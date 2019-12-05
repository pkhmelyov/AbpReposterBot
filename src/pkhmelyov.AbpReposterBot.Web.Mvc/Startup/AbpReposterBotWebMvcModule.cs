using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using pkhmelyov.AbpReposterBot.Configuration;
using Abp.Threading.BackgroundWorkers;
using pkhmelyov.AbpReposterBot.Web.Mvc.Workers;

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

        public override void PostInitialize()
        {
            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            workManager.Add(IocManager.Resolve<ReposterWorker>());
        }
    }
}
