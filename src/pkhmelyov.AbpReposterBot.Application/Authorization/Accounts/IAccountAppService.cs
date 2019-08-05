using System.Threading.Tasks;
using Abp.Application.Services;
using pkhmelyov.AbpReposterBot.Authorization.Accounts.Dto;

namespace pkhmelyov.AbpReposterBot.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
