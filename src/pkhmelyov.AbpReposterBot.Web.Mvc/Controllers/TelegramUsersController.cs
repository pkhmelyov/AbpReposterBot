using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;

using pkhmelyov.AbpReposterBot.Controllers;
using pkhmelyov.AbpReposterBot.Posts;
using pkhmelyov.AbpReposterBot.Web.Mvc.Models.TelegramUsers;

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
            var model = new TelegramUsersIndexViewModel
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
    }
}