using Abp.AspNetCore.Mvc.ViewComponents;

namespace pkhmelyov.AbpReposterBot.Web.Views
{
    public abstract class AbpReposterBotViewComponent : AbpViewComponent
    {
        protected AbpReposterBotViewComponent()
        {
            LocalizationSourceName = AbpReposterBotConsts.LocalizationSourceName;
        }
    }
}
