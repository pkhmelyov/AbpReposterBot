using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace pkhmelyov.AbpReposterBot.Controllers
{
    public abstract class AbpReposterBotControllerBase: AbpController
    {
        protected const int PAGE_SIZE = 10;
        protected AbpReposterBotControllerBase()
        {
            LocalizationSourceName = AbpReposterBotConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
