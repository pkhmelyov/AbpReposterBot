using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using pkhmelyov.AbpReposterBot.Controllers;
using pkhmelyov.AbpReposterBot.Posts;
using pkhmelyov.AbpReposterBot.Posts.Dtos;
using pkhmelyov.AbpReposterBot.Web.Models.KnownChannels;
using pkhmelyov.AbpReposterBot.Web.Mvc.Models.Common;

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

        public async Task<IActionResult> Index(int page = 1, OwnershipFilter filter = OwnershipFilter.All)
        {
            var model = new IndexViewModel<FilterModel, ChannelDto>
            {
                FilterModel = new FilterModel { Ownership = filter },
                PageSize = PAGE_SIZE,
                PageNumber = page,
                Page = await _channelService.GetAllFilteredAsync(new GetAllFilteredInput
                {
                    Own = filter == OwnershipFilter.All ? null : (bool?)(filter == OwnershipFilter.Owned),
                    SkipCount = (page - 1) * PAGE_SIZE,
                    MaxResultCount = PAGE_SIZE,
                })
            };
            return View(model);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var model = await _channelService.Get(new EntityDto<long>(id));
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ChannelDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _channelService.Update(model);
            return RedirectToAction(nameof(Index));
        }
    }
}