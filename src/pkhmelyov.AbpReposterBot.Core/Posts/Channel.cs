using Abp.Domain.Entities;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public class Channel : Entity<long>
    {
        public string Title { get; set; }
        public bool Own { get; set; }
    }
}