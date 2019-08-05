using Abp.AutoMapper;
using pkhmelyov.AbpReposterBot.Sessions.Dto;

namespace pkhmelyov.AbpReposterBot.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
