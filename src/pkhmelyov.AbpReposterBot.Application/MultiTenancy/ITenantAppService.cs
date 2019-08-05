using Abp.Application.Services;
using Abp.Application.Services.Dto;
using pkhmelyov.AbpReposterBot.MultiTenancy.Dto;

namespace pkhmelyov.AbpReposterBot.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

