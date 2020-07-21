using Abp.Domain.Entities.Auditing;

namespace pkhmelyov.AbpReposterBot.Core.Posts
{
    public class FileMetadata : FullAuditedEntity
    {
        public string Name { get; set; }
        public string FileId { get; set; }
        
    }
}