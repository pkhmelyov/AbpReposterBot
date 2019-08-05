using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using pkhmelyov.AbpReposterBot.Configuration.Dto;

namespace pkhmelyov.AbpReposterBot.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AbpReposterBotAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
