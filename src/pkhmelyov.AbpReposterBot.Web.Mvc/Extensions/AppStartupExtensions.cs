using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using pkhmelyov.AbpReposterBot.Web.Mvc.Options;
using pkhmelyov.AbpReposterBot.Web.Mvc.Services;
using pkhmelyov.AbpReposterBot.Web.Startup;
using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;

namespace Microsoft.AspNetCore.Builder
{
    static class AppStartupExtensions
    {
        public static IApplicationBuilder UseTelegramBotLongPolling<TBot>(
            this IApplicationBuilder app,
            IBotBuilder botBuilder,
            TimeSpan startAfter = default,
            CancellationToken cancellationToken = default
        )
            where TBot : BotBase
        {
            if (startAfter == default)
            {
                startAfter = TimeSpan.FromSeconds(2);
            }

            var updateManager = new UpdatePollingManager<TBot>(botBuilder, new BotServiceProvider(app));

            Task.Run(async () =>
            {
                await Task.Delay(startAfter, cancellationToken);
                await updateManager.RunAsync(cancellationToken: cancellationToken);
            }, cancellationToken)
            .ContinueWith(t =>
            {// ToDo use logger
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(t.Exception);
                Console.ResetColor();
                throw t.Exception;
            }, TaskContinuationOptions.OnlyOnFaulted);

            return app;
        }

        public static IApplicationBuilder EnsureWebhookSet<TBot>(
            this IApplicationBuilder app
        )
            where TBot : IBot
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Startup>>();
                var bot = scope.ServiceProvider.GetRequiredService<TBot>();
                var options = scope.ServiceProvider.GetRequiredService<IOptions<CustomBotOptions<TBot>>>();
                var url = new Uri(new Uri(options.Value.WebhookDomain), options.Value.WebhookPath);

                logger.LogInformation("Setting webhook for bot \"{0}\" to URL \"{1}\"", typeof(TBot).Name, url);

                bot.Client.SetWebhookAsync(url.AbsoluteUri)
                    .GetAwaiter().GetResult();
            }

            return app;
        }
    }
}