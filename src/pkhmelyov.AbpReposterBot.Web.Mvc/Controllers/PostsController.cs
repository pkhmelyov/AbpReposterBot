using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using pkhmelyov.AbpReposterBot.Controllers;
using pkhmelyov.AbpReposterBot.Posts;
using pkhmelyov.AbpReposterBot.Posts.Dtos;
using pkhmelyov.AbpReposterBot.Web.Mvc.Bot;
using pkhmelyov.AbpReposterBot.Web.Mvc.Models.Posts;
using Telegram.Bot.Types;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Controllers
{
    public class PostsController : AbpReposterBotControllerBase
    {
        private readonly IPostApplicationService _postApplicationService;
        private readonly IChannelApplicationService _channelApplicationService;
        private readonly ReposterBot _bot;

        public PostsController(IPostApplicationService postApplicationService, IChannelApplicationService channelApplicationService, ReposterBot bot)
        {
            _postApplicationService = postApplicationService;
            _channelApplicationService = channelApplicationService;
            _bot = bot;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _postApplicationService.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostsCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var input = ObjectMapper.Map<CreatePostInput>(model);
                await _postApplicationService.Create(input);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Send(int id)
        {
            var post = await _postApplicationService.GetById(id);
            if (post == null) return RedirectToAction(nameof(Index));
            var channels = await _channelApplicationService.GetAll(
                new PagedAndSortedResultRequestDto
                {
                    MaxResultCount = int.MaxValue
                });

            return View(new PostsSendViewModel
            {
                Id = id,
                Post = post,
                Channels = channels
            });
        }

        [HttpPost]
        [ActionName("Send")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendPost([FromRoute]int id, [FromForm, Bind(nameof(PostsSendViewModel.ChannelId), nameof(PostsSendViewModel.Schedule), nameof(PostsSendViewModel.ScheduleDate))]PostsSendViewModel model)
        {
            if (model.Schedule)
            {
                return Content($@"
Id: {model.Id}
ChannelId: {model.ChannelId}
Schedule: {model.Schedule}
ScheduleDate: {model.ScheduleDate.GetValueOrDefault().ToString("dd.MM.yyyy HH:mm:ss")}
");
            }
            var post = await _postApplicationService.GetById(id);
            if (post == null) return NotFound();
            var channel = await _channelApplicationService.Get(new EntityDto<long>(model.ChannelId));
            if (channel == null) return NotFound();
            await _bot.Client.SendTextMessageAsync(new ChatId(channel.Id), post.Body);
            return RedirectToAction(nameof(Index));
        }
    }
}