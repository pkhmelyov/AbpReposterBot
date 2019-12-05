using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Castle.Facilities.Logging;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using pkhmelyov.AbpReposterBot.Authentication.JwtBearer;
using pkhmelyov.AbpReposterBot.Configuration;
using pkhmelyov.AbpReposterBot.Identity;
using pkhmelyov.AbpReposterBot.Web.Resources;
using Abp.AspNetCore.SignalR.Hubs;
using pkhmelyov.AbpReposterBot.Web.Mvc.Bot;
using Telegram.Bot.Framework;
using pkhmelyov.AbpReposterBot.Web.Mvc.Options;
using Telegram.Bot.Framework.Abstractions;
using pkhmelyov.AbpReposterBot.Web.Mvc.Bot.Handlers;
using pkhmelyov.AbpReposterBot.Web.Mvc;

namespace pkhmelyov.AbpReposterBot.Web.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc(
                options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            );

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddScoped<IWebResourceManager, WebResourceManager>();

            services.AddSignalR();

            services.AddTransient<ReposterBot>()
                .Configure<BotOptions<ReposterBot>>(_appConfiguration.GetSection("ReposterBot"))
                .Configure<CustomBotOptions<ReposterBot>>(_appConfiguration.GetSection("ReposterBot"))
                .AddScoped<GenericHandler>()
                .AddScoped<SaveTelegramUserDetails>()
                .AddScoped<SaveChannelDetails>()
                .AddScoped<TextMessageHandler>();

            // Configure Abp and Dependency Injection
            return services.AddAbp<AbpReposterBotWebMvcModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); // Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseTelegramBotLongPolling<ReposterBot>(ConfigureBot(), TimeSpan.FromSeconds(5));
            }
            else
            {
                app.UseExceptionHandler("/Error");

                app.UseTelegramBotWebhook<ReposterBot>(ConfigureBot());

                app.EnsureWebhookSet<ReposterBot>();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseJwtTokenMiddleware();

            app.UseSignalR(routes =>
            {
                routes.MapHub<AbpCommonHub>("/signalr");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private IBotBuilder ConfigureBot()
        {
            return new BotBuilder()
                .Use<GenericHandler>()
                .UseWhen<SaveTelegramUserDetails>(context => When.NewMessage(context) || When.ChannelPost(context))
                .UseWhen<SaveChannelDetails>(context => When.ChannelPost(context) || When.ForwardFromChannel(context))
                .UseWhen<TextMessageHandler>(context => When.NewMessage(context) || When.ForwardFromChannel(context))
                ;
        }
    }
}
