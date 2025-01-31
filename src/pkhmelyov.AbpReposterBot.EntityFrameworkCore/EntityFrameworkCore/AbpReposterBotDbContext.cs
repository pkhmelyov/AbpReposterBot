﻿using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using pkhmelyov.AbpReposterBot.Authorization.Roles;
using pkhmelyov.AbpReposterBot.Authorization.Users;
using pkhmelyov.AbpReposterBot.MultiTenancy;
using pkhmelyov.AbpReposterBot.Posts;

namespace pkhmelyov.AbpReposterBot.EntityFrameworkCore
{
    public class AbpReposterBotDbContext : AbpZeroDbContext<Tenant, Role, User, AbpReposterBotDbContext>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<TelegramUser> TelegramUsers { get; set; }
        public DbSet<ScheduleItem> ScheduleItems { get; set; }

        public AbpReposterBotDbContext(DbContextOptions<AbpReposterBotDbContext> options)
            : base(options)
        {
        }
    }
}
