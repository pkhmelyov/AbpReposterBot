using Abp.Application.Services.Dto;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Models.KnownChannels
{
    public class KnownChannelsIndexViewModel
    {
        public PagedResultDto<ChannelDto> Page { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
