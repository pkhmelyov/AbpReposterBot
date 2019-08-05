using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using pkhmelyov.AbpReposterBot.Authorization.Roles;
using pkhmelyov.AbpReposterBot.Authorization.Users;
using pkhmelyov.AbpReposterBot.Configuration;
using pkhmelyov.AbpReposterBot.Localization;
using pkhmelyov.AbpReposterBot.MultiTenancy;
using pkhmelyov.AbpReposterBot.Timing;

namespace pkhmelyov.AbpReposterBot
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AbpReposterBotCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            AbpReposterBotLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = AbpReposterBotConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpReposterBotCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
