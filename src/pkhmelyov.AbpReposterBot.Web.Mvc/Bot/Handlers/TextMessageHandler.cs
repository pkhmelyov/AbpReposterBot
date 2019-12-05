using System.Threading;
using System.Threading.Tasks;
using pkhmelyov.AbpReposterBot.Posts;
using pkhmelyov.AbpReposterBot.Posts.Dtos;
using Telegram.Bot.Framework.Abstractions;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Bot.Handlers
{
    public class TextMessageHandler : IUpdateHandler
    {
        private readonly IPostApplicationService _postApplicationService;

        public TextMessageHandler(IPostApplicationService postApplicationService)
        {
            _postApplicationService = postApplicationService;
        }

        public Task HandleAsync(IUpdateContext context, UpdateDelegate next, CancellationToken cancellationToken)
        {
            return _postApplicationService.Create(new CreatePostInput {
                Body = context.Update.Message?.Text ?? context.Update.ChannelPost?.Text
            });
        }
    }
}