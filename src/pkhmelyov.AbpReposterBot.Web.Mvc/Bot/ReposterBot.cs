using Microsoft.Extensions.Options;
using Telegram.Bot.Framework;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Bot
{
    public class ReposterBot : BotBase
    {
        public ReposterBot(IOptions<BotOptions<ReposterBot>> options)
            : base(options.Value) { }
    }
}