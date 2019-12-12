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
            // int pageSize = PAGE_SIZE;
            int pageSize = 1;
            var model = new TelegramUsersIndexViewModel
            {
                PageNumber = page,
                Page = await _telegramUserService.GetAll(
                new PagedAndSortedResultRequestDto
                {
                    Sorting = "FirstName, LastName",
                    SkipCount = (page - 1) * pageSize,
                    MaxResultCount = pageSize,
                })
            };
            return View(model);
        }
    }
}