using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using pkhmelyov.AbpReposterBot.Controllers;
using pkhmelyov.AbpReposterBot.Posts;
using pkhmelyov.AbpReposterBot.Posts.Dtos;
using pkhmelyov.AbpReposterBot.Web.Mvc.Models.Posts;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Controllers
{
    public class PostsController : AbpReposterBotControllerBase
    {
        private readonly IPostApplicationService _postApplicationService;
        private readonly IChannelApplicationService _channelApplicationService;

        public PostsController(IPostApplicationService postApplicationService, IChannelApplicationService channelApplicationService)
        {
            _postApplicationService = postApplicationService;
            _channelApplicationService = channelApplicationService;
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
            var channels = await _channelApplicationService.GetAll(new PagedAndSortedResultRequestDto());

            return View(new PostsSendViewModel
            {
                Id = id,
                Post = post,
                Channels = channels
            });
        }
    }
}