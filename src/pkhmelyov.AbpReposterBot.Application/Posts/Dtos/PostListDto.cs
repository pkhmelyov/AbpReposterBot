using Abp.AutoMapper;

namespace pkhmelyov.AbpReposterBot.Posts.Dtos
{
    [AutoMapFrom(typeof(Post))]
    public class PostListDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
    }
}