using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace pkhmelyov.AbpReposterBot.Posts.Dtos
{
    [AutoMapFrom(typeof(Post))]
    public class PostListDto : EntityDto
    {
        public string Body { get; set; }
    }
}