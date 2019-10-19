using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public class TelegramUserApplicationService : AsyncCrudAppService<TelegramUser, TelegramUserDto, long>, ITelegramUserApplicationService
    {
        public TelegramUserApplicationService(IRepository<TelegramUser, long> repository) : base(repository) { }

        public async Task CreateIfDoesNotExist(TelegramUserDto input)
        {
            if (await Repository.CountAsync(u => u.Id == input.Id) == 0)
            {
                var user = ObjectMapper.Map<TelegramUser>(input);
                await Repository.InsertAsync(user);
            }
        }
    }
}