using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Telegram.Bot.Framework.Abstractions;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Bot.Handlers
{
    public class GenericHandler : IUpdateHandler
    {
        private readonly ILogger<GenericHandler> _logger;

        public GenericHandler(ILogger<GenericHandler> logger)
        {
            _logger = logger;
        }

        public async Task HandleAsync(IUpdateContext context, UpdateDelegate next, CancellationToken cancellationToken)
        {
            _logger.LogCritical(JsonConvert.SerializeObject(context.Update));
            await next(context, cancellationToken);
        }
    }
}