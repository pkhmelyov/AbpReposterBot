using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using pkhmelyov.AbpReposterBot.Roles.Dto;
using pkhmelyov.AbpReposterBot.Users.Dto;

namespace pkhmelyov.AbpReposterBot.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
