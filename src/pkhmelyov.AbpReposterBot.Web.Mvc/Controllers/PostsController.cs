using System.Threading.Tasks;
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

        public PostsController(IPostApplicationService postApplicationService)
        {
            _postApplicationService = postApplicationService;
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
    }
}