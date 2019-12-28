using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;

using pkhmelyov.AbpReposterBot.Controllers;
using pkhmelyov.AbpReposterBot.Posts;
using pkhmelyov.AbpReposterBot.Web.Mvc.Models.Common;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Web.Controllers
{
    [AbpMvcAuthorize]
    public class TelegramUsersController : AbpReposterBotControllerBase
    {
        private readonly ITelegramUserApplicationService _telegramUserService;

        public TelegramUsersController(ITelegramUserApplicationService telegramUserService)
        {
            _telegramUserService = telegramUserService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var model = new IndexViewModel<TelegramUserDto>
            {
                PageSize = PAGE_SIZE,
                PageNumber = page,
                Page = await _telegramUserService.GetAll(
                new PagedAndSortedResultRequestDto
                {
                    Sorting = "FirstName, LastName",
                    SkipCount = (page - 1) * PAGE_SIZE,
                    MaxResultCount = PAGE_SIZE,
                })
            };
            return View(model);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var model = await _telegramUserService.Get(new EntityDto<long>(id));
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Activate(long id)
        {
            var user = await _telegramUserService.Get(new EntityDto<long>(id));
            user.IsActive = true;
            await _telegramUserService.Update(user);
            return RedirectToAction("Edit", new { id = user.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Deactivate(long id)
        {
            var user = await _telegramUserService.Get(new EntityDto<long>(id));
            user.IsActive = false;
            await _telegramUserService.Update(user);
            return RedirectToAction("Edit", new { id = user.Id });
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsNotBot(long id)
        {
            var user = await _telegramUserService.Get(new EntityDto<long>(id));
            user.IsBot = false;
            await _telegramUserService.Update(user);
            return RedirectToAction("Edit", new { id = user.Id });
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsBot(long id)
        {
            var user = await _telegramUserService.Get(new EntityDto<long>(id));
            user.IsBot = true;
            await _telegramUserService.Update(user);
            return RedirectToAction("Edit", new { id = user.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            await _telegramUserService.Delete(new EntityDto<long>(id));
            return RedirectToAction("Index");
        }
    }
}