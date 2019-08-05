using System.Collections.Generic;

namespace pkhmelyov.AbpReposterBot.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
