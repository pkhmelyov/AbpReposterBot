using Abp.AutoMapper;

namespace pkhmelyov.AbpReposterBot.Posts.Dtos
{
    [AutoMapTo(typeof(Post))]
    public class CreatePostInput
    {
        public string Body { get; set; }
    }
}