using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Abp.Timing;
using pkhmelyov.AbpReposterBot.Posts;
using pkhmelyov.AbpReposterBot.Web.Mvc.Bot;
using Telegram.Bot.Types;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Workers
{
    public class ReposterWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly IScheduleItemApplicationService _scheduleService;
        private readonly IPostApplicationService _postService;
        private readonly IChannelApplicationService _channelService;
        private readonly ReposterBot _bot;

        public ReposterWorker(AbpTimer timer, IScheduleItemApplicationService scheduleService, IPostApplicationService postService, IChannelApplicationService channelService, ReposterBot bot) : base(timer)
        {
            _scheduleService = scheduleService;
            _postService = postService;
            _channelService = channelService;
            _bot = bot;
            timer.Period = 1000 * 60;
        }

        [UnitOfWork]
        protected override void DoWork()
        {
            var items = _scheduleService.GetItems(Clock.Now, 20);
            foreach (var item in items)
            {
                var post = _postService.Get(new EntityDto(item.PostId)).Result;
                var channel = _channelService.Get(new EntityDto<long>(item.ChannelId)).Result;
                if(post != null && (channel?.Own ?? false))
                {
                    _bot.Client.SendTextMessageAsync(new ChatId(channel.Id), post.Body).Wait();
                }
                item.Done = true;
                _scheduleService.Update(item).Wait();
            }
        }
    }
}