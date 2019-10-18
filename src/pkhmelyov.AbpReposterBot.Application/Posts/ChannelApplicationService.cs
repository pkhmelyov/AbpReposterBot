using Abp.Application.Services;
using Abp.Domain.Repositories;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public class ChannelApplicationService : AsyncCrudAppService<Channel, ChannelDto, long>, IChannelApplicationService
    {
        public ChannelApplicationService(IRepository<Channel, long> repository) : base(repository) { }

        public bool Exists(ChannelDto channel)
        {
            return Repository.Count(c => c.Id == channel.Id) > 0;
        }
    }
}