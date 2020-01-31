using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PagedResultDto<ChannelDto>> GetAllFilteredAsync(GetAllFilteredInput input) {
            var query = Repository.GetAll()
                .Where(x => input.Own == null || x.Own == input.Own);
            var totalCount = await query.CountAsync();
            var items = await query
                .OrderBy(x => x.Title)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .Select(x => ObjectMapper.Map<ChannelDto>(x))
                .ToListAsync();
            return new PagedResultDto<ChannelDto>(totalCount, items);
        }
    }
}