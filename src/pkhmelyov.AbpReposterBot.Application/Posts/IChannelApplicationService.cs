using Abp.Application.Services;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public interface IChannelApplicationService : IAsyncCrudAppService<ChannelDto, long> {
        bool Exists(ChannelDto channel);
    }
}