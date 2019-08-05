using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using pkhmelyov.AbpReposterBot.EntityFrameworkCore.Seed;

namespace pkhmelyov.AbpReposterBot.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpReposterBotCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class AbpReposterBotEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<AbpReposterBotDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        AbpReposterBotDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        AbpReposterBotDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpReposterBotEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
