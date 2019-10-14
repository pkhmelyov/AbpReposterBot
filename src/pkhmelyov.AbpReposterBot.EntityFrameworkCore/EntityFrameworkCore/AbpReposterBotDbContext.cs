using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using pkhmelyov.AbpReposterBot.Authorization.Roles;
using pkhmelyov.AbpReposterBot.Authorization.Users;
using pkhmelyov.AbpReposterBot.MultiTenancy;
using pkhmelyov.AbpReposterBot.Posts;

namespace pkhmelyov.AbpReposterBot.EntityFrameworkCore
{
    public class AbpReposterBotDbContext : AbpZeroDbContext<Tenant, Role, User, AbpReposterBotDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AbpReposterBotDbContext(DbContextOptions<AbpReposterBotDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
