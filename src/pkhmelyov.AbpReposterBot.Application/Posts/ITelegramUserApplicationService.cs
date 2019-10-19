using System.Threading.Tasks;
using Abp.Application.Services;
using pkhmelyov.AbpReposterBot.Posts.Dtos;

namespace pkhmelyov.AbpReposterBot.Posts
{
    public interface ITelegramUserApplicationService : IAsyncCrudAppService<TelegramUserDto, long>
    {
         Task CreateIfDoesNotExist(TelegramUserDto input);
    }
}