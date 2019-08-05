using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using pkhmelyov.AbpReposterBot.MultiTenancy;

namespace pkhmelyov.AbpReposterBot.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
