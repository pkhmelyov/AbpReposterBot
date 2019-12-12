using Abp.Application.Services.Dto;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Web.Mvc.Models.TelegramUsers
{
    public class TelegramUsersIndexViewModel
    {
        public PagedResultDto<TelegramUserDto> Page { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}