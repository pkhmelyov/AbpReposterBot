using System.Threading.Tasks;
using pkhmelyov.AbpReposterBot.Configuration.Dto;

namespace pkhmelyov.AbpReposterBot.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
