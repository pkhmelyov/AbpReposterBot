using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using pkhmelyov.AbpReposterBot.Authorization;

namespace pkhmelyov.AbpReposterBot
{
    [DependsOn(
        typeof(AbpReposterBotCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpReposterBotApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpReposterBotAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AbpReposterBotApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
