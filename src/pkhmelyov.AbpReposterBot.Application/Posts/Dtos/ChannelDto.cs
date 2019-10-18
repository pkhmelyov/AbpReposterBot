using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace pkhmelyov.AbpReposterBot.Posts.Dtos
{
    [AutoMap(typeof(Channel))]
    public class ChannelDto : EntityDto<long>
    {
        public string Title { get; set; }
        public bool Own { get; set; }
    }
}