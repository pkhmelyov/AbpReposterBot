using System.Threading;
using System.Threading.Tasks;
using Abp.ObjectMapping;
using Microsoft.Extensions.Logging;
using pkhmelyov.AbpReposterBot.Posts;
using pkhmelyov.AbpReposterBot.Posts.Dtos;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Bot.Handlers
{
    public class SaveChannelDetails : IUpdateHandler
    {
        private readonly IChannelApplicationService _channelApplicationService;
        private readonly ILogger<SaveChannelDetails> _logger;
        private readonly IObjectMapper _objectMapper;

        public SaveChannelDetails(IChannelApplicationService channelApplicationService, ILogger<SaveChannelDetails> logger, IObjectMapper objectMapper)
        {
            _channelApplicationService = channelApplicationService;
            _logger = logger;
            _objectMapper = objectMapper;
        }

        public async Task HandleAsync(IUpdateContext context, UpdateDelegate next, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested) return;
            Task t;
            if (context.Update.ChannelPost != null)
            {
                t = ProcessChannelPost(context.Update.ChannelPost);
            }
            else if (context.Update.Message?.ForwardFromChat != null)
            {
                t = ProcessForwardMessage(context.Update.Message);
            }
            else
            {
                t = Task.CompletedTask;
            }

            await t;

            await next(context, cancellationToken);
        }

        private Task ProcessChannelPost(Message post)
        {
            return SaveIfDoesNotExist(new ChannelDto {
                Id = post.Chat.Id,
                Title = post.Chat.Title,
                Own = true
            });
        }

        private Task ProcessForwardMessage(Message message)
        {
            return SaveIfDoesNotExist(new ChannelDto {
                Id = message.ForwardFromChat.Id,
                Title = message.ForwardFromChat.Title,
                Own = false
            });
        }

        private async Task SaveIfDoesNotExist(ChannelDto channelDto)
        {
            if (!_channelApplicationService.Exists(channelDto))
            {
                await _channelApplicationService.Create(channelDto);
            }
        }
    }
}