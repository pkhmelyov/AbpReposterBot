using System.Threading.Tasks;
using Abp.Application.Services;
using pkhmelyov.AbpReposterBot.Sessions.Dto;

namespace pkhmelyov.AbpReposterBot.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
