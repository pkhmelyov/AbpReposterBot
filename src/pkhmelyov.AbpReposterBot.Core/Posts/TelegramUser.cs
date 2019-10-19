using Abp.Domain.Entities;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public class TelegramUser : Entity<long>
    {
        public bool IsBot { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string LanguageCode { get; set; }
    }
}