using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public class Post : FullAuditedEntity, IPassivable
    {
        public bool IsActive { get; set; }
        public string Body { get; set; }
    }
}