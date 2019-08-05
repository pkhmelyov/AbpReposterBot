using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace pkhmelyov.AbpReposterBot.Web.Views
{
    public abstract class AbpReposterBotRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AbpReposterBotRazorPage()
        {
            LocalizationSourceName = AbpReposterBotConsts.LocalizationSourceName;
        }
    }
}
