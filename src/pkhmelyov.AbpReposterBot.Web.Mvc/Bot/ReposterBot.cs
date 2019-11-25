using System;
using Microsoft.Extensions.Options;
using MihaZupan;
using pkhmelyov.AbpReposterBot.Web.Mvc.Options;
using Telegram.Bot;
using Telegram.Bot.Framework;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Bot
{
    public class ReposterBot : BotBase
    {
        public ReposterBot(IOptions<CustomBotOptions<ReposterBot>> options)
            : base(options.Value.Username, CreateClient(options.Value)) { }

        private static ITelegramBotClient CreateClient(CustomBotOptions<ReposterBot> options)
        {
            if (!options.UseTorProxy)
            {
                return new TelegramBotClient(options.ApiToken);
            }
            else
            {
                return new TelegramBotClient(options.ApiToken, new HttpToSocks5Proxy("127.0.0.1", 9150));
            }
        }
    }
}