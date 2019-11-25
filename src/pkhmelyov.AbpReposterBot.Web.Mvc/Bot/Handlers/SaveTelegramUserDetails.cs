using System.Threading;
using System.Threading.Tasks;
using pkhmelyov.AbpReposterBot.Posts;
using pkhmelyov.AbpReposterBot.Posts.Dtos;
using Telegram.Bot.Framework.Abstractions;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Bot.Handlers
{
    public class SaveTelegramUserDetails : IUpdateHandler
    {
        private readonly ITelegramUserApplicationService _telegramUserApplicationService;

        public SaveTelegramUserDetails(ITelegramUserApplicationService telegramUserApplicationService)
        {
            _telegramUserApplicationService = telegramUserApplicationService;
        }

        public async Task HandleAsync(IUpdateContext context, UpdateDelegate next, CancellationToken cancellationToken)
        {
            var user = context.Update.Message?.From ?? context.Update.ChannelPost?.From;
            if (user != null)
            {
                var telegramUserDto = new TelegramUserDto
                {
                    Id = user.Id,
                    IsBot = user.IsBot,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    LanguageCode = user.LanguageCode
                };

                await _telegramUserApplicationService.CreateIfDoesNotExist(telegramUserDto);
            }

            await next(context, cancellationToken);
        }
    }
}