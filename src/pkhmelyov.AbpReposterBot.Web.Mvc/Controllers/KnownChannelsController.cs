using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using pkhmelyov.AbpReposterBot.Controllers;
using pkhmelyov.AbpReposterBot.Posts;
using pkhmelyov.AbpReposterBot.Web.Mvc.Models.KnownChannels;

namespace pkhmelyov.AbpReposterBot.Web.Controllers
{
    [AbpMvcAuthorize]
    public class KnownChannelsController : AbpReposterBotControllerBase
    {
        private readonly IChannelApplicationService _channelService;

        public KnownChannelsController(IChannelApplicationService channelService)
        {
            _channelService = channelService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var model = new KnownChannelsIndexViewModel
            {
                PageSize = PAGE_SIZE,
                PageNumber = page,
                Page = await _channelService.GetAll(new PagedAndSortedResultRequestDto
                {
                    Sorting = "Title",
                    SkipCount = (page - 1) * PAGE_SIZE,
                    MaxResultCount = PAGE_SIZE,
                })
            };
            return View(model);
        }
    }
}