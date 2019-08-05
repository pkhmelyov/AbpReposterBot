using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using pkhmelyov.AbpReposterBot.Configuration;
using pkhmelyov.AbpReposterBot.EntityFrameworkCore;
using pkhmelyov.AbpReposterBot.Migrator.DependencyInjection;

namespace pkhmelyov.AbpReposterBot.Migrator
{
    [DependsOn(typeof(AbpReposterBotEntityFrameworkModule))]
    public class AbpReposterBotMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AbpReposterBotMigratorModule(AbpReposterBotEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(AbpReposterBotMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AbpReposterBotConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(AbpReposterBotMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
