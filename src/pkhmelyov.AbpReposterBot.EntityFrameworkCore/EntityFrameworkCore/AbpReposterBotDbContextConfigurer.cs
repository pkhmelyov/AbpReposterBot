using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace pkhmelyov.AbpReposterBot.EntityFrameworkCore
{
    public static class AbpReposterBotDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpReposterBotDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpReposterBotDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
