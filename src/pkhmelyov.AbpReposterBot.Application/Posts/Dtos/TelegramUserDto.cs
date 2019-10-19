using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace pkhmelyov.AbpReposterBot.Posts.Dtos
{
    [AutoMap(typeof(TelegramUser))]
    public class TelegramUserDto : EntityDto<long>
    {
        public bool IsBot { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string LanguageCode { get; set; }
    }
}