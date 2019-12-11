using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace pkhmelyov.AbpReposterBot.Posts.Dtos
{
    [AutoMap(typeof(TelegramUser))]
    public class TelegramUserDto : EntityDto<long>, IPassivable
    {
        public bool IsBot { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string LanguageCode { get; set; }
        public bool IsActive { get; set; }
    }
}