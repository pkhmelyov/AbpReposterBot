using Abp.AutoMapper;
using pkhmelyov.AbpReposterBot.Authentication.External;

namespace pkhmelyov.AbpReposterBot.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
