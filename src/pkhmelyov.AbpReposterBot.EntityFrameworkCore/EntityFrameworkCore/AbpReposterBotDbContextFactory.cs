using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using pkhmelyov.AbpReposterBot.Configuration;
using pkhmelyov.AbpReposterBot.Web;

namespace pkhmelyov.AbpReposterBot.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AbpReposterBotDbContextFactory : IDesignTimeDbContextFactory<AbpReposterBotDbContext>
    {
        public AbpReposterBotDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpReposterBotDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AbpReposterBotDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AbpReposterBotConsts.ConnectionStringName));

            return new AbpReposterBotDbContext(builder.Options);
        }
    }
}
