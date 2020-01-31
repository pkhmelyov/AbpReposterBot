using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public interface IChannelApplicationService : IAsyncCrudAppService<ChannelDto, long> {
        bool Exists(ChannelDto channel);
        Task<PagedResultDto<ChannelDto>> GetAllFilteredAsync(GetAllFilteredInput input);
    }
}